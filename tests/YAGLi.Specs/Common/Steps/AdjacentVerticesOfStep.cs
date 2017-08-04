using TechTalk.SpecFlow;
using YAGLi.Specs.Common.AbstractSteps;
using YAGLi.Specs.Common.Builders;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    public sealed class AdjacentVerticesOfStep : StepWithVertexCollectionValidator
    {
        public AdjacentVerticesOfStep(GraphBuilder builder, VertexCollectionValidator validator) : base(builder, validator) { }

        [When(@"I retrieve the adjacent vertices of the vertex ""(.*)""")]
        public void WhenIRetrieveTheAdjacentVerticesOfTheVertex(Vertex vertex)
        {
            Validator.Subject = Builder.Instance.AdjacentVerticesOf(vertex);
        }
    }
}
