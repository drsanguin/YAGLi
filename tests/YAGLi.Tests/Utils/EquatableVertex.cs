using System;

namespace YAGLi.Tests.Utils
{
    public class EquatableVertex : Vertex, IEquatable<Vertex>
    {
        private const int HASH_BASE = 43;
        private const int HASH_FACTOR = 47;

        public EquatableVertex(Vertex vertex) : base(vertex.Name) { }

        public override bool Equals(object obj)
        {
            return Equals(obj as Vertex);
        }

        public bool Equals(Vertex other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(other, this))
            {
                return true;
            }

            return Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return HASH_BASE * HASH_FACTOR + Name.GetHashCode();
        }
    }
}
