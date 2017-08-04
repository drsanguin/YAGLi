using NFluent;
using TechTalk.SpecFlow;

namespace YAGLi.Specs.Common.Validators
{
    [Binding]
    public sealed class DegreeValidator
    {
        public int Subject { get; set; }

        [Then(@"I get a degree of (.*)")]
        public void ThenIGetTheDegree(int expectedDegree)
        {
            Check.That(Subject).IsEqualTo(expectedDegree);
        }
    }
}
