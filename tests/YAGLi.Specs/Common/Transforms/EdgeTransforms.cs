using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Transforms
{
    [Binding]
    public sealed class EdgeTransforms
    {
        private const string EDGE_END1_PROPERTY_NAME = nameof(Edge<Vertex>.End1);
        private const string EDGE_END2_PROPERTY_NAME = nameof(Edge<Vertex>.End2);

        [StepArgumentTransformation]
        public Edge<Vertex> TransformTableToEdge(Table table)
        {
            var firstRow = table.Rows[0];

            return new Edge<Vertex>(firstRow[EDGE_END1_PROPERTY_NAME], firstRow[EDGE_END2_PROPERTY_NAME]);
        }

        [StepArgumentTransformation]
        public Edge<Vertex>[] TransformTableToEdgesArray(Table table)
        {
            return TransformTableToEdgesIEnumerable(table).ToArray();
        }

        [StepArgumentTransformation]
        public IEnumerable<Edge<Vertex>> TransformTableToEdgesIEnumerable(Table table)
        {
            return table.Rows.Select(row => new Edge<Vertex>(row[EDGE_END1_PROPERTY_NAME], row[EDGE_END2_PROPERTY_NAME]));
        }
    }
}
