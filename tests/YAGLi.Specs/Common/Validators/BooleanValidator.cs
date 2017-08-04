using NFluent;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.AbstractValidators;

namespace YAGLi.Specs.Common.Validators
{
    public sealed class BooleanValidator : BaseValidator<bool>
    {
        [Then(@"I get the answer true")]
        public void ThenIGetTheAnswerTrue()
        {
            Check.That(Subject).IsTrue();
        }

        [Then(@"I get the answer false")]
        public void ThenIGetTheAnswerFalse()
        {
            Check.That(Subject).IsFalse();
        }
    }
}
