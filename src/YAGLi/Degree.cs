using System;

namespace YAGLi
{
    public struct Degree : IComparable, IComparable<Degree>, IEquatable<Degree>
    {
        private const int HASH_BASE = 163;
        private const int HASH_FACTOR = 167;
        public static readonly Degree Impossible = new Degree(-1);
        public static readonly Degree Zero = new Degree(0);

        public Degree(int value)
        {
            _value = value < 0 ? -1 : value;
        }

        private int _value { get; set; }

        public int CompareTo(Degree other)
        {
            if (_value > other._value)
            {
                return 1;
            }

            if (_value < other._value)
            {
                return -1;
            }

            return 0;
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 1;
            }

            if (!(obj is Degree))
            {
                return -1;
            }

            return CompareTo((Degree)obj);
        }

        public bool Equals(Degree other)
        {
            return _value == other._value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)
                || !(obj is Degree))
            {
                return false;
            }

            return Equals((Degree)obj);
        }

        public override int GetHashCode()
        {
            var hash = HASH_BASE;
            hash = hash * HASH_FACTOR + _value.GetHashCode();

            return hash;
        }

        public override string ToString()
        {
            return Equals(Impossible) ? nameof(Impossible) : _value.ToString();
        }

        public static Degree operator +(Degree degree1, Degree degree2)
        {
            if (degree1.Equals(Impossible) || degree2.Equals(Impossible))
            {
                return Impossible;
            }

            return new Degree(degree1._value + degree2._value);
        }

        public static Degree operator -(Degree degree1, Degree degree2)
        {
            if (degree1.Equals(Impossible) || degree2.Equals(Impossible))
            {
                return Impossible;
            }

            return new Degree(degree1._value - degree2._value);
        }

        public static bool operator ==(Degree degree1, Degree degree2)
        {
            return degree1.Equals(degree2);
        }

        public static bool operator !=(Degree degree1, Degree degree2)
        {
            return !degree1.Equals(degree2);
        }

        public static bool operator <(Degree degree1, Degree degree2)
        {
            return degree1._value < degree2._value;
        }

        public static bool operator >(Degree degree1, Degree degree2)
        {
            return degree1._value > degree2._value;
        }

        public static bool operator <=(Degree degree1, Degree degree2)
        {
            return degree1 < degree2 || degree1 == degree2;
        }

        public static bool operator >=(Degree degree1, Degree degree2)
        {
            return degree1 > degree2 || degree1 == degree2;
        }

        public static implicit operator Degree(int value)
        {
            return new Degree(value);
        }

        public static implicit operator int(Degree degree)
        {
            return degree._value;
        }
    }
}
