using System;
using System.Collections.Generic;
using YAGLi.Interfaces;

namespace YAGLi.EdgeComparers
{
    public class IgnoreDirectionAndDisallowParallelEdges<TVertex, TEdge> : IEqualityComparer<TEdge> where TEdge : IModelAnEdge<TVertex>
    {
        private readonly IEqualityComparer<TVertex> _vertexComparer;
        private readonly IgnoreDirectionAndAllowParallelEdges<TVertex, TEdge> _innerComparer;

        public IgnoreDirectionAndDisallowParallelEdges() : this(EqualityComparer<TVertex>.Default) { }

        public IgnoreDirectionAndDisallowParallelEdges(IEqualityComparer<TVertex> vertexComparer)
        {
            if (vertexComparer == null)
            {
                throw new ArgumentNullException(nameof(vertexComparer));
            }

            _vertexComparer = vertexComparer;
            _innerComparer = new IgnoreDirectionAndAllowParallelEdges<TVertex, TEdge>(vertexComparer);
        }

        public bool Equals(TEdge edge1, TEdge edge2)
        {
            return _innerComparer.Equals(edge1, edge2)
                || (_vertexComparer.Equals(edge1.End1, edge2.End1)
                && _vertexComparer.Equals(edge1.End2, edge2.End2))
                || (_vertexComparer.Equals(edge1.End1, edge2.End2)
                && _vertexComparer.Equals(edge1.End2, edge2.End1));
        }

        public int GetHashCode(TEdge edge)
        {
            return _innerComparer.GetHashCode(edge);
        }
    }
}
