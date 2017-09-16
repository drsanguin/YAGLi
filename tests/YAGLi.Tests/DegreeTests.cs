using NFluent;
using NUnit.Framework;
using YAGLi.Tests.Utils.Extensions.Assertions;

namespace YAGLi.Tests
{
    [TestFixture(TestOf = typeof(Degree))]
    public class DegreeTests
    {
        [Test]
        public void Equals_Degree_override_should_return_false_when_the_values_of_the_degrees_are_not_equal()
        {
            var degree = new Degree(42);
            var other = new Degree(0);

            Check.That(degree.Equals(other)).IsFalse();
        }

        [Test]
        public void Equals_Degree_override_should_return_true_when_the_values_of_the_degrees_are_equal()
        {
            var degree = new Degree(42);
            var other = new Degree(42);

            Check.That(degree.Equals(other)).IsTrue();
        }

        [Test]
        public void Equals_object_override_should_return_false_when_the_object_is_null()
        {
            var degree = new Degree(42);
            object other = null;

            Check.That(degree.Equals(other)).IsFalse();
        }

        [Test]
        public void Equals_object_override_should_return_false_when_the_object_is_not_a_Degree_object()
        {
            var degree = new Degree(42);
            object other = new object();

            Check.That(degree.Equals(other)).IsFalse();
        }

        [Test]
        public void Equals_object_override_should_return_false_when_the_object_is_a_Degree_object_with_a_different_value()
        {
            var degree = new Degree(42);
            var other = new Degree(0);

            Check.That(degree.Equals(other)).IsFalse();
        }

        [Test]
        public void Equals_object_override_should_return_true_when_the_object_is_a_Degree_object_with_the_same_value()
        {
            var degree = new Degree(42);
            object other = new Degree(42);

            Check.That(degree.Equals(other)).IsTrue();
        }

        [Test]
        public void GetHashCode_should_return_the_same_value_for_two_Degree_objects_who_are_equal()
        {
            var degree1 = new Degree(42);
            var degree2 = new Degree(42);

            Check.That(degree1.GetHashCode()).IsEqualTo(degree2.GetHashCode());
        }

        [Test]
        public void GetHashCode_should_not_return_the_same_value_for_two_Degree_objects_who_are_not_equal()
        {
            var degree1 = new Degree(0);
            var degree2 = new Degree(42);

            Check.That(degree1.GetHashCode()).IsNotEqualTo(degree2.GetHashCode());
        }

        [Test]
        public void Impossible_should_return_the_expected_Degree()
        {
            Check.That(Degree.Impossible).IsEqualTo(new Degree(-1));
        }

        [Test]
        public void Zero_should_return_the_expected_Degree()
        {
            Check.That(Degree.Zero).IsEqualTo(new Degree(0));
        }

        [Test]
        public void ToString_should_return_the_expected_value()
        {
            var degree = new Degree(42);

            Check.That(degree.ToString()).IsEqualTo("42");
        }

        [Test]
        public void ToString_of_a_Degree_object_equal_to_Degree_Impossible_should_return_the_expected_value()
        {
            var degree = Degree.Impossible;

            Check.That(degree.ToString()).IsEqualTo(nameof(Degree.Impossible));
        }

        [Test]
        public void CompareTo_Degree_overload_should_return_0_if_the_two_Degree_objects_are_equal()
        {
            var degree1 = new Degree(42);
            var degree2 = new Degree(42);

            Check.That(degree1.CompareTo(degree2)).IsEqualTo(0);
        }

        [Test]
        public void CompareTo_Degree_overload_should_return_1_if_the_other_Degree_object_value_member_is_inferior_to_this_instance()
        {
            var degree1 = new Degree(42);
            var degree2 = new Degree(0);

            Check.That(degree1.CompareTo(degree2)).IsEqualTo(1);
        }

        [Test]
        public void CompareTo_Degree_overload_should_return_minus_1_if_the_other_Degree_object_value_member_is_superior_to_this_instance()
        {
            var degree1 = new Degree(0);
            var degree2 = new Degree(42);

            Check.That(degree1.CompareTo(degree2)).IsEqualTo(-1);
        }

        [Test]
        public void CompareTo_object_overload_should_return_1_if_the_other_object_is_null()
        {
            var degree = new Degree(42);
            object other = null;

            Check.That(degree.CompareTo(other)).IsEqualTo(1);
        }

        [Test]
        public void CompareTo_object_overload_should_return_minus_2_if_the_other_object_is_not_a_Degree_object()
        {
            var degree = new Degree(42);
            object other = new object();

            Check.That(degree.CompareTo(other)).IsEqualTo(-1);
        }

        [Test]
        public void CompareTo_object_overload_should_return_0_if_the_other_object_is_a_Degree_object_equal_to_this_instance()
        {
            var degree1 = new Degree(42);
            object degree2 = new Degree(42);

            Check.That(degree1.CompareTo(degree2)).IsEqualTo(0);
        }

        [Test]
        public void CompareTo_object_overload_should_return_1_if_the_other_object_is_a_Degree_object_with_value_member_inferior_to_this_instance()
        {
            var degree1 = new Degree(42);
            object degree2 = new Degree(0);

            Check.That(degree1.CompareTo(degree2)).IsEqualTo(1);
        }

        [Test]
        public void CompareTo_object_overload_should_return_minus_1_if_the_other_object_is_a_Degree_object_with_value_member_superior_to_this_instance()
        {
            var degree1 = new Degree(0);
            object degree2 = new Degree(42);

            Check.That(degree1.CompareTo(degree2)).IsEqualTo(-1);
        }

        [Test]
        public void Constructor_with_any_int_strictly_inferior_to_0_should_return_a_Degree_object_equal_to_Degree_Impossible()
        {
            Check.That(new Degree(-42)).IsEqualTo(Degree.Impossible);
        }

        [Test]
        public void Operator_plus_with_at_least_one_Degree_object_equal_to_Degree_Impossible_should_return_a_Degree_object_equal_to_Degree_Impossible()
        {
            var degree1 = new Degree(42);
            var degree2 = new Degree(-42);

            Check.That(degree1 + degree2).IsEqualTo(Degree.Impossible);
        }

        [Test]
        public void Operator_plus_with_two_Degree_objects_not_equal_to_Degree_Impossible_should_return_the_expected_result()
        {
            var degree1 = new Degree(21);
            var degree2 = new Degree(21);

            Check.That(degree1 + degree2).IsEqualTo(new Degree(42));
        }

        [Test]
        public void Operator_minus_with_at_least_one_Degree_object_equal_to_Degree_Impossible_should_return_a_Degree_object_equal_to_Degree_Impossible()
        {
            var degree1 = new Degree(42);
            var degree2 = new Degree(-42);

            Check.That(degree1 - degree2).IsEqualTo(Degree.Impossible);
        }

        [Test]
        public void Operator_minus_with_two_Degree_objects_not_equal_to_Degree_Impossible_should_return_the_expected_result()
        {
            var degree1 = new Degree(42);
            var degree2 = new Degree(42);

            Check.That(degree1 - degree2).IsEqualTo(new Degree(0));
        }

        [Test]
        public void Operator_equal_equal_should_return_false_when_the_values_of_the_degrees_are_not_equal()
        {
            var degree1 = new Degree(42);
            var degree2 = new Degree(0);

            Check.That(degree1 == degree2).IsFalse();
        }

        [Test]
        public void Operator_equal_equal_should_return_true_when_the_values_of_the_degrees_are_equal()
        {
            var degree1 = new Degree(42);
            var degree2 = new Degree(42);

            Check.That(degree1 == degree2).IsTrue();
        }

        [Test]
        public void Operator_not_equal_should_return_true_when_the_values_of_the_degrees_are_not_equal()
        {
            var degree1 = new Degree(42);
            var degree2 = new Degree(0);

            Check.That(degree1 != degree2).IsTrue();
        }

        [Test]
        public void Operator_not_equal_should_return_false_when_the_values_of_the_degrees_are_equal()
        {
            var degree1 = new Degree(42);
            var degree2 = new Degree(42);

            Check.That(degree1 != degree2).IsFalse();
        }

        [Test]
        public void Operator_inferior_should_return_true_when_the_first_Degree_object_has_a_value_field_strictly_inferior_to_the_value_field_of_the_second_Degree_object()
        {
            var degree1 = new Degree(0);
            var degree2 = new Degree(42);

            Check.That(degree1 < degree2).IsTrue();
        }

        [Test]
        public void Operator_inferior_should_return_false_when_the_first_Degree_object_has_not_a_value_field_strictly_inferior_to_the_value_field_of_the_second_Degree_object()
        {
            var degree1 = new Degree(42);
            var degree2 = new Degree(0);

            Check.That(degree1 < degree2).IsFalse();
        }

        [Test]
        public void Operator_superior_should_return_true_when_the_first_Degree_object_has_a_value_field_strictly_superior_to_the_value_field_of_the_second_Degree_object()
        {
            var degree1 = new Degree(42);
            var degree2 = new Degree(0);

            Check.That(degree1 > degree2).IsTrue();
        }

        [Test]
        public void Operator_superior_should_return_false_when_the_first_Degree_object_has_not_a_value_field_strictly_superior_to_the_value_field_of_the_second_Degree_object()
        {
            var degree1 = new Degree(0);
            var degree2 = new Degree(42);

            Check.That(degree1 > degree2).IsFalse();
        }

        [Test]
        public void Operator_inferior_or_equal_should_return_true_when_the_first_Degree_object_has_a_value_field_strictly_inferior_to_the_value_field_of_the_second_Degree_object()
        {
            var degree1 = new Degree(0);
            var degree2 = new Degree(42);

            Check.That(degree1 <= degree2).IsTrue();
        }

        [Test]
        public void Operator_inferior_or_equal_should_return_false_when_the_first_Degree_object_has_not_a_value_field_strictly_inferior_to_the_value_field_of_the_second_Degree_object()
        {
            var degree1 = new Degree(42);
            var degree2 = new Degree(0);

            Check.That(degree1 <= degree2).IsFalse();
        }

        [Test]
        public void Operator_inferior_or_equal_should_return_true_when_the_first_Degree_object_has_a_value_field_equal_to_the_value_field_of_the_second_Degree_object()
        {
            var degree1 = new Degree(42);
            var degree2 = new Degree(42);

            Check.That(degree1 <= degree2).IsTrue();
        }

        [Test]
        public void Operator_superior_or_equal_should_return_true_when_the_first_Degree_object_has_a_value_field_strictly_superior_to_the_value_field_of_the_second_Degree_object()
        {
            var degree1 = new Degree(42);
            var degree2 = new Degree(0);

            Check.That(degree1 >= degree2).IsTrue();
        }

        [Test]
        public void Operator_superior_or_equal_should_return_false_when_the_first_Degree_object_has_not_a_value_field_strictly_superior_to_the_value_field_of_the_second_Degree_object()
        {
            var degree1 = new Degree(0);
            var degree2 = new Degree(42);

            Check.That(degree1 >= degree2).IsFalse();
        }

        [Test]
        public void Operator_superior_or_equal_should_return_true_when_the_first_Degree_object_has_a_value_field_equal_to_the_value_field_of_the_second_Degree_object()
        {
            var degree1 = new Degree(42);
            var degree2 = new Degree(42);

            Check.That(degree1 >= degree2).IsTrue();
        }

        [Test]
        public void Implicit_operator_int_to_Degree_should_return_the_expected_Degree_object()
        {
            Degree degree = 42;

            Check.That(degree).IsEqualTo(new Degree(42));
        }

        [Test]
        public void Implicit_operator_Degree_to_int_should_return_the_expected_int()
        {
            int degree = new Degree(42);

            Check.That(degree).IsEqualTo(42);
        }

        [Test]
        public void X()
        {
            Check.That(new Degree(-1)).IsImpossible();
            //Check.That(new Degree(42)).IsImpossible();
        }
    }
}
