using System.Collections.Generic;
using System.Linq;
using YAGLi.Interfaces;

namespace YAGLi.Extensions
{
    public static class FilterEdgesWithNullVerticesExtension
    {
        public static IEnumerable<TEdge> FilterEdgesWithNullVertices<TVertex, TEdge>(this IEnumerable<TEdge> edges) where TEdge : IModelAnEdge<TVertex>
        {
            return edges
                .ReplaceByEmptyIfNull()
                .FilterNulls()
                .Where(edge => !ReferenceEquals(edge.End1, null) && !ReferenceEquals(edge.End2, null));
        }
    }
}
