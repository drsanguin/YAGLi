using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.AbstractSteps;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    public sealed class AreEdgesAdjacentStep : StepWithBooleanValidator
    {
        public AreEdgesAdjacentStep(GraphBuilder builder, BooleanValidator validator) : base(builder, validator) { }

        [When(@"I check if the following edges are adjacent")]
        public void WhenICheckIfTheEdgesAndAreAdjacent(IEnumerable<Edge<Vertex>> edges)
        {
            var array = edges.ToArray();

            Validator.Subject = Builder.Instance.AreEdgesAdjacent(array[0], array[1]);
        }
    }
}
