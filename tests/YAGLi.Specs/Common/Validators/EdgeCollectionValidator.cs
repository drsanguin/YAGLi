using NFluent;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.AbstractValidators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Validators
{
    public sealed class EdgeCollectionValidator : BaseValidator<IEnumerable<Edge<Vertex>>>
    {
        [Then(@"I get the edges")]
        public void ThenTheResultShouldBeTheEdges(IEnumerable<Edge<Vertex>> edges)
        {
            Check.That(Subject.ToEquatable()).ContainsExactly(edges.ToEquatable());
        }

        [Then(@"I get an empty list of edges")]
        public void ThenIGetAnEmptyListOfEdges()
        {
            Check.That(Subject).IsEmpty();
        }
    }
}
