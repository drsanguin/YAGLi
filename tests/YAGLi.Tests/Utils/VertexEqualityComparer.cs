using System.Collections.Generic;

namespace YAGLi.Tests.Utils
{
    public class VertexEqualityComparer : IEqualityComparer<Vertex>
    {
        public bool Equals(Vertex vertex1, Vertex vertex2)
        {
            return vertex1.Name.Equals(vertex2.Name);
        }

        public int GetHashCode(Vertex vertex)
        {
            int hash = 37;

            hash = hash * 41 + vertex.Name.GetHashCode();

            return hash;
        }
    }
}
