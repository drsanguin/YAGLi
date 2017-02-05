using NFluent;
using NUnit.Framework;
using System;

namespace YAGL.Tests
{
    [TestFixture]
    public class VertexTests
    {
        [Test]
        public void Vertex_Label_should_return_string_Empty_if_no_label_has_been_passed_to_the_constructor()
        {
            Vertex vertex = new Vertex();

            Check.That(vertex.Label).IsEqualTo(string.Empty);
        }

        [Test]
        public void Vertex_Label_should_return_the_label_that_has_been_passed_to_the_constructor()
        {
            Vertex vertex = new Vertex("42");

            Check.That(vertex.Label).IsEqualTo("42");
        }

        [Test]
        public void Vertex_constructor_should_throws_a_a_ArgumentNullException_if_the_label_passed_to_the_constructo_is_null()
        {
            Check.ThatCode(() => new Vertex(null)).Throws<ArgumentNullException>();
        }
    }
}
