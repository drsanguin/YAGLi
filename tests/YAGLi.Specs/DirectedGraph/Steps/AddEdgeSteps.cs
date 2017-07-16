using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.DirectedGraph.Steps
{
    public sealed class AddEdgeSteps : DirectedGraphStepWithGraphValidator
    {
        public AddEdgeSteps(DirectedGraphBuilder builder, GraphValidator validator) : base(builder, validator) { }

        [When(@"I add the edges to the directed graph")]
        public void WhenIAddTheEdges(IEnumerable<Edge<Vertex>> edges)
        {
            _validator.Subject = _builder.Instance.AddEdges(edges);
        }

        [When(@"I add the edge to the directed graph")]
        public void WhenIAddTheEdge(Edge<Vertex> edge)
        {
            _validator.Subject = _builder.Instance.AddEdge(edge);
        }

        [When(@"I add the following edge with her vertices to the directed graph")]
        public void WhenIAddTheEdgeWithTheVerticesAnd(Edge<Vertex> edge)
        {
            _validator.Subject = _builder.Instance.AddEdgeAndVertices(edge);
        }

        [When(@"I add the edges and vertices with their vertices to the directed graph")]
        public void WhenIAddTheEdgesAndVertices(IEnumerable<Edge<Vertex>> edges)
        {
            _validator.Subject = _builder.Instance.AddEdgesAndVertices(edges);
        }
    }
}
