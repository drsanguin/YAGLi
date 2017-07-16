using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.AbstractSteps;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    public sealed class ContainsVerticesSteps : StepWithBooleanValidator
    {
        public ContainsVerticesSteps(GraphBuilder builder, BooleanValidator validator) : base(builder, validator) { }

        [When(@"I check that the graph contains the vertex ""(.*)""")]
        public void WhenICheckThatTheGraphContainsTheVertex(Vertex vertex)
        {
            Validator.Subject = Builder.Instance.ContainsVertex(vertex);
        }

        [When(@"I check that the graph contains the vertices")]
        public void WhenICheckThatTheGraphContainsTheVertices(IEnumerable<Vertex> vertices)
        {
            Validator.Subject = Builder.Instance.ContainsVertices(vertices);
        }
    }
}
