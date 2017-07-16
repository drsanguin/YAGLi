using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.UndirectedGraph.Steps
{
    public sealed class RemoveVertexSteps : UndirectedGraphStepWithGraphValidator
    {
        public RemoveVertexSteps(UndirectedGraphBuilder builder, GraphValidator validator) : base(builder, validator) { }

        [When(@"I remove the vertex ""(.*)"" from the undirected graph")]
        public void WhenIRemoveTheVertex(Vertex vertex)
        {
            Validator.Subject = Builder.Instance.RemoveVertex(vertex);
        }

        [When(@"I remove the vertices from the undirected graph")]
        public void WhenIRemoveTheVertices(IEnumerable<Vertex> vertices)
        {
            Validator.Subject = Builder.Instance.RemoveVertices(vertices);
        }
    }
}
