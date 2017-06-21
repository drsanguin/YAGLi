using System.Collections.Generic;
using System.Linq;
using YAGLi.Interfaces;

namespace YAGLi.Extensions
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
        public static IEnumerable<Edge<TVertex>> FilterEdgesWhosVerticesAreNotContainedInThisGraph<TVertex>(this IEnumerable<Edge<TVertex>> edges, IModelAGraph<TVertex> graph)
        {
            return edges
                .FilterNulls()
                .Where(edge => graph.ContainsVertices(edge.End1, edge.End2));
        }
    }
}
