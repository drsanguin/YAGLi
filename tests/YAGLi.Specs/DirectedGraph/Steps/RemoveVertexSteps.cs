using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Specs.DirectedGraph.AbstractSteps;
using YAGLi.Specs.DirectedGraph.Builders;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.DirectedGraph.Steps
{
    [Binding]
    public sealed class RemoveVertexSteps : DirectedGraphStepWithGraphValidator
    {
        public RemoveVertexSteps(DirectedGraphBuilder builder, GraphValidator validator) : base(builder, validator) { }

        [When(@"I remove the vertex ""(.*)"" from the directed graph")]
        public void WhenIRemoveTheVertex(Vertex vertex)
        {
            Validator.Subject = Builder.Instance.RemoveVertex(vertex);
        }

        [When(@"I remove the vertices from the directed graph")]
        public void WhenIRemoveTheVertices(IEnumerable<Vertex> vertices)
        {
            Validator.Subject = Builder.Instance.RemoveVertices(vertices);
        }
    }
}
