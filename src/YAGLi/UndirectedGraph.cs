using System;
using System.Collections.Generic;
using System.Linq;
using YAGLi.EdgeComparers;
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
        #region Instance fields
        /// <summary>
        /// Readonly field who store the incident edges of each vertex contained in this instance.
        /// </summary>
        private readonly IReadOnlyDictionary<TVertex, IEnumerable<Edge<TVertex>>> _incidentEdges;

        /// <summary>
        /// Readonly field who store the incident vertices of each vertex contained in this instance.
        /// </summary>
        private readonly IReadOnlyDictionary<Edge<TVertex>, IEnumerable<TVertex>> _incidentVertices;

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
        public UndirectedGraph(bool allowLoops, bool allowParallelEdges) : this(allowLoops, allowParallelEdges, EqualityComparer< TVertex>.Default) { }

        public UndirectedGraph(bool allowLoops, bool allowParallelEdges, IEqualityComparer<TVertex> verticesComparer) : this(allowLoops, allowParallelEdges, Enumerable.Empty<Edge<TVertex>>(), Enumerable.Empty<TVertex>(), verticesComparer) { }

        public UndirectedGraph(bool allowLoops, bool allowParallelEdges, IEnumerable<Edge<TVertex>> edges, IEnumerable<TVertex> vertices) : this(allowLoops, allowParallelEdges, edges, vertices, EqualityComparer<TVertex>.Default) { }

        public UndirectedGraph(bool allowLoops, bool allowParallelEdges, IEnumerable<Edge<TVertex>> edges, IEnumerable<TVertex> vertices, IEqualityComparer<TVertex> verticesComparer)
        {
            AllowLoops = allowLoops;
            AllowParallelEdges = allowParallelEdges;

            if (AllowParallelEdges)
            {
                _edgesComparer = new IgnoreDirectionAndAllowParallelEdges<TVertex>(verticesComparer);
            }
            else
            {
                _edgesComparer = new IgnoreDirectionAndDisallowParallelEdges<TVertex>(verticesComparer);
            }

            _verticesComparer = verticesComparer;

            Dictionary<TVertex, IList<Edge<TVertex>>> incidentEdges = new Dictionary<TVertex, IList<Edge<TVertex>>>(_verticesComparer);
            Dictionary<Edge<TVertex>, IEnumerable<TVertex>> incidentVertices = new Dictionary<Edge<TVertex>, IEnumerable<TVertex>>(_edgesComparer);

            IEnumerable<Edge<TVertex>> distinctEdges = (AllowParallelEdges) ? edges : edges.Distinct(_edgesComparer);

            foreach (var edge in ((!AllowLoops) ? distinctEdges.Where(edge => !_verticesComparer.Equals(edge.End1, edge.End2)) : distinctEdges))
            {
                IEnumerable<TVertex> distinctEnds = new TVertex[] { edge.End1, edge.End2 }.Distinct();

                foreach (var end in distinctEnds)
                {
                    if (!incidentEdges.ContainsKey(end))
                    {
                        incidentEdges[end] = new List<Edge<TVertex>>();
                    }

                    incidentEdges[end].Add(edge);
                }

                incidentVertices[edge] = distinctEnds;
            }

            foreach (var vertex in vertices.Where(vertex => !incidentEdges.ContainsKey(vertex)))
            {
                incidentEdges.Add(vertex, new List<Edge<TVertex>>(0));
            }

            _incidentEdges = incidentEdges.ToDictionary(x => x.Key, x => x.Value.AsEnumerable(), _verticesComparer);
            _incidentVertices = incidentVertices.ToDictionary(x => x.Key, x => x.Value.AsEnumerable(), _edgesComparer);
        }
        #endregion

        #region Properties
        public bool AllowLoops { get; }

        public bool AllowParallelEdges { get; }
        #endregion

        #region Methods
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
            Edge<TVertex> referenceVertex = new Edge<TVertex>(vertex1, vertex2);

            return Edges.Contains(referenceVertex, new IgnoreDirectionAndDisallowParallelEdges<TVertex>(_verticesComparer));
        }

        public int CompareTo(IModelAUndirectedGraph<TVertex> other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object other)
        {
            throw new NotImplementedException();
        }

        public bool ContainsEdge(Edge<TVertex> edge)
        {
            return _incidentVertices.ContainsKey(edge);
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

            if (ReferenceEquals(this, other))
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
            int hash = 101;

            hash = hash * 107 + AllowLoops.GetHashCode();
            hash = hash * 107 + AllowParallelEdges.GetHashCode();

            foreach (var edgeHashing in Edges.Select(edge => _edgesComparer.GetHashCode(edge)).OrderBy(x => x))
            {
                hash = hash * 107 + edgeHashing;
            }

            foreach (var vertexHashing in Vertices.Select(vertex => _verticesComparer.GetHashCode(vertex)).OrderBy(x => x))
            {
                hash = hash * 107 + vertexHashing;
            }

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

            return _incidentVertices[edge];
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
