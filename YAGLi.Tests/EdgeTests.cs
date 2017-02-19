using NFluent;
using NUnit.Framework;
using System;

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
        public void Edge_Ends_should_contains_the_two_Vertices_passed_in_the_constructor()
        {
            Edge<string> edge = new Edge<string>("Hello", "World!");

            Check.That(edge.Ends).ContainsExactly("Hello", "World!");
        }

        [Test]
        public void Edge_Equals_with_null_and_EdgeComparison_should_return_false()
        {
            Check.That(new Edge<string>("Hello", "World!").Equals(null, EdgeComparison.ConsiderDirection)).IsFalse();
        }

        [Test]
        public void Edge_Equals_with_EdgeComparison_should_throw_a_ArgumentException_if_the_EdgeComparison_value_is_not_one_of_the_valid_values()
        {
            Edge<string> edge1 = new Edge<string>("Hello", "World!");
            Edge<string> edge2 = new Edge<string>("World!", "Hello");

            Check.ThatCode(() => edge1.Equals(edge2, EdgeComparison.IgnoreDirection + 1)).Throws<ArgumentException>();
        }

        [Test]
        public void Edge_Equals_with_EdgeComparison_IgnoreDirection_should_return_true_if_the_other_Edge_Ends_contains_the_same_Vertices_even_if_their_are_not_in_the_same_fields_variables()
        {
            Edge<string> edge1 = new Edge<string>("Hello", "World!");
            Edge<string> edge2 = new Edge<string>("World!", "Hello");

            Check.That(edge1.Equals(edge2, EdgeComparison.IgnoreDirection)).IsTrue();
        }

        [Test]
        public void Edge_Equals_with_EdgeComparison_IgnoreDirection_should_return_true_if_the_other_Edge_Ends_contains_the_same_Vertices_even_in_the_same_fields_variables()
        {
            Edge<string> edge1 = new Edge<string>("Hello", "World!");
            Edge<string> edge2 = new Edge<string>("Hello", "World!");

            Check.That(edge1.Equals(edge2, EdgeComparison.IgnoreDirection)).IsTrue();
        }

        [Test]
        public void Edge_Equals_with_EdgeComparison_ConsiderDirection_should_return_false_if_the_other_Edge_Ends_does_not_contains_the_same_Vertices_even_in_the_same_fields_variables()
        {
            Edge<string> edge1 = new Edge<string>("Hello", "World!");
            Edge<string> edge2 = new Edge<string>("World!", "Hello");

            Check.That(edge1.Equals(edge2, EdgeComparison.ConsiderDirection)).IsFalse();
        }

        [Test]
        public void Edge_Equals_with_EdgeComparison_Considerirection_should_return_true_if_the_other_Edge_Ends_contains_the_same_Vertices_even_in_the_same_fields_variables()
        {
            Edge<string> edge1 = new Edge<string>("Hello", "World!");
            Edge<string> edge2 = new Edge<string>("Hello", "World!");

            Check.That(edge1.Equals(edge2, EdgeComparison.ConsiderDirection)).IsTrue();
        }

        [Test]
        public void Edge_Equals_should_return_true_if_the_other_Edge_Ends_contains_the_same_Vertices_in_the_same_fields_variables()
        {
            Edge<string> edge1 = new Edge<string>("Hello", "World!");
            Edge<string> edge2 = new Edge<string>("Hello", "World!");

            Check.That(edge1.Equals(edge2)).IsTrue();
        }

        [Test]
        public void Edge_Equals_should_return_false_if_the_other_Edge_Ends_does_not_contains_the_same_Vertices_in_the_same_fields_variables()
        {
            Edge<string> edge1 = new Edge<string>("Hello", "World!");
            Edge<string> edge2 = new Edge<string>("World!", "Hello");

            Check.That(edge1.Equals(edge2)).IsFalse();
        }

        [Test]
        public void Edge_GetHashCode_should_return_the_same_value_for_two_Edge_with_the_same_Vertices()
        {
            Edge<string> edge1 = new Edge<string>("Hello", "World!");
            Edge<string> edge2 = new Edge<string>("Hello", "World!");

            Check.That(edge1.GetHashCode()).IsEqualTo(edge2.GetHashCode());
        }

        [Test]
        public void Edge_GetHashCode_should_not_return_the_same_value_for_two_Edge_with_different_Vertices()
        {
            Edge<string> edge1 = new Edge<string>("Hello", "World!");
            Edge<string> edge2 = new Edge<string>("Hello", "World !");

            Check.That(edge1.GetHashCode()).IsNotEqualTo(edge2.GetHashCode());
        }

        [Test]
        public void Edge_ToString_should_return_the_expected_value()
        {
            Edge<string> edge = new Edge<string>("Hello", "World!");

            Check.That(edge.ToString()).IsEqualTo("{ Hello, World! }");
        }

        [Test]
        public void Edge_IsAdjacentTo_should_return_false_if_the_two_edges_do_not_share_a_common_end_vertex()
        {
            Edge<string> edge1 = new Edge<string>("Hello", "World!");
            Edge<string> edge2 = new Edge<string>("Hello, ", "World !");

            Check.That(edge1.IsAdjacentTo(edge2)).IsFalse();
        }

        [Test]
        public void Edge_IsAdjacentTo_should_return_true_if_the_two_edges_do_not_share_a_common_end_vertex()
        {
            Edge<string> edge1 = new Edge<string>("Hello", "World!");
            Edge<string> edge2 = new Edge<string>("Hello", "World !");

            Check.That(edge1.IsAdjacentTo(edge2)).IsTrue();
        }

        [Test]
        public void Edge_AreAdjacent_should_return_false_if_all_the_edges_do_not_share_a_common_vertex()
        {
            Edge<string> edge1 = new Edge<string>("Hello", "World!");
            Edge<string> edge2 = new Edge<string>("Hello, ", "World !");
            Edge<string> edge3 = new Edge<string>("Hello, ", "World!");

            Check.That(Edge<string>.AreAdjacent(edge1, edge2, edge3)).IsFalse();
        }

        [Test]
        public void Edge_AreAdjacent_should_return_true_if_all_the_edges_share_a_common_vertex()
        {
            Edge<string> edge1 = new Edge<string>("Hello, ", "World!");
            Edge<string> edge2 = new Edge<string>("Hello, ", "World !");
            Edge<string> edge3 = new Edge<string>("Hello, ", "World");

            Check.That(Edge<string>.AreAdjacent(edge1, edge2, edge3)).IsTrue();
        }
    }
}
