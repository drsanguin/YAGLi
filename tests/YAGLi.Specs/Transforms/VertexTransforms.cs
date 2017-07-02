using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Transforms
{
    [Binding]
    public class VertexTransforms
    {
        private const string VERTEX_NAME_PROPERTY_NAME = nameof(Vertex.Name);

        [StepArgumentTransformation]
        public Vertex VertexTransform(string name)
        {
            return name;
        }

        [StepArgumentTransformation]
        public Vertex VertexTransform(Table table)
        {
            var firstRow = table.Rows[0];

            return firstRow[VERTEX_NAME_PROPERTY_NAME];
        }

        [StepArgumentTransformation]
        public IEnumerable<Vertex> VerticesTransforms(Table table)
        {
            return table.Rows.Select(row => new Vertex(row[VERTEX_NAME_PROPERTY_NAME]));
        }
    }
}
