using NFluent;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGLi.Interfaces;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests
{
    [TestFixture]
    public class UndirectedGraphTests
    {
        [Test]
        public void UndirectedGraph_AllowLoops_should_return_the_value_passed_in_the_constructor()
        {
            UndirectedGraph<Vertex> graph = new UndirectedGraph<Vertex>(true, true);

            Check.That(graph.AllowLoops).IsTrue();
        }

        [Test]
        public void UndirectedGraph_AllowParallelEdges_should_return_the_value_passed_in_the_constructor()
        {
            UndirectedGraph<Vertex> graph = new UndirectedGraph<Vertex>(true, true);

            Check.That(graph.AllowParallelEdges).IsTrue();
        }

        [Test]
        public void UndirectedGraph_Equals_with_null_should_return_false()
        {
            UndirectedGraph<Vertex> graph = new UndirectedGraph<Vertex>(true, true);

            Check.That(graph.Equals(null)).IsFalse();
        }

        [Test]
        public void UndirectedGraph_Equals_with_another_object_who_is_not_a_UndirectedGraph_should_return_false()
        {
            UndirectedGraph<Vertex> graph = new UndirectedGraph<Vertex>(true, true);

            Check.That(graph.Equals(new object())).IsFalse();
        }

        [Test]
        public void UndirectedGraph_Equals_with_the_same_reference_should_return_true()
        {
            UndirectedGraph<Vertex> graph = new UndirectedGraph<Vertex>(true, true);

            Check.That(graph.Equals(graph)).IsTrue();
        }

        [Test]
        public void UndirectedGraph_Equals_with_another_Undirectedgraph_who_has_a_different_value_for_property_AllowLoops_should_return_false()
        {
            UndirectedGraph<Vertex> graph1 = new UndirectedGraph<Vertex>(true, true);
            UndirectedGraph<Vertex> graph2 = new UndirectedGraph<Vertex>(false, true);

            Check.That(graph1.Equals(graph2)).IsFalse();
        }

        [Test]
        public void UndirectedGraph_Equals_with_another_Undirectedgraph_who_has_a_different_value_for_property_AllowParallelEdges_should_return_false()
        {
            UndirectedGraph<Vertex> graph1 = new UndirectedGraph<Vertex>(true, true);
            UndirectedGraph<Vertex> graph2 = new UndirectedGraph<Vertex>(true, false);

            Check.That(graph1.Equals(graph2)).IsFalse();
        }

        [Test]
        public void UndirectedGraph_Equals_with_another_Undirectedgraph_who_has_a_different_number_of_edges_should_return_false()
        {
            UndirectedGraph<Vertex> graph1 = new UndirectedGraph<Vertex>(
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

            UndirectedGraph<Vertex> graph2 = new UndirectedGraph<Vertex>(
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
            UndirectedGraph<Vertex> graph1 = new UndirectedGraph<Vertex>(
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

            UndirectedGraph<Vertex> graph2 = new UndirectedGraph<Vertex>(
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
            UndirectedGraph<Vertex> graph1 = new UndirectedGraph<Vertex>(
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

            UndirectedGraph<Vertex> graph2 = new UndirectedGraph<Vertex>(
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
            UndirectedGraph<Vertex> graph1 = new UndirectedGraph<Vertex>(
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

            UndirectedGraph<Vertex> graph2 = new UndirectedGraph<Vertex>(
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
            UndirectedGraph<Vertex> graph1 = new UndirectedGraph<Vertex>(
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

            UndirectedGraph<Vertex> graph2 = new UndirectedGraph<Vertex>(
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
            UndirectedGraph<Vertex> graph1 = new UndirectedGraph<Vertex>(
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

            UndirectedGraph<Vertex> graph2 = new UndirectedGraph<Vertex>(
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
            UndirectedGraph<Vertex> graph1 = new UndirectedGraph<Vertex>(
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

            IModelAGraph<Vertex> graph2 = new UndirectedGraph<Vertex>(
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
            UndirectedGraph<Vertex> graph1 = new UndirectedGraph<Vertex>(
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

            UndirectedGraph<Vertex> graph2 = new UndirectedGraph<Vertex>(
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
            UndirectedGraph<Vertex> graph1 = new UndirectedGraph<Vertex>(
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

            UndirectedGraph<Vertex> graph2 = new UndirectedGraph<Vertex>(
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
            UndirectedGraph<Vertex> graph = new UndirectedGraph<Vertex>(
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

            Check.That(graph.ToString()).IsEqualTo(@"{
    Vertices = [v0, v1, v4, v3, v2]
    Edges = [
        (v0 - v1),
        (v1 - v4),
        (v4 - v4),
        (v3 - v4),
        (v3 - v4)
    ]
}");
        }
    }
}
