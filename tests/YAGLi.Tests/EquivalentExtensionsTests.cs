using NFluent;
using NUnit.Framework;
using YAGLi.Extensions;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests
{
    [TestFixture]
    public class EquivalentExtensionsTests
    {
        [Test]
        public void EquivalentExtensions_IsEquivalent_should_return_false_if_the_two_IEnumerable_have_different_sizes()
        {
            var vertices1 = new Vertex[] { "42" };
            var vertices2 = new Vertex[] { "Hello, ", "World!" };

            Check.That(vertices1.IsEquivalent(vertices2, new VertexEqualityComparer())).IsFalse();
        }

        [Test]
        public void EquivalentExtensions_IsEquivalent_should_return_false_if_the_two_IEnumerable_does_not_contains_the_same_elements()
        {
            var vertices1 = new Vertex[] { "Hello", ", World!" };
            var vertices2 = new Vertex[] { "Hello, ", "World!" };

            Check.That(vertices1.IsEquivalent(vertices2, new VertexEqualityComparer())).IsFalse();
        }

        [Test]
        public void EquivalentExtensions_IsEquivalent_should_return_true_if_the_two_IEnumerable_contains_the_same_elements()
        {
            var vertices1 = new Vertex[] { "Hello", ", World!" };
            var vertices2 = new Vertex[] { ", World!", "Hello" };

            Check.That(vertices1.IsEquivalent(vertices2, new VertexEqualityComparer())).IsTrue();
        }

        [Test]
        public void EquivalentExtensions_IsEquivalent_should_return_true_if_the_two_IEnumerable_are_the_same_references()
        {
            var vertices1 = new Vertex[] { "Hello", ", World!" };

            Check.That(vertices1.IsEquivalent(vertices1, new VertexEqualityComparer())).IsTrue();
        }

        [Test]
        public void EquivalentExtensions_IsEquivalent_should_return_true_if_the_two_IEnumerable_are_sequence_equal()
        {
            var vertices1 = new Vertex[] { "Hello", ", World!" };
            var vertices2 = new Vertex[] { "Hello", ", World!" };

            Check.That(vertices1.IsEquivalent(vertices2, new VertexEqualityComparer())).IsTrue();
        }

        [Test]
        public void EquivalentExtensions_IsEquivalent_with_default_IEqualityComparer_should_return_false_if_the_two_IEnumerable_have_different_sizes()
        {
            var vertices1 = new string[] { "42" };
            var vertices2 = new string[] { "Hello, ", "World!" };

            Check.That(vertices1.IsEquivalent(vertices2)).IsFalse();
        }

        [Test]
        public void EquivalentExtensions_IsEquivalent_with_default_IEqualityComparer_should_return_false_if_the_two_IEnumerable_does_not_contains_the_same_elements()
        {
            var vertices1 = new string[] { "Hello", ", World!" };
            var vertices2 = new string[] { "Hello, ", "World!" };

            Check.That(vertices1.IsEquivalent(vertices2)).IsFalse();
        }

        [Test]
        public void EquivalentExtensions_IsEquivalent_with_default_IEqualityComparer_should_return_true_if_the_two_IEnumerable_contains_the_same_elements()
        {
            var vertices1 = new string[] { "Hello", ", World!" };
            var vertices2 = new string[] { ", World!", "Hello" };

            Check.That(vertices1.IsEquivalent(vertices2)).IsTrue();
        }

        [Test]
        public void EquivalentExtensions_IsEquivalent_with_default_IEqualityComparer_should_return_true_if_the_two_IEnumerable_are_the_same_references()
        {
            var vertices1 = new string[] { "Hello", ", World!" };

            Check.That(vertices1.IsEquivalent(vertices1)).IsTrue();
        }

        [Test]
        public void EquivalentExtensions_IsEquivalent_with_default_IEqualityComparer_should_return_true_if_the_two_IEnumerable_are_sequence_equal()
        {
            var vertices1 = new string[] { "Hello", ", World!" };
            var vertices2 = new string[] { "Hello", ", World!" };

            Check.That(vertices1.IsEquivalent(vertices2)).IsTrue();
        }
    }
}
