using System.Collections.Generic;
using System.Linq;

namespace YAGLi.Extensions
{
    /// <summary>
    /// Extensions methods for checking if IEnumerable objects are equivalent.
    /// </summary>
    public static class EquivalentExtensions
    {
        /// <summary>
        /// Check if <paramref name="first"/> and <paramref name="second"/> contains the same elements in any order.
        /// The elements equality will be computed using the default <see cref="IEqualityComparer{T}"/> for the type <typeparamref name="TSource"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the input collections.</typeparam>
        /// <param name="first">A <see cref="IEnumerable{T}"/> to check if it is equivalent to <paramref name="second"/>.</param>
        /// <param name="second">A <see cref="IEnumerable{T}"/> to check if it is equivalent to <paramref name="first"/>.</param>
        /// <returns><see cref="true"/> if <paramref name="first"/> and <paramref name="second"/> are of equal length and contains the same elements in any order.</returns>
        public static bool IsEquivalent<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return IsEquivalent(first, second, EqualityComparer<TSource>.Default);
        }

        /// <summary>
        /// Check if <paramref name="first"/> and <paramref name="second"/> contains the same elements in any order.
        /// The elements equality will be computed using the specified <see cref="IEqualityComparer{T}"/> <paramref name="comparer"/>.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="first">A <see cref="IEnumerable{T}"/> to check if it is equivalent to <paramref name="second"/>.</param>
        /// <param name="second">A <see cref="IEnumerable{T}"/> to check if it is equivalent to <paramref name="first"/>.</param>
        /// <param name="comparer">A <see cref="IEqualityComparer{T}"/> object to use to compare elements.</param>
        /// <returns><see cref="true"/> if <paramref name="first"/> and <paramref name="second"/> are of equal length and contains the same elements in any order.</returns>
        public static bool IsEquivalent<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            if (ReferenceEquals(first, second)
                || first.SequenceEqual(second, comparer))
            {
                return true;
            }

            if (first.Count() != second.Count())
            {
                return false;
            }

            return first.All(element =>
            first.Count(x => comparer.Equals(x, element))
            == second.Count(x => comparer.Equals(x, element)));
        }
    }
}
