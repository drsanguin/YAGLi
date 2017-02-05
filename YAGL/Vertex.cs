using System;

namespace YAGL
{
    /// <summary>
    /// The class <see cref="Vertex{TData}"/> model the fundamental unit of wich graphs are formed in Graph Theory.
    /// </summary>
    /// <typeparam name="TData">The type of the data that the vertex store.</typeparam>
    public class Vertex<TData>
    {
        /// <summary>
        /// The field used to store the Vertex's data.
        /// </summary>
        private readonly TData _data;

        /// <summary>
        /// Vertex constructor that allow the client to assign a data to the Vertex.
        /// </summary>
        /// <param name="data">The data to store in the vertex.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="data"/> is equal to <see cref="null"/>.</exception>
        public Vertex(TData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            _data = data;
        }

        /// <summary>
        /// The Vertex's data.
        /// </summary>
        public TData Data { get { return _data; } }

        /// <summary>
        /// Create and return a <see cref="string"/> representation of the current <see cref="Vertex{TData}"/>.
        /// </summary>
        /// <returns>The <see cref="string"/> representation of the current <see cref="Vertex{TData}"/>.</returns>
        public override string ToString()
        {
            return _data.ToString();
        }
    }
}
