using TechTalk.SpecFlow;
using YAGLi.Specs.Builders;
using YAGLi.Specs.Validators;

namespace YAGLi.Specs.Steps
{
    [Binding]
    public class AdjacentVerticesOfStep
    {
        UndirectedGraphBuilder _builder;
        VertexCollectionValidator _validator;

        public AdjacentVerticesOfStep(UndirectedGraphBuilder builder, VertexCollectionValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

        [When(@"I retrieve the adjacent vertices of the vertex ""(.*)""")]
        public void WhenIRetrieveTheAdjacentVerticesOfTheVertex(string vertex)
        {
            _validator.Subject = _builder.Instance.AdjacentVerticesOf(vertex);
        }
    }
}
