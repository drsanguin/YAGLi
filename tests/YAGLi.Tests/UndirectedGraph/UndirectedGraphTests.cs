using NFluent;
using NUnit.Framework;
using System;
using YAGLi.Interfaces;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests.UndirectedGraph
{
    [TestFixture]
    public class UndirectedGraphTests
    {
        [Test]
        public void UndirectedGraph_AllowLoops_should_return_the_value_passed_in_the_constructor()
        {
            var graph = new UndirectedGraph<Vertex, Edge<Vertex>>(true, true);

            Check.That(graph.AllowLoops).IsTrue();
        }

        [Test]
        public void UndirectedGraph_AllowParallelEdges_should_return_the_value_passed_in_the_constructor()
        {
            var graph = new UndirectedGraph<Vertex, Edge<Vertex>>(true, true);

            Check.That(graph.AllowParallelEdges).IsTrue();
        }

        [Test]
        public void UndirectedGraph_Equals_with_null_should_return_false()
        {
            var graph = new UndirectedGraph<Vertex, Edge<Vertex>>(true, true);

            Check.That(graph.Equals(null)).IsFalse();
        }

        [Test]
        public void UndirectedGraph_Equals_with_another_object_who_is_not_a_UndirectedGraph_should_return_false()
        {
            var graph = new UndirectedGraph<Vertex, Edge<Vertex>>(true, true);

            Check.That(graph.Equals(new object())).IsFalse();
        }

        [Test]
        public void UndirectedGraph_Equals_with_the_same_reference_should_return_true()
        {
            var graph = new UndirectedGraph<Vertex, Edge<Vertex>>(true, true);

            Check.That(graph.Equals(graph)).IsTrue();
        }

        [Test]
        public void UndirectedGraph_Equals_with_another_Undirectedgraph_who_has_a_different_value_for_property_AllowLoops_should_return_false()
        {
            var graph1 = new UndirectedGraph<Vertex, Edge<Vertex>>(true, true);
            var graph2 = new UndirectedGraph<Vertex, Edge<Vertex>>(false, true);

            Check.That(graph1.Equals(graph2)).IsFalse();
        }

        [Test]
        public void UndirectedGraph_Equals_with_another_Undirectedgraph_who_has_a_different_value_for_property_AllowParallelEdges_should_return_false()
        {
            var graph1 = new UndirectedGraph<Vertex, Edge<Vertex>>(true, true);
            var graph2 = new UndirectedGraph<Vertex, Edge<Vertex>>(true, false);

            Check.That(graph1.Equals(graph2)).IsFalse();
        }

        [Test]
        public void UndirectedGraph_Equals_with_another_Undirectedgraph_who_has_a_different_number_of_edges_should_return_false()
        {
            var graph1 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v3", "v4" }, new VertexEqualityComparer());

            var graph2 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v0", "v1")
                },
                new Vertex[] { "v0", "v1", "v3", "v4" }, new VertexEqualityComparer());

            Check.That(graph1.Equals(graph2)).IsFalse();
        }

        [Test]
        public void UndirectedGraph_Equals_with_another_Undirectedgraph_who_has_different_edges_should_return_false()
        {
            var graph1 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v3", "v4" }, new VertexEqualityComparer());

            var graph2 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v3", "v4" }, new VertexEqualityComparer());

            Check.That(graph1.Equals(graph2)).IsFalse();
        }

        [Test]
        public void UndirectedGraph_Equals_with_another_Undirectedgraph_who_has_a_different_number_of_vertices_should_return_false()
        {
            var graph1 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v3", "v4" }, new VertexEqualityComparer());

            var graph2 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v3", "v4", "v5" }, new VertexEqualityComparer());

            Check.That(graph1.Equals(graph2)).IsFalse();
        }

        [Test]
        public void UndirectedGraph_Equals_with_another_Undirectedgraph_who_has_different_vertices_should_return_false()
        {
            var graph1 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v3", "v4" }, new VertexEqualityComparer());

            var graph2 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v3", "v5" }, new VertexEqualityComparer());

            Check.That(graph1.Equals(graph2)).IsFalse();
        }

        [Test]
        public void UndirectedGraph_Equals_with_another_Undirectedgraph_equal_to_the_first_should_return_true()
        {
            var graph1 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                false,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v3", "v4" }, new VertexEqualityComparer());

            var graph2 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                false,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v0", "v1")
                },
                new Vertex[] { "v4", "v3", "v1", "v0" }, new VertexEqualityComparer());

            Check.That(graph1.Equals(graph2)).IsTrue();
        }

        [Test]
        public void UndirectedGraph_Equals_with_another_Undirectedgraph_equal_to_the_first_with_the_two_who_allow_parallel_edges_should_return_true()
        {
            var graph1 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v3", "v4" }, new VertexEqualityComparer());

            var graph2 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v0", "v1")
                },
                new Vertex[] { "v4", "v3", "v1", "v0" }, new VertexEqualityComparer());

            Check.That(graph1.Equals(graph2)).IsTrue();
        }

        [Test]
        public void UndirectedGraph_Equals_with_a_IModelAGraph_object_should_work()
        {
            var graph1 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v3", "v4" }, new VertexEqualityComparer());

            IModelAGraph<Vertex, Edge<Vertex>> graph2 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v0", "v1")
                },
                new Vertex[] { "v4", "v3", "v1", "v0" }, new VertexEqualityComparer());

            Check.That(graph1.Equals(graph2)).IsTrue();
        }

        [Test]
        public void UndirectedGraph_GetHashCode_should_return_the_same_result_for_two_UndirectedGraph_who_are_equal()
        {
            var graph1 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v3", "v4" }, new VertexEqualityComparer());

            var graph2 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v0", "v1")
                },
                new Vertex[] { "v4", "v3", "v1", "v0" }, new VertexEqualityComparer());

            Check.That(graph1.GetHashCode()).IsEqualTo(graph2.GetHashCode());
        }

        [Test]
        public void UndirectedGraph_GetHashCode_should_return_a_different_result_for_two_UndirectedGraph_who_are_not_equal()
        {
            var graph1 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v3", "v4" }, new VertexEqualityComparer());

            var graph2 = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v0", "v1")
                },
                new Vertex[] { "v4", "v1", "v0" }, new VertexEqualityComparer());

            Check.That(graph1.GetHashCode()).IsNotEqualTo(graph2.GetHashCode());
        }

        [Test]
        public void UndirectedGraph_ToString_should_return_the_expected_string()
        {
            var graph = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" }, new VertexEqualityComparer());
            var newLine = Environment.NewLine;

            Check.That(graph.ToString()).IsEqualTo($"{{{newLine}    AllowLoops = True{newLine}    AllowParallelEdges = True{newLine}    Vertices = [v0, v1, v2, v3, v4]{newLine}    Edges = [{newLine}        (v0 - v1),{newLine}        (v1 - v4),{newLine}        (v3 - v4),{newLine}        (v3 - v4),{newLine}        (v4 - v4){newLine}    ]{newLine}}}");
        }

        [Test]
        public void UndirectedGraph_NeighborsOf_with_a_null_vertex_should_return_an_empty_IEnumerable()
        {
            var graph = new UndirectedGraph<Vertex, Edge<Vertex>>(true, true);
            Vertex vertex = null;

            Check.That(graph.NeighborsOf(vertex)).IsEmpty();
        }

        [Test]
        public void UndirectedGraph_PathsToNeighborsOf_with_a_null_vertex_should_return_an_empty_IEnumerable()
        {
            var graph = new UndirectedGraph<Vertex, Edge<Vertex>>(true, true);
            Vertex vertex = null;

            Check.That(graph.PathsToNeighborsOf(vertex)).IsEmpty();
        }
    }
}
