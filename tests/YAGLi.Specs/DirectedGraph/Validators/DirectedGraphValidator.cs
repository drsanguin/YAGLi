using NFluent;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.AbstractValidators;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.DirectedGraph.Validators
{
    [Binding]
    public sealed class DirectedGraphValidator : ValidatorUsingGraphValidator
    {
        public DirectedGraphValidator(GraphValidator graphValidator) : base(graphValidator) { }

        [Then(@"I get a new directed graph")]
        public void ThenIShouldGetANewDirectedGraph()
        {
            Check.That(GraphValidator.Subject).IsInstanceOf<UndirectedGraph<Vertex, Edge<Vertex>>>();
        }
    }
}
