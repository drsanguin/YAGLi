using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;

namespace YAGLi.Specs.UndirectedGraph.Steps
{
    [Binding]
    public abstract class UndirectedGraphStepWithGraphValidator
    {
        protected readonly UndirectedGraphBuilder Builder;
        protected readonly GraphValidator Validator;

        protected UndirectedGraphStepWithGraphValidator(UndirectedGraphBuilder builder, GraphValidator validator)
        {
            Builder = builder;
            Validator = validator;
        }
    }
}
