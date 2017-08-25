using NFluent;
using NUnit.Framework;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests.UndirectedGraph
{
    [TestFixture(TestOf = typeof(UndirectedGraph<Vertex, Edge<Vertex>>))]
    public class UndirectedGraphOptimizationsTests
    {
        private UndirectedGraph<Vertex, Edge<Vertex>> _originalGraph;
        private UndirectedGraph<Vertex, Edge<Vertex>> _newGraph;

        [TearDown]
        public void TearDown()
        {
            Check.That(_newGraph).IsSameReferenceAs(_originalGraph);
        }

        [Test]
        public void AddEdge_with_a_loop_on_a_graph_who_disallow_loops_should_return_the_same_instance()
        {
            _originalGraph = new UndirectedGraph<Vertex, Edge<Vertex>>(
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

            _newGraph = _originalGraph.AddEdge(new Edge<Vertex>("v4", "v4"));
        }

        [Test]
        public void AddEdge_with_a_parallel_edge_on_a_graph_who_disallow_parallel_edges_should_return_the_same_instance()
        {
            _originalGraph = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                false,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" }, new VertexEqualityComparer());

            _newGraph = _originalGraph.AddEdge(new Edge<Vertex>("v3", "v4"));
        }

        [Test]
        public void AddEdges_with_loops_on_a_graph_who_disallow_loops_should_return_the_same_instance()
        {
            _originalGraph = new UndirectedGraph<Vertex, Edge<Vertex>>(
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

            _newGraph = _originalGraph.AddEdges(new Edge<Vertex>("v4", "v4"), new Edge<Vertex>("v0", "v0"));
        }

        [Test]
        public void AddEdges_with_parallel_edges_on_a_graph_who_disallow_parallel_edges_should_return_the_same_instance()
        {
            _originalGraph = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                false,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" }, new VertexEqualityComparer());

            _newGraph = _originalGraph.AddEdges(new Edge<Vertex>("v3", "v4"), new Edge<Vertex>("v0", "v1"));
        }

        [Test]
        public void AndVertices_with_a_loop_on_a_graph_who_disallow_loops_should_return_the_same_instance()
        {
            _originalGraph = new UndirectedGraph<Vertex, Edge<Vertex>>(
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

            _newGraph = _originalGraph.AddEdgeAndVertices(new Edge<Vertex>("v5", "v5"));
        }

        [Test]
        public void AddEdgeAndVertices_with_a_parallel_edge_on_a_graph_who_disallow_parallel_edges_should_return_the_same_instance()
        {
            _originalGraph = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                false,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" }, new VertexEqualityComparer());

            _newGraph = _originalGraph.AddEdgeAndVertices(new Edge<Vertex>("v3", "v4"));
        }

        [Test]
        public void AddEdgesAndVertices_with_loops_on_a_graph_who_disallow_loops_should_return_the_same_instance()
        {
            _originalGraph = new UndirectedGraph<Vertex, Edge<Vertex>>(
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

            _newGraph = _originalGraph.AddEdgesAndVertices(new Edge<Vertex>("v4", "v4"), new Edge<Vertex>("v0", "v0"));
        }

        [Test]
        public void AddEdgesAndVertices_with_parallel_edges_on_a_graph_who_disallow_parallel_edges_should_return_the_same_instance()
        {
            _originalGraph = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                false,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v3", "v4")
                },
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" }, new VertexEqualityComparer());

            _newGraph = _originalGraph.AddEdgesAndVertices(new Edge<Vertex>("v3", "v4"), new Edge<Vertex>("v0", "v1"));
        }

        [Test]
        public void RemoveEdge_with_a_Edge_not_contained_in_the_graph_should_return_the_same_instance()
        {
            _originalGraph = new UndirectedGraph<Vertex, Edge<Vertex>>(
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

            _newGraph = _originalGraph.RemoveEdge(new Edge<Vertex>("v1", "v2"));
        }

        [Test]
        public void RemoveEdgeAndVertices_with_a_Edge_not_contained_in_the_graph_should_return_the_same_instance()
        {
            _originalGraph = new UndirectedGraph<Vertex, Edge<Vertex>>(
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

            _newGraph = _originalGraph.RemoveEdgeAndVertices(new Edge<Vertex>("v1", "v2"));
        }

        [Test]
        public void RemoveEdges_with_edges_who_are_not_contained_in_the_graph_should_return_the_same_instance()
        {
            _originalGraph = new UndirectedGraph<Vertex, Edge<Vertex>>(
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

            _newGraph = _originalGraph.RemoveEdges(new Edge<Vertex>("v1", "v2"), new Edge<Vertex>("v1", "v3"));
        }

        [Test]
        public void RemoveEdgesAndVertices_with_edges_who_are_not_contained_in_the_graph_should_return_the_same_instance()
        {
            _originalGraph = new UndirectedGraph<Vertex, Edge<Vertex>>(
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

            _newGraph = _originalGraph.RemoveEdgesAndVertices(new Edge<Vertex>("v1", "v2"), new Edge<Vertex>("v1", "v3"));
        }

        [Test]
        public void RemoveVertex_with_a_vertex_not_contained_in_the_graph_should_return_the_same_instance()
        {
            _originalGraph = new UndirectedGraph<Vertex, Edge<Vertex>>(
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

            _newGraph = _originalGraph.RemoveVertex("v5");
        }

        [Test]
        public void RemoveVertices_with_vertices_who_are_not_contained_in_the_graph_should_return_the_same_instance()
        {
            _originalGraph = new UndirectedGraph<Vertex, Edge<Vertex>>(
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

            _newGraph = _originalGraph.RemoveVertices("v5", "v6");
        }
    }
}
