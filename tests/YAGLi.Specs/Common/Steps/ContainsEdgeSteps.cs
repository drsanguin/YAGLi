using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Specs.UndirectedGraph;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    [Binding]
    public class ContainsEdgeSteps
    {
        private readonly UndirectedGraphBuilder _builder;
        private readonly BooleanValidator _validator;

        public ContainsEdgeSteps(UndirectedGraphBuilder builder, BooleanValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

        [When(@"I check that the graph contains the edge")]
        public void WhenICheckThatTheGraphContainsTheEdge(Edge<Vertex> edge)
        {
            _validator.Subject = _builder.Instance.ContainsEdge(edge);
        }

        [When(@"I check that the graph contains the edges")]
        public void WhenICheckThatTheGraphContainsTheEdge(IEnumerable<Edge<Vertex>> edges)
        {
            _validator.Subject = _builder.Instance.ContainsEdges(edges);
        }
    }
}
