using NFluent;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.AbstractValidators;
using YAGLi.Tests.Utils;
using YAGLi.Tests.Utils.Extensions;

namespace YAGLi.Specs.Common.Validators
{
    public sealed class VertexCollectionValidator : BaseValidator<IEnumerable<Vertex>>
    {
        [Then(@"I get the vertices")]
        public void ThenIGetTheVertices(IEnumerable<Vertex> vertices)
        {
            Check.That(Subject.ToEquatable()).ContainsExactly(vertices.ToEquatable());
        }

        [Then(@"I get an empty list of vertices")]
        public void ThenIGetAnEmptyListOfVertices()
        {
            Check.That(Subject).IsEmpty();
        }
    }
}
