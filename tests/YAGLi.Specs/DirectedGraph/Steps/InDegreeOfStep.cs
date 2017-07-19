using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Specs.DirectedGraph.AbstractSteps;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.DirectedGraph.Steps
{
    [Binding]
    public sealed class InDegreeOfStep : DirectedGraphStepWithDegreeValidator
    {
        public InDegreeOfStep(DirectedGraphBuilder builder, DegreeValidator validator) : base(builder, validator) { }

        [When(@"I get the in degree of the vertex ""(.*)""")]
        public void WhenIGetTheInDegreeOfTheVertex(Vertex vertex)
        {
            _validator.Subject = _builder.Instance.InDegreeOf(vertex);
        }
    }
}
