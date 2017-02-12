using System;
using System.Collections.Generic;

namespace YAGL
{
    /// <summary>
    /// The class <see cref="Edge{TData}"/> models the fundamental unit of wich graphs are formed in Graph Theory.
    /// </summary>
    /// <typeparam name="TData">The type of the vertices.</typeparam>
    public class Edge<TData>
    {
        /// <summary>
        /// The field that store the first of the two <see cref="Edge{TData}"/> ends.
        /// </summary>
        private TData _end1;

        /// <summary>
        /// The field that store the second of the two <see cref="Edge{TData}"/> ends.
        /// </summary>
        private TData _end2;

        /// <summary>
        /// <see cref="Edge{TData}"/> class constructor that allow the client to assign the two ends of the <see cref="Edge{TData}"/> object.
        /// </summary>
        /// <param name="end1">The first of the two <see cref="Edge{TData}"/> ends.</param>
        /// <param name="end2">The second of the two <see cref="Edge{TData}"/> ends.</param>
        /// <exception cref="ArgumentNullException">
        /// Either if <paramref name="end1"/> or <paramref name="end2"/> is equal to <see cref="null"/>.
        /// </exception>
        public Edge(TData end1, TData end2)
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
        public IEnumerable<TData> Ends { get { yield return _end1; yield return _end2; } }

        /// <summary>
        /// Determine if the paramter <paramref name="obj"/> is equal to this instance.
        /// The result of this method is equivalent to calling the method <see cref="Equals(Edge{TData}, EdgeComparison)"/> with the value <see cref="EdgeComparison.ConsiderDirection"/>.
        /// </summary>
        /// <param name="obj">The other object to compare to this instance.</param>
        /// <returns><see cref="true"/> if the object <paramref name="obj"/> is equal to this instance. <see cref="false"/> otherwise.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Edge<TData>, EdgeComparison.ConsiderDirection);
        }

        /// <summary>
        /// Determine if the parameter <paramref name="other"/> is equal to this instance.
        /// </summary>
        /// <param name="other">The other <see cref="Edge{TData}"/> object to compare to this instance.</param>
        /// <param name="comparisonType">One of the value of <see cref="EdgeComparison"/> who determine the way of comparing the two <see cref="Edge{TData}"/> objects.</param>
        /// <returns><see cref="true"/> if the parameter <paramref name="other"/> is equal to this instance. <see cref="false"/> otherwise.</returns>
        /// <exception cref="ArgumentException"> If <paramref name="comparisonType"/> is not a value from <see cref="EdgeComparison"/>.</exception>
        public bool Equals(Edge<TData> other, EdgeComparison comparisonType)
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
        /// <param name="other">The other <see cref="Edge{TData}"/> object to compare to this instance.</param>
        /// <returns><see cref="true"/> if the parameter <paramref name="other"/> is equal to this instance. <see cref="false"/> otherwise.</returns>
        private bool haveTheSameFieldsReferences(Edge<TData> other)
        {
            return _end1.Equals(other._end1) && _end2.Equals(other._end2);
        }

        /// <summary>
        /// The <see cref="Edge{TData}"/> hashing method.
        /// </summary>
        /// <returns>The hashed value of this instance.</returns>
        public override int GetHashCode()
        {
            int hash = 17;

            hash = hash * 23 + _end1.GetHashCode();
            hash = hash * 23 + _end2.GetHashCode();

            return hash;
        }

        public override string ToString()
        {
            return string.Format("{{ {0}, {1} }}", _end1, _end2);
        }
    }
}
