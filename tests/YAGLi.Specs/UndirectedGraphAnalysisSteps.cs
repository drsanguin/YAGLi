using NFluent;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace YAGLi.Specs
{
    [Binding]
    public class UndirectedGraphAnalysisSteps
    {
        private readonly UndirectedGraphContext _context;

        public UndirectedGraphAnalysisSteps(UndirectedGraphContext context)
        {
            _context = context;
        }

        [Given(@"the undirected graph created with them")]
        public void GivenTheUndirectedGraphCreatedWithThem()
        {
            _context.Graph = new UndirectedGraph<string>(_context.AllowLoops, _context.AllowParallelEdges, _context.GivenEdges.Values, _context.GivenVertices);
        }

        [When(@"I retrieve the adjacent edges of the edge ""(.*)""")]
        public void WhenIRetrieveTheAdjacentEdgesOfTheEdge(string edgeName)
        {
            _context.ResultingEdges = _context.Graph.AdjacentEdgesOf(_context.GivenEdges[edgeName]);
        }

        [Then(@"I get the edges")]
        public void ThenTheResultShouldBeTheEdges(Table table)
        {
            IEnumerable<Edge<string>> actualEdges = _context.ResultingEdges;
            IEnumerable<Edge<string>> expectedEdges = table.Rows.Select(row => _context.GivenEdges[row["Name"]]);

            Check.That(actualEdges).ContainsExactly(expectedEdges);
        }

        [When(@"I retrieve the adjacent edges of the edge with the ends ""(.*)"" and ""(.*)""")]
        public void WhenIRetrieveTheAdjacentEdgesOfTheEdgeWithTheEndsAnd(string end1, string end2)
        {
            Edge<string> edge = new Edge<string>(end1, end2);
            _context.ResultingEdges = _context.Graph.AdjacentEdgesOf(edge);
        }

        [Then(@"I get a empty list of edges")]
        public void ThenTheResultShouldBeAEmptyListOfEdge()
        {
            Check.That(_context.ResultingEdges).IsEmpty();
        }

        [When(@"I retrieve the adjacent vertices of the vertex ""(.*)""")]
        public void WhenIRetrieveTheAdjacentVerticesOfTheVertex(string vertex)
        {
            _context.ResultingVertices = _context.Graph.AdjacentVerticesOf(vertex);
        }

        [Then(@"I get the vertices")]
        public void ThenIGetTheVertices(Table table)
        {
            IEnumerable<string> expectedVertices = table.Rows.Select(row => row["Name"]);

            Check.That(_context.ResultingVertices).ContainsExactly(expectedVertices);
        }

        [Then(@"I get a empty list of vertices")]
        public void ThenIGetAEmptyListOfVertices()
        {
            Check.That(_context.ResultingVertices).IsEmpty();
        }

        [When(@"I get the degree of the vertex ""(.*)""")]
        public void WhenIGetTheDegreeOfTheVertex(string vertex)
        {
            _context.ResultingDegree = _context.Graph.DegreeOf(vertex);
        }

        [Then(@"I get the degree (.*)")]
        public void ThenIGetTheDegree(int expectedDegree)
        {
            Check.That(_context.ResultingDegree).IsEqualTo(expectedDegree);
        }

        [When(@"I get the in degree of the vertex ""(.*)""")]
        public void WhenIGetTheInDegreeOfTheVertex(string vertex)
        {
            _context.ResultingInDegree = _context.Graph.InDegreeOf(vertex);
        }

        [Then(@"I get the in degree (.*)")]
        public void ThenIGetTheInDegree(int expectedInDegree)
        {
            Check.That(_context.ResultingInDegree).IsEqualTo(expectedInDegree);
        }

        [When(@"I get the out degree of the vertex ""(.*)""")]
        public void WhenIGetTheOutDegreeOfTheVertex(string vertex)
        {
            _context.ResultingOutDegree = _context.Graph.OutDegreeOf(vertex);
        }

        [Then(@"I get the out degree (.*)")]
        public void ThenIGetTheOutDegree(int expectedOutDegree)
        {
            Check.That(_context.ResultingOutDegree).IsEqualTo(expectedOutDegree);
        }

        [When(@"I retrieve the incident edges of the vertex ""(.*)""")]
        public void WhenIRetrieveTheIncidentEdgesOfTheVertex(string vertex)
        {
            _context.ResultingEdges = _context.Graph.IncidentEdgesOf(vertex);
        }

        [When(@"I get the incident vertices of the edge ""(.*)""")]
        public void WhenIGetTheIncidentVerticesOfTheEdge(string edgeName)
        {
            _context.ResultingVertices = _context.Graph.IncidentVerticesOf(_context.GivenEdges[edgeName]);
        }

        [When(@"I get the incident vertices of the edge with the ends ""(.*)"" and ""(.*)""")]
        public void WhenIGetTheIncidentVerticesOfTheEdgeWithTheEndsAnd(string end1, string end2)
        {
            Edge<string> edge = new Edge<string>(end1, end2);

            _context.ResultingVertices = _context.Graph.IncidentVerticesOf(edge);
        }

        [When(@"I check that the graph contains the vertex ""(.*)""")]
        public void WhenICheckThatTheGraphContainsTheVertex(string p0)
        {
            _context.BooleanResult = _context.Graph.ContainsVertex(p0);
        }

        [Then(@"I get the answer true")]
        public void ThenIGetTheAnswerTrue()
        {
            Check.That(_context.BooleanResult).IsTrue();
        }

        [Then(@"I get the answer false")]
        public void ThenIGetTheAnswerFalse()
        {
            Check.That(_context.BooleanResult).IsFalse();
        }

        [When(@"I check that the graph contains the vertices")]
        public void WhenICheckThatTheGraphContainsTheVertices(Table table)
        {
            _context.BooleanResult = _context.Graph.ContainsVertices(table.Rows.Select(row => row["Name"]));
        }

        [When(@"I check that the graph contains the edge ""(.*)""")]
        public void WhenICheckThatTheGraphContainsTheEdge(string edgeName)
        {
            _context.BooleanResult = _context.Graph.ContainsEdge(_context.GivenEdges[edgeName]);
        }

        [When(@"I check that the graph contains the edge with the ends ""(.*)"" and ""(.*)""")]
        public void WhenICheckThatTheGraphContainsTheEdgeWithTheEndsAnd(string end1, string end2)
        {
            Edge<string> edge = new Edge<string>(end1, end2);

            _context.BooleanResult = _context.Graph.ContainsEdge(edge);
        }

        [When(@"I check that the graph contains the edges")]
        public void WhenICheckThatTheGraphContainsTheEdges(Table table)
        {
            _context.BooleanResult = _context.Graph.ContainsEdges(table.Rows.Select(row => _context.GivenEdges[row["Name"]]));
        }

        [When(@"I check that the graph contains the edges with the ends ""(.*)"" and ""(.*)"" and the edge with the ends ""(.*)"" and ""(.*)""")]
        public void A(string end1, string end2, string end3, string end4)
        {
            Edge<string>[] edges = new Edge<string>[]
            {
                new Edge<string>(end1, end2),
                new Edge<string>(end3, end4)
            };

            _context.BooleanResult = _context.Graph.ContainsEdges(edges);
        }
    }
}
