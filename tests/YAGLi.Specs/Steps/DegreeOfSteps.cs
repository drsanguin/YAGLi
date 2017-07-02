using TechTalk.SpecFlow;
using YAGLi.Specs.Builders;
using YAGLi.Specs.Validators;

namespace YAGLi.Specs.Steps
{
    [Binding]
    public class DegreeOfSteps
    {
        UndirectedGraphBuilder _builder;
        DegreeValidator _validator;

        DegreeOfSteps(UndirectedGraphBuilder builder, DegreeValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

        [When(@"I get the degree of the vertex ""(.*)""")]
        public void WhenIGetTheDegreeOfTheVertex(string vertex)
        {
            _validator.Subject = _builder.Instance.DegreeOf(vertex);
        }
    }
}
