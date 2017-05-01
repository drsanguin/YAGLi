using System.Collections.Generic;

namespace YAGLi.Extensions
{
    public static class YieldExtension
    {
        /// <summary>
        /// Wrap this instance <paramref name="item"/> into a <see cref="IEnumerable{T}"/>. 
        /// </summary>
        /// <typeparam name="T">The type of this instance.</typeparam>
        /// <param name="item">The instance to wrap into a <see cref="IEnumerable{T}"/>.</param>
        /// <returns>A <see cref="IEnumerable{T}"/> containing only this instance <paramref name="item"/>.</returns>
        public static IEnumerable<T> Yield<T>(this T item)
        {
            if (ReferenceEquals(item, null))
            {
                yield break;
            }

            yield return item;
        }
    }
}
