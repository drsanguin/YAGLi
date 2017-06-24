using System.Collections.Generic;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.UndirectedGraph
{
    public class UndirectedGraphContext
    {
        public bool AllowLoops { get; set; }
        public bool AllowParallelEdges { get; set; }
        public Dictionary<string, Edge<Vertex>> GivenEdges { get; set; }
        public Dictionary<string, Vertex> GivenVertices { get; set; }
        public UndirectedGraph<Vertex, Edge<Vertex>> Graph { get; set; }
        public int ResultingDegree { get; set; }
        public IEnumerable<Edge<Vertex>> ResultingEdges { get; set; }
        public IEnumerable<Vertex> ResultingVertices { get; set; }
        public bool BooleanResult { get; set; }
        public UndirectedGraph<Vertex, Edge<Vertex>> NewGraph { get; set; }
    }
}
