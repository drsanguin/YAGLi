using NFluent;
using System.Linq;
using TechTalk.SpecFlow;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.UndirectedGraph.Analysis
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
            _context.Graph = new UndirectedGraph<Vertex, Edge<Vertex>>(_context.AllowLoops, _context.AllowParallelEdges, _context.GivenEdges.Values, _context.GivenVertices.Values, new VertexEqualityComparer());
        }

        [When(@"I retrieve the adjacent edges of the edge ""(.*)""")]
        public void WhenIRetrieveTheAdjacentEdgesOfTheEdge(string edgeName)
        {
            _context.ResultingEdges = _context.Graph.AdjacentEdgesOf(_context.GivenEdges[edgeName]);
        }

        [Then(@"I get the edges")]
        public void ThenTheResultShouldBeTheEdges(Table table)
        {
            var actualEdges = _context.ResultingEdges;
            var expectedEdges = table.Rows.Select(row => _context.GivenEdges[row["Name"]]);

            Check.That(actualEdges).ContainsExactly(expectedEdges);
        }

        [When(@"I retrieve the adjacent edges of the edge with the ends ""(.*)"" and ""(.*)""")]
        public void WhenIRetrieveTheAdjacentEdgesOfTheEdgeWithTheEndsAnd(string end1, string end2)
        {
            var edge = new Edge<Vertex>(end1, end2);
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
            var expectedVertices = table.Rows.Select(row => _context.GivenVertices[row["Name"]]);

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
            var edge = new Edge<Vertex>(end1, end2);

            _context.ResultingVertices = _context.Graph.IncidentVerticesOf(edge);
        }

        [When(@"I check that the graph contains the vertex ""(.*)""")]
        public void WhenICheckThatTheGraphContainsTheVertex(string vertex)
        {
            _context.BooleanResult = _context.Graph.ContainsVertex(vertex);
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
            _context.BooleanResult = _context.Graph.ContainsVertices(table.Rows.Select(row => new Vertex(row["Name"])).ToArray());
        }

        [When(@"I check that the graph contains the edge ""(.*)""")]
        public void WhenICheckThatTheGraphContainsTheEdge(string edgeName)
        {
            _context.BooleanResult = _context.Graph.ContainsEdge(_context.GivenEdges[edgeName]);
        }

        [When(@"I check that the graph contains the edge with the ends ""(.*)"" and ""(.*)""")]
        public void WhenICheckThatTheGraphContainsTheEdgeWithTheEndsAnd(string end1, string end2)
        {
            var edge = new Edge<Vertex>(end1, end2);

            _context.BooleanResult = _context.Graph.ContainsEdge(edge);
        }

        [When(@"I check that the graph contains the edges")]
        public void WhenICheckThatTheGraphContainsTheEdges(Table table)
        {
            _context.BooleanResult = _context.Graph.ContainsEdges(table.Rows.Select(row => _context.GivenEdges[row["Name"]]));
        }

        [When(@"I check that the graph contains the edges with the ends ""(.*)"" and ""(.*)"" and the ends ""(.*)"" and ""(.*)""")]
        public void WhenICheckThatTheGraphContainsTheEdgesWithTheEndsAndAndTheEndsAnd(string end1, string end2, string end3, string end4)
        {
            var edge1 = new Edge<Vertex>(end1, end2);
            var edge2 = new Edge<Vertex>(end3, end4);

            _context.BooleanResult = _context.Graph.ContainsEdges(edge1, edge2);
        }

        [When(@"I check if the vertices ""(.*)"" and ""(.*)"" are adjacent")]
        public void WhenICheckIfTheVerticesAndAreAdjacent(string vertex1, string vertex2)
        {
            _context.BooleanResult = _context.Graph.AreVerticesAdjacent(vertex1, vertex2);
        }

        [When(@"I check if the edges ""(.*)"" and ""(.*)"" are adjacent")]
        public void WhenICheckIfTheEdgesAndAreAdjacent(string edgeName1, string edgeName2)
        {
            _context.BooleanResult = _context.Graph.AreEdgesAdjacent(_context.GivenEdges[edgeName1], _context.GivenEdges[edgeName2]);
        }

        [When(@"I check if the edge ""(.*)"" and the edge with the ends ""(.*)"" and ""(.*)"" are adjacent")]
        public void WhenICheckIfTheEdgeAndTheEdgeWithTheEndsAndAreAdjacent(string edgeName, string end1, string end2)
        {
            var edge1 = _context.GivenEdges[edgeName];
            var edge2 = new Edge<Vertex>(end1, end2);

            _context.BooleanResult = _context.Graph.AreEdgesAdjacent(edge1, edge2);
        }
    }
}
