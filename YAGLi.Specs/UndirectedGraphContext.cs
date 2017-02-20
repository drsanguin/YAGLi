using System.Collections.Generic;

namespace YAGLi.Specs
{
    public class UndirectedGraphContext
    {
        public bool AllowLoops { get; set; }
        public bool AllowParallelEdges { get; set; }
        public Dictionary<string, Edge<string>> GivenEdges { get; set; }
        public List<string> GivenVertices { get; set; }
        public UndirectedGraph<string> Graph { get; set; }
    }
}
