using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Builders
{
    [Binding]
    public class GraphBuilder
    {
        public bool AllowLoops { get; private set; }
        public bool AllowParallelEdges { get; private set; }
        public IEnumerable<Vertex> Vertices { get; private set; }
        public IEnumerable<Edge<Vertex>> Edges { get; private set; }

        [Given(@"the property allow loops")]
        public void GivenThePropertyAllowLoops()
        {
            AllowLoops = true;
        }

        [Given(@"the property allow parallel edges")]
        public void GivenThePropertyAllowParallelEdges()
        {
            AllowParallelEdges = true;
        }

        [Given(@"the property disallow loops")]
        public void GivenThePropertyDisallowLoops()
        {
            AllowLoops = false;
        }

        [Given(@"the property disallow parallel edges")]
        public void GivenThePropertyDisallowParallelEdges()
        {
            AllowParallelEdges = false;
        }

        [Given(@"the vertices")]
        public void GivenTheVertices(IEnumerable<Vertex> vertices)
        {
            Vertices = vertices;
        }

        [Given(@"the edges")]
        public void GivenTheEdges(IEnumerable<Edge<Vertex>> edges)
        {
            Edges = edges;
        }
    }
}
