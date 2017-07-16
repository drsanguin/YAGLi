using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;

namespace YAGLi.Specs.Common.AbstractSteps
{
    [Binding]
    public abstract class StepWithBooleanValidator
    {
        protected readonly GraphBuilder Builder;
        protected readonly BooleanValidator Validator;

        protected StepWithBooleanValidator(GraphBuilder builder, BooleanValidator validator)
        {
            Builder = builder;
            Validator = validator;
        }
    }
}
