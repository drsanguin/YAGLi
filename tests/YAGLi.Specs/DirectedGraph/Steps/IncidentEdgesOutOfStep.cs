using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Specs.DirectedGraph.AbstractSteps;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.DirectedGraph.Steps
{
    public sealed class IncidentEdgesOutOfStep : DirectedGraphStepWithEdgeCollectionValidator
    {
        public IncidentEdgesOutOfStep(DirectedGraphBuilder builder, EdgeCollectionValidator validator) : base(builder, validator) { }

        [When(@"I retrieve the incident edges out of ""(.*)""")]
        public void WhenIRetrieveTheIncidentEdgesInto(Vertex vertex)
        {
            Validator.Subject = Builder.Instance.IncidentEdgesOutOf(vertex);
        }
    }
}
