using System;
using System.Collections.Generic;
using System.Linq;

namespace YAGLi
{
    /// <summary>
    /// The class <see cref="Edge{TVertex}"/> models the fundamental unit of wich graphs are formed in Graph Theory.
    /// </summary>
    /// <typeparam name="TVertex">The type of the vertices.</typeparam>
    public class Edge<TVertex>
    {
        /// <summary>
        /// <see cref="Edge{TVertex}"/> class constructor that allow the client to assign the two ends of the <see cref="Edge{TVertex}"/> object.
        /// </summary>
        /// <param name="end1">The first of the two <see cref="Edge{TVertex}"/> ends.</param>
        /// <param name="end2">The second of the two <see cref="Edge{TVertex}"/> ends.</param>
        /// <exception cref="ArgumentNullException">
        /// Either if <paramref name="end1"/> or <paramref name="end2"/> is equal to <see cref="null"/>.
        /// </exception>
        public Edge(TVertex end1, TVertex end2)
        {
            if (end1 == null)
            {
                throw new ArgumentNullException(nameof(end1));
            }

            if (end2 == null)
            {
                throw new ArgumentNullException(nameof(end2));
            }

            End1 = end1;
            End2 = end2;
        }

        /// <summary>
        /// The first end of this instance.
        /// </summary>
        public TVertex End1 { get; }

        /// <summary>
        /// The second end of this instance.
        /// </summary>
        public TVertex End2 { get; }

        /// <summary>
        /// Return the <see cref="string"/> representation of the current <see cref="Edge{TVertex}"/>instance.
        /// </summary>
        /// <returns>The <see cref="string"/> representation of the current <see cref="Edge{TVertex}"/>instance.</returns>
        public override string ToString()
        {
            return string.Format("{{ {0}, {1} }}", End1, End2);
        }

        /// <summary>
        /// The method <see cref="AreAdjacent(Edge{TVertex}, Edge{TVertex}, IEqualityComparer{TVertex})"/> check if the two edges <paramref name="edge1"/> and <paramref name="edge2"/> are adjacent.
        /// Meaning if they share a common vertex.
        /// </summary>
        /// <param name="edge1">A <see cref="Edge{TVertex}"/> to check if it is adjacent to <paramref name="edge2"/>.</param>
        /// <param name="edge2">A <see cref="Edge{TVertex}"/> to check if it is adjacent to <paramref name="edge1"/>.</param>
        /// <param name="vertexComparer">A <see cref="IEqualityComparer{T}"/> object to use to compare edges's ends.</param>
        /// <returns><see cref="true"/> if if the two edges <paramref name="edge1"/> and <paramref name="edge2"/> share a common vertex, <see cref="false"/> otherwise.</returns>
        public static bool AreAdjacent(Edge<TVertex> edge1, Edge<TVertex> edge2, IEqualityComparer<TVertex> vertexComparer)
        {
            return new TVertex[] { edge1.End1, edge1.End2 }
            .Intersect(new TVertex[] { edge2.End1, edge2.End2 }, vertexComparer)
            .Any();
        }
    }
}
