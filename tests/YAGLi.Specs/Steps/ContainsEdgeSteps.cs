using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Builders;
using YAGLi.Specs.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Steps
{
    [Binding]
    public class ContainsEdgeSteps
    {
        UndirectedGraphBuilder _builder;
        BooleanValidator _validator;

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
