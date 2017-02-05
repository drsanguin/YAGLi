using System;

namespace YAGL
{
    /// <summary>
    /// The class <see cref="Vertex"/> model the fundamental unit of wich graphs are formed in Graph Theory.
    /// </summary>
    public class Vertex
    {
        /// <summary>
        /// The field used to store the Vertex's label.
        /// </summary>
        private readonly string _label;

        /// <summary>
        /// Default Vertex constructor. Will create a Vertex with a label equal to <see cref="string.Empty"/>
        /// </summary>
        public Vertex() : this(string.Empty) { }

        /// <summary>
        /// Vertex constructor that allow the client to set a specific label to the Vertex.
        /// </summary>
        /// <param name="label">The label that the client will apply to the Vertex.</param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="label"/> is equal to null.
        /// </exception>
        public Vertex(string label)
        {
            if (label == null)
            {
                throw new ArgumentNullException(nameof(label));
            }

            _label = label;
        }

        /// <summary>
        /// The Vertex's label.
        /// </summary>
        public string Label { get { return _label; } }
    }
}
