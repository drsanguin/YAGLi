using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.AbstractSteps;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    public sealed class ContainsEdgeSteps : StepWithBooleanValidator
    {
        public ContainsEdgeSteps(GraphBuilder builder, BooleanValidator validator) : base(builder, validator) { }

        [When(@"I check that the graph contains the edge")]
        public void WhenICheckThatTheGraphContainsTheEdge(Edge<Vertex> edge)
        {
            Validator.Subject = Builder.Instance.ContainsEdge(edge);
        }

        [When(@"I check that the graph contains the edges")]
        public void WhenICheckThatTheGraphContainsTheEdge(IEnumerable<Edge<Vertex>> edges)
        {
            Validator.Subject = Builder.Instance.ContainsEdges(edges);
        }
    }
}
