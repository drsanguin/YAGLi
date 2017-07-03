using NFluent;
using TechTalk.SpecFlow;

namespace YAGLi.Specs.Common.Validators
{
    [Binding]
    public class DegreeValidator
    {
        public int Subject { get; set; }

        [Then(@"I get the degree (.*)")]
        public void ThenIGetTheDegree(int expectedDegree)
        {
            Check.That(Subject).IsEqualTo(expectedDegree);
        }
    }
}
