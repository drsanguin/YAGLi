using NFluent;
using NUnit.Framework;
using System.Collections.Generic;
using YAGLi.Extensions.Collection;

namespace YAGLi.Tests.Extensions.Collection
{
    [TestFixture]
    public class ReplaceByEmptyIfNullExtensionTests
    {
        [Test]
        public void ReplaceByEmptyIfNullExtension_ReplaceByEmptyIfNull_should_return_the_same_instance_if_the_source_is_not_null()
        {
            var source = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Check.That(source.ReplaceByEmptyIfNull()).IsSameReferenceAs(source);
        }

        [Test]
        public void ReplaceByEmptyIfNullExtension_ReplaceByEmptyIfNull_should_return_an_empty_IEnumerable_if_the_source_is_null()
        {
            IEnumerable<int> source = null;

            Check.That(source.ReplaceByEmptyIfNull()).IsEmpty();
        }
    }
}
