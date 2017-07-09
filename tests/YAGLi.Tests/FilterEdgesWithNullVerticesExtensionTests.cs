using NFluent;
using NUnit.Framework;
using System.Collections.Generic;
using YAGLi.Extensions.EdgeCollection;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests
{
    [TestFixture]
    public class FilterEdgesWithNullVerticesExtensionTests
    {
        [Test]
        public void FilterEdgesWithNullVerticesExtensionTests_with_null_IEnumerable_should_return_a_empty_IEnumerable()
        {
            IEnumerable<Edge<Vertex>> edges = null;

            Check.That(edges.FilterEdgesWithNullVertices<Vertex, Edge<Vertex>>()).IsEmpty();
        }

        [Test]
        public void FilterEdgesWithNullVerticesExtensionTests_should_return_the_expected_result()
        {
            IEnumerable<Edge<Vertex>> edges = new Edge<Vertex>[]
            {
                new Edge<Vertex>("v0", "v1"),
                new Edge<Vertex>("v1", null),
                new Edge<Vertex>("v1", "v2")
            };

            Check.That(edges.FilterEdgesWithNullVertices<Vertex, Edge<Vertex>>()).ContainsExactly(new Edge<Vertex>("v0", "v1"), new Edge<Vertex>("v1", "v2"));
        }

        [Test]
        public void FilterEdgesWithNullVerticesExtensionTests_should_filter_null_edges()
        {
            IEnumerable<Edge<Vertex>> edges = new Edge<Vertex>[] { null };

            Check.That(edges.FilterEdgesWithNullVertices<Vertex, Edge<Vertex>>()).IsEmpty();
        }
    }
}
