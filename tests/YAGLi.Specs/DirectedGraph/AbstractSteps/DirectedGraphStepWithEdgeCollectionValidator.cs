using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Specs.DirectedGraph.Builders;

namespace YAGLi.Specs.DirectedGraph.AbstractSteps
{
    [Binding]
    public abstract class DirectedGraphStepWithEdgeCollectionValidator
    {
        protected DirectedGraphStepWithEdgeCollectionValidator(DirectedGraphBuilder builder, EdgeCollectionValidator validator)
        {
            Builder = builder;
            Validator = validator;
        }

        protected DirectedGraphBuilder Builder { get; }
        protected EdgeCollectionValidator Validator { get; }
    }
}
