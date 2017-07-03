using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Builders;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.UndirectedGraph
{
    [Binding]
    public class UndirectedGraphBuilder
    {
        private readonly GraphBuilder _graphBuilder;

        public UndirectedGraphBuilder(GraphBuilder graphBuilder)
        {
            _graphBuilder = graphBuilder;
        }

        public UndirectedGraph<Vertex, Edge<Vertex>> Instance { get; private set; }

        [Given(@"the undirected graph created with them")]
        public void GivenTheUndirectedGraphCreatedWithThem()
        {
            Instance = new UndirectedGraph<Vertex, Edge<Vertex>>(_graphBuilder.AllowLoops, _graphBuilder.AllowParallelEdges, _graphBuilder.Edges, _graphBuilder.Vertices, new VertexEqualityComparer());
        }
    }
}
