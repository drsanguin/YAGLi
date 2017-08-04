using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Builders;
using YAGLi.Specs.Common.Validators;

namespace YAGLi.Specs.Common.AbstractSteps
{
    [Binding]
    public abstract class StepWithEdgeCollectionValidator
    {
        protected StepWithEdgeCollectionValidator(GraphBuilder builder, EdgeCollectionValidator validator)
        {
            Builder = builder;
            Validator = validator;
        }

        protected GraphBuilder Builder { get; }
        protected EdgeCollectionValidator Validator { get; }
    }
}
