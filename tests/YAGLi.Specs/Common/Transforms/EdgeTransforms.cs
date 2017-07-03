using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Transforms
{
    [Binding]
    public class EdgeTransforms
    {
        private const string EDGE_END1_PROPERTY_NAME = nameof(Edge<Vertex>.End1);
        private const string EDGE_END2_PROPERTY_NAME = nameof(Edge<Vertex>.End2);

        [StepArgumentTransformation]
        public IEnumerable<Edge<Vertex>> EdgesTransform(Table table)
        {
            return table.Rows.Select(row => new Edge<Vertex>(row[EDGE_END1_PROPERTY_NAME], row[EDGE_END2_PROPERTY_NAME]));
        }

        [StepArgumentTransformation]
        public Edge<Vertex> EdgeTransform(Table table)
        {
            var firstRow = table.Rows[0];

            return new Edge<Vertex>(firstRow[EDGE_END1_PROPERTY_NAME], firstRow[EDGE_END2_PROPERTY_NAME]);
        }
    }
}
