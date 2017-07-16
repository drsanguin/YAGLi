using System.Collections.Generic;
using System.Linq;
using YAGLi.Extensions.Collection;
using YAGLi.Interfaces;

namespace YAGLi.Extensions.EdgeCollection
{
    public static class FilterEdgesWhoViolatesAGraphPropertiesExtension
    {
        /// <summary>
        /// Filter a collection of edges so that only remains edges who doesn't violate the input graph properties.
        /// </summary>
        /// <typeparam name="TVertex">The type of the vertices.</typeparam>
        /// <param name="edges">The input edges collection.</param>
        /// <param name="graph">The input graph.</param>
        /// <param name="verticesComparer">The <see cref="IEqualityComparer{T}"/> implementation to use to compare vertices, or <see cref="null"/> to use the default <see cref="EqualityComparer{T}"/> for the type of the vertices.</param>
        /// <returns></returns>
        public static IEnumerable<TEdge> FilterEdgesWhoViolatesThisInstanceProperties<TVertex, TEdge>(this IEnumerable<TEdge> edges, IModelAGraph<TVertex, TEdge> graph, IEqualityComparer<TVertex> verticesComparer) where TEdge : IModelAnEdge<TVertex>
        {
            return edges.ReplaceByEmptyIfNull()
                        .Where(edge => graph.AllowLoops ? true : !(verticesComparer ?? EqualityComparer<TVertex>.Default).Equals(edge.End1, edge.End2))
                        .Where(edge => graph.AllowParallelEdges ? true : !graph.ContainsEdge(edge));
        }
    }
}
