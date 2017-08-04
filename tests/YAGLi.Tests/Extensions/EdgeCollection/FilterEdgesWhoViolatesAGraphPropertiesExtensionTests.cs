using NFluent;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using YAGLi.Extensions.EdgeCollection;
using YAGLi.Interfaces;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests.Extensions.EdgeCollection
{
    [TestFixture]
    public class FilterEdgesWhoViolatesAGraphPropertiesExtensionTests
    {
        [Test]
        public void FilterEdgesWhoViolatesAGraphPropertiesExtension_with_a_null_collection_of_edges_should_return_a_empty_IEnumerable()
        {
            IEnumerable<Edge<int>> edges = null;
            var graph = Substitute.For<IModelAGraph<int, Edge<int>>>();

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

            var graph = Substitute.For<IModelAGraph<int, Edge<int>>>();
            graph.AllowLoops
                 .Returns(false);

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
                new Edge<int>(2, 3),
                new Edge<int>(4, 5),
                new Edge<int>(6, 7),
                new Edge<int>(8, 9)
            };

            var graph = Substitute.For<IModelAGraph<int, Edge<int>>>();
            graph.AllowParallelEdges
                 .Returns(false);
            graph.ContainsEdge(edges[0])
                 .Returns(true);
            graph.ContainsEdge(edges[3])
                 .Returns(true);

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

            var graph = Substitute.For<IModelAGraph<int, Edge<int>>>();
            graph.AllowLoops
                 .Returns(false);

            Check.That(edges.FilterEdgesWhoViolatesThisInstanceProperties(graph, null)).ContainsExactly(
                edges[1],
                edges[2],
                edges[4]);
        }
    }
}
