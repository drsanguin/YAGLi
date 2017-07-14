using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.DirectedGraph.Steps
{
    [Binding]
    public class RemoveEdgeSteps
    {
        private readonly DirectedGraphBuilder _builder;
        private readonly GraphValidator _validator;

        public RemoveEdgeSteps(DirectedGraphBuilder builder, GraphValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

        [When(@"I remove the edge from the directed graph")]
        public void WhenIRemoveTheEdge(Edge<Vertex> edge)
        {
            _validator.Subject = _builder.Instance.RemoveEdge(edge);
        }

        [When(@"I remove the edge and her vertices from the directed graph")]
        public void WhenIRemoveTheEdgeAndHerVertices(Edge<Vertex> edge)
        {
            _validator.Subject = _builder.Instance.RemoveEdgeAndVertices(edge);
        }

        [When(@"I remove the edges from the directed graph")]
        public void WhenIRemoveTheEdges(IEnumerable<Edge<Vertex>> edges)
        {
            _validator.Subject = _builder.Instance.RemoveEdges(edges);
        }

        [When(@"I remove the edges and their vertices from the directed graph")]
        public void WhenIRemoveTheEdgesAndTheirVertices(IEnumerable<Edge<Vertex>> edges)
        {
            _validator.Subject = _builder.Instance.RemoveEdgesAndVertices(edges);
        }
    }
}
