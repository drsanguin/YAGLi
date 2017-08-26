using NFluent;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Interfaces;
using YAGLi.Specs.Common.AbstractValidators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Validators
{
    public sealed class GraphValidator : BaseValidator<IModelAGraph<Vertex, Edge<Vertex>>>
    {
        [Then(@"he should contains the vertices")]
        public void ThenHeShouldContainsTheVerticesAnd(IEnumerable<Vertex> vertices)
        {
            Check.That(Subject.Vertices.ToEquatable()).ContainsExactly(vertices.ToEquatable());
        }

        [Then(@"he should contains the edges")]
        public void ThenTheEdges(IEnumerable<Edge<Vertex>> edges)
        {
            Check.That(Subject.Edges.ToEquatable()).ContainsExactly(edges.ToEquatable());
        }

        [Then(@"he contains the vertices")]
        public void ThenThisNewUndirectedGraphShouldContainsTheVertices(IEnumerable<Vertex> vertices)
        {
            Check.That(Subject.Vertices.ToEquatable())
                .IsOnlyMadeOf(vertices.ToEquatable())
                .And
                .HasSize(vertices.Count());
        }

        [Then(@"he contains the edges")]
        public void ThenThisNewUndirectedGraphShouldContainsTheEdges(IEnumerable<Edge<Vertex>> edges)
        {
            Check.That(Subject.Edges.ToEquatable())
                .IsOnlyMadeOf(edges.ToEquatable())
                .And
                .HasSize(edges.Count());
        }
    }
}
