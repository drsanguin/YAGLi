using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;

namespace YAGLi.Specs.Common.AbstractSteps
{
    [Binding]
    public abstract class StepWithVertexCollectionValidator
    {
        protected readonly GraphBuilder Builder;
        protected readonly VertexCollectionValidator Validator;

        protected StepWithVertexCollectionValidator(GraphBuilder builder, VertexCollectionValidator validator)
        {
            Builder = builder;
            Validator = validator;
        }
    }
}
