﻿using NFluent;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Validators
{
    [Binding]
    public sealed class EdgeCollectionValidator
    {
        public IEnumerable<Edge<Vertex>> Subject { get; set; }

        [Then(@"I get the edges")]
        public void ThenTheResultShouldBeTheEdges(IEnumerable<Edge<Vertex>> edges)
        {
            Check.That(Subject.ConvertToTuples()).ContainsExactly(edges.ConvertToTuples());
        }

        [Then(@"I get an empty list of edges")]
        public void ThenIGetAnEmptyListOfEdges()
        {
            Check.That(Subject).IsEmpty();
        }
    }
}
