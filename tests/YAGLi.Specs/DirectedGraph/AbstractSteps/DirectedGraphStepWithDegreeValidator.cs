using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;

namespace YAGLi.Specs.DirectedGraph.AbstractSteps
{
    [Binding]
    public abstract class DirectedGraphStepWithDegreeValidator
    {
        protected DirectedGraphStepWithDegreeValidator(DirectedGraphBuilder builder, DegreeValidator validator)
        {
            Builder = builder;
            Validator = validator;
        }

        protected DirectedGraphBuilder Builder { get; }
        protected DegreeValidator Validator { get; }
    }
}
