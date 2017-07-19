using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;

namespace YAGLi.Specs.Common.AbstractSteps
{
    [Binding]
    public abstract class StepWithVertexCollectionValidator
    {
        protected StepWithVertexCollectionValidator(GraphBuilder builder, VertexCollectionValidator validator)
        {
            Builder = builder;
            Validator = validator;
        }

        protected GraphBuilder Builder { get; }
        protected VertexCollectionValidator Validator { get; }
    }
}
