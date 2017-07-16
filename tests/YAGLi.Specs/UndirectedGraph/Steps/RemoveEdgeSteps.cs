using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.UndirectedGraph.Steps
{
    public sealed class RemoveEdgeSteps : UndirectedGraphStepWithGraphValidator
    {
        public RemoveEdgeSteps(UndirectedGraphBuilder builder, GraphValidator validator) : base(builder, validator) { }

        [When(@"I remove the edge from the undirected graph")]
        public void WhenIRemoveTheEdge(Edge<Vertex> edge)
        {
            Validator.Subject = Builder.Instance.RemoveEdge(edge);
        }

        [When(@"I remove the edge and her vertices from the undirected graph")]
        public void WhenIRemoveTheEdgeAndHerVertices(Edge<Vertex> edge)
        {
            Validator.Subject = Builder.Instance.RemoveEdgeAndVertices(edge);
        }

        [When(@"I remove the edges from the undirected graph")]
        public void WhenIRemoveTheEdges(IEnumerable<Edge<Vertex>> edges)
        {
            Validator.Subject = Builder.Instance.RemoveEdges(edges);
        }

        [When(@"I remove the edges and their vertices from the undirected graph")]
        public void WhenIRemoveTheEdgesAndTheirVertices(IEnumerable<Edge<Vertex>> edges)
        {
            Validator.Subject = Builder.Instance.RemoveEdgesAndVertices(edges);
        }
    }
}
