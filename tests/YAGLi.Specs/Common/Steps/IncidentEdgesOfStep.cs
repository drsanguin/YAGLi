using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    [Binding]
    public class IncidentEdgesOfStep
    {
        private readonly GraphBuilder _builder;
        private readonly EdgeCollectionValidator _validator;

        public IncidentEdgesOfStep(GraphBuilder builder, EdgeCollectionValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

        [When(@"I retrieve the incident edges of the vertex ""(.*)""")]
        public void WhenIRetrieveTheIncidentEdgesOfTheVertex(Vertex vertex)
        {
            _validator.Subject = _builder.Instance.IncidentEdgesOf(vertex);
        }
    }
}
