using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Builders;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.DirectedGraph.Steps
{
    [Binding]
    public sealed class InstantiateDirectedGraphStep
    {
        private readonly GraphBuilder _builder;
        private readonly GraphValidator _validator;

        public InstantiateDirectedGraphStep(GraphBuilder builder, GraphValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

        [When(@"I create a new directed graph with them")]
        public void WhenICreateANewDirectedGraphWithThem()
        {
            _validator.Subject = new DirectedGraph<Vertex, Edge<Vertex>>(_builder.AllowLoops, _builder.AllowParallelEdges, _builder.Edges, _builder.Vertices, new VertexEqualityComparer());
        }
    }
}
