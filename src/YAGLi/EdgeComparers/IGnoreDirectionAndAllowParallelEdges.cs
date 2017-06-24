using System;
using System.Collections.Generic;
using System.Linq;
using YAGLi.Interfaces;

namespace YAGLi.EdgeComparers
{
    public class IgnoreDirectionAndAllowParallelEdges<TVertex, TEdge> : IEqualityComparer<TEdge> where TEdge : IModelAnEdge<TVertex>
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

        public bool Equals(TEdge edge1, TEdge edge2)
        {
            return ReferenceEquals(edge1, edge2);
        }

        public int GetHashCode(TEdge edge)
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
