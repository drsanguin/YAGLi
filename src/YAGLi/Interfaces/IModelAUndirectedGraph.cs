using System;

namespace YAGLi.Interfaces
{
    /// <summary>
    /// The interface <see cref="IModelAUndirectedGraph{TVertex}"/> defines the behaviour for objects who models a undirected graph from graph theory.
    /// In graph theory, a undirected graph is a graph where edges have no direction. Meaning the edges (x -- y) and (y -- x) are equal.
    /// </summary>
    /// <typeparam name="TVertex">The graph's vertices type.</typeparam>
    /// <typeparam name="TEdge">The graph's edges type.</typeparam>
    public interface IModelAUndirectedGraph<TVertex, TEdge> : IModelAGraph<TVertex, TEdge>, IEquatable<IModelAUndirectedGraph<TVertex, TEdge>> where TEdge : IModelAnEdge<TVertex> { }
}
