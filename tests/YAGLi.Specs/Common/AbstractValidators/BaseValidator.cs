using TechTalk.SpecFlow;

namespace YAGLi.Specs.Common.AbstractValidators
{
    [Binding]
    public abstract class BaseValidator<TSubject>
    {
        public TSubject Subject { get; set; }
    }
}
