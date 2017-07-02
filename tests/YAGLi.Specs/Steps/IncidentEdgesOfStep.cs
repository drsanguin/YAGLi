using TechTalk.SpecFlow;
using YAGLi.Specs.Builders;
using YAGLi.Specs.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Steps
{
    [Binding]
    public class IncidentEdgesOfStep
    {
        UndirectedGraphBuilder _builder;
        EdgeCollectionValidator _validator;

        public IncidentEdgesOfStep(UndirectedGraphBuilder builder, EdgeCollectionValidator validator)
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
