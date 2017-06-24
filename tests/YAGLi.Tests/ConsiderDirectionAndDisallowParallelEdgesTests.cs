using NFluent;
using NUnit.Framework;
using System;
using YAGLi.EdgeComparers;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests
{
    [TestFixture]
    public class ConsiderDirectionAndDisallowParallelEdgesTests
    {
        private VertexEqualityComparer _vertexComparer;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _vertexComparer = new VertexEqualityComparer();
        }

        [Test]
        public void ConsiderDirectionAndDisallowParallelEdges_constructor_should_throw_a_ArgumentnullExeception_if_the_parameter_vertexComparer_is_null()
        {
            Check.ThatCode(() => new ConsiderDirectionAndDisallowParallelEdges<Vertex, Edge<Vertex>>(null)).Throws<ArgumentNullException>();
        }

        [Test]
        public void ConsiderDirectionAndDisallowParallelEdges_GetHashCode_when_the_instance_has_been_created_with_a_IEqualityComparer_should_return_the_same_value_for_two_Edge_who_have_the_same_ends()
        {
            var edge1 = new Edge<Vertex>("Hello, ", "World!");
            var edge2 = new Edge<Vertex>("Hello, ", "World!");

            var edgeComparer = new ConsiderDirectionAndDisallowParallelEdges<Vertex, Edge<Vertex>>(_vertexComparer);

            Check.That(edgeComparer.GetHashCode(edge1)).IsEqualTo(edgeComparer.GetHashCode(edge2));
        }

        [Test]
        public void ConsiderDirectionAndDisallowParallelEdges_GetHashCode_when_the_instance_has_been_created_with_a_IEqualityComparer_should_not_return_the_same_value_for_two_Edge_who_have_the_same_ends_in_different_order()
        {
            var edge1 = new Edge<Vertex>("Hello, ", "World!");
            var edge2 = new Edge<Vertex>("World!", "Hello, ");

            var edgeComparer = new ConsiderDirectionAndDisallowParallelEdges<Vertex, Edge<Vertex>>(_vertexComparer);

            Check.That(edgeComparer.GetHashCode(edge1)).IsNotEqualTo(edgeComparer.GetHashCode(edge2));
        }

        [Test]
        public void ConsiderDirectionAndDisallowParallelEdges_GetHashCode_when_the_instance_has_been_created_with_a_IEqualityComparer_should_not_return_the_same_value_for_two_Edge_who_have_not_the_same_ends()
        {
            var edge1 = new Edge<Vertex>("Hello, ", "World!");
            var edge2 = new Edge<Vertex>("Hello", ", World!");

            var edgeComparer = new ConsiderDirectionAndDisallowParallelEdges<Vertex, Edge<Vertex>>(_vertexComparer);

            Check.That(edgeComparer.GetHashCode(edge1)).IsNotEqualTo(edgeComparer.GetHashCode(edge2));
        }

        [Test]
        public void ConsiderDirectionAndDisallowParallelEdges_Equals_when_the_instance_has_been_created_with_a_IEqualityComparer_should_return_true_if_the_edges_are_the_same_references()
        {
            var edge1 = new Edge<Vertex>("Hello, ", "World!");

            var edgeComparer = new ConsiderDirectionAndDisallowParallelEdges<Vertex, Edge<Vertex>>(_vertexComparer);

            Check.That(edgeComparer.Equals(edge1, edge1)).IsTrue();
        }

        [Test]
        public void ConsiderDirectionAndDisallowParallelEdges_Equals_when_the_instance_has_been_created_with_a_IEqualityComparer_should_return_true_if_the_edges_ends_are_equal()
        {
            var edge1 = new Edge<Vertex>("Hello, ", "World!");
            var edge2 = new Edge<Vertex>("Hello, ", "World!");

            var edgeComparer = new ConsiderDirectionAndDisallowParallelEdges<Vertex, Edge<Vertex>>(_vertexComparer);

            Check.That(edgeComparer.Equals(edge1, edge2)).IsTrue();
        }

        [Test]
        public void ConsiderDirectionAndDisallowParallelEdges_Equals_when_the_instance_has_been_created_with_a_IEqualityComparer_should_return_false_if_the_edges_ends_are_not_equal()
        {
            var edge1 = new Edge<Vertex>("Hello, ", "World!");
            var edge2 = new Edge<Vertex>("Hello", ", World!");

            var edgeComparer = new ConsiderDirectionAndDisallowParallelEdges<Vertex, Edge<Vertex>>(_vertexComparer);

            Check.That(edgeComparer.Equals(edge1, edge2)).IsFalse();
        }

        [Test]
        public void ConsiderDirectionAndDisallowParallelEdges_GetHashCode_when_the_instance_has_been_created_with_a_default_IEqualityComparer_should_return_the_same_value_for_two_Edge_who_have_the_same_ends()
        {
            var edge1 = new Edge<string>("Hello, ", "World!");
            var edge2 = new Edge<string>("Hello, ", "World!");

            var edgeComparer = new ConsiderDirectionAndDisallowParallelEdges<string, Edge<string>>();

            Check.That(edgeComparer.GetHashCode(edge1)).IsEqualTo(edgeComparer.GetHashCode(edge2));
        }

        [Test]
        public void ConsiderDirectionAndDisallowParallelEdges_GetHashCode_when_the_instance_has_been_created_with_a_default_IEqualityComparer_should_not_return_the_same_value_for_two_Edge_who_have_not_the_same_ends()
        {
            var edge1 = new Edge<string>("Hello, ", "World!");
            var edge2 = new Edge<string>("Hello", ", World!");

            var edgeComparer = new ConsiderDirectionAndDisallowParallelEdges<string, Edge<string>>();

            Check.That(edgeComparer.GetHashCode(edge1)).IsNotEqualTo(edgeComparer.GetHashCode(edge2));
        }

        [Test]
        public void ConsiderDirectionAndDisallowParallelEdges_GetHashCode_when_the_instance_has_been_created_with_a_default_IEqualityComparer_should_not_return_the_same_value_for_two_Edge_who_have_the_same_ends_in_different_order()
        {
            var edge1 = new Edge<string>("Hello, ", "World!");
            var edge2 = new Edge<string>("World!", "Hello, ");

            var edgeComparer = new ConsiderDirectionAndDisallowParallelEdges<string, Edge<string>>();

            Check.That(edgeComparer.GetHashCode(edge1)).IsNotEqualTo(edgeComparer.GetHashCode(edge2));
        }

        [Test]
        public void ConsiderDirectionAndDisallowParallelEdges_Equals_when_the_instance_has_been_created_with_a_default_IEqualityComparer_should_return_true_if_the_edges_are_the_same_references()
        {
            var edge1 = new Edge<string>("Hello, ", "World!");

            var edgeComparer = new ConsiderDirectionAndDisallowParallelEdges<string, Edge<string>>();

            Check.That(edgeComparer.Equals(edge1, edge1)).IsTrue();
        }

        [Test]
        public void ConsiderDirectionAndDisallowParallelEdges_Equals_when_the_instance_has_been_created_with_a_default_IEqualityComparer_should_return_true_if_the_edges_ends_are_equal()
        {
            var edge1 = new Edge<string>("Hello, ", "World!");
            var edge2 = new Edge<string>("Hello, ", "World!");

            var edgeComparer = new ConsiderDirectionAndDisallowParallelEdges<string, Edge<string>>();

            Check.That(edgeComparer.Equals(edge1, edge2)).IsTrue();
        }

        [Test]
        public void ConsiderDirectionAndDisallowParallelEdges_Equals_when_the_instance_has_been_created_with_a_default_IEqualityComparer_should_return_false_if_the_edges_ends_are_not_equal()
        {
            var edge1 = new Edge<string>("Hello, ", "World!");
            var edge2 = new Edge<string>("Hello", ", World!");

            var edgeComparer = new ConsiderDirectionAndDisallowParallelEdges<string, Edge<string>>();

            Check.That(edgeComparer.Equals(edge1, edge2)).IsFalse();
        }
    }
}
