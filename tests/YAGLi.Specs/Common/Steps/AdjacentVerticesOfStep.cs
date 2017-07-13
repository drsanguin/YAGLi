using TechTalk.SpecFlow;
using YAGLi.Specs.Common.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Common.Steps
{
    [Binding]
    public class AdjacentVerticesOfStep
    {
        private readonly GraphBuilder _builder;
        private readonly VertexCollectionValidator _validator;

        public AdjacentVerticesOfStep(GraphBuilder builder, VertexCollectionValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

        [When(@"I retrieve the adjacent vertices of the vertex ""(.*)""")]
        public void WhenIRetrieveTheAdjacentVerticesOfTheVertex(Vertex vertex)
        {
            _validator.Subject = _builder.Instance.AdjacentVerticesOf(vertex);
        }
    }
}
