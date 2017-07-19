using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Transforms
{
    [Binding]
    public sealed class VertexTransforms
    {
        private const string VERTEX_NAME_PROPERTY_NAME = nameof(Vertex.Name);

        [StepArgumentTransformation]
        public Vertex TransformStringToVertex(string name)
        {
            return name;
        }

        [StepArgumentTransformation]
        public Vertex[] TransformTableToVerticesArray(Table table)
        {
            return TransformTableToVerticesIEnumerable(table).ToArray();
        }

        [StepArgumentTransformation]
        public IEnumerable<Vertex> TransformTableToVerticesIEnumerable(Table table)
        {
            return table.Rows.Select(row => new Vertex(row[VERTEX_NAME_PROPERTY_NAME]));
        }
    }
}
