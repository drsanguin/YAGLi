using YAGLi.Interfaces;

namespace YAGLi.Tests.Utils
{
    public class Edge<TVertex> : IModelAnEdge<TVertex>
    {
        private const int HASH_BASE = 41;
        private const int HASH_FACTOR = 43;

        public Edge(TVertex end1, TVertex end2)
        {
            End1 = end1;
            End2 = end2;
        }

        public TVertex End1 { get; }

        public TVertex End2 { get; }

        public override bool Equals(object obj)
        {
            Edge<TVertex> other = obj as Edge<TVertex>;

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            return End1.Equals(other.End1)
                && End2.Equals(other.End2);
        }

        public override int GetHashCode()
        {
            int hash = HASH_BASE;

            hash = hash * HASH_FACTOR + End1.GetHashCode();
            hash = hash * HASH_FACTOR + End2.GetHashCode();

            return hash;
        }

        public override string ToString()
        {
            return $"{{ {End1}, {End2} }}";
        }
    }
}
