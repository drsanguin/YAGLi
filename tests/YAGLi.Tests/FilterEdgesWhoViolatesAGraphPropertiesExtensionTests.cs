using Moq;
using NFluent;
using NUnit.Framework;
using System.Collections.Generic;
using YAGLi.Extensions;
using YAGLi.Interfaces;

namespace YAGLi.Tests
{
    [TestFixture]
    public class FilterEdgesWhoViolatesAGraphPropertiesExtensionTests
    {
        [Test]
        public void FilterEdgesWhoViolatesAGraphPropertiesExtension_with_a_null_collection_of_edges_should_return_a_empty_IEnumerable()
        {
            IEnumerable<Edge<int>> edges = null;
            var graph = new Mock<IModelAGraph<int>>().Object;

            Check.That(edges.FilterEdgesWhoViolatesThisInstanceProperties(graph, EqualityComparer<int>.Default)).IsEmpty();
        }

        [Test]
        public void FilterEdgesWhoViolatesAGraphPropertiesExtension_with_a_graph_who_disallow_loops_should_return_the_expected_result()
        {
            Edge<int>[] edges = new Edge<int>[]
            {
                new Edge<int>(0, 0),
                new Edge<int>(1, 0),
                new Edge<int>(2, 3),
                new Edge<int>(4, 4),
                new Edge<int>(5, 6)
            };

            var mockedGraph = new Mock<IModelAGraph<int>>();
            mockedGraph.Setup(x => x.AllowLoops).Returns(false);

            var graph = mockedGraph.Object;

            Check.That(edges.FilterEdgesWhoViolatesThisInstanceProperties(graph, EqualityComparer<int>.Default)).ContainsExactly(
                edges[1],
                edges[2],
                edges[4]);
        }

        [Test]
        public void FilterEdgesWhoViolatesAGraphPropertiesExtension_with_a_graph_who_disallow_parallel_edges_should_return_the_expected_result()
        {
            Edge<int>[] edges = new Edge<int>[]
            {
                new Edge<int>(0, 1),
                new Edge<int>(0, 1),
                new Edge<int>(2, 3),
                new Edge<int>(5, 6),
                new Edge<int>(5, 6)
            };

            var mockedGraph = new Mock<IModelAGraph<int>>();
            mockedGraph.Setup(x => x.AllowParallelEdges).Returns(false);
            mockedGraph.Setup(x => x.ContainsEdge(edges[0])).Returns(true);
            mockedGraph.Setup(x => x.ContainsEdge(edges[3])).Returns(true);

            var graph = mockedGraph.Object;

            Check.That(edges.FilterEdgesWhoViolatesThisInstanceProperties(graph, EqualityComparer<int>.Default)).ContainsExactly(
                edges[1],
                edges[2],
                edges[4]);
        }

        [Test]
        public void FilterEdgesWhoViolatesAGraphPropertiesExtension_with_null_IEqualityComparer_should_return_the_expected_result()
        {
            Edge<int>[] edges = new Edge<int>[]
            {
                new Edge<int>(0, 0),
                new Edge<int>(1, 0),
                new Edge<int>(2, 3),
                new Edge<int>(4, 4),
                new Edge<int>(5, 6)
            };

            var mockedGraph = new Mock<IModelAGraph<int>>();
            mockedGraph.Setup(x => x.AllowLoops).Returns(false);

            var graph = mockedGraph.Object;

            Check.That(edges.FilterEdgesWhoViolatesThisInstanceProperties(graph, null)).ContainsExactly(
                edges[1],
                edges[2],
                edges[4]);
        }
    }
}
