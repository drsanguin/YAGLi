using System.Collections.Generic;
using System.Linq;
using YAGLi.Extensions.Collection;
using YAGLi.Interfaces;

namespace YAGLi.Extensions.EdgeCollection
{
    public static class MapEdgesWithTheEdgesOfAGraphExtension
    {
        public static IEnumerable<TEdge> MapEdgesWithTheEdgesOfAGraph<TVertex, TEdge>(this IEnumerable<TEdge> edges, IModelAGraph<TVertex, TEdge> graph, params IEqualityComparer<TEdge>[] edgeComparers) where TEdge : IModelAnEdge<TVertex>
        {
            var inputEdges = edges.ToList();
            var referenceEdges = graph.Edges.ToList();
            var mapedEdges = new List<TEdge>();

            edgeComparers.ForEach(comparer =>
            {
                Enumerable.Range(0, inputEdges.Count)
                          .Reverse()
                          .ForEach(i =>
                          {
                              if (!referenceEdges.Contains(inputEdges[i], comparer))
                              {
                                  return;
                              }

                              var firstReferenceToMatch = referenceEdges.First(edge => comparer.Equals(inputEdges[i], edge));

                              mapedEdges.Add(firstReferenceToMatch);
                              referenceEdges.Remove(firstReferenceToMatch);
                              inputEdges.RemoveAt(i);
                          });
            });

            return mapedEdges;
        }
    }
}
