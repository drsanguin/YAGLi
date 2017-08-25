using NFluent;
using NUnit.Framework;
using System;
using YAGLi.Tests.Utils;

namespace YAGLi.Tests.DirectedGraph
{
    [TestFixture(TestOf = typeof(DirectedGraph<Vertex, Edge<Vertex>>))]
    public class DirectedGraphCtorDefensiveCodeTests
    {
        private Action _ctor;

        [TearDown]
        public void TearDown()
        {
            Check.ThatCode(_ctor).DoesNotThrow();
        }

        [Test]
        public void ctor_should_not_throw_if_the_edges_are_null()
        {
            _ctor = () => new DirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                null,
                new Vertex[]
                {
                    "v0",
                    "v1",
                    "v2",
                    "v3",
                    "v4"
                });
        }

        [Test]
        public void ctor_should_not_throw_if_the_vertices_are_null()
        {
            _ctor = () => new DirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v3")
                },
                null);
        }

        [Test]
        public void ctor_should_not_throw_if_the_edges_contains_a_null()
        {
            _ctor = () => new DirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    null,
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v3")
                },
                new Vertex[]
                {
                    "v0",
                    "v1",
                    "v2",
                    "v3",
                    "v4"
                });
        }

        [Test]
        public void ctor_should_not_throw_if_the_edges_contains_an_edge_with_a_null_vertex()
        {
            _ctor = () => new DirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    null,
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v3"),
                    new Edge<Vertex>("v4", null)
                },
                new Vertex[]
                {
                    "v0",
                    "v1",
                    "v2",
                    "v3",
                    "v4"
                });
        }

        [Test]
        public void ctor_should_not_throw_if_the_vertices_contains_a_null()
        {
            _ctor = () => new DirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v3")
                },
                new Vertex[]
                {
                    null,
                    "v1",
                    "v2",
                    "v3",
                    "v4"
                });
        }

        [Test]
        public void ctor_should_not_throw_if_the_vertex_comparer_is_null()
        {
            _ctor = () => new DirectedGraph<Vertex, Edge<Vertex>>(
                true,
                true,
                new Edge<Vertex>[]
                {
                    new Edge<Vertex>("v0", "v1"),
                    new Edge<Vertex>("v1", "v4"),
                    new Edge<Vertex>("v4", "v4"),
                    new Edge<Vertex>("v3", "v4"),
                    new Edge<Vertex>("v4", "v3")
                },
                new Vertex[]
                {
                    "v0",
                    "v1",
                    "v2",
                    "v3",
                    "v4"
                }, null);
        }
    }
}
