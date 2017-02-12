using NFluent;
using NUnit.Framework;
using System;

namespace YAGL.Tests
{
    [TestFixture]
    public class EdgeTests
    {
        [Test]
        public void Edge_constructor_should_throw_a_ArgumentNullException_if_end1_is_equal_to_null()
        {
            Check.ThatCode(() => new Edge<string>(null, new Vertex<string>("42"))).Throws<ArgumentNullException>();
        }

        [Test]
        public void Edge_constructor_should_throw_a_ArgumentNullException_if_end2_is_equal_to_null()
        {
            Check.ThatCode(() => new Edge<string>(new Vertex<string>("42"), null)).Throws<ArgumentNullException>();
        }

        [Test]
        public void Edge_Ends_should_contains_the_two_Vertices_passed_in_the_constructor()
        {
            Vertex<string> end1 = new Vertex<string>("Hello");
            Vertex<string> end2 = new Vertex<string>("Wordl!");

            Edge<string> edge = new Edge<string>(end1, end2);

            Check.That(edge.Ends).ContainsExactly(end1, end2);
        }

        [Test]
        public void Edge_Equals_with_null_and_EdgeComparison_should_return_false()
        {
            Check.That(new Edge<string>(new Vertex<string>("Hello"), new Vertex<string>("World!")).Equals(null, EdgeComparison.ConsiderDirection)).IsFalse();
        }

        [Test]
        public void Edge_Equals_with_EdgeComparison_should_throw_a_ArgumentException_if_the_EdgeComparison_value_is_not_one_of_the_valid_values()
        {
            Vertex<string> end1 = new Vertex<string>("Hello");
            Vertex<string> end2 = new Vertex<string>("Wordl!");

            Edge<string> edge1 = new Edge<string>(end1, end2);
            Edge<string> edge2 = new Edge<string>(end2, end1);

            Check.ThatCode(() => edge1.Equals(edge2, EdgeComparison.IgnoreDirection + 1)).Throws<ArgumentException>();
        }

        [Test]
        public void Edge_Equals_with_EdgeComparison_IgnoreDirection_should_return_true_if_the_other_Edge_Ends_contains_the_same_Vertices_even_if_their_are_not_in_the_same_fields_variables()
        {
            Vertex<string> end1 = new Vertex<string>("Hello");
            Vertex<string> end2 = new Vertex<string>("Wordl!");

            Edge<string> edge1 = new Edge<string>(end1, end2);
            Edge<string> edge2 = new Edge<string>(end2, end1);

            Check.That(edge1.Equals(edge2, EdgeComparison.IgnoreDirection)).IsTrue();
        }

        [Test]
        public void Edge_Equals_with_EdgeComparison_IgnoreDirection_should_return_true_if_the_other_Edge_Ends_contains_the_same_Vertices_even_in_the_same_fields_variables()
        {
            Vertex<string> end1 = new Vertex<string>("Hello");
            Vertex<string> end2 = new Vertex<string>("Wordl!");

            Edge<string> edge1 = new Edge<string>(end1, end2);
            Edge<string> edge2 = new Edge<string>(end1, end2);

            Check.That(edge1.Equals(edge2, EdgeComparison.IgnoreDirection)).IsTrue();
        }

        [Test]
        public void Edge_Equals_with_EdgeComparison_ConsiderDirection_should_return_false_if_the_other_Edge_Ends_does_not_contains_the_same_Vertices_even_in_the_same_fields_variables()
        {
            Vertex<string> end1 = new Vertex<string>("Hello");
            Vertex<string> end2 = new Vertex<string>("Wordl!");

            Edge<string> edge1 = new Edge<string>(end1, end2);
            Edge<string> edge2 = new Edge<string>(end2, end1);

            Check.That(edge1.Equals(edge2, EdgeComparison.ConsiderDirection)).IsFalse();
        }

        [Test]
        public void Edge_Equals_with_EdgeComparison_Considerirection_should_return_true_if_the_other_Edge_Ends_contains_the_same_Vertices_even_in_the_same_fields_variables()
        {
            Vertex<string> end1 = new Vertex<string>("Hello");
            Vertex<string> end2 = new Vertex<string>("Wordl!");

            Edge<string> edge1 = new Edge<string>(end1, end2);
            Edge<string> edge2 = new Edge<string>(end1, end2);

            Check.That(edge1.Equals(edge2, EdgeComparison.ConsiderDirection)).IsTrue();
        }

        [Test]
        public void Edge_Equals_should_return_true_if_the_other_Edge_Ends_contains_the_same_Vertices_in_the_same_fields_variables()
        {
            Vertex<string> end1 = new Vertex<string>("Hello");
            Vertex<string> end2 = new Vertex<string>("Wordl!");

            Edge<string> edge1 = new Edge<string>(end1, end2);
            Edge<string> edge2 = new Edge<string>(end1, end2);

            Check.That(edge1.Equals(edge2)).IsTrue();
        }

        [Test]
        public void Edge_Equals_should_return_false_if_the_other_Edge_Ends_does_not_contains_the_same_Vertices_in_the_same_fields_variables()
        {
            Vertex<string> end1 = new Vertex<string>("Hello");
            Vertex<string> end2 = new Vertex<string>("Wordl!");

            Edge<string> edge1 = new Edge<string>(end1, end2);
            Edge<string> edge2 = new Edge<string>(end2, end1);

            Check.That(edge1.Equals(edge2)).IsFalse();
        }

        [Test]
        public void Edge_GetHashCode_should_return_the_same_value_for_two_Edge_with_the_same_Vertices()
        {
            Vertex<string> end1 = new Vertex<string>("Hello");
            Vertex<string> end2 = new Vertex<string>("Wordl!");

            Edge<string> edge1 = new Edge<string>(end1, end2);
            Edge<string> edge2 = new Edge<string>(end1, end2);

            Check.That(edge1.GetHashCode()).IsEqualTo(edge2.GetHashCode());
        }

        [Test]
        public void Edge_GetHashCode_should_not_return_the_same_value_for_two_Edge_with_different_Vertices()
        {
            Vertex<string> end1 = new Vertex<string>("Hello");
            Vertex<string> end2 = new Vertex<string>("Wordl!");
            Vertex<string> end3 = new Vertex<string>("Wordl !");

            Edge<string> edge1 = new Edge<string>(end1, end2);
            Edge<string> edge2 = new Edge<string>(end1, end3);

            Check.That(edge1.GetHashCode()).IsNotEqualTo(edge2.GetHashCode());
        }
    }
}
