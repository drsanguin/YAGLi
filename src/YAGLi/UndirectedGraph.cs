using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAGLi.EdgeComparers;
using YAGLi.Extensions;
using YAGLi.Extensions.Collection;
using YAGLi.Extensions.EdgeCollection;
using YAGLi.Interfaces;

namespace YAGLi
{
    /// <summary>
    /// The class <see cref="UndirectedGraph{TVertex}"/> models graph in which edges have no direction.
    /// The edge (x -- y) is equal to the edge (y -- x).
    /// </summary>
    /// <typeparam name="TVertex">The type of the vertex that the graph store.</typeparam>
    public class UndirectedGraph<TVertex, TEdge> : AbstractGraph<TVertex, TEdge, UndirectedGraph<TVertex, TEdge>> , IModelAUndirectedGraph<TVertex, TEdge> where TEdge : IModelAnEdge<TVertex>
    {
        #region Constants
        private const int UNDIRECTED_GRAPHS_HASH_BASE = 101;
        private const int UNDIRECTED_GRAPHS_HASH_FACTOR = 107;
        #endregion

        #region Fields
        /// <summary>
        /// Readonly field who store the incident edges of each vertex contained in this instance.
        /// </summary>
        private readonly IReadOnlyDictionary<TVertex, IEnumerable<TEdge>> _incidentEdges;

        /// <summary>
        /// Readonly field who hold the edge comparison logic specific of this instance.
        /// </summary>
        private readonly IEqualityComparer<TEdge> _edgesComparer;
        #endregion

        #region Constructors
        public UndirectedGraph(bool allowLoops, bool allowParallelEdges) : this(allowLoops, allowParallelEdges, EqualityComparer<TVertex>.Default) { }

        public UndirectedGraph(bool allowLoops, bool allowParallelEdges, IEqualityComparer<TVertex> verticesComparer) : this(allowLoops, allowParallelEdges, Enumerable.Empty<TEdge>(), Enumerable.Empty<TVertex>(), verticesComparer) { }

        public UndirectedGraph(bool allowLoops, bool allowParallelEdges, IEnumerable<TEdge> edges, IEnumerable<TVertex> vertices) : this(allowLoops, allowParallelEdges, edges, vertices, EqualityComparer<TVertex>.Default) { }

        public UndirectedGraph(bool allowLoops, bool allowParallelEdges, IEnumerable<TEdge> edges, IEnumerable<TVertex> vertices, IEqualityComparer<TVertex> verticesComparer) : base(allowLoops, allowParallelEdges, verticesComparer)
        {
            _edgesComparer = AllowParallelEdges ? new IgnoreDirectionAndAllowParallelEdges<TVertex, TEdge>(VerticesComparer) as IEqualityComparer<TEdge> : new IgnoreDirectionAndDisallowParallelEdges<TVertex, TEdge>(VerticesComparer);

            var filteredEdges = edges.ReplaceByEmptyIfNull()
                                     .FilterNulls()
                                     .FilterEdgesWithNullVertices<TVertex, TEdge>()
                                     .Where(edge => !AllowLoops ? !VerticesComparer.Equals(edge.End1, edge.End2) : true)
                                     .Distinct(_edgesComparer);

            var filteredVertices = vertices.ReplaceByEmptyIfNull()
                                           .FilterNulls()
                                           .Distinct(VerticesComparer);

            var incidentEdges = new Dictionary<TVertex, IList<TEdge>>(VerticesComparer);

            foreach (var edge in filteredEdges)
            {
                var distinctEnds = VerticesComparer.Equals(edge.End1, edge.End2) ? edge.End1.Yield() : new TVertex[] { edge.End1, edge.End2 };

                foreach (var end in distinctEnds)
                {
                    if (!incidentEdges.ContainsKey(end))
                    {
                        incidentEdges[end] = new List<TEdge>();
                    }

                    incidentEdges[end].Add(edge);
                }
            }

            foreach (var vertex in filteredVertices.Where(vertex => !incidentEdges.ContainsKey(vertex)))
            {
                incidentEdges.Add(vertex, new List<TEdge>(0));
            }

            _incidentEdges = incidentEdges.ToDictionary(x => x.Key, x => x.Value.AsEnumerable(), VerticesComparer);
        }
        #endregion

        #region Properties

        public override IEnumerable<TEdge> Edges
        {
            get
            {
                return _incidentEdges.Values
                                     .SelectMany(edge => edge)
                                     .Distinct(_edgesComparer);
            }
        }

        public override IEnumerable<TVertex> Vertices
        {
            get
            {
                return _incidentEdges.Keys;
            }
        }
        #endregion

        #region Methods
        public override IEnumerable<TEdge> AdjacentEdgesOf(TEdge edge)
        {
            if (!ContainsEdge(edge))
            {
                return Enumerable.Empty<TEdge>();
            }

            return AllowParallelEdges ? adjacentEdgesWhenGraphAllowParallelEdges(edge) : adjacentEdgesWhenGraphDisallowParallelEdges(edge);
        }

        private IEnumerable<TEdge> adjacentEdgesWhenGraphAllowParallelEdges(TEdge edge)
        {
            var comparers = new IEqualityComparer<TEdge>[]
            {
                _edgesComparer,
                new ConsiderDirectionAndDisallowParallelEdges<TVertex, TEdge>(VerticesComparer),
                new IgnoreDirectionAndDisallowParallelEdges<TVertex, TEdge>(VerticesComparer)
            };

            TEdge mappedEdge = edge;

            foreach (var comparer in comparers)
            {
                if (!Edges.Contains(edge, comparer))
                {
                    continue;
                }

                mappedEdge = Edges.First(x => comparer.Equals(x, edge));
            }

            return adjacentEdgesWhenGraphDisallowParallelEdges(mappedEdge);
        }

        private IEnumerable<TEdge> adjacentEdgesWhenGraphDisallowParallelEdges(TEdge edge)
        {
            return Edges.Except(edge.Yield(), _edgesComparer)
                        .Where(x => AreEdgesAdjacentImpl(x, edge));
        }

        public override IEnumerable<TVertex> AdjacentVerticesOf(TVertex vertex)
        {
            if (!ContainsVertex(vertex))
            {
                return Enumerable.Empty<TVertex>();
            }

            return _incidentEdges[vertex].SelectMany(edge => new TVertex[] { edge.End1, edge.End2 })
                                         .Except(vertex.Yield(), VerticesComparer);
        }

        public override UndirectedGraph<TVertex, TEdge> AddEdge(TEdge edge)
        {
            return AddEdges(edge.Yield());
        }

        public override UndirectedGraph<TVertex, TEdge> AddEdgeAndVertices(TEdge edge)
        {
            return AddEdgesAndVertices(edge.Yield());
        }

        private UndirectedGraph<TVertex, TEdge> addEdges(IEnumerable<TEdge> edges)
        {
            var filteredEdges = edges.FilterNulls()
                                     .FilterEdgesWhoViolatesThisInstanceProperties(this, VerticesComparer);

            if (!filteredEdges.Any())
            {
                return this;
            }

            return new UndirectedGraph<TVertex, TEdge>(AllowLoops, AllowParallelEdges, Edges.Concat(filteredEdges), Vertices, VerticesComparer);
        }

        public override UndirectedGraph<TVertex, TEdge> AddEdges(IEnumerable<TEdge> edges)
        {
            return addEdges(edges.FilterEdgesWithNullVertices<TVertex, TEdge>()
                                 .FilterEdgesWhosVerticesAreNotContainedInThisGraph(this));
        }

        public override UndirectedGraph<TVertex, TEdge> AddEdges(params TEdge[] edges)
        {
            return AddEdges(edges.ReplaceByEmptyIfNull());
        }

        public override UndirectedGraph<TVertex, TEdge> AddVertex(TVertex vertex)
        {
            return AddVertices(vertex.Yield());
        }

        public override UndirectedGraph<TVertex, TEdge> AddEdgesAndVertices(IEnumerable<TEdge> edges)
        {
            return addEdges(edges.FilterEdgesWithNullVertices<TVertex, TEdge>());
        }

        public override UndirectedGraph<TVertex, TEdge> AddEdgesAndVertices(params TEdge[] edges)
        {
            return AddEdgesAndVertices(edges.ReplaceByEmptyIfNull());
        }

        public override UndirectedGraph<TVertex, TEdge> AddVertices(IEnumerable<TVertex> vertices)
        {
            var filteredVertices = vertices.ReplaceByEmptyIfNull()
                                           .FilterNulls();

            if (!filteredVertices.Any())
            {
                return this;
            }

            return new UndirectedGraph<TVertex, TEdge>(AllowLoops, AllowParallelEdges, Edges, Vertices.Concat(filteredVertices), VerticesComparer);
        }

        public override UndirectedGraph<TVertex, TEdge> AddVertices(params TVertex[] vertices)
        {
            return AddVertices(vertices.ReplaceByEmptyIfNull()
                                       .FilterNulls());
        }

        public override bool AreEdgesAdjacent(TEdge edge1, TEdge edge2)
        {
            if (!ContainsEdges(edge1, edge2))
            {
                return false;
            }

            return AreEdgesAdjacentImpl(edge1, edge2);
        }

        public override bool ContainsEdge(TEdge edge)
        {
            if (!AllowParallelEdges)
            {
                return Edges.Contains(edge, _edgesComparer);
            }

            return Edges.Contains(edge, _edgesComparer)
                || Edges.Contains(edge, new IgnoreDirectionAndDisallowParallelEdges<TVertex, TEdge>(VerticesComparer));
        }

        public override bool ContainsEdges(params TEdge[] edges)
        {
            return ContainsEdges(edges.AsEnumerable());
        }

        public override bool ContainsEdges(IEnumerable<TEdge> edges)
        {
            return edges.All(ContainsEdge);
        }

        public override bool ContainsVertex(TVertex vertex)
        {
            return _incidentEdges.ContainsKey(vertex);
        }

        public override bool ContainsVertices(params TVertex[] vertices)
        {
            return ContainsVertices(vertices.AsEnumerable());
        }

        public override bool ContainsVertices(IEnumerable<TVertex> vertices)
        {
            return vertices.All(ContainsVertex);
        }

        public override int DegreeOf(TVertex vertex)
        {
            if (!ContainsVertex(vertex))
            {
                return -1;
            }

            return _incidentEdges[vertex].Sum(edge => VerticesComparer.Equals(edge.End1, edge.End2) ? 2 : 1);
        }

        public bool Equals(IModelAUndirectedGraph<TVertex, TEdge> other)
        {
            return Equals(other, new IgnoreDirectionAndDisallowParallelEdges<TVertex, TEdge>(VerticesComparer));
        }

        public override bool Equals(IModelAGraph<TVertex, TEdge> other)
        {
            return Equals(other as IModelAUndirectedGraph<TVertex, TEdge>);
        }

        public override bool Equals(object other)
        {
            return Equals(other as IModelAUndirectedGraph<TVertex, TEdge>);
        }

        public override int GetHashCode()
        {
            return GetHashCode(UNDIRECTED_GRAPHS_HASH_BASE, UNDIRECTED_GRAPHS_HASH_FACTOR, _edgesComparer);
        }

        public override IEnumerable<TEdge> IncidentEdgesOf(TVertex vertex)
        {
            if (!ContainsVertex(vertex))
            {
                return Enumerable.Empty<TEdge>();
            }

            return _incidentEdges[vertex];
        }

        public override IEnumerable<TVertex> IncidentVerticesOf(TEdge edge)
        {
            if (!ContainsEdge(edge))
            {
                return Enumerable.Empty<TVertex>();
            }

            if (VerticesComparer.Equals(edge.End1, edge.End2))
            {
                return edge.End1.Yield();
            }

            return new TVertex[] { edge.End1, edge.End2 };
        }

        public override IEnumerable<TVertex> NeighborsOf(TVertex vertex)
        {
            if (ReferenceEquals(vertex, null) || !_incidentEdges.ContainsKey(vertex))
            {
                return Enumerable.Empty<TVertex>();
            }

            return _incidentEdges[vertex].Select(edge => VerticesComparer.Equals(vertex, edge.End1) ? edge.End2 : edge.End1)
                                         .Distinct(VerticesComparer);
        }

        public override UndirectedGraph<TVertex, TEdge> RemoveEdge(TEdge edge)
        {
            return RemoveEdges(edge.Yield());
        }

        public override UndirectedGraph<TVertex, TEdge> RemoveEdgeAndVertices(TEdge edge)
        {
            return RemoveEdgesAndVertices(edge.Yield());
        }

        public override UndirectedGraph<TVertex, TEdge> RemoveEdges(IEnumerable<TEdge> edges)
        {
            var edgesToRemove = edges.ReplaceByEmptyIfNull()
                                     .FilterNulls()
                                     .FilterEdgesWithNullVertices<TVertex, TEdge>()
                                     .Distinct(_edgesComparer)
                                     .Where(edge => ContainsEdge(edge));

            if (!edgesToRemove.Any())
            {
                return this;
            }

            return AllowParallelEdges ? removeEdgesWhenGraphAllowParallelEdges(edges) : removeEdgesWhenGraphDisallowParallelEdges(edges);
        }

        private UndirectedGraph<TVertex, TEdge> removeEdgesWhenGraphAllowParallelEdges(IEnumerable<TEdge> edges)
        {
            var mappedEdges = edges.MapEdgesWithTheEdgesOfAGraph(this, _edgesComparer, new ConsiderDirectionAndDisallowParallelEdges<TVertex, TEdge>(VerticesComparer), new IgnoreDirectionAndDisallowParallelEdges<TVertex, TEdge>(VerticesComparer));

            return removeEdgesWhenGraphDisallowParallelEdges(mappedEdges);
        }

        private UndirectedGraph<TVertex, TEdge> removeEdgesWhenGraphDisallowParallelEdges(IEnumerable<TEdge> edges)
        {
            return new UndirectedGraph<TVertex, TEdge>(AllowLoops, AllowParallelEdges, Edges.Except(edges, _edgesComparer), Vertices, VerticesComparer);
        }

        public override UndirectedGraph<TVertex, TEdge> RemoveEdges(params TEdge[] edges)
        {
            return RemoveEdges(edges.AsEnumerable());
        }

        public override UndirectedGraph<TVertex, TEdge> RemoveEdgesAndVertices(IEnumerable<TEdge> edges)
        {
            var edgesToRemove = edges.ReplaceByEmptyIfNull()
                                     .FilterNulls()
                                     .FilterEdgesWithNullVertices<TVertex, TEdge>()
                                     .Where(edge => ContainsEdge(edge));

            if (!edgesToRemove.Any())
            {
                return this;
            }

            var verticesToRemove = edgesToRemove.Select(edge => new[] { edge.End1, edge.End2 })
                                                .SelectMany(vertexArray => vertexArray)
                                                .Distinct(VerticesComparer);

            return new UndirectedGraph<TVertex, TEdge>(AllowLoops, AllowParallelEdges, Edges.Where(edge => !verticesToRemove.Contains(edge.End1, VerticesComparer) && !verticesToRemove.Contains(edge.End2, VerticesComparer)), Vertices.Except(verticesToRemove, VerticesComparer), VerticesComparer);
        }

        public override UndirectedGraph<TVertex, TEdge> RemoveEdgesAndVertices(params TEdge[] edges)
        {
            return RemoveEdgesAndVertices(edges.AsEnumerable());
        }

        public override UndirectedGraph<TVertex, TEdge> RemoveVertex(TVertex vertex)
        {
            return RemoveVertices(vertex.Yield());
        }

        public override UndirectedGraph<TVertex, TEdge> RemoveVertices(IEnumerable<TVertex> vertices)
        {
            if (ReferenceEquals(vertices, null))
            {
                return this;
            }

            var verticesToRemove = vertices.Where(vertex => !ReferenceEquals(vertex, null))
                                           .Where(vertex => Vertices.Contains(vertex));

            if (!verticesToRemove.Any())
            {
                return this;
            }

            var verticesToKeep = Vertices.Except(verticesToRemove, VerticesComparer);
            var edgesToKeep = Edges.Where(edge => verticesToKeep.Contains(edge.End1, VerticesComparer) && verticesToKeep.Contains(edge.End2, VerticesComparer));

            return new UndirectedGraph<TVertex, TEdge>(AllowLoops, AllowParallelEdges, edgesToKeep, verticesToKeep, VerticesComparer);
        }

        public override UndirectedGraph<TVertex, TEdge> RemoveVertices(params TVertex[] vertices)
        {
            return RemoveVertices(vertices.AsEnumerable());
        }

        public override IEnumerable<TEdge> PathsToNeighborsOf(TVertex vertex)
        {
            if (ReferenceEquals(vertex, null) || !_incidentEdges.ContainsKey(vertex))
            {
                return Enumerable.Empty<TEdge>();
            }

            return _incidentEdges[vertex];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("{");
            sb.AppendLine($"    {nameof(AllowLoops)} = {AllowLoops}");
            sb.AppendLine($"    {nameof(AllowParallelEdges)} = {AllowParallelEdges}");
            sb.AppendLine($"    {nameof(Vertices)} = [{string.Join(", ", Vertices)}]");
            sb.AppendLine($"    {nameof(Edges)} = [");
            sb.AppendLine(string.Join($",{Environment.NewLine}", Edges.Select(edge => $"        ({edge.End1} - {edge.End2})")));
            sb.AppendLine("    ]");
            sb.Append("}");

            return sb.ToString();
        }
        #endregion
    }
}
