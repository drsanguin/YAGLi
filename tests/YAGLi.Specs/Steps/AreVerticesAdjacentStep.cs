using TechTalk.SpecFlow;
using YAGLi.Specs.Builders;
using YAGLi.Specs.Validators;

namespace YAGLi.Specs.Steps
{
    [Binding]
    public class AreVerticesAdjacentStep
    {
        UndirectedGraphBuilder _builder;
        BooleanValidator _validator;

        public AreVerticesAdjacentStep(UndirectedGraphBuilder builder, BooleanValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

        [When(@"I check if the vertices ""(.*)"" and ""(.*)"" are adjacent")]
        public void WhenICheckIfTheVerticesAndAreAdjacent(string vertex1, string vertex2)
        {
            _validator.Subject = _builder.Instance.AreVerticesAdjacent(vertex1, vertex2);
        }
    }
}
