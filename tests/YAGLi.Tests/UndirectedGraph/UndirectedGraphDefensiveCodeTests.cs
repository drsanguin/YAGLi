using NFluent;
using NUnit.Framework;
using System.Collections.Generic;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests.UndirectedGraph
{
    [TestFixture]
    public class UndirectedGraphDefensiveCodeTests
    {
        private UndirectedGraph<Vertex, Edge<Vertex>> _originalGraph;
        private UndirectedGraph<Vertex, Edge<Vertex>> _newGraph;

        [OneTimeSetUp]
        public void OneTimeSetUp()
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
                }, new VertexEqualityComparer());
        }

        [TearDown]
        public void TearDown()
        {
            Check.That(_newGraph).IsSameReferenceAs(_originalGraph);
        }

        [Test]
        public void UndirectedGraph_AddEdges_when_the_array_is_null_should_return_the_same_instance()
        {
            Edge<Vertex>[] edges = null;

            _newGraph = _originalGraph.AddEdges(edges);
        }

        [Test]
        public void UndirectedGraph_AddEdges_when_the_collection_is_null_should_return_the_same_instance()
        {
            IEnumerable<Edge<Vertex>> edges = null;

            _newGraph = _originalGraph.AddEdges(edges);
        }

        [Test]
        public void UndirectedGraph_AddEdges_with_Array_should_filter_edges_equal_to_null()
        {
            Edge<Vertex>[] edges = new Edge<Vertex>[]
            {
                null
            };

            _newGraph = _originalGraph.AddEdges(edges);
        }

        [Test]
        public void UndirectedGraph_AddEdges_with_IEnumerable_should_filter_edges_equal_to_null()
        {
            IEnumerable<Edge<Vertex>> edges = new Edge<Vertex>[]
            {
                null
            };

            _newGraph = _originalGraph.AddEdges(edges);
        }

        [Test]
        public void UndirectedGraph_AddEdgesAndVertices_when_the_array_is_null_should_return_the_same_instance()
        {
            Edge<Vertex>[] edges = null;

            _newGraph = _originalGraph.AddEdgesAndVertices(edges);
        }

        [Test]
        public void UndirectedGraph_AddEdgesAndVertices_when_the_collection_is_null_should_return_the_same_instance()
        {
            IEnumerable<Edge<Vertex>> edges = null;

            _newGraph = _originalGraph.AddEdgesAndVertices(edges);
        }

        [Test]
        public void UndirectedGraph_AddEdgesAndVertices_with_Array_should_filter_null_edges()
        {
            Edge<Vertex>[] edges = new Edge<Vertex>[]
            {
                null
            };

            _newGraph = _originalGraph.AddEdgesAndVertices(edges);
        }

        [Test]
        public void UndirectedGraph_AddEdgesAndVertices_with_IEnumerable_should_filter_null_edges()
        {
            IEnumerable<Edge<Vertex>> edges = new Edge<Vertex>[]
            {
                null
            };

            _newGraph = _originalGraph.AddEdgesAndVertices(edges);
        }

        [Test]
        public void UndirectedGraph_AddVertices_when_the_array_is_null_should_return_the_same_instance()
        {
            Vertex[] vertices = null;

            _newGraph = _originalGraph.AddVertices(vertices);
        }

        [Test]
        public void UndirectedGraph_AddVertices_when_the_collection_is_null_should_return_the_same_instance()
        {
            IEnumerable<Vertex> vertices = null;

            _newGraph = _originalGraph.AddVertices(vertices);
        }

        [Test]
        public void UndirectedGraph_AddVertices_with_Array_should_filter_the_null_vertices()
        {
            Vertex[] vertices = new Vertex[]
            {
                null
            };

            _newGraph = _originalGraph.AddVertices(vertices);
        }

        [Test]
        public void UndirectedGraph_AddVertices_with_IEnumerable_should_filter_the_null_vertices()
        {
            IEnumerable<Vertex> vertices = new Vertex[]
            {
                null
            };

            _newGraph = _originalGraph.AddVertices(vertices);
        }

        [Test]
        public void UndirectedGraph_RemoveEdge_with_null_should_return_the_same_instance()
        {
            _newGraph = _originalGraph.RemoveEdge(null);
        }

        [Test]
        public void UndirectedGraph_RemoveEdgeAndVertices_with_null_should_return_the_same_instance()
        {
            _newGraph = _originalGraph.RemoveEdgeAndVertices(null);
        }

        [Test]
        public void UndirectedGraph_RemoveEdges_with_null_IEnumerable_should_return_the_same_instance()
        {
            IEnumerable<Edge<Vertex>> edges = null;

            _newGraph = _originalGraph.RemoveEdges(edges);
        }

        [Test]
        public void UndirectedGraph_RemoveEdges_with_null_Array_should_return_the_same_instance()
        {
            Edge<Vertex>[] edges = null;

            _newGraph = _originalGraph.RemoveEdges(edges);
        }

        [Test]
        public void UndirectedGraph_RemoveEdges_with_IEnumerable_should_filter_null_edges()
        {
            IEnumerable<Edge<Vertex>> edges = new Edge<Vertex>[]
            {
                null
            };

            _newGraph = _originalGraph.RemoveEdges(edges);
        }

        [Test]
        public void UndirectedGraph_RemoveEdges_with_Array_should_filter_null_edges()
        {
            Edge<Vertex>[] edges = new Edge<Vertex>[]
            {
                null
            };

            _newGraph = _originalGraph.RemoveEdges(edges);
        }

        [Test]
        public void UndirectedGraph_RemoveEdgesAndVertices_with_null_IEnumerable_should_return_the_same_instance()
        {
            IEnumerable<Edge<Vertex>> edges = null;

            _newGraph = _originalGraph.RemoveEdgesAndVertices(edges);
        }

        [Test]
        public void UndirectedGraph_RemoveEdgesAndVertices_with_null_Array_should_return_the_same_instance()
        {
            Edge<Vertex>[] edges = null;

            _newGraph = _originalGraph.RemoveEdgesAndVertices(edges);
        }

        [Test]
        public void UndirectedGraph_RemoveEdgesAndVertices_IEnumerable_should_filter_null_edges()
        {
            IEnumerable<Edge<Vertex>> edges = new Edge<Vertex>[]
            {
                null
            };

            _newGraph = _originalGraph.RemoveEdgesAndVertices(edges);
        }

        [Test]
        public void UndirectedGraph_RemoveEdgesAndVertices_with_Array_should_filter_null_edges()
        {
            Edge<Vertex>[] edges = new Edge<Vertex>[]
            {
                null
            };

            _newGraph = _originalGraph.RemoveEdgesAndVertices(edges);
        }

        [Test]
        public void UndirectedGraph_RemoveVertex_with_null_should_return_the_same_instance()
        {
            _newGraph = _originalGraph.RemoveVertex(null);
        }

        [Test]
        public void UndirectedGraph_RemoveVertices_with_null_IEnumerable_should_return_the_same_instance()
        {
            IEnumerable<Vertex> vertices = null;

            _newGraph = _originalGraph.RemoveVertices(vertices);
        }

        [Test]
        public void UndirectedGraph_RemoveVertices_with_null_Array_should_return_the_same_instance()
        {
            Vertex[] vertices = null;

            _newGraph = _originalGraph.RemoveVertices(vertices);
        }

        [Test]
        public void UndirectedGraph_RemoveVertices_with_IEnumerable_should_filter_null_vertices()
        {
            IEnumerable<Vertex> vertices = new Vertex[]
            {
                null
            };

            _newGraph = _originalGraph.RemoveVertices(vertices);
        }

        [Test]
        public void UndirectedGraph_RemoveVertices_with_Array_should_filter_null_vertices()
        {
            Vertex[] vertices = new Vertex[]
            {
                null
            };

            _newGraph = _originalGraph.RemoveVertices(vertices);
        }
    }
}
