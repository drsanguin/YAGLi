using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;

namespace YAGLi.Specs.DirectedGraph.AbstractSteps
{
    [Binding]
    public abstract class DirectedGraphStepWithGraphValidator
    {
        public DirectedGraphStepWithGraphValidator(DirectedGraphBuilder builder, GraphValidator validator)
        {
            Builder = builder;
            Validator = validator;
        }

        protected DirectedGraphBuilder Builder { get; }
        protected GraphValidator Validator { get; }
    }
}
