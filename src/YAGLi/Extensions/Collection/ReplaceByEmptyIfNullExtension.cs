using System.Collections.Generic;
using System.Linq;

namespace YAGLi.Extensions.Collection
{
    public static class ReplaceByEmptyIfNullExtension
    {
        /// <summary>
        /// Replace <paramref name="source"/> by <see cref="Enumerable.Empty{TSource}"/> if <see cref="object.ReferenceEquals(source, null)"/> return <see cref="true"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the input collection.</typeparam>
        /// <param name="source">The collection for wich to check if it is <see cref="null"/>.</param>
        /// <returns><see cref="Enumerable.Empty{TSource}"/> if <see cref="object.ReferenceEquals(source, null)"/> return <see cref="true"/>, <paramref name="source"/> otherwise.</returns>
        public static IEnumerable<TSource> ReplaceByEmptyIfNull<TSource>(this IEnumerable<TSource> source)
        {
            return source ?? Enumerable.Empty<TSource>();
        }
    }
}
