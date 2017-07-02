using TechTalk.SpecFlow;
using YAGLi.Specs.Builders;
using YAGLi.Specs.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Steps
{
    [Binding]
    public class AdjacentEdgesOfSteps
    {
        private UndirectedGraphBuilder _builder;
        private EdgeCollectionValidator _validator;

        public AdjacentEdgesOfSteps(UndirectedGraphBuilder builder, EdgeCollectionValidator validator)
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
