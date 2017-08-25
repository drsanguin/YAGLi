using NFluent;
using NUnit.Framework;
using System;
using YAGLi.Interfaces;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests.DirectedGraph
{
    [TestFixture(TestOf = typeof(DirectedGraph<Vertex, Edge<Vertex>>))]
    public class DirectedGraphTests
    {
        [Test]
        public void AllowLoops_should_return_the_value_passed_in_the_constructor()
        {
            var graph = new DirectedGraph<Vertex, Edge<Vertex>>(true, true);

            Check.That(graph.AllowLoops).IsTrue();
        }

        [Test]
        public void AllowParallelEdges_should_return_the_value_passed_in_the_constructor()
        {
            var graph = new DirectedGraph<Vertex, Edge<Vertex>>(true, true);

            Check.That(graph.AllowParallelEdges).IsTrue();
        }

        [Test]
        public void ToString_should_return_the_expected_value()
        {
            var graph = new DirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[] 
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v4", "v3"),
                    new Edge<Vertex>("v4", "v3")
                },
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" },
                new VertexEqualityComparer()
            );

            var newLine = Environment.NewLine;

            Check.That(graph.ToString()).IsEqualTo($"{{{newLine}    AllowLoops = True{newLine}    AllowParallelEdges = True{newLine}    Vertices = [v0, v1, v2, v3, v4]{newLine}    Edges = [{newLine}        (v0 -> v1),{newLine}        (v1 -> v4),{newLine}        (v4 -> v4),{newLine}        (v4 -> v3),{newLine}        (v4 -> v3){newLine}    ]{newLine}}}");
        }

        [Test]
        public void AdjacentEdgesOf_with_an_edge_contained_in_the_graph_should_returned_the_expected_colelction_of_edge()
        {
            var edges = new Edge<Vertex>[]
            {
                new Edge<Vertex>("v0", "v1"),
                new Edge<Vertex>("v1", "v4"),
                new Edge<Vertex>("v4", "v4"),
                new Edge<Vertex>("v4", "v3"),
                new Edge<Vertex>("v4", "v3")
            };

            var graph = new DirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                edges,
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" },
                new VertexEqualityComparer()
            );

            Check.That(graph.AdjacentEdgesOf(edges[3])).ContainsExactly(edges[1], edges[2], edges[4]);
        }

        [Test]
        public void Equals_with_null_should_return_false()
        {
            var graph = new DirectedGraph<Vertex, Edge<Vertex>>(true, true);

            Check.That(graph.Equals(null)).IsFalse();
        }

        [Test]
        public void Equals_with_another_object_who_is_not_a_DirectedGraph_should_return_false()
        {
            var graph = new DirectedGraph<Vertex, Edge<Vertex>>(true, true);

            Check.That(graph.Equals(new object())).IsFalse();
        }

        [Test]
        public void Equals_with_the_same_reference_should_return_true()
        {
            var graph = new DirectedGraph<Vertex, Edge<Vertex>>(true, true);

            Check.That(graph.Equals(graph)).IsTrue();
        }

        [Test]
        public void Equals_with_another_DirectedGraph_who_has_a_different_value_for_property_AllowLoops_should_return_false()
        {
            var graph1 = new DirectedGraph<Vertex, Edge<Vertex>>(true, true);
            var graph2 = new DirectedGraph<Vertex, Edge<Vertex>>(false, true);

            Check.That(graph1.Equals(graph2)).IsFalse();
        }

        [Test]
        public void Equals_with_another_DirectedGraph_who_has_a_different_value_for_property_AllowParallelEdges_should_return_false()
        {
            var graph1 = new DirectedGraph<Vertex, Edge<Vertex>>(true, true);
            var graph2 = new DirectedGraph<Vertex, Edge<Vertex>>(true, false);

            Check.That(graph1.Equals(graph2)).IsFalse();
        }

        [Test]
        public void Equals_with_another_DirectedGraph_who_has_a_different_number_of_edges_should_return_false()
        {
            var graph1 = new DirectedGraph<Vertex, Edge<Vertex>>(
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

            var graph2 = new DirectedGraph<Vertex, Edge<Vertex>>(
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
        public void Equals_with_another_DirectedGraph_who_has_different_edges_should_return_false()
        {
            var graph1 = new DirectedGraph<Vertex, Edge<Vertex>>(
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

            var graph2 = new DirectedGraph<Vertex, Edge<Vertex>>(
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
        public void Equals_with_another_DirectedGraph_who_has_a_different_number_of_vertices_should_return_false()
        {
            var graph1 = new DirectedGraph<Vertex, Edge<Vertex>>(
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

            var graph2 = new DirectedGraph<Vertex, Edge<Vertex>>(
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
        public void Equals_with_another_DirectedGraph_who_has_different_vertices_should_return_false()
        {
            var graph1 = new DirectedGraph<Vertex, Edge<Vertex>>(
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

            var graph2 = new DirectedGraph<Vertex, Edge<Vertex>>(
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
        public void Equals_with_another_DirectedGraph_equal_to_the_first_should_return_true()
        {
            var graph1 = new DirectedGraph<Vertex, Edge<Vertex>>(
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

            var graph2 = new DirectedGraph<Vertex, Edge<Vertex>>(
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
        public void Equals_with_another_DirectedGraph_equal_to_the_first_with_the_two_who_allow_parallel_edges_should_return_true()
        {
            var graph1 = new DirectedGraph<Vertex, Edge<Vertex>>(
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

            var graph2 = new DirectedGraph<Vertex, Edge<Vertex>>(
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
        public void Equals_with_a_IModelAGraph_object_should_work()
        {
            var graph1 = new DirectedGraph<Vertex, Edge<Vertex>>(
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

            IModelAGraph<Vertex, Edge<Vertex>> graph2 = new DirectedGraph<Vertex, Edge<Vertex>>(
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
        public void Equals_with_another_graph_with_the_same_edges_in_opposite_direction_should_return_false()
        {
            var graph1 = new DirectedGraph<Vertex, Edge<Vertex>>(
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

            var graph2 = new DirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v1", "v0"),
                    new Edge<Vertex>("v4", "v1"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v4", "v3"),
                    new Edge<Vertex>("v4", "v3")
                },
                new Vertex[] { "v0", "v1", "v3", "v4" }, new VertexEqualityComparer());

            Check.That(graph1.Equals(graph2)).IsFalse();
        }

        [Test]
        public void GetHashCode_should_return_the_same_result_for_two_DirectedGraph_who_are_equal()
        {
            var graph1 = new DirectedGraph<Vertex, Edge<Vertex>>(
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

            var graph2 = new DirectedGraph<Vertex, Edge<Vertex>>(
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
        public void GetHashCode_should_return_a_different_result_for_two_DirectedGraph_who_are_not_equal()
        {
            var graph1 = new DirectedGraph<Vertex, Edge<Vertex>>(
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

            var graph2 = new DirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v1", "v0"),
                    new Edge<Vertex>("v4", "v1"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v4", "v3"),
                    new Edge<Vertex>("v4", "v3")
                },
                new Vertex[] { "v0", "v1", "v3", "v4" }, new VertexEqualityComparer());

            Check.That(graph1.GetHashCode()).IsNotEqualTo(graph2.GetHashCode());
        }
    }
}
