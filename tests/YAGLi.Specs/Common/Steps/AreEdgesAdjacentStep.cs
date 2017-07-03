using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Specs.UndirectedGraph;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    [Binding]
    public class AreEdgesAdjacentStep
    {
        private readonly UndirectedGraphBuilder _builder;
        private readonly BooleanValidator _validator;

        public AreEdgesAdjacentStep(UndirectedGraphBuilder builder, BooleanValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

        [When(@"I check if the following edges are adjacent")]
        public void WhenICheckIfTheEdgesAndAreAdjacent(IEnumerable<Edge<Vertex>> edges)
        {
            var array = edges.ToArray();

            _validator.Subject = _builder.Instance.AreEdgesAdjacent(array[0], array[1]);
        }
    }
}
