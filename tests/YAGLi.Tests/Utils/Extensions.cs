using System;
using System.Collections.Generic;
using System.Linq;

namespace YAGLi.Tests.Utils
{
    public static class Extensions
    {
        public static IEnumerable<string> ExtractNames(this IEnumerable<Vertex> vertices)
        {
            return vertices.Select(vertex => vertex.Name);
        }

        public static IEnumerable<Tuple<string, string>> ConvertToTuples(this IEnumerable<Edge<Vertex>> edges)
        {
            return edges.Select(edge => Tuple.Create(edge.End1.Name, edge.End2.Name));
        }
    }
}
