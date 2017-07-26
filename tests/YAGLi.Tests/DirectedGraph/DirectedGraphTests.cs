using NFluent;
using NUnit.Framework;
using System;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests.DirectedGraph
{
    [TestFixture]
    public class DirectedGraphTests
    {
        [Test]
        public void DirectedGraph_AllowLoops_should_return_the_value_passed_in_the_constructor()
        {
            var graph = new DirectedGraph<Vertex, Edge<Vertex>>(true, true);

            Check.That(graph.AllowLoops).IsTrue();
        }

        [Test]
        public void DirectedGraph_AllowParallelEdges_should_return_the_value_passed_in_the_constructor()
        {
            var graph = new DirectedGraph<Vertex, Edge<Vertex>>(true, true);

            Check.That(graph.AllowParallelEdges).IsTrue();
        }

        [Test]
        public void DirectedGraph_ToString_should_return_the_expected_value()
        {
            var graph = new DirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[] 
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v4", "v3"),
                    new Edge<Vertex>("v4", "v3")
                },
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" },
                new VertexEqualityComparer()
            );

            var newLine = Environment.NewLine;

            Check.That(graph.ToString()).IsEqualTo($"{{{newLine}    AllowLoops = True{newLine}    AllowParallelEdges = True{newLine}    Vertices = [v1, v4, v3, v2, v0]{newLine}    Edges = [{newLine}        (v0 -> v1),{newLine}        (v1 -> v4),{newLine}        (v4 -> v4),{newLine}        (v4 -> v3),{newLine}        (v4 -> v3){newLine}    ]{newLine}}}");
        }

        [Test]
        public void DirectedGraph_AdjacentEdgesOf_with_an_edge_contained_in_the_graph_should_returned_the_expected_colelction_of_edge()
        {
            var edges = new Edge<Vertex>[]
            {
                new Edge<Vertex>("v0", "v1"),
                new Edge<Vertex>("v1", "v4"),
                new Edge<Vertex>("v4", "v4"),
                new Edge<Vertex>("v4", "v3"),
                new Edge<Vertex>("v4", "v3")
            };

            var graph = new DirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                edges,
                new Vertex[] { "v0", "v1", "v2", "v3", "v4" },
                new VertexEqualityComparer()
            );

            Check.That(graph.AdjacentEdgesOf(edges[3])).ContainsExactly(
                new Edge<Vertex>("v1", "v4"),
                new Edge<Vertex>("v4", "v4"),
                new Edge<Vertex>("v4", "v3"));
        }
    }
}
