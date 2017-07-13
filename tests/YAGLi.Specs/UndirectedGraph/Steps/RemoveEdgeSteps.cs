using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.UndirectedGraph.Steps
{
    [Binding]
    public class RemoveEdgeSteps
    {
        private readonly UndirectedGraphBuilder _builder;
        private readonly GraphValidator _validator;

        public RemoveEdgeSteps(UndirectedGraphBuilder builder, GraphValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

        [When(@"I remove the edge from the undirected graph")]
        public void WhenIRemoveTheEdge(Edge<Vertex> edge)
        {
            _validator.Subject = _builder.Instance.RemoveEdge(edge);
        }

        [When(@"I remove the edge and her vertices from the undirected graph")]
        public void WhenIRemoveTheEdgeAndHerVertices(Edge<Vertex> edge)
        {
            _validator.Subject = _builder.Instance.RemoveEdgeAndVertices(edge);
        }

        [When(@"I remove the edges from the undirected graph")]
        public void WhenIRemoveTheEdges(IEnumerable<Edge<Vertex>> edges)
        {
            _validator.Subject = _builder.Instance.RemoveEdges(edges);
        }

        [When(@"I remove the edges and their vertices from the undirected graph")]
        public void WhenIRemoveTheEdgesAndTheirVertices(IEnumerable<Edge<Vertex>> edges)
        {
            _validator.Subject = _builder.Instance.RemoveEdgesAndVertices(edges);
        }
    }
}
