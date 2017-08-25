using NFluent;
using NUnit.Framework;
using YAGLi.Extensions.Ends;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests.Extensions.Edges
{
    [TestFixture(TestOf = typeof(EndsExtension))]
    public class EndsExtensionTests
    {
        [Test]
        public void Ends_should_return_the_expected_result()
        {
            var end1 = new Vertex("v0");
            var end2 = new Vertex("v1");
            var edge = new Edge<Vertex>(end1, end2);

            Check.That(edge.Ends()).ContainsExactly(end1, end2);
        }

        [Test]
        public void Ends_with_a_null_edge_should_return_the_expected_result()
        {
            Edge<Vertex> edge = null;

            Check.That(edge.Ends()).IsEmpty();
        }

        [Test]
        public void Ends_with_an_edge_with_null_ends_should_return_an_empty_IEnumerable()
        {
            Edge<Vertex> edge = new Edge<Vertex>(null, null);

            Check.That(edge.Ends()).IsEmpty();
        }
    }
}
