using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;

namespace YAGLi.Specs.Common.AbstractValidators
{
    [Binding]
    public abstract class ValidatorUsingGraphValidator
    {
        protected ValidatorUsingGraphValidator(GraphValidator graphValidator)
        {
            GraphValidator = graphValidator;
        }

        protected GraphValidator GraphValidator { get; }
    }
}
