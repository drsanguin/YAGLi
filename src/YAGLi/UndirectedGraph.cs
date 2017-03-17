using System;
using System.Collections.Generic;
using System.Linq;

namespace YAGLi
{
    /// <summary>
    /// The class <see cref="UndirectedGraph{TVertex}"/> models graph in which edges have no direction.
    /// The edge (x -- y) is equal to the edge (y -- x).
    /// </summary>
    /// <typeparam name="TVertex">The type of the vertex that the graph store.</typeparam>
    public class UndirectedGraph<TVertex> : IModelAGraph<TVertex> where TVertex : IEquatable<TVertex>
    {
        /// <summary>
        /// Models a empty undirected graph who allow loops but disallow parallel edges. This field is readonly.
        /// </summary>
        public static readonly UndirectedGraph<TVertex> EmptyWhoAllowLoops = new UndirectedGraph<TVertex>(true, false);

        /// <summary>
        /// Models a empty undirected graph who allow parallel edges but disallow loops. This field is readonly.
        /// </summary>
        public static readonly UndirectedGraph<TVertex> EmptyWhoAllowParallelEdges = new UndirectedGraph<TVertex>(false, true);

        /// <summary>
        /// Models a empty undirected graph who allow loops and parallel edges. This field is readonly.
        /// </summary>
        public static readonly UndirectedGraph<TVertex> EmptyWhoAllowLoopsAndParallelEdges = new UndirectedGraph<TVertex>(true, true);

        /// <summary>
        /// Models a empty undirected graph who disallow loops and parallel edges. This field is readonly.
        /// </summary>
        public static readonly UndirectedGraph<TVertex> EmptyWhoDisallowLoopsAndParallelEdges = new UndirectedGraph<TVertex>(false, false);

        /// <summary>
        /// Readonly field who store the incident edges of each vertex contained in this instance.
        /// </summary>
        private readonly IReadOnlyDictionary<TVertex, IEnumerable<Edge<TVertex>>> _incidentEdges;

        /// <summary>
        /// Readonly field who store the incident vertices of each vertex contained in this instance.
        /// </summary>
        private readonly IReadOnlyDictionary<Edge<TVertex>, IEnumerable<TVertex>> _incidentVertices;

        public UndirectedGraph(bool allowLoops, bool allowParallelEdges) : this(allowLoops, allowParallelEdges, Enumerable.Empty<Edge<TVertex>>(), Enumerable.Empty<TVertex>()) { }

        public UndirectedGraph(bool allowLoops, bool allowParallelEdges, IEnumerable<Edge<TVertex>> edges, IEnumerable<TVertex> vertices)
        {
            AllowLoops = allowLoops;
            AllowParallelEdges = allowParallelEdges;

            Dictionary <TVertex, IList<Edge<TVertex>>> incidentEdges = new Dictionary<TVertex, IList<Edge<TVertex>>>();
            Dictionary<Edge<TVertex>, IEnumerable<TVertex>> incidentVertices = new Dictionary<Edge<TVertex>, IEnumerable<TVertex>>(
                (AllowParallelEdges) ? EdgeEqualityComparers<TVertex>.IgnoreDirectionAndAllowParallelEdges : EdgeEqualityComparers<TVertex>.IgnoreDirectionAndDisallowParallelEdges);

            foreach (var edge in ((!AllowLoops)? edges.Where(edge => !edge.Ends.First().Equals(edge.Ends.Last())) : edges ))
            {
                TVertex end1 = edge.Ends.First();
                TVertex end2 = edge.Ends.Last();

                if (!incidentEdges.ContainsKey(end1))
                {
                    incidentEdges[end1] = new List<Edge<TVertex>>();
                }

                if (!incidentEdges.ContainsKey(end2))
                {
                    incidentEdges[end2] = new List<Edge<TVertex>>();
                }

                incidentEdges[end1].Add(edge);

                if (!end1.Equals(end2))
                {
                    incidentEdges[end2].Add(edge);
                }
                
                incidentVertices[edge] = new HashSet<TVertex>(edge.Ends);
            }

            foreach (var vertex in vertices.Where(vertex => !incidentEdges.Keys.Contains(vertex)))
            {
                incidentEdges.Add(vertex, new List<Edge<TVertex>>(0));
            }

            _incidentEdges = incidentEdges.ToDictionary(x => x.Key, x => x.Value.AsEnumerable());
            _incidentVertices = incidentVertices;
        }

        /// <summary>
        /// Piece of intelligence about whether this instance allow loops.
        /// </summary>
        public bool AllowLoops { get; }

        /// <summary>
        /// Piece of intelligence about whether this instance allow parallel edges.
        /// </summary>
        public bool AllowParallelEdges { get; }

        public IEnumerable<Edge<TVertex>> Edges
        {
            get
            {
                return _incidentVertices.Keys;
            }
        }

        public IEnumerable<TVertex> Vertices
        {
            get
            {
                return _incidentEdges.Keys;
            }
        }

        public UndirectedGraph<TVertex> AddEdge(Edge<TVertex> edge)
        {
            throw new NotImplementedException();
        }

        public UndirectedGraph<TVertex> AddEdges(IEnumerable<Edge<TVertex>> edges)
        {
            throw new NotImplementedException();
        }

        public UndirectedGraph<TVertex> AddVertex(TVertex vertex)
        {
            throw new NotImplementedException();
        }

        public UndirectedGraph<TVertex> AddVertices(IEnumerable<TVertex> vertices)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The method <see cref="AdjacentEdgesOf(Edge{TVertex})"/> get the edges contained in this instance that are adjacent to the parameter <paramref name="edge"/>.
        /// First, the function will look if the parameter <paramref name="edge"/> is contained in this instance.
        /// If the graph allow parallel edges, then the edges comparison will be by reference. If not, the edges will be compared using the method <see cref="Edge{TVertex}.Equals(Edge{TVertex}, EdgeComparison)"/> with the value <see cref="EdgeComparison.IgnoreDirection"/>.
        /// </summary>
        /// <param name="edge">The edge for which to search the adjacent edges contained in this instance.</param>
        /// <returns>The edges contained in this instance that are adjacent to the parameter <paramref name="edge"/></returns>
        public IEnumerable<Edge<TVertex>> AdjacentEdgesOf(Edge<TVertex> edge)
        {
            Func<Edge<TVertex>, Edge<TVertex>, bool> predicate = (AllowParallelEdges) ? 
                new Func<Edge<TVertex>, Edge<TVertex>, bool>((x, y) => ReferenceEquals(x, y)) : 
                (x, y) => x.Equals(y, EdgeComparison.IgnoreDirection);

            if (!Edges.Any(x => predicate(x, edge)))
            {
                return Enumerable.Empty<Edge<TVertex>>();
            }
            else
            {
                return Edges.Where(x => !predicate(edge, x) && x.IsAdjacentTo(edge));
            }
        }

        /// <summary>
        /// The method <see cref="AdjacentVerticesOf(TVertex)"/> returns the vertices contained in this instance that are adjacent to the parameter <paramref name="vertex"/>.
        /// If the parameter <paramref name="vertex"/> is not contained in this instance, a empty collection is returned.
        /// </summary>
        /// <param name="vertex">The vertex for wich to search the adjacent vertices that are contained in this instance.</param>
        /// <returns>The vertices contained in this instance that are adjacent to the parameter <paramref name="vertex"/> if it is contained in this instance. Otherwise, a emtpy collection.</returns>
        public IEnumerable<TVertex> AdjacentVerticesOf(TVertex vertex)
        {
            if (!Vertices.Contains(vertex))
            {
                return Enumerable.Empty<TVertex>();
            }

            return _incidentEdges[vertex].SelectMany(edge => edge.Ends).Where(v => !v.Equals(vertex));
        }

        public bool AreEdgesAdjacent(IEnumerable<Edge<TVertex>> edges)
        {
            throw new NotImplementedException();
        }

        public bool AreVerticesAdjacent(IEnumerable<TVertex> vertices)
        {
            throw new NotImplementedException();
        }

        public bool ContainsEdge(Edge<TVertex> edge)
        {
            throw new NotImplementedException();
        }

        public bool ContainsEdges(IEnumerable<Edge<TVertex>> edges)
        {
            throw new NotImplementedException();
        }

        public bool ContainsVertex(TVertex vertex)
        {
            throw new NotImplementedException();
        }

        public bool ContainsVertices(IEnumerable<TVertex> vertices)
        {
            throw new NotImplementedException();
        }

        public int DegreeOf(TVertex vertex)
        {
            if(!Vertices.Contains(vertex))
            {
                return -1;
            }

            return _incidentEdges[vertex].Sum(edge => (edge.Ends.First().Equals(edge.Ends.Last())) ? 2 : 1);
        }

        public IEnumerable<Edge<TVertex>> IncidentEdgesOf(TVertex vertex)
        {
            if (!Vertices.Contains(vertex))
            {
                return Enumerable.Empty<Edge<TVertex>>();
            }

            return _incidentEdges[vertex];
        }

        public IEnumerable<TVertex> IncidentVerticesOf(Edge<TVertex> edge)
        {
            if (!_incidentVertices.ContainsKey(edge))
            {
                return Enumerable.Empty<TVertex>();
            }

            return _incidentVertices[edge];
        }

        public int InDegreeOf(TVertex vertex)
        {
            return DegreeOf(vertex);
        }

        public int OutDegreeOf(TVertex vertex)
        {
            return DegreeOf(vertex);
        }
    }
}
