using NFluent;
using NUnit.Framework;
using System;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests
{
    [TestFixture]
    public class EdgeTests
    {
        [Test]
        public void Edge_constructor_should_throw_a_ArgumentNullException_if_end1_is_equal_to_null()
        {
            Check.ThatCode(() => new Edge<string>(null, "42")).Throws<ArgumentNullException>();
        }

        [Test]
        public void Edge_constructor_should_throw_a_ArgumentNullException_if_end2_is_equal_to_null()
        {
            Check.ThatCode(() => new Edge<string>("42", null)).Throws<ArgumentNullException>();
        }

        [Test]
        public void Edge_End1_should_be_equal_to_the_parameter_end1_of_the_constructor()
        {
            Edge<string> edge = new Edge<string>("Hello", "World!");

            Check.That(edge.End1).IsEqualTo("Hello");
        }

        [Test]
        public void Edge_End2_should_be_equal_to_the_parameter_end2_of_the_constructor()
        {
            Edge<string> edge = new Edge<string>("Hello", "World!");

            Check.That(edge.End2).IsEqualTo("World!");
        }

        [Test]
        public void Edge_AreAdjacent_should_return_false_if_the_edges_does_not_share_a_common_vertex()
        {
            Edge<Vertex> edge1 = new Edge<Vertex>("Hello, ", "World!");
            Edge<Vertex> edge2 = new Edge<Vertex>("Hello", ", World!");

            Check.That(Edge<Vertex>.AreAdjacent(edge1, edge2, new VertexEqualityComparer())).IsFalse();
        }

        [Test]
        public void Edge_AreAdjacent_should_return_true_if_the_edges_does_share_a_common_vertex()
        {
            Edge<Vertex> edge1 = new Edge<Vertex>("Hello, ", "World!");
            Edge<Vertex> edge2 = new Edge<Vertex>("Hello, ", "World!");

            Check.That(Edge<Vertex>.AreAdjacent(edge1, edge2, new VertexEqualityComparer())).IsTrue();
        }
    }
}
