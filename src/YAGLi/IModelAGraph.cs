using System;
using System.Collections.Generic;

namespace YAGLi
{
    /// <summary>
    /// The interface <see cref="IModelAGraph{TVertex}"/> represent a generic graph object from Graph Theory.
    /// </summary>
    /// <typeparam name="TVertex">The type of the graph's vertices.</typeparam>
    public interface IModelAGraph<TVertex> where TVertex : IEquatable<TVertex>
    {
        #region Properties
        /// <summary>
        /// Get the piece of intelligence about whether or not this instance allow parallel edges.
        /// </summary>
        bool AllowParallelEdges { get; }

        /// <summary>
        /// Get the piece of intelligence about whether or not this instance allow loops.
        /// </summary>
        bool AllowLoops { get; }

        /// <summary>
        /// Get the edges that this instance contains.
        /// </summary>
        IEnumerable<Edge<TVertex>> Edges { get; }

        /// <summary>
        /// Get the vertices that this instance contains.
        /// </summary>
        IEnumerable<TVertex> Vertices { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Get the edges contained in this instance that are adjacent the parameter <paramref name="edge"/>.
        /// Two <see cref="Edge{TVertex}"/> are adjacent if they share a common end vertex.
        /// </summary>
        /// <param name="edge">The <see cref="Edge{TVertex}"/> object for which the adjacent edges will be searched.</param>
        /// <returns>The edges adjacent to <paramref name="edge"/>.</returns>
        /// <remarks>The parameter <paramref name="edge"/> is expected to be contained in the set of edges of this instance.</remarks>
        IEnumerable<Edge<TVertex>> AdjacentEdgesOf(Edge<TVertex> edge);

        /// <summary>
        /// Get the vertices contained in this instance that are adjacent to the parameter <paramref name="vertex"/>.
        /// Two vertices are adjacent if they are connected by an <see cref="Edge{TVertex}"/> contained in this instance.
        /// </summary>
        /// <param name="vertex">The vertex for which the adjacent vertices will be searched.</param>
        /// <returns>The vertices adjacent to the parameter <paramref name="vertex"/>.</returns>
        /// <remarks>The parameter <paramref name="vertex"/> is expected to be contained in the set of vertices of this instance.</remarks>
        IEnumerable<TVertex> AdjacentVerticesOf(TVertex vertex);

        /// <summary>
        /// Determine whether the given set of edges <paramref name="edges"/> are adjacent in this instance.
        /// Two <see cref="Edge{TVertex}"/> are adjacent if they share a common end vertex.
        /// </summary>
        /// <param name="edges">The set of edges to determine if they are adjacent.</param>
        /// <returns><see cref="true"/> if the set of edges <paramref name="edges"/> are adjacent in this instance, <see cref="false"/> otherwise.</returns>
        /// <remarks>Each <see cref="Edge{TVertex}"/> object contained in <paramref name="edges"/> is expected to be contained in the set of edges of this instance.</remarks>
        bool AreEdgesAdjacent(IEnumerable<Edge<TVertex>> edges);

        /// <summary>
        /// Determine whether the given set of vertices <paramref name="vertices"/> are adjacent in this instance.
        /// Two vertices are adjacent if they are connected by an <see cref="Edge{TVertex}"/> contained in this instance.
        /// </summary>
        /// <param name="vertices">The vertices to determine if they are adjacent in this instance.</param>
        /// <returns><see cref="true"/> if the vertices are adjacent in this instance, <see cref="false"/> otherwise.</returns>
        /// <remarks>Each vertex contained in <paramref name="vertices"/> is expected to be contained in the set of vertices of this instance.</remarks>
        bool AreVerticesAdjacent(IEnumerable<TVertex> vertices);

        /// <summary>
        /// Determine whether this instance contains the edge <paramref name="edge"/>.
        /// </summary>
        /// <param name="edge">The edge to determine if it is contained in this instance.</param>
        /// <returns><see cref="true"/> if the parameter <paramref name="edge"/> is contained in the set of edges of this instance, <see cref="false"/> otherwise.</returns>
        bool ContainsEdge(Edge<TVertex> edge);

        /// <summary>
        /// Determine whether this instance contains the given set of edges.
        /// </summary>
        /// <param name="edges">The edges to determine if they are contained in this instance.</param>
        /// <returns><see cref="true"/> if each <see cref="Edge{TVertex}"/> object of the parameter <paramref name="edges"/> is contained in the set of edges of this instance, <see cref="false"/> otherwise.</returns>
        bool ContainsEdges(IEnumerable<Edge<TVertex>> edges);

        /// <summary>
        /// Determine whether this instance contains the given set of edges.
        /// </summary>
        /// <param name="edges">The edges to determine if they are contained in this instance.</param>
        /// <returns><see cref="true"/> if each <see cref="Edge{TVertex}"/> object of the parameter <paramref name="edges"/> is contained in the set of edges of this instance, <see cref="false"/> otherwise.</returns>
        bool ContainsEdges(params Edge<TVertex>[] edges);

        /// <summary>
        /// Determine whether this instance contains the given vertex.
        /// </summary>
        /// <param name="vertex">The vertex to determine is it is contained in this instance.</param>
        /// <returns><see cref="true"/> if the parameter <paramref name="vertex"/> is contained in the set of vertices of this instance.</returns>
        bool ContainsVertex(TVertex vertex);

        /// <summary>
        /// Determine whether the given set of vertices is contained in the set of vertices of this instance.
        /// </summary>
        /// <param name="vertices">The set of vertices for which to check if they are contained in the set of vertices of this instance.</param>
        /// <returns><see cref="true"/> if each vertex contained in <paramref name="vertices"/> is also contained in the set of vertices of this instance.</returns>
        bool ContainsVertices(IEnumerable<TVertex> vertices);

        /// <summary>
        /// Determine whether the given set of vertices is contained in the set of vertices of this instance.
        /// </summary>
        /// <param name="vertices">The set of vertices for which to check if they are contained in the set of vertices of this instance.</param>
        /// <returns><see cref="true"/> if each vertex contained in <paramref name="vertices"/> is also contained in the set of vertices of this instance.</returns>
        bool ContainsVertices(params TVertex[] vertices);

        /// <summary>
        /// Get the degree of a given vertex.
        /// The degree of a vertex is the number of <see cref="Edge{TVertex}"/> with <paramref name="vertex"/> as an end vertex.
        /// </summary>
        /// <param name="vertex">The vertex for wich the degree will be comput.</param>
        /// <returns>The degree of the parameter <paramref name="vertex"/>.</returns>
        /// <remarks>
        /// The parameter <paramref name="vertex"/> is expected to be contained in this instance.
        /// By convention the loops count twice.
        /// </remarks>
        int DegreeOf(TVertex vertex);

        /// <summary>
        /// Get the incident <see cref="Edge{TVertex}"/> of the given vertex.
        /// A <see cref="Edge{TVertex}"/> is incident to a vertex if the vertex is one of the <see cref="Edge{TVertex}"/> ends.
        /// </summary>
        /// <param name="vertex">The vertex for which to search the incident <see cref="Edge{TVertex}"/>(s).</param>
        /// <returns>The list of the <see cref="Edge{TVertex}"/> incident to the vertex <paramref name="vertex"/> that are contained in the set of edges of this instance.</returns>
        /// <remarks>The parameter <paramref name="vertex"/> is expected to be contained in the set of vertices of this instance.</remarks>
        IEnumerable<Edge<TVertex>> IncidentEdgesOf(TVertex vertex);

        /// <summary>
        /// Get the incident vertices of the given edge <paramref name="edge"/>.
        /// A vertex is incident to a <see cref="Edge{TVertex}"/> if it is one of his end vertices. 
        /// </summary>
        /// <param name="edge">The <see cref="Edge{TVertex}"/> for which to search the incident vertices.</param>
        /// <returns>The vertices incident to this <see cref="Edge{TVertex}"/> that are contained in the set of vertices of this instance.</returns>
        /// <remarks>The parameter <paramref name="edge"/> is expected to be contained in the set of edges of this instance.</remarks>
        IEnumerable<TVertex> IncidentVerticesOf(Edge<TVertex> edge);

        /// <summary>
        /// Get the in-degree of the vertex <paramref name="vertex"/>.
        /// The in-degree of a vertex is the number of <see cref="Edge{TVertex}"/> going into it.
        /// </summary>
        /// <param name="vertex">The vertex for which to compute the in-degree.</param>
        /// <returns>The in-degree of the vertex.</returns>
        /// <remarks>The parameter <paramref name="vertex"/> is expected to be contained in the set of vertices of this instance.</remarks>
        int InDegreeOf(TVertex vertex);

        /// <summary>
        /// Get the out-degree of the vertex <paramref name="vertex"/>.
        /// The out-degree of a vertex is the number of <see cref="Edge{TVertex}"/> going out of it.
        /// </summary>
        /// <param name="vertex">The vertex for which to compute the out-degree.</param>
        /// <returns>The out-degree of the vertex.</returns>
        /// <remarks>The parameter <paramref name="vertex"/> is expected to be contained in the set of vertices of this instance.</remarks>
        int OutDegreeOf(TVertex vertex); 
        #endregion
    }
}
