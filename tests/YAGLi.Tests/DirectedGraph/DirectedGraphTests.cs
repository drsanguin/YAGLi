using NFluent;
using NUnit.Framework;
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
    }
}
