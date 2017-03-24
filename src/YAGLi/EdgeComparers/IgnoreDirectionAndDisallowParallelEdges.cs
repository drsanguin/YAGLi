using System;
using System.Collections.Generic;

namespace YAGLi.EdgeComparers
{
    public class IgnoreDirectionAndDisallowParallelEdges<TVertex> : IEqualityComparer<Edge<TVertex>>
    {
        private readonly IEqualityComparer<TVertex> _vertexComparer;
        private readonly IgnoreDirectionAndAllowParallelEdges<TVertex> _innerComparer;

        public IgnoreDirectionAndDisallowParallelEdges() : this(EqualityComparer<TVertex>.Default) { }

        public IgnoreDirectionAndDisallowParallelEdges(IEqualityComparer<TVertex> vertexComparer)
        {
            if (vertexComparer == null)
            {
                throw new ArgumentNullException(nameof(vertexComparer));
            }

            _vertexComparer = vertexComparer;
            _innerComparer = new IgnoreDirectionAndAllowParallelEdges<TVertex>(vertexComparer);
        }

        public bool Equals(Edge<TVertex> edge1, Edge<TVertex> edge2)
        {
            return _innerComparer.Equals(edge1, edge2)
                || (_vertexComparer.Equals(edge1.End1, edge2.End1)
                && _vertexComparer.Equals(edge1.End2, edge2.End2))
                || (_vertexComparer.Equals(edge1.End1, edge2.End2)
                && _vertexComparer.Equals(edge1.End2, edge2.End1));
        }

        public int GetHashCode(Edge<TVertex> edge)
        {
            return _innerComparer.GetHashCode(edge);
        }
    }
}
