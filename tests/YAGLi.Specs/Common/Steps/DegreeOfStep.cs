using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Specs.UndirectedGraph;

namespace YAGLi.Specs.Common.Steps
{
    [Binding]
    public class DegreeOfStep
    {
        private readonly UndirectedGraphBuilder _builder;
        private readonly DegreeValidator _validator;

        DegreeOfStep(UndirectedGraphBuilder builder, DegreeValidator validator)
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
