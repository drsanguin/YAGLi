using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Specs.DirectedGraph.AbstractSteps;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.DirectedGraph.Steps
{
    [Binding]
    public sealed class OutDegreeOfStep : DirectedGraphStepWithDegreeValidator
    {
        public OutDegreeOfStep(DirectedGraphBuilder builder, DegreeValidator validator) : base(builder, validator) { }

        [When(@"I get the out degree of the vertex ""(.*)""")]
        public void WhenIGetTheInDegreeOfTheVertex(Vertex vertex)
        {
            Validator.Subject = Builder.Instance.OutDegreeOf(vertex);
        }
    }
}
