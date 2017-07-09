using System.Collections.Generic;
using System.Linq;
using YAGLi.Extensions.Collection;
using YAGLi.Interfaces;

namespace YAGLi.Extensions.EdgeCollection
{
    public static class FilterEdgesNotContainedExtension
    {
        /// <summary>
        /// Filter the edges who's vertices are not contained in the input graph.
        /// </summary>
        /// <typeparam name="TVertex">The type of the vertices of the input edges collection.</typeparam>
        /// <param name="edges">The collection to filter.</param>
        /// <param name="graph">The graph.</param>
        /// <returns>The filtered collection.</returns>
        public static IEnumerable<TEdge> FilterEdgesWhosVerticesAreNotContainedInThisGraph<TVertex, TEdge>(this IEnumerable<TEdge> edges, IModelAGraph<TVertex, TEdge> graph) where TEdge : IModelAnEdge<TVertex>
        {
            return edges
                .FilterNulls()
                .Where(edge => graph.ContainsVertices(edge.End1, edge.End2));
        }
    }
}
