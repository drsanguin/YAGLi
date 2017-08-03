using System.Collections.Generic;
using System.Linq;
using YAGLi.Interfaces;

namespace YAGLi
{
    public abstract class AbstractGraph<TVertex, TEdge, TGraph> : IModelAGraph<TVertex, TEdge> where TEdge : IModelAnEdge<TVertex> where TGraph : IModelAGraph<TVertex, TEdge>
    {
        #region Fields 
        /// <summary>
        /// Readonly field who store the object who hold the comparison logic for the vertices.
        /// </summary>
        protected readonly IEqualityComparer<TVertex> VerticesComparer;
        #endregion

        #region Constructors
        protected AbstractGraph(bool allowLoops, bool allowParallelEdges, IEqualityComparer<TVertex> verticesComparer)
        {
            AllowLoops = allowLoops;
            AllowParallelEdges = allowParallelEdges;
            VerticesComparer = verticesComparer ?? EqualityComparer<TVertex>.Default;
        }
        #endregion

        #region Properties
        public bool AllowParallelEdges { get; }
        public bool AllowLoops { get; }
        public abstract IEnumerable<TEdge> Edges { get; }
        public abstract IEnumerable<TVertex> Vertices { get; }
        #endregion

        #region Methods
        public bool AreVerticesAdjacent(TVertex vertex1, TVertex vertex2)
        {
            return Edges.Where(edge => (VerticesComparer.Equals(edge.End1, vertex1) && VerticesComparer.Equals(edge.End2, vertex2)) || (VerticesComparer.Equals(edge.End1, vertex2) && VerticesComparer.Equals(edge.End2, vertex1)))
                        .Any();
        }
        #endregion

        #region Abstract methods
        public abstract TGraph AddEdge(TEdge edge);
        public abstract TGraph AddEdgeAndVertices(TEdge edge);
        public abstract TGraph AddEdges(IEnumerable<TEdge> edges);
        public abstract TGraph AddEdges(params TEdge[] edges);
        public abstract TGraph AddVertex(TVertex vertex);
        public abstract TGraph AddEdgesAndVertices(IEnumerable<TEdge> edges);
        public abstract TGraph AddEdgesAndVertices(params TEdge[] edges);
        public abstract TGraph AddVertices(IEnumerable<TVertex> vertices);
        public abstract TGraph AddVertices(params TVertex[] vertices);
        public abstract IEnumerable<TEdge> AdjacentEdgesOf(TEdge edge);
        public abstract IEnumerable<TVertex> AdjacentVerticesOf(TVertex vertex);
        public abstract bool AreEdgesAdjacent(TEdge edge1, TEdge edge2);
        public abstract bool ContainsEdge(TEdge edge);
        public abstract bool ContainsEdges(IEnumerable<TEdge> edges);
        public abstract bool ContainsEdges(params TEdge[] edges);
        public abstract bool ContainsVertex(TVertex vertex);
        public abstract bool ContainsVertices(IEnumerable<TVertex> vertices);
        public abstract bool ContainsVertices(params TVertex[] vertices);
        public abstract int DegreeOf(TVertex vertex);
        public abstract bool Equals(IModelAGraph<TVertex, TEdge> other);
        public abstract IEnumerable<TEdge> IncidentEdgesOf(TVertex vertex);
        public abstract IEnumerable<TVertex> IncidentVerticesOf(TEdge edge);
        public abstract IEnumerable<TVertex> NeighborsOf(TVertex vertex);
        public abstract TGraph RemoveEdge(TEdge edge);
        public abstract TGraph RemoveEdgeAndVertices(TEdge edge);
        public abstract TGraph RemoveEdges(IEnumerable<TEdge> edges);
        public abstract TGraph RemoveEdges(params TEdge[] edges);
        public abstract TGraph RemoveEdgesAndVertices(IEnumerable<TEdge> edges);
        public abstract TGraph RemoveEdgesAndVertices(params TEdge[] edges);
        public abstract TGraph RemoveVertex(TVertex vertex);
        public abstract TGraph RemoveVertices(IEnumerable<TVertex> vertices);
        public abstract TGraph RemoveVertices(params TVertex[] vertices);
        public abstract IEnumerable<TEdge> PathsToNeighborsOf(TVertex vertex);
        #endregion

        #region Protected methods
        protected bool AreEdgesAdjacentImpl(TEdge edge1, TEdge edge2)
        {
            return VerticesComparer.Equals(edge1.End1, edge2.End1)
                || VerticesComparer.Equals(edge1.End1, edge2.End2)
                || VerticesComparer.Equals(edge1.End2, edge2.End1)
                || VerticesComparer.Equals(edge1.End2, edge2.End2);
        } 
        #endregion
    }
}
