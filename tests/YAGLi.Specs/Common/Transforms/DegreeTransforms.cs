using TechTalk.SpecFlow;

namespace YAGLi.Specs.Common.Transforms
{
    [Binding]
    public sealed class DegreeTransforms
    {
        [StepArgumentTransformation]
        public Degree TransformsStringToDegree(string degree)
        {
            return int.Parse(degree);
        }
    }
}
