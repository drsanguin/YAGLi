using TechTalk.SpecFlow;
using YAGLi.Specs.Common.AbstractSteps;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    public sealed class PathsToNeighborsOfStep : StepWithEdgeCollectionValidator
    {
        public PathsToNeighborsOfStep(GraphBuilder graphBuilder, EdgeCollectionValidator validator) : base(graphBuilder, validator) { }

        [When(@"I get the paths to the neighbors of ""(.*)""")]
        public void WhenIGetThePathsToTheNeighborsOf(Vertex vertex)
        {
            Validator.Subject = Builder.Instance.PathsToNeighborsOf(vertex);
        }
    }
}
