using System;
using System.Collections.Generic;

namespace YAGLi.EdgeComparers
{
    public class ConsiderDirectionAndAllowParallelEdges<TVertex> : IEqualityComparer<Edge<TVertex>>
    {
        private readonly IEqualityComparer<TVertex> _vertexComparer;

        public ConsiderDirectionAndAllowParallelEdges() : this(EqualityComparer<TVertex>.Default) { }

        public ConsiderDirectionAndAllowParallelEdges(IEqualityComparer<TVertex> vertexComparer)
        {
            if (vertexComparer == null)
            {
                throw new ArgumentNullException(nameof(vertexComparer));
            }

            _vertexComparer = vertexComparer;
        }

        public bool Equals(Edge<TVertex> edge1, Edge<TVertex> edge2)
        {
            return ReferenceEquals(edge1, edge2);
        }

        public int GetHashCode(Edge<TVertex> edge)
        {
            int hash = 17;

            hash = 23 * hash + _vertexComparer.GetHashCode(edge.End1);
            hash = 23 * hash + _vertexComparer.GetHashCode(edge.End2);

            return hash;
        }
    }
}
