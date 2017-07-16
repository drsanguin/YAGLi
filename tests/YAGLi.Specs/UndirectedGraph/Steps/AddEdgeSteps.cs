using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.UndirectedGraph.Steps
{
    public sealed class AddEdgeSteps : UndirectedGraphStepWithGraphValidator
    {
        public AddEdgeSteps(UndirectedGraphBuilder builder, GraphValidator validator) : base(builder, validator) { }

        [When(@"I add the edges to the undirected graph")]
        public void WhenIAddTheEdges(IEnumerable<Edge<Vertex>> edges)
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

        [When(@"I add the edges and vertices with their vertices to the undirected graph")]
        public void WhenIAddTheEdgesAndVertices(IEnumerable<Edge<Vertex>> edges)
        {
            Validator.Subject = Builder.Instance.AddEdgesAndVertices(edges);
        }
    }
}
