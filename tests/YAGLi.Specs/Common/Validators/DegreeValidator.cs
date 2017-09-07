using NFluent;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.AbstractValidators;

namespace YAGLi.Specs.Common.Validators
{
    public sealed class DegreeValidator : BaseValidator<Degree>
    {
        [Then(@"I get a degree of (\d+)")]
        public void ThenIGetTheDegree(Degree expectedDegree)
        {
            Check.That(Subject).IsEqualTo(expectedDegree);
        }

        [Then(@"I get a impossible degree")]
        public void ThenIGetAImpossibleDegree()
        {
            Check.That(Subject).IsEqualTo(Degree.Impossible);
        }
    }
}
