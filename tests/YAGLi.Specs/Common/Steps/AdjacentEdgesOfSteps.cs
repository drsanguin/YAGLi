using TechTalk.SpecFlow;
using YAGLi.Specs.Common.AbstractSteps;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    public sealed class AdjacentEdgesOfSteps : StepWithEdgeCollectionValidator
    {
        public AdjacentEdgesOfSteps(GraphBuilder graphBuilder, EdgeCollectionValidator validator) : base(graphBuilder, validator) { }

        [When(@"I retrieve the adjacent edges of the edge")]
        public void WhenIRetrieveTheAdjacentEdgesOfTheEdge(Edge<Vertex> edge)
        {
            Validator.Subject = Builder.Instance.AdjacentEdgesOf(edge);
        }
    }
}
