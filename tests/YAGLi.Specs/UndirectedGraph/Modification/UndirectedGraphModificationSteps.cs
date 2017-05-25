using NFluent;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.UndirectedGraph.Modification
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
            var edges = new Edge<Vertex>[table.RowCount];

            for (var i = 0; i < table.RowCount; i++)
            {
                var row = table.Rows[i];
                var newEdge = new Edge<Vertex>(_context.GivenVertices[row[1]], _context.GivenVertices[row[2]]);

                edges[i] = newEdge;
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
            var expectedVertices = new List<Vertex>(table.RowCount);

            foreach (var row in table.Rows)
            {
                expectedVertices.Add(_context.GivenVertices[row[0]]);
            }

            Check.That(_context.NewGraph.Vertices)
                .IsOnlyMadeOf(expectedVertices)
                .And
                .HasSize(expectedVertices.Count);
        }

        [Then(@"this new undirected graph should contains the edges")]
        public void ThenThisNewUndirectedGraphShouldContainsTheEdges(Table table)
        {
            var expectedEdges = new List<Edge<Vertex>>(table.RowCount);

            foreach (var row in table.Rows)
            {
                expectedEdges.Add(_context.GivenEdges[row[0]]);
            }

            Check.That(_context.NewGraph.Edges)
                .IsOnlyMadeOf(expectedEdges)
                .And
                .HasSize(expectedEdges.Count);
        }

        [When(@"I add the vertices")]
        public void WhenIAddTheVertices(Table table)
        {
            var verticesToAdd = new Vertex[table.RowCount];

            for (var i = 0; i < table.RowCount; i++)
            {
                var row = table.Rows[i];
                var vertexToAdd = new Vertex(row[0]);

                verticesToAdd[i] = vertexToAdd;
                _context.GivenVertices.Add(vertexToAdd.Name, vertexToAdd);
            }

            _context.NewGraph = _context.Graph.AddVertices(verticesToAdd);
        }

        [When(@"I add the edge")]
        public void WhenIAddTheEdge(Table table)
        {
            string newEdgeName = table.Rows[0][0];
            string endName1 = table.Rows[0][1];
            string endName2 = table.Rows[0][2];

            var end1 = _context.GivenVertices.ContainsKey(endName1) ? _context.GivenVertices[endName1] : new Vertex(endName1);
            var end2 = _context.GivenVertices.ContainsKey(endName2) ? _context.GivenVertices[endName2] : new Vertex(endName2);

            var newEdge = new Edge<Vertex>(end1, end2);
            _context.GivenEdges.Add(newEdgeName, newEdge);

            _context.NewGraph = _context.Graph.AddEdge(newEdge);
        }

        [When(@"I add the vertex ""(.*)""")]
        public void WhenIAddTheVertex(string vertexName)
        {
            var newVertex = new Vertex(vertexName);
            _context.GivenVertices.Add(newVertex.Name, newVertex);

            _context.NewGraph = _context.Graph.AddVertex(newVertex);
        }

        [When(@"I add the edge ""(.*)"" and the vertices ""(.*)"" and ""(.*)""")]
        public void WhenIAddTheEdgeWithTheVerticesAnd(string edgeName, string endName1, string endName2)
        {
            var end1 = new Vertex(endName1);
            var end2 = new Vertex(endName2);
            var newEdge = new Edge<Vertex>(end1, end2);

            _context.GivenVertices.Add(endName1, end1);
            _context.GivenVertices.Add(endName2, end2);
            _context.GivenEdges.Add(edgeName, newEdge);

            _context.NewGraph = _context.Graph.AddEdgeAndVertices(newEdge);
        }

        [When(@"I add the edges and vertices")]
        public void WhenIAddTheEdgesAndVertices(Table table)
        {
            var edgesToAdd = new Edge<Vertex>[table.RowCount];

            for (var i = 0; i < edgesToAdd.Length; i++)
            {
                var row = table.Rows[i];
                var end1 = _context.GivenVertices.ContainsKey(row[1]) ? _context.GivenVertices[row[1]] : row[1];
                var end2 = _context.GivenVertices.ContainsKey(row[2]) ? _context.GivenVertices[row[2]] : row[2];
                var edgeToAdd = new Edge<Vertex>(end1, end2);

                _context.GivenEdges.Add(row[0], edgeToAdd);

                if (!_context.GivenVertices.ContainsKey(row[1]))
                {
                    _context.GivenVertices.Add(row[1], end1);
                }

                if (!_context.GivenVertices.ContainsKey(row[2]))
                {
                    _context.GivenVertices.Add(row[2], end2);
                }

                edgesToAdd[i] = edgeToAdd;
            }

            _context.NewGraph = _context.Graph.AddEdgesAndVertices(edgesToAdd);
        }

        [When(@"I remove the edge")]
        public void WhenIRemoveTheEdge(Table table)
        {
            var edgeName = table.Rows[0][0];
            var end1Name = table.Rows[0][1];
            var end2Name = table.Rows[0][2];

            var edge = _context.GivenEdges.ContainsKey(edgeName) ? _context.GivenEdges[edgeName] : new Edge<Vertex>(end1Name, end2Name);

            _context.NewGraph = _context.Graph.RemoveEdge(edge);
        }

        [When(@"I remove the edge and her vertices")]
        public void WhenIRemoveTheEdgeAndHerVertices(Table table)
        {
            var edgeName = table.Rows[0][0];
            var end1Name = table.Rows[0][1];
            var end2Name = table.Rows[0][2];

            var edge = _context.GivenEdges.ContainsKey(edgeName) ? _context.GivenEdges[edgeName] : new Edge<Vertex>(end1Name, end2Name);

            _context.NewGraph = _context.Graph.RemoveEdgeAndVertices(edge);
        }

        [When(@"I remove the edges")]
        public void WhenIRemoveTheEdges(Table table)
        {
            var edgesToRemove = new Edge<Vertex>[table.RowCount];

            for (var i = 0; i < table.RowCount; i++)
            {
                var row = table.Rows[i];

                var edgeName = row[0];
                var end1Name = row[1];
                var end2Name = row[2];

                edgesToRemove[i] = _context.GivenEdges.ContainsKey(edgeName) ? _context.GivenEdges[edgeName] : new Edge<Vertex>(end1Name, end2Name);
            }

            _context.NewGraph = _context.Graph.RemoveEdges(edgesToRemove);
        }

        [When(@"I remove the edges and their vertices")]
        public void WhenIRemoveTheEdgesAndTheirVertices(Table table)
        {
            var edgesToRemove = new Edge<Vertex>[table.RowCount];

            for (var i = 0; i < table.RowCount; i++)
            {
                var row = table.Rows[i];

                var edgeName = row[0];
                var end1Name = row[1];
                var end2Name = row[2];

                edgesToRemove[i] = _context.GivenEdges.ContainsKey(edgeName) ? _context.GivenEdges[edgeName] : new Edge<Vertex>(end1Name, end2Name);
            }

            _context.NewGraph = _context.Graph.RemoveEdgesAndVertices(edgesToRemove);
        }

        [When(@"I remove the vertex ""(.*)""")]
        public void WhenIRemoveTheVertex(string p0)
        {
            var vertexToRemove = _context.GivenVertices[p0];

            _context.NewGraph = _context.Graph.RemoveVertex(vertexToRemove);
        }

        [When(@"I remove the vertices")]
        public void WhenIRemoveTheVertices(Table table)
        {
            var verticesToRemove = new Vertex[table.RowCount];

            for (var i = 0; i < table.RowCount; i++)
            {
                var vertexToRemove = _context.GivenVertices[table.Rows[i][0]];

                verticesToRemove[i] = vertexToRemove;
            }

            _context.NewGraph = _context.Graph.RemoveVertices(verticesToRemove);
        }
    }
}
