using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Specs.UndirectedGraph;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    [Binding]
    public class RemoveVertexSteps
    {
        private readonly UndirectedGraphBuilder _builder;
        private readonly GraphValidator _validator;

        public RemoveVertexSteps(UndirectedGraphBuilder builder, GraphValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

        [When(@"I remove the vertex ""(.*)""")]
        public void WhenIRemoveTheVertex(Vertex vertex)
        {
            _validator.Subject = _builder.Instance.RemoveVertex(vertex);
        }

        [When(@"I remove the vertices")]
        public void WhenIRemoveTheVertices(IEnumerable<Vertex> vertices)
        {
            _validator.Subject = _builder.Instance.RemoveVertices(vertices);
        }
    }
}
