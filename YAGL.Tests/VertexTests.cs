using NFluent;
using NUnit.Framework;
using System;

namespace YAGL.Tests
{
    [TestFixture]
    public class VertexTests
    {
        [Test]
        public void Vertex_Constructor_should_throw_a_ArgumentNullException_if_the_data_is_null()
        {
            Check.ThatCode(() => new Vertex<object>(null)).Throws<ArgumentNullException>();
        }

        [Test]
        public void Vertex_Data_should_return_the_same_data_passed_in_the_constructor()
        {
            Vertex<string> vertex = new Vertex<string>("42");

            Check.That(vertex.Data).IsEqualTo("42");
        }

        [Test]
        public void Vertex_ToString_should_return_the_same_string_returned_by_the_ToString_of_the_data_stored_in_the_Vertex()
        {
            Vertex<string> vertex = new Vertex<string>("42");

            Check.That(vertex.ToString()).IsEqualTo("42");
        }
    }
}
