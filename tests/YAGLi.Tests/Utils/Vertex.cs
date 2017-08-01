namespace YAGLi.Tests.Utils
{
    public class Vertex
    {
        public Vertex(string name)
        {
            Name = name;
        }

        public string Name { get; }

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
