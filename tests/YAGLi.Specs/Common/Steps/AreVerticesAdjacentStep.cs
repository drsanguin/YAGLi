using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Specs.UndirectedGraph;

namespace YAGLi.Specs.Common.Steps
{
    [Binding]
    public class AreVerticesAdjacentStep
    {
        private readonly UndirectedGraphBuilder _builder;
        private readonly BooleanValidator _validator;

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
