using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Specs.UndirectedGraph;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    [Binding]
    public class IncidentEdgesOfStep
    {
        private readonly UndirectedGraphBuilder _builder;
        private readonly EdgeCollectionValidator _validator;

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
