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
        public void UndirectedGraph_ctor_should_not_throw_if_the_edges_are_null()
        {
            Check.ThatCode(() => new UndirectedGraph<Vertex>(
                true,
                true,
                null,
                new Vertex[]
                {
                    "v0",
                    "v1",
                    "v2",
                    "v3",
                    "v4"
                })).DoesNotThrow();
        }

        [Test]
        public void UndirectedGraph_ctor_should_not_throw_if_the_vertices_are_null()
        {
            Check.ThatCode(() => new UndirectedGraph<Vertex>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v3")
                },
                null)).DoesNotThrow();
        }

        [Test]
        public void UndirectedGraph_ctor_should_not_throw_if_the_edges_contains_a_null()
        {
            Check.ThatCode(() => new UndirectedGraph<Vertex>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    null,
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v3")
                },
                new Vertex[]
                {
                    "v0",
                    "v1",
                    "v2",
                    "v3",
                    "v4"
                })).DoesNotThrow();
        }

        [Test]
        public void UndirectedGraph_ctor_should_not_throw_if_the_vertices_contains_a_null()
        {
            Check.ThatCode(() => new UndirectedGraph<Vertex>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v3")
                },
                new Vertex[]
                {
                    null,
                    "v1",
                    "v2",
                    "v3",
                    "v4"
                })).DoesNotThrow();
        }

        [Test]
        public void UndirectedGraph_ctor_should_not_throw_if_the_vertex_comparer_is_null()
        {
            Check.ThatCode(() => new UndirectedGraph<Vertex>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v3")
                },
                new Vertex[]
                {
                    "v0",
                    "v1",
                    "v2",
                    "v3",
                    "v4"
                }, null)).DoesNotThrow();
        }

        [Test]
        public void UndirectedGraph_AllowLoops_should_return_the_value_passed_in_the_constructor()
        {
            var graph = new UndirectedGraph<Vertex>(true, true);

            Check.That(graph.AllowLoops).IsTrue();
        }

        [Test]
        public void UndirectedGraph_AllowParallelEdges_should_return_the_value_passed_in_the_constructor()
        {
            var graph = new UndirectedGraph<Vertex>(true, true);

            Check.That(graph.AllowParallelEdges).IsTrue();
        }

        [Test]
        public void UndirectedGraph_Equals_with_null_should_return_false()
        {
            var graph = new UndirectedGraph<Vertex>(true, true);

            Check.That(graph.Equals(null)).IsFalse();
        }

        [Test]
        public void UndirectedGraph_Equals_with_another_object_who_is_not_a_UndirectedGraph_should_return_false()
        {
            var graph = new UndirectedGraph<Vertex>(true, true);

            Check.That(graph.Equals(new object())).IsFalse();
        }

        [Test]
        public void UndirectedGraph_Equals_with_the_same_reference_should_return_true()
        {
            var graph = new UndirectedGraph<Vertex>(true, true);

            Check.That(graph.Equals(graph)).IsTrue();
        }

        [Test]
        public void UndirectedGraph_Equals_with_another_Undirectedgraph_who_has_a_different_value_for_property_AllowLoops_should_return_false()
        {
            var graph1 = new UndirectedGraph<Vertex>(true, true);
            var graph2 = new UndirectedGraph<Vertex>(false, true);

            Check.That(graph1.Equals(graph2)).IsFalse();
        }

        [Test]
        public void UndirectedGraph_Equals_with_another_Undirectedgraph_who_has_a_different_value_for_property_AllowParallelEdges_should_return_false()
        {
            var graph1 = new UndirectedGraph<Vertex>(true, true);
            var graph2 = new UndirectedGraph<Vertex>(true, false);

            Check.That(graph1.Equals(graph2)).IsFalse();
        }

        [Test]
        public void UndirectedGraph_Equals_with_another_Undirectedgraph_who_has_a_different_number_of_edges_should_return_false()
        {
            var graph1 = new UndirectedGraph<Vertex>(
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

            var graph2 = new UndirectedGraph<Vertex>(
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
            var graph1 = new UndirectedGraph<Vertex>(
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

            var graph2 = new UndirectedGraph<Vertex>(
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
            var graph1 = new UndirectedGraph<Vertex>(
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

            var graph2 = new UndirectedGraph<Vertex>(
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
            var graph1 = new UndirectedGraph<Vertex>(
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

            var graph2 = new UndirectedGraph<Vertex>(
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
            var graph1 = new UndirectedGraph<Vertex>(
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

            var graph2 = new UndirectedGraph<Vertex>(
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
            var graph1 = new UndirectedGraph<Vertex>(
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

            var graph2 = new UndirectedGraph<Vertex>(
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
            var graph1 = new UndirectedGraph<Vertex>(
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
            var graph1 = new UndirectedGraph<Vertex>(
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

            var graph2 = new UndirectedGraph<Vertex>(
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
            var graph1 = new UndirectedGraph<Vertex>(
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

            var graph2 = new UndirectedGraph<Vertex>(
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
            var graph = new UndirectedGraph<Vertex>(
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

            Check.That(graph.ToString()).IsEqualTo(string.Format("{{{0}    AllowLoops = True{1}    AllowParallelEdges = True{2}    Vertices = [v0, v1, v4, v3, v2]{3}    Edges = [{4}        (v0 - v1),{5}        (v1 - v4),{6}        (v4 - v4),{7}        (v3 - v4),{8}        (v3 - v4){9}    ]{10}}}",
                Environment.NewLine,
                Environment.NewLine,
                Environment.NewLine,
                Environment.NewLine,
                Environment.NewLine,
                Environment.NewLine,
                Environment.NewLine,
                Environment.NewLine,
                Environment.NewLine,
                Environment.NewLine,
                Environment.NewLine));
        }

        [Test]
        public void UndirectedGraph_AddEdge_with_a_loop_on_a_graph_who_disallow_loops_should_return_the_same_instance()
        {
            var graph = new UndirectedGraph<Vertex>(
                false,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" }, new VertexEqualityComparer());

            var newGraph = graph.AddEdge(new Edge<Vertex>("v4", "v4"));

            Check.That(newGraph).IsSameReferenceThan(graph);
        }

        [Test]
        public void UndirectedGraph_AddEdge_with_a_parallel_edge_on_a_graph_who_disallow_parallel_edges_should_return_the_same_instance()
        {
            var graph = new UndirectedGraph<Vertex>(
                true,
                false,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" }, new VertexEqualityComparer());

            var newGraph = graph.AddEdge(new Edge<Vertex>("v3", "v4"));

            Check.That(newGraph).IsSameReferenceThan(graph);
        }

        [Test]
        public void UndirectedGraph_AddEdges_with_loops_on_a_graph_who_disallow_loops_should_return_the_same_instance()
        {
            var graph = new UndirectedGraph<Vertex>(
                false,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" }, new VertexEqualityComparer());

            var newGraph = graph.AddEdges(new Edge<Vertex>("v4", "v4"), new Edge<Vertex>("v0", "v0"));

            Check.That(newGraph).IsSameReferenceThan(graph);
        }

        [Test]
        public void UndirectedGraph_AddEdges_with_parallel_edges_on_a_graph_who_disallow_parallel_edges_should_return_the_same_instance()
        {
            var graph = new UndirectedGraph<Vertex>(
                true,
                false,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" }, new VertexEqualityComparer());

            var newGraph = graph.AddEdges(new Edge<Vertex>("v3", "v4"), new Edge<Vertex>("v0", "v1"));

            Check.That(newGraph).IsSameReferenceThan(graph);
        }

        [Test]
        public void UndirectedGraph_AndVertices_with_a_loop_on_a_graph_who_disallow_loops_should_return_the_same_instance()
        {
            var graph = new UndirectedGraph<Vertex>(
                false,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" }, new VertexEqualityComparer());

            var newGraph = graph.AddEdgeAndVertices(new Edge<Vertex>("v5", "v5"));

            Check.That(newGraph).IsSameReferenceThan(graph);
        }

        [Test]
        public void UndirectedGraph_AddEdgeAndVertices_with_a_parallel_edge_on_a_graph_who_disallow_parallel_edges_should_return_the_same_instance()
        {
            var graph = new UndirectedGraph<Vertex>(
                true,
                false,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" }, new VertexEqualityComparer());

            var newGraph = graph.AddEdgeAndVertices(new Edge<Vertex>("v3", "v4"));

            Check.That(newGraph).IsSameReferenceThan(graph);
        }

        [Test]
        public void UndirectedGraph_AddEdgesAndVertices_with_loops_on_a_graph_who_disallow_loops_should_return_the_same_instance()
        {
            var graph = new UndirectedGraph<Vertex>(
                false,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" }, new VertexEqualityComparer());

            var newGraph = graph.AddEdgesAndVertices(new Edge<Vertex>("v4", "v4"), new Edge<Vertex>("v0", "v0"));

            Check.That(newGraph).IsSameReferenceThan(graph);
        }

        [Test]
        public void UndirectedGraph_AddEdgesAndVertices_with_parallel_edges_on_a_graph_who_disallow_parallel_edges_should_return_the_same_instance()
        {
            var graph = new UndirectedGraph<Vertex>(
                true,
                false,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" }, new VertexEqualityComparer());

            var newGraph = graph.AddEdgesAndVertices(new Edge<Vertex>("v3", "v4"), new Edge<Vertex>("v0", "v1"));

            Check.That(newGraph).IsSameReferenceThan(graph);
        }

        [Test]
        public void UndirectedGraph_RemoveEdge_with_a_Edge_not_contained_in_the_graph_should_return_the_same_instance()
        {
            var graph = new UndirectedGraph<Vertex>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v3")
                },
                new Vertex[]
                {
                    "v0",
                    "v1",
                    "v2",
                    "v3",
                    "v4"
                },
                new VertexEqualityComparer());

            var newGraph = graph.RemoveEdge(new Edge<Vertex>("v1", "v2"));

            Check.That(newGraph).IsSameReferenceThan(graph);
        }

        [Test]
        public void UndirectedGraph_RemoveEdgeAndVertices_with_a_Edge_not_contained_in_the_graph_should_return_the_same_instance()
        {
            var graph = new UndirectedGraph<Vertex>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v3")
                },
                new Vertex[]
                {
                    "v0",
                    "v1",
                    "v2",
                    "v3",
                    "v4"
                },
                new VertexEqualityComparer());

            var newGraph = graph.RemoveEdgeAndVertices(new Edge<Vertex>("v1", "v2"));

            Check.That(newGraph).IsSameReferenceThan(graph);
        }

        [Test]
        public void UndirectedGraph_RemoveEdges_with_edges_who_are_not_contained_in_the_graph_should_return_the_same_instance()
        {
            var graph = new UndirectedGraph<Vertex>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v3")
                },
                new Vertex[]
                {
                    "v0",
                    "v1",
                    "v2",
                    "v3",
                    "v4"
                },
                new VertexEqualityComparer());

            var newGraph = graph.RemoveEdges(new Edge<Vertex>("v1", "v2"), new Edge<Vertex>("v1", "v3"));

            Check.That(newGraph).IsSameReferenceThan(graph);
        }

        [Test]
        public void UndirectedGraph_RemoveEdgesAndVertices_with_edges_who_are_not_contained_in_the_graph_should_return_the_same_instance()
        {
            var graph = new UndirectedGraph<Vertex>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v3")
                },
                new Vertex[]
                {
                    "v0",
                    "v1",
                    "v2",
                    "v3",
                    "v4"
                },
                new VertexEqualityComparer());

            var newGraph = graph.RemoveEdgesAndVertices(new Edge<Vertex>("v1", "v2"), new Edge<Vertex>("v1", "v3"));

            Check.That(newGraph).IsSameReferenceThan(graph);
        }

        [Test]
        public void UndirectedGraph_RemoveVertex_with_a_vertex_not_contained_in_the_graph_should_return_the_same_instance()
        {
            var graph = new UndirectedGraph<Vertex>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v3")
                },
                new Vertex[]
                {
                    "v0",
                    "v1",
                    "v2",
                    "v3",
                    "v4"
                },
                new VertexEqualityComparer());

            var newGraph = graph.RemoveVertex("v5");

            Check.That(newGraph).IsSameReferenceThan(graph);
        }

        [Test]
        public void UndirectedGraph_RemoveVertices_with_vertices_who_are_not_contained_in_the_graph_should_return_the_same_instance()
        {
            var graph = new UndirectedGraph<Vertex>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v3")
                },
                new Vertex[]
                {
                    "v0",
                    "v1",
                    "v2",
                    "v3",
                    "v4"
                },
                new VertexEqualityComparer());

            var newGraph = graph.RemoveVertices("v5", "v6");

            Check.That(newGraph).IsSameReferenceThan(graph);
        }
    }
}
