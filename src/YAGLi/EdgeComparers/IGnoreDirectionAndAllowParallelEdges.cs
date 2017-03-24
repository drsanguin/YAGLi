using System;
using System.Collections.Generic;
using System.Linq;

namespace YAGLi.EdgeComparers
{
    public class IgnoreDirectionAndAllowParallelEdges<TVertex> : IEqualityComparer<Edge<TVertex>>
    {
        private readonly IEqualityComparer<TVertex> _vertexComparer;

        public IgnoreDirectionAndAllowParallelEdges() : this(EqualityComparer<TVertex>.Default) { }

        public IgnoreDirectionAndAllowParallelEdges(IEqualityComparer<TVertex> vertexComparer)
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

            foreach (var endHashing in new int[] { _vertexComparer.GetHashCode(edge.End1), _vertexComparer.GetHashCode(edge.End2) }.OrderBy( x => x))
            {
                hash = hash * 23 + endHashing;
            }

            return hash;
        }
    }
}
