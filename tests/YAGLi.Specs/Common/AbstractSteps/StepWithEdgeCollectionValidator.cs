using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;

namespace YAGLi.Specs.Common.AbstractSteps
{
    [Binding]
    public abstract class StepWithEdgeCollectionValidator
    {
        protected readonly GraphBuilder Builder;
        protected readonly EdgeCollectionValidator Validator;

        protected StepWithEdgeCollectionValidator(GraphBuilder builder, EdgeCollectionValidator validator)
        {
            Builder = builder;
            Validator = validator;
        }
    }
}
