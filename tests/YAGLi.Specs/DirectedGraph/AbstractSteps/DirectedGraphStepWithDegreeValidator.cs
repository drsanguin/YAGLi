using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;

namespace YAGLi.Specs.DirectedGraph.AbstractSteps
{
    [Binding]
    public abstract class DirectedGraphStepWithDegreeValidator
    {
        protected readonly DirectedGraphBuilder _builder;
        protected readonly DegreeValidator _validator;

        protected DirectedGraphStepWithDegreeValidator(DirectedGraphBuilder builder, DegreeValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }
    }
}
