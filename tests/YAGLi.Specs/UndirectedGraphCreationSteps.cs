using NFluent;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs
{
    [Binding]
    public class UndirectedGraphCreationSteps
    {
        private readonly UndirectedGraphContext _context;

        public UndirectedGraphCreationSteps(UndirectedGraphContext context)
        {
            _context = context;
        }

        [Given(@"the property disallow loops")]
        public void GivenThePropertyDisallowLoops()
        {
            _context.AllowLoops = false;
        }
        
        [Given(@"the property disallow parallel edges")]
        public void GivenThePropertyDisallowParallelEdges()
        {
            _context.AllowParallelEdges = false;
        }
        
        [Given(@"the vertices")]
        public void GivenTheVerticesAnd(Table table)
        {
            _context.GivenVertices = new Dictionary<string, Vertex>(table.RowCount);

            foreach (var row in table.Rows)
            {
                _context.GivenVertices.Add(row[0], row[0]);
            }
        }
        
        [Given(@"the edges")]
        public void GivenTheEdges(Table table)
        {
            _context.GivenEdges = new Dictionary<string, Edge<Vertex>>(table.RowCount);
            foreach (var row in table.Rows)
            {
                _context.GivenEdges.Add(row[0], new Edge<Vertex>(_context.GivenVertices[row[1]], _context.GivenVertices[row[2]]));
            }
        }
        
        [Given(@"the property allow parallel edges")]
        public void GivenThePropertyAllowParallelEdges()
        {
            _context.AllowParallelEdges = true;
        }

        [Given(@"the property allow loops")]
        public void GivenThePropertyAllowLoops()
        {
            _context.AllowLoops = true;
        }
        
        [When(@"I create a new undirected graph with them")]
        public void WhenICreateANewUndirectedGraphWithThem()
        {
            _context.Graph = new UndirectedGraph<Vertex>(_context.AllowLoops, _context.AllowParallelEdges, _context.GivenEdges.Values, _context.GivenVertices.Values, new VertexEqualityComparer());
        }
        
        [Then(@"he should contains the vertices")]
        public void ThenHeShouldContainsTheVerticesAnd(Table table)
        {
            var expectedVertices = new List<Vertex>(table.RowCount);

            foreach (var row in table.Rows)
            {
                expectedVertices.Add(_context.GivenVertices[row[0]]);
            }

            Check.That(_context.Graph.Vertices).ContainsExactly(expectedVertices);
        }
        
        [Then(@"the edges")]
        public void ThenTheEdges(Table table)
        {
            var expectedEdges = new List<Edge<Vertex>>(table.RowCount);

            foreach (var row in table.Rows)
            {
                expectedEdges.Add(_context.GivenEdges[row[0]]);
            }

            Check.That(_context.Graph.Edges).ContainsExactly(expectedEdges);
        }
    }
}
