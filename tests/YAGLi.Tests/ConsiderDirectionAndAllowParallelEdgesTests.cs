using NFluent;
using NUnit.Framework;
using System;
using YAGLi.EdgeComparers;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests
{
    [TestFixture]
    public class ConsiderDirectionAndAllowParallelEdgesTests
    {
        private VertexEqualityComparer _vertexComparer;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _vertexComparer = new VertexEqualityComparer();
        }

        [Test]
        public void ConsiderDirectionAndAllowParallelEdgesTests_constructor_should_throw_a_ArgumentnullExeception_if_the_parameter_vertexComparer_is_null()
        {
            Check.ThatCode(() => new ConsiderDirectionAndAllowParallelEdges<Vertex>(null)).Throws<ArgumentNullException>();
        }

        [Test]
        public void ConsiderDirectionAndAllowParallelEdges_GetHashCode_when_the_instance_has_been_created_with_a_IEqualityComparer_should_return_the_same_value_for_two_Edge_who_have_the_same_ends()
        {
            Edge<Vertex> edge1 = new Edge<Vertex>("Hello, ", "World!");
            Edge<Vertex> edge2 = new Edge<Vertex>("Hello, ", "World!");

            ConsiderDirectionAndAllowParallelEdges<Vertex> edgeComparer = new ConsiderDirectionAndAllowParallelEdges<Vertex>(_vertexComparer);

            Check.That(edgeComparer.GetHashCode(edge1)).IsEqualTo(edgeComparer.GetHashCode(edge2));
        }

        [Test]
        public void ConsiderDirectionAndAllowParallelEdges_GetHashCode_when_the_instance_has_been_created_with_a_IEqualityComparer_should_not_return_the_same_value_for_two_Edge_who_have_the_same_ends_in_different_order()
        {
            Edge<Vertex> edge1 = new Edge<Vertex>("Hello, ", "World!");
            Edge<Vertex> edge2 = new Edge<Vertex>("World!", "Hello, ");

            ConsiderDirectionAndAllowParallelEdges<Vertex> edgeComparer = new ConsiderDirectionAndAllowParallelEdges<Vertex>(_vertexComparer);

            Check.That(edgeComparer.GetHashCode(edge1)).IsNotEqualTo(edgeComparer.GetHashCode(edge2));
        }

        [Test]
        public void ConsiderDirectionAndAllowParallelEdgesTests_Equals_when_the_instance_has_been_created_with_a_IEqualityComparer_should_return_false_when_edges_are_not_the_same_references()
        {
            Edge<Vertex> edge1 = new Edge<Vertex>("Hello, ", "World!");
            Edge<Vertex> edge2 = new Edge<Vertex>("Hello, ", "World!");

            ConsiderDirectionAndAllowParallelEdges<Vertex> edgeComparer = new ConsiderDirectionAndAllowParallelEdges<Vertex>(_vertexComparer);

            Check.That(edgeComparer.Equals(edge1, edge2)).IsFalse();
        }

        [Test]
        public void ConsiderDirectionAndAllowParallelEdgesTests_Equals_when_the_instance_has_been_created_with_a_IEqualityComparer_should_return_true_when_edges_are_the_same_references()
        {
            Edge<Vertex> edge = new Edge<Vertex>("Hello, ", "World!");

            ConsiderDirectionAndAllowParallelEdges<Vertex> edgeComparer = new ConsiderDirectionAndAllowParallelEdges<Vertex>(_vertexComparer);

            Check.That(edgeComparer.Equals(edge, edge)).IsTrue();
        }

        [Test]
        public void ConsiderDirectionAndAllowParallelEdges_GetHashCode_when_the_instance_has_been_created_with_a_default_IEqualityComparer_should_return_the_same_value_for_two_Edge_who_have_the_same_ends()
        {
            Edge<string> edge1 = new Edge<string>("Hello, ", "World!");
            Edge<string> edge2 = new Edge<string>("Hello, ", "World!");

            ConsiderDirectionAndAllowParallelEdges<string> edgeComparer = new ConsiderDirectionAndAllowParallelEdges<string>();

            Check.That(edgeComparer.GetHashCode(edge1)).IsEqualTo(edgeComparer.GetHashCode(edge2));
        }

        [Test]
        public void ConsiderDirectionAndAllowParallelEdges_GetHashCode_when_the_instance_has_been_created_with_a_default_IEqualityComparer_should_not_return_the_same_value_for_two_Edge_who_have_the_same_ends_in_different_order()
        {
            Edge<string> edge1 = new Edge<string>("Hello, ", "World!");
            Edge<string> edge2 = new Edge<string>("World!", "Hello, ");

            ConsiderDirectionAndAllowParallelEdges<string> edgeComparer = new ConsiderDirectionAndAllowParallelEdges<string>();

            Check.That(edgeComparer.GetHashCode(edge1)).IsNotEqualTo(edgeComparer.GetHashCode(edge2));
        }

        [Test]
        public void ConsiderDirectionAndAllowParallelEdgesTests_Equals_when_the_instance_has_been_created_with_a_default_IEqualityComparer_should_return_false_when_edges_are_not_the_same_references()
        {
            Edge<string> edge1 = new Edge<string>("Hello, ", "World!");
            Edge<string> edge2 = new Edge<string>("Hello, ", "World!");

            ConsiderDirectionAndAllowParallelEdges<string> edgeComparer = new ConsiderDirectionAndAllowParallelEdges<string>();

            Check.That(edgeComparer.Equals(edge1, edge2)).IsFalse();
        }

        [Test]
        public void ConsiderDirectionAndAllowParallelEdgesTests_Equals_when_the_instance_has_been_created_with_a_default_IEqualityComparer_should_return_true_when_edges_are_the_same_references()
        {
            Edge<string> edge = new Edge<string>("Hello, ", "World!");

            ConsiderDirectionAndAllowParallelEdges<string> edgeComparer = new ConsiderDirectionAndAllowParallelEdges<string>();

            Check.That(edgeComparer.Equals(edge, edge)).IsTrue();
        }
    }
}
