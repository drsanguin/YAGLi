using System;

namespace YAGLi.Tests.Utils
{
    public class EquatableEdge<TVertex> : Edge<TVertex> , IEquatable<Edge<TVertex>>
    {
        private const int HASH_BASE = 41;
        private const int HASH_FACTOR = 43;

        public EquatableEdge(TVertex end1, TVertex end2) : base(end1, end2) { }

        public bool Equals(Edge<TVertex> other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(other, this))
            {
                return true;
            }

            return End1.Equals(other.End1)
                && End2.Equals(other.End2);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Edge<TVertex>);
        }

        public override int GetHashCode()
        {
            var hash = HASH_BASE;

            hash = hash * HASH_FACTOR + End1.GetHashCode();
            hash = hash * HASH_FACTOR + End2.GetHashCode();

            return hash;
        }
    }
}
