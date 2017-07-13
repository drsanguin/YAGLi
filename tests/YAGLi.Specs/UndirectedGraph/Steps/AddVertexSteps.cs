using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.UndirectedGraph.Steps
{
    [Binding]
    public class AddVertexSteps
    {
        private readonly UndirectedGraphBuilder _builder;
        private readonly GraphValidator _validator;

        public AddVertexSteps(UndirectedGraphBuilder builder, GraphValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

        [When(@"I add the vertices to the undirected graph")]
        public void WhenIAddTheVertices(IEnumerable<Vertex> vertices)
        {
            _validator.Subject = _builder.Instance.AddVertices(vertices);
        }

        [When(@"I add the vertex ""(.*)"" to the undirected graph")]
        public void WhenIAddTheVertex(Vertex vertex)
        {
            _validator.Subject = _builder.Instance.AddVertex(vertex);
        }
    }
}
