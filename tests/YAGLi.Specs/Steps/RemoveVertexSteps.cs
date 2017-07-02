using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Builders;
using YAGLi.Specs.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Steps
{
    [Binding]
    public class RemoveVertexSteps
    {
        UndirectedGraphBuilder _builder;
        GraphValidator _validator;

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
