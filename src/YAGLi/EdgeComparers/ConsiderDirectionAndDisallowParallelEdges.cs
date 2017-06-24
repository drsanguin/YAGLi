using System;
using System.Collections.Generic;
using YAGLi.Interfaces;

namespace YAGLi.EdgeComparers
{
    public class ConsiderDirectionAndDisallowParallelEdges<TVertex, TEdge> : IEqualityComparer<TEdge> where TEdge : IModelAnEdge<TVertex>
    {
        private readonly IEqualityComparer<TVertex> _vertexComparer;
        private readonly ConsiderDirectionAndAllowParallelEdges<TVertex, TEdge> _innerComparer;

        public ConsiderDirectionAndDisallowParallelEdges() : this(EqualityComparer<TVertex>.Default) { }

        public ConsiderDirectionAndDisallowParallelEdges(IEqualityComparer<TVertex> vertexComparer)
        {
            if (vertexComparer == null)
            {
                throw new ArgumentNullException(nameof(vertexComparer));
            }

            _vertexComparer = vertexComparer;
            _innerComparer = new ConsiderDirectionAndAllowParallelEdges<TVertex, TEdge>(vertexComparer);
        }

        public bool Equals(TEdge edge1, TEdge edge2)
        {
            return _innerComparer.Equals(edge1, edge2)
                || (_vertexComparer.Equals(edge1.End1, edge2.End1)
                && _vertexComparer.Equals(edge1.End2, edge2.End2));
        }

        public int GetHashCode(TEdge edge)
        {
            return _innerComparer.GetHashCode(edge);
        }
    }
}
