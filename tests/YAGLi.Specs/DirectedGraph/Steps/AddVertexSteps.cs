using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.DirectedGraph.Steps
{
    public sealed class AddVertexSteps : DirectedGraphStepWithGraphValidator
    {
        public AddVertexSteps(DirectedGraphBuilder builder, GraphValidator validator) : base(builder, validator) { }

        [When(@"I add the vertices to the directed graph")]
        public void WhenIAddTheVertices(IEnumerable<Vertex> vertices)
        {
            _validator.Subject = _builder.Instance.AddVertices(vertices);
        }

        [When(@"I add the vertex ""(.*)"" to the directed graph")]
        public void WhenIAddTheVertex(Vertex vertex)
        {
            _validator.Subject = _builder.Instance.AddVertex(vertex);
        }
    }
}
