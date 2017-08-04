using NFluent;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.AbstractValidators;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.UndirectedGraph.Validators
{
    [Binding]
    public sealed class UndirectedGraphValidator : ValidatorUsingGraphValidator
    {
        public UndirectedGraphValidator(GraphValidator graphValidator) : base(graphValidator) { }

        [Then(@"I get a new undirected graph")]
        public void ThenIShouldGetANewUndirectedGraph()
        {
            Check.That(GraphValidator.Subject).IsInstanceOf<UndirectedGraph<Vertex, Edge<Vertex>>>();
        }
    }
}
