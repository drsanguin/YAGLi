using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAGLi.EdgeComparers;
using YAGLi.Extensions;
using YAGLi.Interfaces;

namespace YAGLi
{
    /// <summary>
    /// The class <see cref="UndirectedGraph{TVertex}"/> models graph in which edges have no direction.
    /// The edge (x -- y) is equal to the edge (y -- x).
    /// </summary>
    /// <typeparam name="TVertex">The type of the vertex that the graph store.</typeparam>
    public class UndirectedGraph<TVertex, TEdge> : IModelAUndirectedGraph<TVertex, TEdge> where TEdge : IModelAnEdge<TVertex>
    {
        #region Constants
        private const int UNDIRECTED_GRAPHS_HASH_BASE = 101;
        private const int UNDIRECTED_GRAPHS_HASH_FACTOR = 107;
        #endregion

        #region Instance fields
        /// <summary>
        /// Readonly field who store the incident edges of each vertex contained in this instance.
        /// </summary>
        private readonly IReadOnlyDictionary<TVertex, IEnumerable<TEdge>> _incidentEdges;

        /// <summary>
        /// Readonly field who hold the edge comparison logic specific of this instance.
        /// </summary>
        private readonly IEqualityComparer<TEdge> _edgesComparer;

        /// <summary>
        /// Readonly field who store the object who hold the comparison logic for the vertices.
        /// </summary>
        private readonly IEqualityComparer<TVertex> _verticesComparer;
        #endregion

        #region Constructors
        public UndirectedGraph(bool allowLoops, bool allowParallelEdges) : this(allowLoops, allowParallelEdges, EqualityComparer<TVertex>.Default) { }

        public UndirectedGraph(bool allowLoops, bool allowParallelEdges, IEqualityComparer<TVertex> verticesComparer) : this(allowLoops, allowParallelEdges, Enumerable.Empty<TEdge>(), Enumerable.Empty<TVertex>(), verticesComparer) { }

        public UndirectedGraph(bool allowLoops, bool allowParallelEdges, IEnumerable<TEdge> edges, IEnumerable<TVertex> vertices) : this(allowLoops, allowParallelEdges, edges, vertices, EqualityComparer<TVertex>.Default) { }

        public UndirectedGraph(bool allowLoops, bool allowParallelEdges, IEnumerable<TEdge> edges, IEnumerable<TVertex> vertices, IEqualityComparer<TVertex> verticesComparer)
        {
            AllowLoops = allowLoops;
            AllowParallelEdges = allowParallelEdges;

            verticesComparer = verticesComparer ?? EqualityComparer<TVertex>.Default;
            edges = edges.ReplaceByEmptyIfNull();
            vertices = vertices.ReplaceByEmptyIfNull();

            _edgesComparer = AllowParallelEdges ? new IgnoreDirectionAndAllowParallelEdges<TVertex, TEdge>(verticesComparer) as IEqualityComparer<TEdge> : new IgnoreDirectionAndDisallowParallelEdges<TVertex, TEdge>(verticesComparer);
            _verticesComparer = verticesComparer;

            edges = edges.FilterNulls();
            vertices = vertices.FilterNulls();

            var incidentEdges = new Dictionary<TVertex, IList<TEdge>>(_verticesComparer);
            var distinctEdges = AllowParallelEdges ? edges : edges.Distinct(_edgesComparer);

            foreach (var edge in (!AllowLoops ? distinctEdges.Where(edge => !_verticesComparer.Equals(edge.End1, edge.End2)) : distinctEdges))
            {
                var distinctEnds = _verticesComparer.Equals(edge.End1, edge.End2) ? edge.End1.Yield() : new TVertex[] { edge.End1, edge.End2 };

                foreach (var end in distinctEnds)
                {
                    if (!incidentEdges.ContainsKey(end))
                    {
                        incidentEdges[end] = new List<TEdge>();
                    }

                    incidentEdges[end].Add(edge);
                }
            }

            foreach (var vertex in vertices.Where(vertex => !incidentEdges.ContainsKey(vertex)))
            {
                incidentEdges.Add(vertex, new List<TEdge>(0));
            }

            _incidentEdges = incidentEdges.ToDictionary(x => x.Key, x => x.Value.AsEnumerable(), _verticesComparer);
        }
        #endregion

        #region Properties
        public bool AllowLoops { get; }

        public bool AllowParallelEdges { get; }

        public IEnumerable<TEdge> Edges
        {
            get
            {
                return _incidentEdges
                    .Values
                    .SelectMany(x => x)
                    .Distinct(_edgesComparer);
            }
        }

        public IEnumerable<TVertex> Vertices
        {
            get
            {
                return _incidentEdges.Keys;
            }
        }
        #endregion

        #region Methods
        public IEnumerable<TEdge> AdjacentEdgesOf(TEdge edge)
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
                new ConsiderDirectionAndDisallowParallelEdges<TVertex, TEdge>(_verticesComparer),
                new IgnoreDirectionAndDisallowParallelEdges<TVertex, TEdge>(_verticesComparer)
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
            return Edges
                .Except(edge.Yield(), _edgesComparer)
                .Where(x => areEdgesAdjacent(x, edge));
        }

        public IEnumerable<TVertex> AdjacentVerticesOf(TVertex vertex)
        {
            if (!ContainsVertex(vertex))
            {
                return Enumerable.Empty<TVertex>();
            }

            return _incidentEdges[vertex]
                .SelectMany(edge => new TVertex[] { edge.End1, edge.End2 })
                .Except(vertex.Yield(), _verticesComparer);
        }

        public UndirectedGraph<TVertex, TEdge> AddEdge(TEdge edge)
        {
            return AddEdges(edge.Yield());
        }

        public UndirectedGraph<TVertex, TEdge> AddEdgeAndVertices(TEdge edge)
        {
            return AddEdgesAndVertices(edge.Yield());
        }

        private UndirectedGraph<TVertex, TEdge> addEdges(IEnumerable<TEdge> edges)
        {
            var filteredEdges = edges
                .FilterNulls()
                .FilterEdgesWhoViolatesThisInstanceProperties(this, _verticesComparer);

            if (!filteredEdges.Any())
            {
                return this;
            }

            return new UndirectedGraph<TVertex, TEdge>(AllowLoops, AllowParallelEdges, Edges.Concat(filteredEdges), Vertices, _verticesComparer);
        }

        public UndirectedGraph<TVertex, TEdge> AddEdges(IEnumerable<TEdge> edges)
        {
            return addEdges(edges.FilterEdgesWhosVerticesAreNotContainedInThisGraph(this));
        }

        public UndirectedGraph<TVertex, TEdge> AddEdges(params TEdge[] edges)
        {
            return AddEdges(edges.ReplaceByEmptyIfNull());
        }

        public UndirectedGraph<TVertex, TEdge> AddVertex(TVertex vertex)
        {
            return AddVertices(vertex.Yield());
        }

        public UndirectedGraph<TVertex, TEdge> AddEdgesAndVertices(IEnumerable<TEdge> edges)
        {
            return addEdges(edges);
        }

        public UndirectedGraph<TVertex, TEdge> AddEdgesAndVertices(params TEdge[] edges)
        {
            return AddEdgesAndVertices(edges.ReplaceByEmptyIfNull());
        }

        public UndirectedGraph<TVertex, TEdge> AddVertices(IEnumerable<TVertex> vertices)
        {
            var filteredVertices = vertices
                .ReplaceByEmptyIfNull()
                .FilterNulls();

            if (!filteredVertices.Any())
            {
                return this;
            }

            return new UndirectedGraph<TVertex, TEdge>(AllowLoops, AllowParallelEdges, Edges, Vertices.Concat(filteredVertices), _verticesComparer);
        }

        public UndirectedGraph<TVertex, TEdge> AddVertices(params TVertex[] vertices)
        {
            return AddVertices(vertices
                .ReplaceByEmptyIfNull()
                .FilterNulls());
        }

        private bool areEdgesAdjacent(TEdge edge1, TEdge edge2)
        {
            return _verticesComparer.Equals(edge1.End1, edge2.End1)
                || _verticesComparer.Equals(edge1.End1, edge2.End2)
                || _verticesComparer.Equals(edge1.End2, edge2.End1)
                || _verticesComparer.Equals(edge1.End2, edge2.End2);
        }

        public bool AreEdgesAdjacent(TEdge edge1, TEdge edge2)
        {
            if (!ContainsEdges(edge1, edge2))
            {
                return false;
            }

            return areEdgesAdjacent(edge1, edge2);
        }

        public bool AreVerticesAdjacent(TVertex vertex1, TVertex vertex2)
        {
            return Edges
                .Where(edge => (_verticesComparer.Equals(edge.End1, vertex1) && _verticesComparer.Equals(edge.End2, vertex2)) || (_verticesComparer.Equals(edge.End1, vertex2) && _verticesComparer.Equals(edge.End2, vertex1)))
                .Any();
        }

        public bool ContainsEdge(TEdge edge)
        {
            if (!AllowParallelEdges)
            {
                return Edges.Contains(edge, _edgesComparer);
            }

            return Edges.Contains(edge, _edgesComparer)
                || Edges.Contains(edge, new IgnoreDirectionAndDisallowParallelEdges<TVertex, TEdge>(_verticesComparer));
        }

        public bool ContainsEdges(params TEdge[] edges)
        {
            return ContainsEdges(edges.AsEnumerable());
        }

        public bool ContainsEdges(IEnumerable<TEdge> edges)
        {
            return edges.All(ContainsEdge);
        }

        public bool ContainsVertex(TVertex vertex)
        {
            return _incidentEdges.ContainsKey(vertex);
        }

        public bool ContainsVertices(params TVertex[] vertices)
        {
            return ContainsVertices(vertices.AsEnumerable());
        }

        public bool ContainsVertices(IEnumerable<TVertex> vertices)
        {
            return vertices.All(ContainsVertex);
        }

        public int DegreeOf(TVertex vertex)
        {
            if (!ContainsVertex(vertex))
            {
                return -1;
            }

            return _incidentEdges[vertex].Sum(edge => _verticesComparer.Equals(edge.End1, edge.End2) ? 2 : 1);
        }

        public bool Equals(IModelAUndirectedGraph<TVertex, TEdge> other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(other, this))
            {
                return true;
            }

            if (AllowLoops != other.AllowLoops
                || AllowParallelEdges != other.AllowParallelEdges
                || !Edges.IsEquivalent(other.Edges, new IgnoreDirectionAndDisallowParallelEdges<TVertex, TEdge>(_verticesComparer))
                || !Vertices.IsEquivalent(other.Vertices, _verticesComparer))
            {
                return false;
            }

            return true;
        }

        public bool Equals(IModelAGraph<TVertex, TEdge> other)
        {
            return Equals(other as IModelAUndirectedGraph<TVertex, TEdge>);
        }

        public override bool Equals(object other)
        {
            return Equals(other as IModelAUndirectedGraph<TVertex, TEdge>);
        }

        public override int GetHashCode()
        {
            var hash = UNDIRECTED_GRAPHS_HASH_BASE;

            hash = hash * UNDIRECTED_GRAPHS_HASH_FACTOR + AllowLoops.GetHashCode();
            hash = hash * UNDIRECTED_GRAPHS_HASH_FACTOR + AllowParallelEdges.GetHashCode();
            hash = Edges
                .Select(_edgesComparer.GetHashCode)
                .OrderBy(x => x)
                .Aggregate(hash, (x, y) => x * UNDIRECTED_GRAPHS_HASH_FACTOR + y);
            hash = Vertices
                .Select(_verticesComparer.GetHashCode)
                .OrderBy(x => x)
                .Aggregate(hash, (x, y) => x * UNDIRECTED_GRAPHS_HASH_FACTOR + y);

            return hash;
        }

        public IEnumerable<TEdge> IncidentEdgesOf(TVertex vertex)
        {
            if (!ContainsVertex(vertex))
            {
                return Enumerable.Empty<TEdge>();
            }

            return _incidentEdges[vertex];
        }

        public IEnumerable<TVertex> IncidentVerticesOf(TEdge edge)
        {
            if (!ContainsEdge(edge))
            {
                return Enumerable.Empty<TVertex>();
            }

            if (_verticesComparer.Equals(edge.End1, edge.End2))
            {
                return edge.End1.Yield();
            }

            return new TVertex[] { edge.End1, edge.End2 };
        }

        public UndirectedGraph<TVertex, TEdge> RemoveEdge(TEdge edge)
        {
            return RemoveEdges(edge.Yield());
        }

        public UndirectedGraph<TVertex, TEdge> RemoveEdgeAndVertices(TEdge edge)
        {
            return RemoveEdgesAndVertices(edge.Yield());
        }

        public UndirectedGraph<TVertex, TEdge> RemoveEdges(IEnumerable<TEdge> edges)
        {
            var edgesToRemove = edges
                .ReplaceByEmptyIfNull()
                .FilterNulls()
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
            var inputEdges = edges.ToList();
            var referenceEdges = Edges.ToList();
            var mappedEdges = new List<TEdge>();

            var comparers = new IEqualityComparer<TEdge>[]
            {
                _edgesComparer,
                new ConsiderDirectionAndDisallowParallelEdges<TVertex, TEdge>(_verticesComparer),
                new IgnoreDirectionAndDisallowParallelEdges<TVertex, TEdge>(_verticesComparer)
            };

            foreach (var comparer in comparers)
            {
                for (var i = inputEdges.Count - 1; i >= 0; i--)
                {
                    if (!referenceEdges.Contains(inputEdges[i], comparer))
                    {
                        continue;
                    }

                    var firstReferenceToMatch = referenceEdges.First(x => comparer.Equals(inputEdges[i], x));

                    mappedEdges.Add(firstReferenceToMatch);
                    referenceEdges.Remove(firstReferenceToMatch);
                    inputEdges.RemoveAt(i);
                }

                if (!inputEdges.Any())
                {
                    break;
                }
            }

            return removeEdgesWhenGraphDisallowParallelEdges(mappedEdges);
        }

        private UndirectedGraph<TVertex, TEdge> removeEdgesWhenGraphDisallowParallelEdges(IEnumerable<TEdge> edges)
        {
            return new UndirectedGraph<TVertex, TEdge>(AllowLoops, AllowParallelEdges, Edges.Except(edges, _edgesComparer), Vertices, _verticesComparer);
        }

        public UndirectedGraph<TVertex, TEdge> RemoveEdges(params TEdge[] edges)
        {
            return RemoveEdges(edges.AsEnumerable());
        }

        public UndirectedGraph<TVertex, TEdge> RemoveEdgesAndVertices(IEnumerable<TEdge> edges)
        {
            var edgesToRemove = edges
                .ReplaceByEmptyIfNull()
                .FilterNulls()
                .Where(edge => ContainsEdge(edge));

            if (!edgesToRemove.Any())
            {
                return this;
            }

            var verticesToRemove = edgesToRemove
                .Select(x => new[] { x.End1, x.End2 })
                .SelectMany(x => x)
                .Distinct(_verticesComparer);

            return new UndirectedGraph<TVertex, TEdge>(AllowLoops, AllowParallelEdges, Edges.Where(x => !verticesToRemove.Contains(x.End1, _verticesComparer) && !verticesToRemove.Contains(x.End2, _verticesComparer)), Vertices.Except(verticesToRemove, _verticesComparer), _verticesComparer);
        }

        public UndirectedGraph<TVertex, TEdge> RemoveEdgesAndVertices(params TEdge[] edges)
        {
            return RemoveEdgesAndVertices(edges.AsEnumerable());
        }

        public UndirectedGraph<TVertex, TEdge> RemoveVertex(TVertex vertex)
        {
            return RemoveVertices(vertex.Yield());
        }

        public UndirectedGraph<TVertex, TEdge> RemoveVertices(IEnumerable<TVertex> vertices)
        {
            if (ReferenceEquals(vertices, null))
            {
                return this;
            }

            var verticesToRemove = vertices
                .Where(vertex => !ReferenceEquals(vertex, null))
                .Where(vertex => Vertices.Contains(vertex));

            if (!verticesToRemove.Any())
            {
                return this;
            }

            var verticesToKeep = Vertices.Except(verticesToRemove, _verticesComparer);
            var edgesToKeep = Edges.Where(edge => verticesToKeep.Contains(edge.End1, _verticesComparer) && verticesToKeep.Contains(edge.End2, _verticesComparer));

            return new UndirectedGraph<TVertex, TEdge>(AllowLoops, AllowParallelEdges, edgesToKeep, verticesToKeep, _verticesComparer);
        }

        public UndirectedGraph<TVertex, TEdge> RemoveVertices(params TVertex[] vertices)
        {
            return RemoveVertices(vertices.AsEnumerable());
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
