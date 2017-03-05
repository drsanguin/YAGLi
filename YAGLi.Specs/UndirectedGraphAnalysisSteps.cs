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

        private List<Edge<string>> extractExpectedEdges(Table table)
        {
            List<Edge<string>> expectedEdges = new List<Edge<string>>(table.RowCount);

            foreach (var row in table.Rows)
            {
                expectedEdges.Add(_context.GivenEdges[row["Name"]]);
            }

            return expectedEdges;
        }

        [Then(@"the adjacent edges of the edge ""(.*)"" should be")]
        public void ThenIShouldgetTheEdges(string edgeId, Table table)
        {
            Edge<string> edge = _context.GivenEdges[edgeId];
            List<Edge<string>> expectedEdges = extractExpectedEdges(table);

            Check.That(_context.Graph.AdjacentEdgesOf(edge)).ContainsExactly(expectedEdges);
        }

        [Then(@"the adjacent edges of the edge with the ends ""(.*)"" and ""(.*)"" should be empty")]
        public void ThenTheAdjacentEdgesOfTheEdgeWithTheEndsAndShouldBeEmpty(string end1, string end2)
        {
            Edge<string> edge = new Edge<string>(end1, end2);

            Check.That(_context.Graph.AdjacentEdgesOf(edge)).IsEmpty();
        }

        [Then(@"the adjacent edges of the edge with the ends ""(.*)"" and ""(.*)"" should be")]
        public void ThenTheAdjacentEdgesOfTheEdgeWithTheEndsAndShouldBe(string end1, string end2, Table table)
        {
            Edge<string> edge = new Edge<string>(end1, end2);
            List<Edge<string>> expectedEdges = extractExpectedEdges(table);

            Check.That(_context.Graph.AdjacentEdgesOf(edge)).ContainsExactly(expectedEdges);
        }

        [Then(@"the adjacent vertices of the vertex ""(.*)"" should be")]
        public void TheAdjacentVerticesOfTheVertexShouldBe(string vertexId, Table table)
        {
            IEnumerable<string> expectedVertices = table.Rows.Select(row => row["Name"]);

            Check.That(_context.Graph.AdjacentVerticesOf(vertexId)).ContainsExactly(expectedVertices);
        }

        [Then(@"the adjacent vertices of the vertex ""(.*)"" should be empty")]
        public void ThenTheAdjacentVerticesOfTheVertexShouldBeEmpty(string p0)
        {
            Check.That(_context.Graph.AdjacentVerticesOf(p0)).IsEmpty();
        }

        [Then(@"the degree of the vertex ""(.*)"" should be (.*)")]
        public void ThenTheDegreeOfTheVertexShouldBe(string vertex, int expectedDegree)
        {
            Check.That(_context.Graph.DegreeOf(vertex)).IsEqualTo(expectedDegree);
        }

        [Then(@"the incident edges of the vertex ""(.*)"" should be")]
        public void ThenTheIncidentEdgesOfTheVertexShouldBe(string vertex, Table table)
        {
            IEnumerable<Edge<string>> expectedEdges = table
                .Rows
                .Select(row => row["Name"])
                .Select(edgeName => _context.GivenEdges[edgeName]);

            Check.That(_context.Graph.IncidentEdgesOf(vertex)).ContainsExactly(expectedEdges);
        }

        [Then(@"the incident edges of the vertex ""(.*)"" should be empty")]
        public void ThenTheIncidentEdgesOfTheVertexShouldBeEmpty(string vertex)
        {
            Check.That(_context.Graph.IncidentEdgesOf(vertex)).IsEmpty();
        }

        [Then(@"the incident vertices of the edge ""(.*)"" should be")]
        public void ThenTheIncidentVerticesOfTheEdgeShouldBe(string edgeName, Table table)
        {
            Edge<string> edge = _context.GivenEdges[edgeName];

            IEnumerable<string> expectedEdges = table.Rows.Select(row => row["Name"]);

            Check.That(_context.Graph.IncidentVerticesOf(edge)).ContainsExactly(expectedEdges);
        }

        [Then(@"the incident vertices of the edge with the ends ""(.*)"" and ""(.*)"" should be empty")]
        public void ThenTheIncidentVerticesOfTheEdgeWithTheEndsAndShouldBeEmpty(string end1, string end2)
        {
            Edge<string> edge = new Edge<string>(end1, end2);

            Check.That(_context.Graph.IncidentVerticesOf(edge)).IsEmpty();
        }
    }
}
