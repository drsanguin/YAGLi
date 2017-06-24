namespace YAGLi.Interfaces
{
    /// <summary>
    /// The interface <see cref="IModelAnEdge{TVertex}"/> represent a generic edge object from graph theory.
    /// </summary>
    /// <typeparam name="TVertex">The type of the vertices.</typeparam>
    public interface IModelAnEdge<TVertex>
    {
        /// <summary>
        /// Get the first end vertex of this instance.
        /// </summary>
        TVertex End1 { get; }

        /// <summary>
        /// Get the second end vertex of this instance.
        /// </summary>
        TVertex End2 { get; }
    }
}
