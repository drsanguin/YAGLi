using NFluent;
using NUnit.Framework;
using YAGLi.Extensions;

namespace YAGLi.Tests.Extensions
{
    [TestFixture]
    public class YieldExtensionTests
    {
        [Test]
        public void YieldExtension_Yield_should_return_a_empty_IEnumerable_if_the_item_is_equal_to_null()
        {
            object item = null;

            Check.That(item.Yield()).IsEmpty();
        }

        [Test]
        public void YieldExtension_Yield_should_return_IEnumerable_containing_the_single_item()
        {
            object item = new object();

            Check.That(item.Yield()).ContainsExactly(item);
        }
    }
}
