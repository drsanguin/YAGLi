using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Specs.UndirectedGraph.Builders;
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

        [When(@"I remove the following IEnumerable of vertices from the undirected graph")]
        public void WhenIRemoveTheFollowingIEnumerableOfVerticesFromTheUndirectedGraph(IEnumerable<Vertex> vertices)
        {
            Validator.Subject = Builder.Instance.RemoveVertices(vertices);
        }

        [When(@"I remove the following array of vertices from the undirected graph")]
        public void WhenIRemoveTheFollowingArrayOfVerticesFromTheUndirectedGraph(Vertex[] vertices)
        {
            Validator.Subject = Builder.Instance.RemoveVertices(vertices);
        }
    }
}
