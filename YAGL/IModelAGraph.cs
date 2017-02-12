using System;
using System.Collections.Generic;

namespace YAGL
{
    public interface IModelAGraph<TVertex> where TVertex : IEquatable<TVertex>
    {
        #region Properties
        bool AllowParallelEdges { get; }
        bool AllowLoops { get; }
        IEnumerable<Edge<TVertex>> Edges { get; }
        IEnumerable<TVertex> Vertices { get; }
        #endregion

        #region Methods
        IEnumerable<Edge<TVertex>> AdjacentEdgesOfEdge(Edge<TVertex> edge);
        IEnumerable<TVertex> AdjacentVerticesOfVertex(TVertex vertex);
        bool AreEdgesAdjacent(params Edge<TVertex>[] edges);
        bool AreVerticesAdjacent(params TVertex[] vertices);
        bool ContainsEdge(Edge<TVertex> edge);
        bool ContainsEdges(params Edge<TVertex>[] edges);
        bool ContainsVertex(TVertex vertex);
        bool ContainsVertices(params TVertex[] vertex);
        int DegreeOf(TVertex vertex);
        IEnumerable<Edge<TVertex>> IncidentEdgesOfVertex(TVertex vertex);
        IEnumerable<TVertex> IncidentVerticesOfEdge(Edge<TVertex> edge);
        int InDegreeOf(TVertex vertex);
        int OutDegreeOf(TVertex vertex); 
        #endregion
    }
}
