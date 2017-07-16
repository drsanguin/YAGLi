using NFluent;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.DirectedGraph
{
    [Binding]
    public sealed class DirectedGraphValidator
    {
        private readonly GraphValidator _graphValidator;

        public DirectedGraphValidator(GraphValidator graphValidator)
        {
            _graphValidator = graphValidator;
        }

        [Then(@"I get a new directed graph")]
        public void ThenIShouldGetANewDirectedGraph()
        {
            Check.That(_graphValidator.Subject).IsInstanceOf<UndirectedGraph<Vertex, Edge<Vertex>>>();
        }
    }
}
