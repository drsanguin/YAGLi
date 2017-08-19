using System.Collections.Generic;
using YAGLi.Extensions.Collection;
using YAGLi.Interfaces;

namespace YAGLi.Extensions.Ends
{
    public static class EndsExtension
    {
        public static IEnumerable<TVertex> Ends<TVertex>(this IModelAnEdge<TVertex> edge)
        {
            return edge.ends()
                       .FilterNulls();
        }

        private static IEnumerable<TVertex> ends<TVertex>(this IModelAnEdge<TVertex> edge)
        {
            if (ReferenceEquals(edge, null))
            {
                yield break;
            }

            yield return edge.End1;

            yield return edge.End2;
        }
    }
}
