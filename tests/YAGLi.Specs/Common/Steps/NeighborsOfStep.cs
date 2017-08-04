using TechTalk.SpecFlow;
using YAGLi.Specs.Common.AbstractSteps;
using YAGLi.Specs.Common.Builders;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    public sealed class NeighborsOfStep : StepWithVertexCollectionValidator
    {
        public NeighborsOfStep(GraphBuilder builder, VertexCollectionValidator validator) : base(builder, validator) { }

        [When(@"I retrieve the neighbors of ""(.*)""")]
        public void WhenIGetTheNeighborsOf(Vertex vertex)
        {
            Validator.Subject = Builder.Instance.NeighborsOf(vertex);
        }
    }
}
