using NFluent;
using NUnit.Framework;
using System.Collections.Generic;
using YAGLi.EdgeComparers;
using YAGLi.Extensions.EdgeCollection;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests.Extensions.EdgeCollection
{
    [TestFixture(TestOf = typeof(MapEdgesWithTheEdgesOfAGraphExtension))]
    public class MapEdgesWithTheEdgesOfAGraphExtensionTests
    {
        [Test]
        public void MapEdgesWithTheEdgesOfAGraph_should_return_the_expected_result()
        {
            var vertexComparer = new VertexEqualityComparer();
            var graphEdges = new Edge<Vertex>[]
            {
                new Edge<Vertex>("v0", "v1"),
                new Edge<Vertex>("v1", "v4"),
                new Edge<Vertex>("v4", "v4"),
                new Edge<Vertex>("v4", "v3"),
                new Edge<Vertex>("v3", "v4")
            };

            var graph = new UndirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                graphEdges,
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" },
                vertexComparer
            );

            var edges = new Edge<Vertex>[]
            {
                graphEdges[0],
                new Edge<Vertex>("v4", "v1"),
                new Edge<Vertex>("v4", "v4"),
                new Edge<Vertex>("v4", "v3")
            };

            var comparers = new IEqualityComparer<Edge<Vertex>>[]
            {
                new IgnoreDirectionAndAllowParallelEdges<Vertex, Edge<Vertex>>(vertexComparer),
                new ConsiderDirectionAndDisallowParallelEdges<Vertex, Edge<Vertex>>(vertexComparer),
                new IgnoreDirectionAndDisallowParallelEdges<Vertex, Edge<Vertex>>(vertexComparer)
            };

            Check.That(edges.MapEdgesWithTheEdgesOfAGraph(graph, comparers)).ContainsExactly(graphEdges[0], graphEdges[3], graphEdges[2], graphEdges[1]);
        }
    }
}
