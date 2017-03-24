using System;
using System.Collections.Generic;

namespace YAGLi.EdgeComparers
{
    public class ConsiderDirectionAndDisallowParallelEdges<TVertex> : IEqualityComparer<Edge<TVertex>>
    {
        private readonly IEqualityComparer<TVertex> _vertexComparer;
        private readonly ConsiderDirectionAndAllowParallelEdges<TVertex> _innerComparer;

        public ConsiderDirectionAndDisallowParallelEdges() : this(EqualityComparer<TVertex>.Default) { }

        public ConsiderDirectionAndDisallowParallelEdges(IEqualityComparer<TVertex> vertexComparer)
        {
            if (vertexComparer == null)
            {
                throw new ArgumentNullException(nameof(vertexComparer));
            }

            _vertexComparer = vertexComparer;
            _innerComparer = new ConsiderDirectionAndAllowParallelEdges<TVertex>(vertexComparer);
        }

        public bool Equals(Edge<TVertex> edge1, Edge<TVertex> edge2)
        {
            return _innerComparer.Equals(edge1, edge2)
                || (_vertexComparer.Equals(edge1.End1, edge2.End1)
                && _vertexComparer.Equals(edge1.End2, edge2.End2));
        }

        public int GetHashCode(Edge<TVertex> edge)
        {
            return _innerComparer.GetHashCode(edge);
        }
    }
}
