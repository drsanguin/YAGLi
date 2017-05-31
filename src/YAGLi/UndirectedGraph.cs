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
    public class UndirectedGraph<TVertex> : IModelAUndirectedGraph<TVertex>
    {
        #region Constants
        private const int UNDIRECTED_GRAPHS_HASH_BASE = 101;
        private const int UNDIRECTED_GRAPHS_HASH_FACTOR = 107;
        #endregion

        #region Instance fields
        /// <summary>
        /// Readonly field who store the incident edges of each vertex contained in this instance.
        /// </summary>
        private readonly IReadOnlyDictionary<TVertex, IEnumerable<Edge<TVertex>>> _incidentEdges;

        /// <summary>
        /// Readonly field who hold the edge comparison logic specific of this instance.
        /// </summary>
        private readonly IEqualityComparer<Edge<TVertex>> _edgesComparer;

        /// <summary>
        /// Readonly field who store the object who hold the comparison logic for the vertices.
        /// </summary>
        private readonly IEqualityComparer<TVertex> _verticesComparer;
        #endregion

        #region Constructors
        public UndirectedGraph(bool allowLoops, bool allowParallelEdges) : this(allowLoops, allowParallelEdges, EqualityComparer<TVertex>.Default) { }

        public UndirectedGraph(bool allowLoops, bool allowParallelEdges, IEqualityComparer<TVertex> verticesComparer) : this(allowLoops, allowParallelEdges, Enumerable.Empty<Edge<TVertex>>(), Enumerable.Empty<TVertex>(), verticesComparer) { }

        public UndirectedGraph(bool allowLoops, bool allowParallelEdges, IEnumerable<Edge<TVertex>> edges, IEnumerable<TVertex> vertices) : this(allowLoops, allowParallelEdges, edges, vertices, EqualityComparer<TVertex>.Default) { }

        public UndirectedGraph(bool allowLoops, bool allowParallelEdges, IEnumerable<Edge<TVertex>> edges, IEnumerable<TVertex> vertices, IEqualityComparer<TVertex> verticesComparer)
        {
            AllowLoops = allowLoops;
            AllowParallelEdges = allowParallelEdges;

            _edgesComparer = AllowParallelEdges ? new IgnoreDirectionAndAllowParallelEdges<TVertex>(verticesComparer) as IEqualityComparer<Edge<TVertex>> : new IgnoreDirectionAndDisallowParallelEdges<TVertex>(verticesComparer);
            _verticesComparer = verticesComparer;

            var incidentEdges = new Dictionary<TVertex, IList<Edge<TVertex>>>(_verticesComparer);
            var distinctEdges = AllowParallelEdges ? edges : edges.Distinct(_edgesComparer);

            foreach (var edge in (!AllowLoops ? distinctEdges.Where(edge => !_verticesComparer.Equals(edge.End1, edge.End2)) : distinctEdges))
            {
                var distinctEnds = _verticesComparer.Equals(edge.End1, edge.End2) ? edge.End1.Yield() : new TVertex[] { edge.End1, edge.End2 };

                foreach (var end in distinctEnds)
                {
                    if (!incidentEdges.ContainsKey(end))
                    {
                        incidentEdges[end] = new List<Edge<TVertex>>();
                    }

                    incidentEdges[end].Add(edge);
                }
            }

            foreach (var vertex in vertices.Where(vertex => !incidentEdges.ContainsKey(vertex)))
            {
                incidentEdges.Add(vertex, new List<Edge<TVertex>>(0));
            }

            _incidentEdges = incidentEdges.ToDictionary(x => x.Key, x => x.Value.AsEnumerable(), _verticesComparer);
        }
        #endregion

        #region Properties
        public bool AllowLoops { get; }

        public bool AllowParallelEdges { get; }

        public IEnumerable<Edge<TVertex>> Edges
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
        public IEnumerable<Edge<TVertex>> AdjacentEdgesOf(Edge<TVertex> edge)
        {
            if (!ContainsEdge(edge))
            {
                return Enumerable.Empty<Edge<TVertex>>();
            }

            return Edges.Where(x => !_edgesComparer.Equals(edge, x) && Edge<TVertex>.AreAdjacent(x, edge, _verticesComparer));
        }

        public IEnumerable<TVertex> AdjacentVerticesOf(TVertex vertex)
        {
            if (!ContainsVertex(vertex))
            {
                return Enumerable.Empty<TVertex>();
            }

            return _incidentEdges[vertex].SelectMany(edge => new TVertex[] { edge.End1, edge.End2 }).Where(v => !_verticesComparer.Equals(v, vertex));
        }

        public UndirectedGraph<TVertex> AddEdge(Edge<TVertex> edge)
        {
            return AddEdges(edge.Yield());
        }

        public UndirectedGraph<TVertex> AddEdgeAndVertices(Edge<TVertex> edge)
        {
            return AddEdgesAndVertices(edge.Yield());
        }

        private IEnumerable<Edge<TVertex>> filterEdgesWhosVerticesAreNotContainedInThisInstance(IEnumerable<Edge<TVertex>> edges)
        {
            return edges.Where(edge => ContainsVertices(edge.End1, edge.End2));
        }

        private IEnumerable<Edge<TVertex>> filterEdgesWhoViolatesThisInstanceProperties(IEnumerable<Edge<TVertex>> edges)
        {
            return edges
                .Where(edge => !AllowLoops ? !_verticesComparer.Equals(edge.End1, edge.End2) : true)
                .Where(edge => !AllowParallelEdges ? !Edges.Contains(edge, _edgesComparer) : true);
        }

        private UndirectedGraph<TVertex> filterEdgesAndCreateGraph(IEnumerable<Edge<TVertex>> edges, params Func<IEnumerable<Edge<TVertex>>, IEnumerable<Edge<TVertex>>>[] predicates)
        {
            var filteredEdges = edges;

            foreach (var predicate in predicates)
            {
                filteredEdges = predicate(filteredEdges);
            }

            if (!filteredEdges.Any())
            {
                return this;
            }

            return new UndirectedGraph<TVertex>(AllowLoops, AllowParallelEdges, Edges.Concat(filteredEdges), Vertices, _verticesComparer);
        }

        public UndirectedGraph<TVertex> AddEdges(IEnumerable<Edge<TVertex>> edges)
        {
            return filterEdgesAndCreateGraph(edges, filterEdgesWhosVerticesAreNotContainedInThisInstance, filterEdgesWhoViolatesThisInstanceProperties);
        }

        public UndirectedGraph<TVertex> AddEdges(params Edge<TVertex>[] edges)
        {
            return AddEdges(edges.AsEnumerable());
        }

        public UndirectedGraph<TVertex> AddVertex(TVertex vertex)
        {
            return AddVertices(vertex.Yield());
        }

        public UndirectedGraph<TVertex> AddEdgesAndVertices(IEnumerable<Edge<TVertex>> edges)
        {
            return filterEdgesAndCreateGraph(edges, filterEdgesWhoViolatesThisInstanceProperties);
        }

        public UndirectedGraph<TVertex> AddEdgesAndVertices(params Edge<TVertex>[] edges)
        {
            return AddEdgesAndVertices(edges.AsEnumerable());
        }

        public UndirectedGraph<TVertex> AddVertices(IEnumerable<TVertex> vertices)
        {
            return new UndirectedGraph<TVertex>(AllowLoops, AllowParallelEdges, Edges, Vertices.Concat(vertices), _verticesComparer);
        }

        public UndirectedGraph<TVertex> AddVertices(params TVertex[] vertices)
        {
            return AddVertices(vertices.AsEnumerable());
        }

        public bool AreEdgesAdjacent(Edge<TVertex> edge1, Edge<TVertex> edge2)
        {
            if (!ContainsEdges(edge1, edge2))
            {
                return false;
            }

            return Edge<TVertex>.AreAdjacent(edge1, edge2, _verticesComparer);
        }

        public bool AreVerticesAdjacent(TVertex vertex1, TVertex vertex2)
        {
            var referenceVertex = new Edge<TVertex>(vertex1, vertex2);

            return Edges.Contains(referenceVertex, new IgnoreDirectionAndDisallowParallelEdges<TVertex>(_verticesComparer));
        }

        public bool ContainsEdge(Edge<TVertex> edge)
        {
            return Edges.Contains(edge, _edgesComparer);
        }

        public bool ContainsEdges(params Edge<TVertex>[] edges)
        {
            return ContainsEdges(edges.AsEnumerable());
        }

        public bool ContainsEdges(IEnumerable<Edge<TVertex>> edges)
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

        public bool Equals(IModelAUndirectedGraph<TVertex> other)
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
                || !Edges.IsEquivalent(other.Edges, new IgnoreDirectionAndDisallowParallelEdges<TVertex>(_verticesComparer))
                || !Vertices.IsEquivalent(other.Vertices, _verticesComparer))
            {
                return false;
            }

            return true;
        }

        public bool Equals(IModelAGraph<TVertex> other)
        {
            return Equals(other as IModelAUndirectedGraph<TVertex>);
        }

        public override bool Equals(object other)
        {
            return Equals(other as IModelAUndirectedGraph<TVertex>);
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

        public IEnumerable<Edge<TVertex>> IncidentEdgesOf(TVertex vertex)
        {
            if (!ContainsVertex(vertex))
            {
                return Enumerable.Empty<Edge<TVertex>>();
            }

            return _incidentEdges[vertex];
        }

        public IEnumerable<TVertex> IncidentVerticesOf(Edge<TVertex> edge)
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

        public UndirectedGraph<TVertex> RemoveEdge(Edge<TVertex> edge)
        {
            return RemoveEdges(edge.Yield());
        }

        public UndirectedGraph<TVertex> RemoveEdgeAndVertices(Edge<TVertex> edge)
        {
            return RemoveEdgesAndVertices(edge.Yield());
        }

        public UndirectedGraph<TVertex> RemoveEdges(IEnumerable<Edge<TVertex>> edges)
        {
            var edgesToRemove = edges.Where(edge => ContainsEdge(edge));

            if (!edgesToRemove.Any())
            {
                return this;
            }

            return new UndirectedGraph<TVertex>(AllowLoops, AllowParallelEdges, Edges.Except(edgesToRemove, _edgesComparer), Vertices, _verticesComparer);
        }

        public UndirectedGraph<TVertex> RemoveEdges(params Edge<TVertex>[] edges)
        {
            return RemoveEdges(edges.AsEnumerable());
        }

        public UndirectedGraph<TVertex> RemoveEdgesAndVertices(IEnumerable<Edge<TVertex>> edges)
        {
            var edgesToRemove = edges.Where(edge => ContainsEdge(edge));

            if (!edgesToRemove.Any())
            {
                return this;
            }

            var edgesToKeep = Edges.Except(edgesToRemove, _edgesComparer);
            var verticesToKeep = Vertices
                .Where(vertex => !_incidentEdges[vertex]
                    .Except(edgesToKeep, _edgesComparer)
                    .Any());

            return new UndirectedGraph<TVertex>(AllowLoops, AllowParallelEdges, edgesToKeep, verticesToKeep, _verticesComparer);
        }

        public UndirectedGraph<TVertex> RemoveEdgesAndVertices(params Edge<TVertex>[] edges)
        {
            return RemoveEdgesAndVertices(edges.AsEnumerable());
        }

        public UndirectedGraph<TVertex> RemoveVertex(TVertex vertex)
        {
            return RemoveVertices(vertex.Yield());
        }

        public UndirectedGraph<TVertex> RemoveVertices(IEnumerable<TVertex> vertices)
        {
            var verticesToRemove = vertices.Where(vertex => Vertices.Contains(vertex));

            if (!verticesToRemove.Any())
            {
                return this;
            }

            var verticesToKeep = Vertices.Except(verticesToRemove, _verticesComparer);
            var edgesToKeep = Edges.Where(edge => verticesToKeep.Contains(edge.End1, _verticesComparer) && verticesToKeep.Contains(edge.End2, _verticesComparer));

            return new UndirectedGraph<TVertex>(AllowLoops, AllowParallelEdges, edgesToKeep, verticesToKeep, _verticesComparer);
        }

        public UndirectedGraph<TVertex> RemoveVertices(params TVertex[] vertices)
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
