using NFluent;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.UndirectedGraph.Validators
{
    [Binding]
    public sealed class UndirectedGraphValidator
    {
        private readonly GraphValidator _graphValidator;

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
