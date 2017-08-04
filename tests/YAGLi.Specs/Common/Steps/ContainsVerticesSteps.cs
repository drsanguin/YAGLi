using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.AbstractSteps;
using YAGLi.Specs.Common.Builders;
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

        [When(@"I check that the graph contains the following IEnumerable of vertices")]
        public void WhenICheckThatTheGraphContainsTheFollowingIEnumerableOfVertices(IEnumerable<Vertex> vertices)
        {
            Validator.Subject = Builder.Instance.ContainsVertices(vertices);
        }

        [When(@"I check that the graph contains the following array of vertices")]
        public void WhenICheckThatTheGraphContainsTheFollowingArrayOfVertices(Vertex[] vertices)
        {
            Validator.Subject = Builder.Instance.ContainsVertices(vertices);
        }
    }
}
