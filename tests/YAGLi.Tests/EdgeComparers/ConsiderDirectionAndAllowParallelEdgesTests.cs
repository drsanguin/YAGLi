using NFluent;
using NUnit.Framework;
using System;
using YAGLi.EdgeComparers;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests.EdgeComparers
{
    [TestFixture(TestOf = typeof(ConsiderDirectionAndAllowParallelEdges<Vertex, Edge<Vertex>>))]
    public class ConsiderDirectionAndAllowParallelEdgesTests
    {
        private VertexEqualityComparer _vertexComparer;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _vertexComparer = new VertexEqualityComparer();
        }

        [Test]
        public void constructor_should_throw_a_ArgumentnullExeception_if_the_parameter_vertexComparer_is_null()
        {
            Check.ThatCode(() => new ConsiderDirectionAndAllowParallelEdges<Vertex, Edge<Vertex>>(null)).Throws<ArgumentNullException>();
        }

        [Test]
        public void GetHashCode_when_the_instance_has_been_created_with_a_IEqualityComparer_should_return_the_same_value_for_two_Edge_who_have_the_same_ends()
        {
            var edge1 = new Edge<Vertex>("Hello, ", "World!");
            var edge2 = new Edge<Vertex>("Hello, ", "World!");

            var edgeComparer = new ConsiderDirectionAndAllowParallelEdges<Vertex, Edge<Vertex>>(_vertexComparer);

            Check.That(edgeComparer.GetHashCode(edge1)).IsEqualTo(edgeComparer.GetHashCode(edge2));
        }

        [Test]
        public void GetHashCode_when_the_instance_has_been_created_with_a_IEqualityComparer_should_not_return_the_same_value_for_two_Edge_who_have_the_same_ends_in_different_order()
        {
            var edge1 = new Edge<Vertex>("Hello, ", "World!");
            var edge2 = new Edge<Vertex>("World!", "Hello, ");

            var edgeComparer = new ConsiderDirectionAndAllowParallelEdges<Vertex, Edge<Vertex>>(_vertexComparer);

            Check.That(edgeComparer.GetHashCode(edge1)).IsNotEqualTo(edgeComparer.GetHashCode(edge2));
        }

        [Test]
        public void Equals_when_the_instance_has_been_created_with_a_IEqualityComparer_should_return_false_when_edges_are_not_the_same_references()
        {
            var edge1 = new Edge<Vertex>("Hello, ", "World!");
            var edge2 = new Edge<Vertex>("Hello, ", "World!");

            var edgeComparer = new ConsiderDirectionAndAllowParallelEdges<Vertex, Edge<Vertex>>(_vertexComparer);

            Check.That(edgeComparer.Equals(edge1, edge2)).IsFalse();
        }

        [Test]
        public void Equals_when_the_instance_has_been_created_with_a_IEqualityComparer_should_return_true_when_edges_are_the_same_references()
        {
            var edge = new Edge<Vertex>("Hello, ", "World!");

            var edgeComparer = new ConsiderDirectionAndAllowParallelEdges<Vertex, Edge<Vertex>>(_vertexComparer);

            Check.That(edgeComparer.Equals(edge, edge)).IsTrue();
        }

        [Test]
        public void GetHashCode_when_the_instance_has_been_created_with_a_default_IEqualityComparer_should_return_the_same_value_for_two_Edge_who_have_the_same_ends()
        {
            var edge1 = new Edge<string>("Hello, ", "World!");
            var edge2 = new Edge<string>("Hello, ", "World!");

            var edgeComparer = new ConsiderDirectionAndAllowParallelEdges<string, Edge<string>>();

            Check.That(edgeComparer.GetHashCode(edge1)).IsEqualTo(edgeComparer.GetHashCode(edge2));
        }

        [Test]
        public void GetHashCode_when_the_instance_has_been_created_with_a_default_IEqualityComparer_should_not_return_the_same_value_for_two_Edge_who_have_the_same_ends_in_different_order()
        {
            var edge1 = new Edge<string>("Hello, ", "World!");
            var edge2 = new Edge<string>("World!", "Hello, ");

            var edgeComparer = new ConsiderDirectionAndAllowParallelEdges<string, Edge<string>>();

            Check.That(edgeComparer.GetHashCode(edge1)).IsNotEqualTo(edgeComparer.GetHashCode(edge2));
        }

        [Test]
        public void Equals_when_the_instance_has_been_created_with_a_default_IEqualityComparer_should_return_false_when_edges_are_not_the_same_references()
        {
            var edge1 = new Edge<string>("Hello, ", "World!");
            var edge2 = new Edge<string>("Hello, ", "World!");

            var edgeComparer = new ConsiderDirectionAndAllowParallelEdges<string, Edge<string>>();

            Check.That(edgeComparer.Equals(edge1, edge2)).IsFalse();
        }

        [Test]
        public void Equals_when_the_instance_has_been_created_with_a_default_IEqualityComparer_should_return_true_when_edges_are_the_same_references()
        {
            var edge = new Edge<string>("Hello, ", "World!");

            var edgeComparer = new ConsiderDirectionAndAllowParallelEdges<string, Edge<string>>();

            Check.That(edgeComparer.Equals(edge, edge)).IsTrue();
        }
    }
}
