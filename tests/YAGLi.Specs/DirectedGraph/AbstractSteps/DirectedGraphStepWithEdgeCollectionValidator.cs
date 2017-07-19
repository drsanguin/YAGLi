using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;

namespace YAGLi.Specs.DirectedGraph.AbstractSteps
{
    [Binding]
    public abstract class DirectedGraphStepWithEdgeCollectionValidator
    {
        protected readonly DirectedGraphBuilder _builder;
        protected readonly EdgeCollectionValidator _validator;

        protected DirectedGraphStepWithEdgeCollectionValidator(DirectedGraphBuilder builder, EdgeCollectionValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }
    }
}
