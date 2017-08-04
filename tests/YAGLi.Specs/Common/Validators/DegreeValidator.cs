using NFluent;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.AbstractValidators;

namespace YAGLi.Specs.Common.Validators
{
    public sealed class DegreeValidator : BaseValidator<int>
    {
        [Then(@"I get a degree of (.*)")]
        public void ThenIGetTheDegree(int expectedDegree)
        {
            Check.That(Subject).IsEqualTo(expectedDegree);
        }
    }
}
