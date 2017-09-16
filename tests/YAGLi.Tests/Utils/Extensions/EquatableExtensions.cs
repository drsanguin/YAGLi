using System.Collections.Generic;
using System.Linq;

namespace YAGLi.Tests.Utils.Extensions
{
    public static class EquatableExtensions
    {
        public static IEnumerable<EquatableVertex> ToEquatable(this IEnumerable<Vertex> vertices)
        {
            return vertices.Select(vertex => new EquatableVertex(vertex));
        }

        public static IEnumerable<EquatableEdge<EquatableVertex>> ToEquatable(this IEnumerable<Edge<Vertex>> edges)
        {
            return edges.Select(edge => new EquatableEdge<EquatableVertex>(new EquatableVertex(edge.End1), new EquatableVertex(edge.End2)));
        }
    }
}
