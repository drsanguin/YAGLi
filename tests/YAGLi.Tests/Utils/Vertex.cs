namespace YAGLi.Tests.Utils
{
    public class Vertex
    {
        private const int HASH_BASE = 47;
        private const int HASH_FACTOR = 43;

        public Vertex(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override bool Equals(object obj)
        {
            Vertex other = obj as Vertex;

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
            int hash = HASH_BASE;

            hash = hash * HASH_FACTOR + Name.GetHashCode();

            return hash;
        }

        public override string ToString()
        {
            return Name;
        }

        public static implicit operator Vertex(string name)
        {
            return new Vertex(name);
        }
    }
}
