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
    public class DirectedGraph<TVertex, TEdge> : AbstractGraph<TVertex, TEdge, DirectedGraph<TVertex, TEdge>>, IModelADirectedGraph<TVertex, TEdge> where TEdge : IModelAnEdge<TVertex>
    {
        #region Instance members
        private readonly IReadOnlyDictionary<TVertex, IEnumerable<TEdge>> _incidentEdgesIn;
        private readonly IReadOnlyDictionary<TVertex, IEnumerable<TEdge>> _incidentEdgesOutOf;

        /// <summary>
        /// Readonly field who hold the edge comparison logic specific of this instance.
        /// </summary>
        private readonly IEqualityComparer<TEdge> _edgesComparer;
        #endregion

        #region Constructors
        public DirectedGraph(bool allowLoops, bool allowParallelEdges) : this(allowLoops, allowParallelEdges, EqualityComparer<TVertex>.Default) { }

        public DirectedGraph(bool allowLoops, bool allowParallelEdges, IEqualityComparer<TVertex> verticesComparer) : this(allowLoops, allowParallelEdges, Enumerable.Empty<TEdge>(), Enumerable.Empty<TVertex>(), verticesComparer) { }

        public DirectedGraph(bool allowLoops, bool allowParallelEdges, IEnumerable<TEdge> edges, IEnumerable<TVertex> vertices) : this(allowLoops, allowParallelEdges, edges, vertices, EqualityComparer<TVertex>.Default) { }

        public DirectedGraph(bool allowLoops, bool allowParallelEdges, IEnumerable<TEdge> edges, IEnumerable<TVertex> vertices, IEqualityComparer<TVertex> verticesComparer) : base(allowLoops, allowParallelEdges, verticesComparer)
        {
            _edgesComparer = AllowParallelEdges ? new ConsiderDirectionAndAllowParallelEdges<TVertex, TEdge>(_verticesComparer) as IEqualityComparer<TEdge> : new ConsiderDirectionAndDisallowParallelEdges<TVertex, TEdge>(_verticesComparer);

            var filteredEdges = edges.ReplaceByEmptyIfNull()
                                     .FilterNulls()
                                     .FilterEdgesWithNullVertices<TVertex, TEdge>()
                                     .Where(edge => !AllowLoops ? !_verticesComparer.Equals(edge.End1, edge.End2) : true)
                                     .Distinct(_edgesComparer);

            var filteredVertices = vertices.ReplaceByEmptyIfNull()
                                           .FilterNulls()
                                           .Distinct(_verticesComparer);

            var incidentEdgesIn = new Dictionary<TVertex, IList<TEdge>>(_verticesComparer);
            var incidentEdgesOut = new Dictionary<TVertex, IList<TEdge>>(_verticesComparer);

            foreach (var edge in filteredEdges)
            {
                if (!incidentEdgesOut.ContainsKey(edge.End1))
                {
                    incidentEdgesOut[edge.End1] = new List<TEdge>();
                }

                if (!incidentEdgesIn.ContainsKey(edge.End2))
                {
                    incidentEdgesIn[edge.End2] = new List<TEdge>();
                }

                incidentEdgesOut[edge.End1].Add(edge);
                incidentEdgesIn[edge.End2].Add(edge);
            }

            foreach (var vertex in filteredVertices.Where(vertex => !incidentEdgesOut.ContainsKey(vertex) && !incidentEdgesIn.ContainsKey(vertex)))
            {
                incidentEdgesOut.Add(vertex, new List<TEdge>(0));
                incidentEdgesIn.Add(vertex, new List<TEdge>(0));
            }

            _incidentEdgesOutOf = incidentEdgesOut.ToDictionary(x => x.Key, x => x.Value.AsEnumerable(), _verticesComparer);
            _incidentEdgesIn = incidentEdgesIn.ToDictionary(x => x.Key, x => x.Value.AsEnumerable(), _verticesComparer);
        }
        #endregion

        #region Properties
        public override IEnumerable<TEdge> Edges
        {
            get
            {
                return _incidentEdgesOutOf.Values
                                          .Concat(_incidentEdgesOutOf.Values)
                                          .SelectMany(edge => edge)
                                          .Distinct(_edgesComparer);
            }
        }

        public override IEnumerable<TVertex> Vertices
        {
            get
            {
                return _incidentEdgesIn.Keys
                                       .Concat(_incidentEdgesOutOf.Keys)
                                       .Distinct(_verticesComparer);
            }
        }
        #endregion

        #region Methods
        public override DirectedGraph<TVertex, TEdge> AddEdge(TEdge edge)
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph<TVertex, TEdge> AddEdgeAndVertices(TEdge edge)
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph<TVertex, TEdge> AddEdges(IEnumerable<TEdge> edges)
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph<TVertex, TEdge> AddEdges(params TEdge[] edges)
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph<TVertex, TEdge> AddEdgesAndVertices(IEnumerable<TEdge> edges)
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph<TVertex, TEdge> AddEdgesAndVertices(params TEdge[] edges)
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph<TVertex, TEdge> AddVertex(TVertex vertex)
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph<TVertex, TEdge> AddVertices(IEnumerable<TVertex> vertices)
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph<TVertex, TEdge> AddVertices(params TVertex[] vertices)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TEdge> AdjacentEdgesOf(TEdge edge)
        {
            if (!ContainsEdge(edge))
            {
                return Enumerable.Empty<TEdge>();
            }

            if (!AllowParallelEdges)
            {
                return adjacentEdgesOf(edge);
            }

            if (Edges.Contains(edge, _edgesComparer))
            {
                return adjacentEdgesOf(edge);
            }
            else
            {
                var comparer = new ConsiderDirectionAndDisallowParallelEdges<TVertex, TEdge>(_verticesComparer);

                return adjacentEdgesOf(Edges.First(x => comparer.Equals(x, edge)));
            }
        }

        private IEnumerable<TEdge> adjacentEdgesOf(TEdge edge)
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

            var adjacentVertices =  IncidentEdgesOf(vertex).SelectMany(edge => new TVertex[] { edge.End1, edge.End2 })
                                          .Distinct(_verticesComparer);

            return Edges.Any(edge => _verticesComparer.Equals(edge.End1, vertex) && _verticesComparer.Equals(edge.End2, vertex)) ? adjacentVertices : adjacentVertices.Except(vertex.Yield());
        }

        public override bool AreEdgesAdjacent(TEdge edge1, TEdge edge2)
        {
            var mappedEdges = MapEdges(new TEdge[] { edge1, edge2 }, new IEqualityComparer<TEdge>[]
            {
                _edgesComparer,
                new ConsiderDirectionAndDisallowParallelEdges<TVertex, TEdge>(_verticesComparer)
            });

            return mappedEdges.Count() == 2 && AreEdgesAdjacentImpl(edge1, edge2);
        }

        public override bool AreVerticesAdjacent(TVertex vertex1, TVertex vertex2)
        {
            throw new NotImplementedException();
        }

        public override bool ContainsEdge(TEdge edge)
        {
            return Edges.Contains(edge, _edgesComparer)
                || Edges.Contains(edge, new ConsiderDirectionAndDisallowParallelEdges<TVertex, TEdge>(_verticesComparer));
        }

        private bool containsEdges(IEnumerable<TEdge> edges)
        {
            var filteredEdges = edges.ReplaceByEmptyIfNull()
                                     .FilterNulls()
                                     .FilterEdgesWithNullVertices<TVertex, TEdge>();

            return filteredEdges.Any() ? filteredEdges.All(ContainsEdge) : false;
        }

        public override bool ContainsEdges(IEnumerable<TEdge> edges)
        {
            return containsEdges(edges);
        }

        public override bool ContainsEdges(params TEdge[] edges)
        {
            return containsEdges(edges);
        }

        public override bool ContainsVertex(TVertex vertex)
        {
            return Vertices.Contains(vertex, _verticesComparer);
        }

        public bool containsVertices(IEnumerable<TVertex> vertices)
        {
            var filteredVertices = vertices.ReplaceByEmptyIfNull()
                                           .FilterNulls();

            return filteredVertices.Any() ? filteredVertices.All(ContainsVertex) : false;
        }

        public override bool ContainsVertices(IEnumerable<TVertex> vertices)
        {
            return containsVertices(vertices);
        }

        public override bool ContainsVertices(params TVertex[] vertices)
        {
            return containsVertices(vertices);
        }

        public override int DegreeOf(TVertex vertex)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IModelADirectedGraph<TVertex, TEdge> other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(IModelAGraph<TVertex, TEdge> other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TEdge> IncidentEdgesOf(TVertex vertex)
        {
            return !ContainsVertex(vertex) ? Enumerable.Empty<TEdge>() : IncidentEdgesInto(vertex).Concat(IncidentEdgesOutOf(vertex))
                                                                                                                        .Distinct(_edgesComparer);
        }

        public IEnumerable<TEdge> IncidentEdgesInto(TVertex vertex)
        {
            return !ContainsVertex(vertex) ? Enumerable.Empty<TEdge>() : _incidentEdgesIn[vertex];
        }

        public IEnumerable<TEdge> IncidentEdgesOutOf(TVertex vertex)
        {
            return !ContainsVertex(vertex) ? Enumerable.Empty<TEdge>() : _incidentEdgesOutOf[vertex];
        }

        public override IEnumerable<TVertex> IncidentVerticesOf(TEdge edge)
        {
            if (!ContainsEdge(edge))
            {
                return Enumerable.Empty<TVertex>();
            }

            return new TVertex[] { edge.End1, edge.End2 }.Distinct(_verticesComparer);
        }

        public override IEnumerable<TVertex> NeighborsOf(TVertex vertex)
        {
            throw new NotImplementedException();
        }

        public int InDegreeOf(TVertex vertex)
        {
            throw new NotImplementedException();
        }

        public int OutDegreeOf(TVertex vertex)
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph<TVertex, TEdge> RemoveEdge(TEdge edge)
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph<TVertex, TEdge> RemoveEdgeAndVertices(TEdge edge)
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph<TVertex, TEdge> RemoveEdges(IEnumerable<TEdge> edges)
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph<TVertex, TEdge> RemoveEdges(params TEdge[] edges)
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph<TVertex, TEdge> RemoveEdgesAndVertices(IEnumerable<TEdge> edges)
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph<TVertex, TEdge> RemoveEdgesAndVertices(params TEdge[] edges)
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph<TVertex, TEdge> RemoveVertex(TVertex vertex)
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph<TVertex, TEdge> RemoveVertices(IEnumerable<TVertex> vertices)
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph<TVertex, TEdge> RemoveVertices(params TVertex[] vertices)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("{");
            sb.AppendLine($"    {nameof(AllowLoops)} = {AllowLoops}");
            sb.AppendLine($"    {nameof(AllowParallelEdges)} = {AllowParallelEdges}");
            sb.AppendLine($"    {nameof(Vertices)} = [{string.Join(", ", Vertices)}]");
            sb.AppendLine($"    {nameof(Edges)} = [");
            sb.AppendLine(string.Join($",{Environment.NewLine}", Edges.Select(edge => $"        ({edge.End1} -> {edge.End2})")));
            sb.AppendLine("    ]");
            sb.Append("}");

            return sb.ToString();
        }

        public override IEnumerable<TEdge> PathsToNeighborsOf(TVertex vertex)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
