using NFluent;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using YAGLi.Extensions.Collection;

namespace YAGLi.Tests.Extensions.Collection
{
    [TestFixture]
    public class ForEachExtensionTests
    {
        [Test]
        public void ForEachExtension_should_call_the_action_for_each_element_of_the_collection()
        {
            var collection = Enumerable.Range(0, 10);
            var collection2 = new List<int>(collection.Count());
            Action<int> action = x => collection2.Add(x);

            collection.ForEach(action);

            Check.That(collection2).ContainsExactly(collection);
        }

        [Test]
        public void ForEachExtension_should_not_throw_with_a_null_collection()
        {
            IEnumerable<int> collection = null;
            Action<int> action = x => { };

            Check.ThatCode(() => collection.ForEach(action)).DoesNotThrow();
        }
    }
}
