using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Specs.UndirectedGraph;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    [Binding]
    public class ContainsVerticesSteps
    {
        private readonly UndirectedGraphBuilder _builder;
        private readonly BooleanValidator _validator;

        public ContainsVerticesSteps(UndirectedGraphBuilder builder, BooleanValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

        [When(@"I check that the graph contains the vertex ""(.*)""")]
        public void WhenICheckThatTheGraphContainsTheVertex(string vertex)
        {
            _validator.Subject = _builder.Instance.ContainsVertex(vertex);
        }

        [When(@"I check that the graph contains the vertices")]
        public void WhenICheckThatTheGraphContainsTheVertices(IEnumerable<Vertex> vertices)
        {
            _validator.Subject = _builder.Instance.ContainsVertices(vertices);
        }
    }
}
