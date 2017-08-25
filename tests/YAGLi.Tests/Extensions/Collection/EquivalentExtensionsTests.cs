using NFluent;
using NUnit.Framework;
using System.Collections.Generic;
using YAGLi.Extensions.Collection;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests.Extensions.Collection
{
    [TestFixture(TestOf = typeof(EquivalentExtensions))]
    public class EquivalentExtensionsTests
    {
        [Test]
        public void IsEquivalent_should_return_false_if_the_two_IEnumerable_have_different_sizes()
        {
            var vertices1 = new Vertex[] { "42" };
            var vertices2 = new Vertex[] { "Hello, ", "World!" };

            Check.That(vertices1.IsEquivalent(vertices2, new VertexEqualityComparer())).IsFalse();
        }

        [Test]
        public void IsEquivalent_should_return_false_if_the_two_IEnumerable_does_not_contains_the_same_elements()
        {
            var vertices1 = new Vertex[] { "Hello", ", World!" };
            var vertices2 = new Vertex[] { "Hello, ", "World!" };

            Check.That(vertices1.IsEquivalent(vertices2, new VertexEqualityComparer())).IsFalse();
        }

        [Test]
        public void IsEquivalent_should_return_true_if_the_two_IEnumerable_contains_the_same_elements()
        {
            var vertices1 = new Vertex[] { "Hello", ", World!" };
            var vertices2 = new Vertex[] { ", World!", "Hello" };

            Check.That(vertices1.IsEquivalent(vertices2, new VertexEqualityComparer())).IsTrue();
        }

        [Test]
        public void IsEquivalent_should_return_true_if_the_two_IEnumerable_are_the_same_references()
        {
            var vertices1 = new Vertex[] { "Hello", ", World!" };

            Check.That(vertices1.IsEquivalent(vertices1, new VertexEqualityComparer())).IsTrue();
        }

        [Test]
        public void IsEquivalent_should_return_true_if_the_two_IEnumerable_are_sequence_equal()
        {
            var vertices1 = new Vertex[] { "Hello", ", World!" };
            var vertices2 = new Vertex[] { "Hello", ", World!" };

            Check.That(vertices1.IsEquivalent(vertices2, new VertexEqualityComparer())).IsTrue();
        }

        [Test]
        public void IsEquivalent_should_return_true_if_both_parameters_are_null()
        {
            IEnumerable<Vertex> vertices1 = null;
            IEnumerable<Vertex> vertices2 = null;

            Check.That(vertices1.IsEquivalent(vertices2, new VertexEqualityComparer())).IsTrue();
        }

        [Test]
        public void IsEquivalent_should_return_false_if_parameter_first_is_null_but_paramter_second_is_not()
        {
            IEnumerable<Vertex> vertices1 = null;
            IEnumerable<Vertex> vertices2 = new Vertex[] { "Hello", ", World!" };

            Check.That(vertices1.IsEquivalent(vertices2, new VertexEqualityComparer())).IsFalse();
        }

        [Test]
        public void IsEquivalent_should_return_false_if_parameter_second_is_null_but_paramter_first_is_not()
        {
            IEnumerable<Vertex> vertices1 = new Vertex[] { "Hello", ", World!" };
            IEnumerable<Vertex> vertices2 = null;

            Check.That(vertices1.IsEquivalent(vertices2, new VertexEqualityComparer())).IsFalse();
        }

        [Test]
        public void IsEquivalent_with_default_IEqualityComparer_should_return_false_if_the_two_IEnumerable_have_different_sizes()
        {
            var vertices1 = new string[] { "42" };
            var vertices2 = new string[] { "Hello, ", "World!" };

            Check.That(vertices1.IsEquivalent(vertices2)).IsFalse();
        }

        [Test]
        public void IsEquivalent_with_default_IEqualityComparer_should_return_false_if_the_two_IEnumerable_does_not_contains_the_same_elements()
        {
            var vertices1 = new string[] { "Hello", ", World!" };
            var vertices2 = new string[] { "Hello, ", "World!" };

            Check.That(vertices1.IsEquivalent(vertices2)).IsFalse();
        }

        [Test]
        public void IsEquivalent_with_default_IEqualityComparer_should_return_true_if_the_two_IEnumerable_contains_the_same_elements()
        {
            var vertices1 = new string[] { "Hello", ", World!" };
            var vertices2 = new string[] { ", World!", "Hello" };

            Check.That(vertices1.IsEquivalent(vertices2)).IsTrue();
        }

        [Test]
        public void IsEquivalent_with_default_IEqualityComparer_should_return_true_if_the_two_IEnumerable_are_the_same_references()
        {
            var vertices1 = new string[] { "Hello", ", World!" };

            Check.That(vertices1.IsEquivalent(vertices1)).IsTrue();
        }

        [Test]
        public void IsEquivalent_with_default_IEqualityComparer_should_return_true_if_the_two_IEnumerable_are_sequence_equal()
        {
            var vertices1 = new string[] { "Hello", ", World!" };
            var vertices2 = new string[] { "Hello", ", World!" };

            Check.That(vertices1.IsEquivalent(vertices2)).IsTrue();
        }

        [Test]
        public void IsEquivalent_with_default_IEqualityComparer_should_return_true_if_both_parameters_are_null()
        {
            IEnumerable<string> vertices1 = null;
            IEnumerable<string> vertices2 = null;

            Check.That(vertices1.IsEquivalent(vertices2)).IsTrue();
        }

        [Test]
        public void IsEquivalent_with_default_IEqualityComparer_should_return_false_if_parameter_first_is_null_but_paramter_second_is_not()
        {
            IEnumerable<string> vertices1 = null;
            IEnumerable<string> vertices2 = new string[] { "Hello", ", World!" };

            Check.That(vertices1.IsEquivalent(vertices2)).IsFalse();
        }

        [Test]
        public void IsEquivalent_with_default_IEqualityComparer_should_return_false_if_parameter_second_is_null_but_paramter_first_is_not()
        {
            IEnumerable<string> vertices1 = new string[] { "Hello", ", World!" };
            IEnumerable<string> vertices2 = null;

            Check.That(vertices1.IsEquivalent(vertices2)).IsFalse();
        }
    }
}
