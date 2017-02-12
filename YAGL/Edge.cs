using System;
using System.Collections.Generic;
using System.Linq;

namespace YAGL
{
    /// <summary>
    /// The class <see cref="Edge{TVertex}"/> models the fundamental unit of wich graphs are formed in Graph Theory.
    /// </summary>
    /// <typeparam name="TVertex">The type of the vertices.</typeparam>
    public class Edge<TVertex> where TVertex : IEquatable<TVertex> 
    {
        /// <summary>
        /// The field that store the first of the two <see cref="Edge{TVertex}"/> ends.
        /// </summary>
        private TVertex _end1;

        /// <summary>
        /// The field that store the second of the two <see cref="Edge{TVertex}"/> ends.
        /// </summary>
        private TVertex _end2;

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

            _end1 = end1;
            _end2 = end2;
        }

        /// <summary>
        /// The vertices end of this instance.
        /// </summary>
        public IEnumerable<TVertex> Ends { get { yield return _end1; yield return _end2; } }

        /// <summary>
        /// Determine if the paramter <paramref name="obj"/> is equal to this instance.
        /// The result of this method is equivalent to calling the method <see cref="Equals(Edge{TVertex}, EdgeComparison)"/> with the value <see cref="EdgeComparison.ConsiderDirection"/>.
        /// </summary>
        /// <param name="obj">The other object to compare to this instance.</param>
        /// <returns><see cref="true"/> if the object <paramref name="obj"/> is equal to this instance. <see cref="false"/> otherwise.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Edge<TVertex>, EdgeComparison.ConsiderDirection);
        }

        /// <summary>
        /// Determine if the parameter <paramref name="other"/> is equal to this instance.
        /// </summary>
        /// <param name="other">The other <see cref="Edge{TVertex}"/> object to compare to this instance.</param>
        /// <param name="comparisonType">One of the value of <see cref="EdgeComparison"/> who determine the way of comparing the two <see cref="Edge{TVertex}"/> objects.</param>
        /// <returns><see cref="true"/> if the parameter <paramref name="other"/> is equal to this instance. <see cref="false"/> otherwise.</returns>
        /// <exception cref="ArgumentException"> If <paramref name="comparisonType"/> is not a value from <see cref="EdgeComparison"/>.</exception>
        public bool Equals(Edge<TVertex> other, EdgeComparison comparisonType)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            switch (comparisonType)
            {
                case EdgeComparison.ConsiderDirection:
                    return haveTheSameFieldsReferences(other);

                case EdgeComparison.IgnoreDirection:
                    return haveTheSameFieldsReferences(other) || _end1.Equals(other._end2) && _end2.Equals(other._end1);

                default:
                    throw new ArgumentException(string.Format("Not supported {0} value.", typeof(EdgeComparison)), nameof(comparisonType));
            }
        }

        /// <summary>
        /// Determine if the parameter <paramref name="other"/> have the same references setted to his fields as this instance.
        /// </summary>
        /// <param name="other">The other <see cref="Edge{TVertex}"/> object to compare to this instance.</param>
        /// <returns><see cref="true"/> if the parameter <paramref name="other"/> is equal to this instance. <see cref="false"/> otherwise.</returns>
        private bool haveTheSameFieldsReferences(Edge<TVertex> other)
        {
            return _end1.Equals(other._end1) && _end2.Equals(other._end2);
        }

        /// <summary>
        /// The <see cref="Edge{TVertex}"/> hashing method.
        /// </summary>
        /// <returns>The hashed value of this instance.</returns>
        public override int GetHashCode()
        {
            int hash = 17;

            hash = hash * 23 + _end1.GetHashCode();
            hash = hash * 23 + _end2.GetHashCode();

            return hash;
        }

        /// <summary>
        /// Return the <see cref="string"/> representation of the current <see cref="Edge{TVertex}"/>instance.
        /// </summary>
        /// <returns>The <see cref="string"/> representation of the current <see cref="Edge{TVertex}"/>instance.</returns>
        public override string ToString()
        {
            return string.Format("{{ {0}, {1} }}", _end1, _end2);
        }

        /// <summary>
        /// The function <see cref="IsAdjacentTo(Edge{TVertex})"/> determine whether the parameter <paramref name="otherEdge"/> is adjacent to this instance.
        /// Meaning if they share a common end vertex.
        /// </summary>
        /// <param name="otherEdge">The other <see cref="Edge{TVertex}"/> object to determine whether or not this instance is adjacent to.</param>
        /// <returns><see cref="true"/> if this instance is adjacent to <paramref name="otherEdge"/>, <see cref="false"/> otherwise.</returns>
        public bool IsAdjacentTo(Edge<TVertex> otherEdge)
        {
            return Ends.Intersect(otherEdge.Ends).Any();
        }

        /// <summary>
        /// The method <see cref="AreAdjacent(Edge{TVertex}[])"/> determine if the collection of <see cref="Edge{TVertex}"/> objects <paramref name="edges"/> are adjacent or not.
        /// </summary>
        /// <param name="edges">The collection of <see cref="Edge{TVertex}"/> objects to determine if they are adjacent or not.</param>
        /// <returns><see cref="true"/> if the collection of <see cref="Edge{TVertex}"/> objects <paramref name="edges"/> are adjacent, <see cref="false"/> otherwise.</returns>
        public static bool AreAdjacent(params Edge<TVertex>[] edges)
        {
            foreach (var edge1 in edges)
            {
                foreach (var edge2 in edges)
                {
                    if (ReferenceEquals(edge1, edge2))
                    {
                        continue;
                    }

                    if (!edge1.IsAdjacentTo(edge2))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
