using NFluent;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs
{
    [Binding]
    public class UndirectedGraphModificationSteps
    {
        private readonly UndirectedGraphContext _context;

        public UndirectedGraphModificationSteps(UndirectedGraphContext context)
        {
            _context = context;
        }

        [When(@"I add the edges")]
        public void WhenIAddTheEdges(Table table)
        {
            List<Edge<Vertex>> edges = new List<Edge<Vertex>>(table.RowCount);

            foreach (var row in table.Rows)
            {
                var newEdge = new Edge<Vertex>(_context.GivenVertices[row[1]], _context.GivenVertices[row[2]]);

                edges.Add(newEdge);
                _context.GivenEdges.Add(row[0], newEdge);
            }

            _context.NewGraph = _context.Graph.AddEdges(edges);
        }

        [Then(@"I should get a new undirected graph")]
        public void ThenIShouldGetANewUndirectedGraph()
        {
            Check.That(_context.NewGraph).IsNotNull();
        }

        [Then(@"this new undirected graph should contains the vertices")]
        public void ThenThisNewUndirectedGraphShouldContainsTheVertices(Table table)
        {
            List<Vertex> expectedVertices = new List<Vertex>(table.RowCount);

            foreach (var row in table.Rows)
            {
                expectedVertices.Add(_context.GivenVertices[row[0]]);
            }

            Check.That(_context.NewGraph.Vertices).IsOnlyMadeOf(expectedVertices);
        }

        [Then(@"this new undirected graph should contains the edges")]
        public void ThenThisNewUndirectedGraphShouldContainsTheEdges(Table table)
        {
            List<Edge<Vertex>> expectedEdges = new List<Edge<Vertex>>(table.RowCount);

            foreach (var row in table.Rows)
            {
                expectedEdges.Add(_context.GivenEdges[row[0]]);
            }

            Check.That(_context.NewGraph.Edges).IsOnlyMadeOf(expectedEdges);
        }

        [When(@"I add the vertices")]
        public void WhenIAddTheVertices(Table table)
        {
            var verticesToAdd = new List<Vertex>(table.RowCount);

            foreach (var row in table.Rows)
            {
                var vertexToAdd = new Vertex(row[0]);

                verticesToAdd.Add(vertexToAdd);
                _context.GivenVertices.Add(vertexToAdd.Name, vertexToAdd);
            }

            _context.NewGraph = _context.Graph.AddVertices(verticesToAdd);
        }

        [When(@"I add the edge ""(.*)"" with the ends ""(.*)"" and ""(.*)""")]
        public void WhenIAddTheEdgeWithTheEndsAnd(string edgeName, string edgeEnd1, string edgeEnd2)
        {
            var newEdge = new Edge<Vertex>(_context.GivenVertices[edgeEnd1], _context.GivenVertices[edgeEnd2]);
            _context.GivenEdges.Add(edgeName, newEdge);

            _context.NewGraph = _context.Graph.AddEdge(newEdge);
        }

        [When(@"I add the vertex ""(.*)""")]
        public void WhenIAddTheVertex(string vertexName)
        {
            var newVertex = new Vertex(vertexName);
            _context.GivenVertices.Add(newVertex.Name, newVertex);

            _context.NewGraph = _context.Graph.AddVertex(newVertex);
        }
    }
}
