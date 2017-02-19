using NFluent;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGL.Tests
{
    [TestFixture]
    public class UndirectedGraphTests
    {
        [Test]
        public void UndirectedGraph_AllowLoops_should_return_the_value_passed_in_the_constructor()
        {
            UndirectedGraph<string> graph = new UndirectedGraph<string>(true, true);

            Check.That(graph.AllowLoops).IsTrue();
        }

        [Test]
        public void UndirectedGraph_AllowParallelEdges_should_return_the_value_passed_in_the_constructor()
        {
            UndirectedGraph<string> graph = new UndirectedGraph<string>(true, true);

            Check.That(graph.AllowParallelEdges).IsTrue();
        }
    }
}
