using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    [Binding]
    public sealed class PathsToNeighborsOf
    {
        private GraphBuilder _graphBuilder;
        private EdgeCollectionValidator _validator;

        public PathsToNeighborsOf(GraphBuilder graphBuilder, EdgeCollectionValidator validator)
        {
            _graphBuilder = graphBuilder;
            _validator = validator;
        }

        [When(@"I get the paths to the neighbors of ""(.*)""")]
        public void WhenIGetThePathsToTheNeighborsOf(Vertex vertex)
        {
            _validator.Subject = _graphBuilder.Instance.PathsToNeighborsOf(vertex);
        }
    }
}
