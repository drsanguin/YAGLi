using NFluent;
using TechTalk.SpecFlow;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Validators
{
    [Binding]
    public class UndirectedGraphValidator
    {
        private GraphValidator _graphValidator;

        public UndirectedGraphValidator(GraphValidator graphValidator)
        {
            _graphValidator = graphValidator;
        }

        [Then(@"I get a new undirected graph")]
        public void ThenIShouldGetANewUndirectedGraph()
        {
            Check.That(_graphValidator.Subject).IsInstanceOf<UndirectedGraph<Vertex, Edge<Vertex>>>();
        }
    }
}
