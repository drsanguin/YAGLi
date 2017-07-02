using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using YAGLi.Specs.Builders;
using YAGLi.Specs.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Steps
{
    [Binding]
    public class AreEdgesAdjacentStep
    {
        private UndirectedGraphBuilder _builder;
        private BooleanValidator _validator;

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
