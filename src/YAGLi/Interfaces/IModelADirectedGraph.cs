using System;

namespace YAGLi.Interfaces
{
    /// <summary>
    /// The interface <see cref="IModelADirectedGraph{TVertex}"/> defines the behaviour for objects who models a directed graph from graph theory.
    /// In graph theory, a undirected graph is a graph where edges have direction. Meaning the edges (x -- y) and (x -- y) are equal whereas the edges (x -- y) and (y -- x) are not.
    /// </summary>
    /// <typeparam name="TVertex"></typeparam>
    /// <typeparam name="TEdge"></typeparam>
    public interface IModelADirectedGraph<TVertex, TEdge> : IModelAGraph<TVertex, TEdge>, IEquatable<IModelAUndirectedGraph<TVertex, TEdge>> where TEdge : IModelAnEdge<TVertex>
    {
        #region Methods
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
