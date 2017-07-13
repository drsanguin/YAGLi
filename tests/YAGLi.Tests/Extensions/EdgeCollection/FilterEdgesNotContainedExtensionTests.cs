using Moq;
using NFluent;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using YAGLi.Extensions.EdgeCollection;
using YAGLi.Interfaces;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests.Extensions.EdgeCollection
{
    [TestFixture]
    public class FilterEdgesNotContainedExtensionTests
    {
        private IModelAGraph<int, Edge<int>> _graph;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Mock<IModelAGraph<int, Edge<int>>> mockedGraph = new Mock<IModelAGraph<int, Edge<int>>>();
            mockedGraph.Setup(x => x.ContainsVertices(It.IsAny<int[]>())).Returns<int[]>(vertices => vertices.All(vertex => vertex % 2 == 0));

            _graph = mockedGraph.Object;
        }

        [Test]
        public void FilterNullsExtension_with_a_null_collection_of_edges_should_return_a_empty_IEnumerable()
        {
            IEnumerable<Edge<int>> edges = null;

            Check.That(edges.FilterEdgesWhosVerticesAreNotContainedInThisGraph(_graph)).IsEmpty();
        }

        [Test]
        public void FilterNullsExtension_should_return_the_expected_result()
        {
            Edge<int>[] edges = new Edge<int>[]
            {
                new Edge<int>(0, 0),
                new Edge<int>(1, 1),
                new Edge<int>(2, 2),
                new Edge<int>(3, 3),
                new Edge<int>(4, 4),
                new Edge<int>(5, 5),
                new Edge<int>(6, 6),
                new Edge<int>(7, 7),
                new Edge<int>(8, 8),
                new Edge<int>(9, 9)
            };

            Check.That(edges.FilterEdgesWhosVerticesAreNotContainedInThisGraph(_graph))
                .ContainsExactly(edges[0], edges[2], edges[4], edges[6], edges[8]);
        }
    }
}
