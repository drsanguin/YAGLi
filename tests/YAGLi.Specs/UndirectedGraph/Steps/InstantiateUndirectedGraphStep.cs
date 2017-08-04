using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Builders;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.UndirectedGraph.Steps
{
    [Binding]
    public sealed class UndirectedGraphCreationSteps
    {
        private readonly GraphBuilder _builder;
        private readonly GraphValidator _validator;

        public UndirectedGraphCreationSteps(GraphBuilder builder, GraphValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

        [When(@"I create a new undirected graph with them")]
        public void WhenICreateANewUndirectedGraphWithThem()
        {
            _validator.Subject = new UndirectedGraph<Vertex, Edge<Vertex>>(_builder.AllowLoops, _builder.AllowParallelEdges, _builder.Edges, _builder.Vertices, new VertexEqualityComparer());
        }
    }
}
