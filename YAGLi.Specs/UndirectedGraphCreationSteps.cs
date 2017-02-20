using NFluent;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace YAGLi.Specs
{
    [Binding]
    public class UndirectedGraphCreationSteps
    {
        private bool _allowLoops;
        private bool _allowParalleleEdges;
        private List<string> _givenVertices;
        private Dictionary<string, Edge<string>> _givenEdges;

        UndirectedGraph<string> _graph;

        [Given(@"the property disallow loops")]
        public void GivenThePropertyDisallowLoops()
        {
            _allowLoops = false;
        }
        
        [Given(@"the property disallow parallel edges")]
        public void GivenThePropertyDisallowParallelEdges()
        {
            _allowParalleleEdges = false;
        }
        
        [Given(@"the vertices")]
        public void GivenTheVerticesAnd(Table table)
        {
            _givenVertices = new List<string>(table.RowCount);

            foreach (var row in table.Rows)
            {
                _givenVertices.Add(row[0]);
            }
        }
        
        [Given(@"the edges")]
        public void GivenTheEdges(Table table)
        {
            _givenEdges = new Dictionary<string, Edge<string>>(table.RowCount);
            foreach (var row in table.Rows)
            {
                _givenEdges.Add(row[0], new Edge<string>(row[1], row[2]));
            }
        }
        
        [Given(@"the property allow parallel edges")]
        public void GivenThePropertyAllowParallelEdges()
        {
            _allowParalleleEdges = true;
        }

        [Given(@"the property allow loops")]
        public void GivenThePropertyAllowLoops()
        {
            _allowLoops = true;
        }
        
        [When(@"I create a new undirected graph with them")]
        public void WhenICreateANewUndirectedGraphWithThem()
        {
            _graph = new UndirectedGraph<string>(_allowLoops, _allowParalleleEdges, _givenEdges.Values, _givenVertices);
        }
        
        [Then(@"he should contains the vertices")]
        public void ThenHeShouldContainsTheVerticesAnd(Table table)
        {
            List<string> expectedVertices = new List<string>(table.RowCount);

            foreach (var row in table.Rows)
            {
                expectedVertices.Add(row[0]);
            }

            Check.That(_graph.Vertices).ContainsExactly(expectedVertices);
        }
        
        [Then(@"the edges")]
        public void ThenTheEdges(Table table)
        {
            List<Edge<string>> expectedEdges = new List<Edge<string>>(table.RowCount);

            foreach (var row in table.Rows)
            {
                expectedEdges.Add(_givenEdges[row[0]]);
            }

            Check.That(_graph.Edges).ContainsExactly(expectedEdges);
        }
    }
}
