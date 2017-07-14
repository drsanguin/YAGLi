using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.DirectedGraph.Steps
{
    [Binding]
    public class AddVertexSteps
    {
        private readonly DirectedGraphBuilder _builder;
        private readonly GraphValidator _validator;

        public AddVertexSteps(DirectedGraphBuilder builder, GraphValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

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
