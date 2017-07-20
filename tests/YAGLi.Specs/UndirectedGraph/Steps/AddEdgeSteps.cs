using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.UndirectedGraph.Steps
{
    public sealed class AddEdgeSteps : UndirectedGraphStepWithGraphValidator
    {
        public AddEdgeSteps(UndirectedGraphBuilder builder, GraphValidator validator) : base(builder, validator) { }

        [When(@"I add the following IEnumerable of edges to the undirected graph")]
        public void WhenIAddTheFollowingIEnumerableOfEdgesToTheUndirectedGraph(IEnumerable<Edge<Vertex>> edges)
        {
            Validator.Subject = Builder.Instance.AddEdges(edges);
        }

        [When(@"I add the following array of edges to the undirected graph")]
        public void WhenIAddTheFollowingArrayOfEdgesToTheUndirectedGraph(Edge<Vertex>[] edges)
        {
            Validator.Subject = Builder.Instance.AddEdges(edges);
        }

        [When(@"I add the edge to the undirected graph")]
        public void WhenIAddTheEdge(Edge<Vertex> edge)
        {
            Validator.Subject = Builder.Instance.AddEdge(edge);
        }

        [When(@"I add the following edge with her vertices to the undirected graph")]
        public void WhenIAddTheEdgeWithTheVerticesAnd(Edge<Vertex> edge)
        {
            Validator.Subject = Builder.Instance.AddEdgeAndVertices(edge);
        }

        [When(@"I add the following IEnumerable of edges with their vertices to the undirected graph")]
        public void WhenIAddTheFollowingIEnumerableOfEdgesWithTheirVerticesToTheUndirectedGraph(IEnumerable<Edge<Vertex>> edges)
        {
            Validator.Subject = Builder.Instance.AddEdgesAndVertices(edges);
        }

        [When(@"I add the following array of edges with their vertices to the undirected graph")]
        public void WhenIAddTheFollowingArrayOfEdgesWithTheirVerticesToTheUndirectedGraph(Edge<Vertex>[] edges)
        {
            Validator.Subject = Builder.Instance.AddEdgesAndVertices(edges);
        }
    }
}
