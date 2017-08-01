using NFluent;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Validators
{
    [Binding]
    public sealed class VertexCollectionValidator
    {
        public IEnumerable<Vertex> Subject { get; set; }

        [Then(@"I get the vertices")]
        public void ThenIGetTheVertices(IEnumerable<Vertex> vertices)
        {
            Check.That(Subject.ExtractNames()).ContainsExactly(vertices.ExtractNames());
        }

        [Then(@"I get an empty list of vertices")]
        public void ThenIGetAnEmptyListOfVertices()
        {
            Check.That(Subject).IsEmpty();
        }
    }
}
