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
        /// Readonly field who store the piece of intelligence about whether this instance allow loops. 
        /// </summary>
        private readonly bool _allowLoops;

        /// <summary>
        /// Readonly field who store the piece of intelligence about whether this instance allow parallel edges.
        /// </summary>
        private readonly bool _allowParallelEdges;

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
            _allowLoops = allowLoops;
            _allowParallelEdges = allowParallelEdges;

            Dictionary <TVertex, IEnumerable<Edge<TVertex>>> incidentEdges = new Dictionary<TVertex, IEnumerable<Edge<TVertex>>>();
            Dictionary<Edge<TVertex>, IEnumerable<TVertex>> incidentVertices = new Dictionary<Edge<TVertex>, IEnumerable<TVertex>>(
                (_allowParallelEdges) ? EdgeEqualityComparers<TVertex>.IgnoreDirectionAndAllowParallelEdges : EdgeEqualityComparers<TVertex>.IgnoreDirectionAndDisallowParallelEdges);

            foreach (var edge in ((!_allowLoops)? edges.Where(edge => !edge.Ends.First().Equals(edge.Ends.Last())) : edges ))
            {
                TVertex end1 = edge.Ends.First();
                TVertex end2 = edge.Ends.Last();

                if (!incidentEdges.ContainsKey(end1))
                {
                    incidentEdges[end1] = Enumerable.Empty<Edge<TVertex>>();
                }

                if (!incidentEdges.ContainsKey(end2))
                {
                    incidentEdges[end2] = Enumerable.Empty<Edge<TVertex>>();
                }

                incidentEdges[end1] = Enumerable.Concat(incidentEdges[end1], Enumerable.Repeat(edge, 1));
                incidentEdges[end2] = Enumerable.Concat(incidentEdges[end2], Enumerable.Repeat(edge, 1));
                incidentVertices[edge] = new HashSet<TVertex>(edge.Ends);
            }

            foreach (var vertex in vertices.Where(vertex => !incidentEdges.Keys.Contains(vertex)))
            {
                incidentEdges.Add(vertex, Enumerable.Empty<Edge<TVertex>>());
            }

            _incidentEdges = incidentEdges;
            _incidentVertices = incidentVertices;
        }

        public bool AllowLoops
        {
            get { return _allowLoops; }
        }

        public bool AllowParallelEdges
        {
            get { return _allowParallelEdges; }
        }

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

        public UndirectedGraph<TVertex> AddEdges(params Edge<TVertex>[] edges)
        {
            throw new NotImplementedException();
        }

        public UndirectedGraph<TVertex> AddVertex(TVertex vertex)
        {
            throw new NotImplementedException();
        }

        public UndirectedGraph<TVertex> AddVertices(params TVertex[] vertices)
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

        public IEnumerable<TVertex> AdjacentVerticesOf(TVertex vertex)
        {
            throw new NotImplementedException();
        }

        public bool AreEdgesAdjacent(params Edge<TVertex>[] edges)
        {
            throw new NotImplementedException();
        }

        public bool AreVerticesAdjacent(params TVertex[] vertices)
        {
            throw new NotImplementedException();
        }

        public bool ContainsEdge(Edge<TVertex> edge)
        {
            throw new NotImplementedException();
        }

        public bool ContainsEdges(params Edge<TVertex>[] edges)
        {
            throw new NotImplementedException();
        }

        public bool ContainsVertex(TVertex vertex)
        {
            throw new NotImplementedException();
        }

        public bool ContainsVertices(params TVertex[] vertices)
        {
            throw new NotImplementedException();
        }

        public int DegreeOf(TVertex vertex)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Edge<TVertex>> IncidentEdgesOf(TVertex vertex)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TVertex> IncidentVerticesOf(Edge<TVertex> edge)
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
    }
}
