using NFluent;
using NUnit.Framework;
using System.Collections.Generic;
using YAGLi.Extensions.Collection;

namespace YAGLi.Tests.Extensions.Collection
{
    [TestFixture]
    public class FilterNullsExtensionTests
    {
        [Test]
        public void FilterNullsExtension_FilterNulls_should_return_a_empty_IEnumerable_if_the_source_is_null()
        {
            IEnumerable<string> source = null;

            Check.That(source.FilterNulls()).IsEmpty();
        }

        [Test]
        public void FilterNullsExtension_FilterNulls_should_filter_nulls()
        {
            var source = new string[]
            {
                null,
                "Hello",
                null,
                ",",
                null,
                "World",
                null,
                "!"
            };

            Check.That(source.FilterNulls()).ContainsExactly("Hello", ",", "World", "!");
        }
    }
}
