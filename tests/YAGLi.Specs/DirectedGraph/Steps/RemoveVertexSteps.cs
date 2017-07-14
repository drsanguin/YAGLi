using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.DirectedGraph.Steps
{
    [Binding]
    public class RemoveVertexSteps
    {
        private readonly DirectedGraphBuilder _builder;
        private readonly GraphValidator _validator;

        public RemoveVertexSteps(DirectedGraphBuilder builder, GraphValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

        [When(@"I remove the vertex ""(.*)"" from the directed graph")]
        public void WhenIRemoveTheVertex(Vertex vertex)
        {
            _validator.Subject = _builder.Instance.RemoveVertex(vertex);
        }

        [When(@"I remove the vertices from the directed graph")]
        public void WhenIRemoveTheVertices(IEnumerable<Vertex> vertices)
        {
            _validator.Subject = _builder.Instance.RemoveVertices(vertices);
        }
    }
}
