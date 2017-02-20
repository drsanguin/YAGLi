using NFluent;
using System.Collections.Generic;
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
    }
}
