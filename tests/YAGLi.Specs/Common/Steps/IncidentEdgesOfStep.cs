using TechTalk.SpecFlow;
using YAGLi.Specs.Common.AbstractSteps;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    public sealed class IncidentEdgesOfStep : StepWithEdgeCollectionValidator
    {
        public IncidentEdgesOfStep(GraphBuilder graphBuilder, EdgeCollectionValidator validator) : base(graphBuilder, validator) { }

        [When(@"I retrieve the incident edges of the vertex ""(.*)""")]
        public void WhenIRetrieveTheIncidentEdgesOfTheVertex(Vertex vertex)
        {
            Validator.Subject = Builder.Instance.IncidentEdgesOf(vertex);
        }
    }
}
