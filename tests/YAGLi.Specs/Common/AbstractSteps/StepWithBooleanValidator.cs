using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;

namespace YAGLi.Specs.Common.AbstractSteps
{
    [Binding]
    public abstract class StepWithBooleanValidator
    {
        protected StepWithBooleanValidator(GraphBuilder builder, BooleanValidator validator)
        {
            Builder = builder;
            Validator = validator;
        }

        protected GraphBuilder Builder { get; }
        protected BooleanValidator Validator { get; }
    }
}
