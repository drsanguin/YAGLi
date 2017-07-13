using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    [Binding]
    public class AdjacentEdgesOfSteps
    {
        private readonly GraphBuilder _builder;
        private readonly EdgeCollectionValidator _validator;

        public AdjacentEdgesOfSteps(GraphBuilder builder, EdgeCollectionValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

        [When(@"I retrieve the adjacent edges of the edge")]
        public void WhenIRetrieveTheAdjacentEdgesOfTheEdge(Edge<Vertex> edge)
        {
            _validator.Subject = _builder.Instance.AdjacentEdgesOf(edge);
        }
    }
}
