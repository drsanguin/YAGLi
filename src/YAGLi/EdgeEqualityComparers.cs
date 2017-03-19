using System;
using System.Collections.Generic;

namespace YAGLi
{
    public static class EdgeEqualityComparers<TVertex> where TVertex : IEquatable<TVertex>
    {
        public static readonly IEqualityComparer<Edge<TVertex>> IgnoreDirectionAndDisallowParallelEdges = new ComparerWhoIgnoreDirectionAndDisallowParallelEdges();
        public static readonly IEqualityComparer<Edge<TVertex>> IgnoreDirectionAndAllowParallelEdges = new ComparerWhoIgnoreDirectionAndAllowParallelEdges();

        private class ComparerWhoIgnoreDirectionAndDisallowParallelEdges : IEqualityComparer<Edge<TVertex>>
        {
            public bool Equals(Edge<TVertex> edge1, Edge<TVertex> edge2)
            {
                return edge1.Equals(edge2, EdgeComparison.IgnoreDirection);
            }

            public int GetHashCode(Edge<TVertex> edge)
            {
                return edge.GetHashCode();
            }
        }

        private class ComparerWhoIgnoreDirectionAndAllowParallelEdges : IEqualityComparer<Edge<TVertex>>
        {
            public bool Equals(Edge<TVertex> edge1, Edge<TVertex> edge2)
            {
                return ReferenceEquals(edge1, edge2);
            }

            public int GetHashCode(Edge<TVertex> edge)
            {
                return edge.GetHashCode();
            }
        }
    }
}
