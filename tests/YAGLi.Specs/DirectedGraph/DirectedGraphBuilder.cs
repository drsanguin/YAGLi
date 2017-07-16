using TechTalk.SpecFlow;
using YAGLi.Specs.Common;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.DirectedGraph
{
    [Binding]
    public sealed class DirectedGraphBuilder
    {
        private readonly GraphBuilder _graphBuilder;

        public DirectedGraphBuilder(GraphBuilder graphBuilder)
        {
            _graphBuilder = graphBuilder;
        }

        public DirectedGraph<Vertex, Edge<Vertex>> Instance { get; private set; }

        [Given(@"the directed graph created with them")]
        public void GivenTheUndirectedGraphCreatedWithThem()
        {
            var instance = new DirectedGraph<Vertex, Edge<Vertex>>(_graphBuilder.AllowLoops, _graphBuilder.AllowParallelEdges, _graphBuilder.Edges, _graphBuilder.Vertices, new VertexEqualityComparer());

            Instance = instance;
            _graphBuilder.Instance = instance;
        }
    }
}
