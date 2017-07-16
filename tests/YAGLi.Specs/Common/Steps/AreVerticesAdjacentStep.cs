using TechTalk.SpecFlow;
using YAGLi.Specs.Common.AbstractSteps;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    public sealed class AreVerticesAdjacentStep : StepWithBooleanValidator
    {
        public AreVerticesAdjacentStep(GraphBuilder builder, BooleanValidator validator) : base(builder, validator) { }

        [When(@"I check if the vertices ""(.*)"" and ""(.*)"" are adjacent")]
        public void WhenICheckIfTheVerticesAndAreAdjacent(Vertex vertex1, Vertex vertex2)
        {
            Validator.Subject = Builder.Instance.AreVerticesAdjacent(vertex1, vertex2);
        }
    }
}
