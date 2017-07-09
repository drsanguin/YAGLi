using System.Collections.Generic;
using System.Linq;

namespace YAGLi.Extensions.Collection
{
    public static class FilterNullsExtension
    {
        /// <summary>
        /// Filter the elements contained in this instance for wich <see cref="object.ReferenceEquals(object, null)"/> return <see cref="true"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the input collection.</typeparam>
        /// <param name="source">A <see cref="IEnumerable{T}"/> for wich to filter null elements.</param>
        /// <returns>A <see cref="IEnumerable{T}"/> who contained all the elements from <paramref name="source"/> in the same order but without the elements for wich <see cref="object.ReferenceEquals(object, null)"/> returns <see cref="true"/>.</returns>
        public static IEnumerable<TSource> FilterNulls<TSource>(this IEnumerable<TSource> source)
        {
            return source
                .ReplaceByEmptyIfNull()
                .Where(element => !ReferenceEquals(element, null));
        }
    }
}
