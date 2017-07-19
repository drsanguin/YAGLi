using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;

namespace YAGLi.Specs.DirectedGraph.AbstractSteps
{
    [Binding]
    public abstract class DirectedGraphStepWithGraphValidator
    {
        protected readonly DirectedGraphBuilder _builder;
        protected readonly GraphValidator _validator;

        public DirectedGraphStepWithGraphValidator(DirectedGraphBuilder builder, GraphValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }
    }
}
