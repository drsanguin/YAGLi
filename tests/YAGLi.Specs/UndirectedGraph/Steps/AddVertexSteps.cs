using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.UndirectedGraph.Steps
{
    public sealed class AddVertexSteps : UndirectedGraphStepWithGraphValidator
    {
        public AddVertexSteps(UndirectedGraphBuilder builder, GraphValidator validator) : base(builder, validator) { }

        [When(@"I add the following IEnumerable of vertices to the undirected graph")]
        public void WhenIAddTheFollowingIEnumerableOfVerticesToTheUndirectedGraph(IEnumerable<Vertex> vertices)
        {
            Validator.Subject = Builder.Instance.AddVertices(vertices);
        }

        [When(@"I add the following array of vertices to the undirected graph")]
        public void WhenIAddTheFollowingArrayOfVerticesToTheUndirectedGraph(Vertex[] vertices)
        {
            Validator.Subject = Builder.Instance.AddVertices(vertices);
        }

        [When(@"I add the vertex ""(.*)"" to the undirected graph")]
        public void WhenIAddTheVertex(Vertex vertex)
        {
            Validator.Subject = Builder.Instance.AddVertex(vertex);
        }
    }
}
