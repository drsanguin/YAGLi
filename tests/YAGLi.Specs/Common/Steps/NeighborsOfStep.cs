using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    [Binding]
    public sealed class NeighborsOfStep
    {
        private readonly GraphBuilder _graphBuilder;
        private readonly VertexCollectionValidator _validator;

        public NeighborsOfStep(GraphBuilder graphBuilder, VertexCollectionValidator validator)
        {
            _graphBuilder = graphBuilder;
            _validator = validator;
        }

        [When(@"I get the neighbors of ""(.*)""")]
        public void WhenIGetTheNeighborsOf(Vertex vertex)
        {
            _validator.Subject = _graphBuilder.Instance.NeighborsOf(vertex);
        }
    }
}
