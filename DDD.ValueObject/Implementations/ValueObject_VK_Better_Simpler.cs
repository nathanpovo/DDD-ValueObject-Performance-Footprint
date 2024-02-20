using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.ValueObject
{
    /// <summary>
    /// The most recent implementation of DDD value object from Vladimir Khorikov:
    /// https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
    /// https://github.com/vkhorikov/CSharpFunctionalExtensions/blob/81405ec818ef377fd43c939668c69ba81d713972/CSharpFunctionalExtensions/ValueObject/ValueObject.cs
    /// </summary>
    [Serializable]
    public abstract class ValueObject_VK_Better_Simpler : IComparable, IComparable<ValueObject_VK_Better_Simpler>
    {
        private int? _cachedHashCode;

        protected abstract IEnumerable<IComparable> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            var valueObject = (ValueObject_VK_Better_Simpler)obj;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();

            foreach (var item in GetEqualityComponents())
            {
                hashCode.Add(item);
            }

            return hashCode.ToHashCode();
        }

        
        public virtual int CompareTo(ValueObject_VK_Better_Simpler other)
        {
            if (other is null)
                return 1;

            if (ReferenceEquals(this, other))
                return 0;

            Type thisType = GetType();
            Type otherType = other.GetType();
            if (thisType != otherType)
                return string.Compare($"{thisType}", $"{otherType}", StringComparison.Ordinal);

            return
                GetEqualityComponents().Zip(
                    other.GetEqualityComponents(),
                    (left, right) =>
                        left?.CompareTo(right) ?? (right is null ? 0 : -1))
                .FirstOrDefault(cmp => cmp != 0);
        }

        public virtual int CompareTo(object other) 
        {
            return CompareTo(other as ValueObject_VK_Better_Simpler);
        }

        public static bool operator ==(ValueObject_VK_Better_Simpler a, ValueObject_VK_Better_Simpler b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject_VK_Better_Simpler a, ValueObject_VK_Better_Simpler b)
        {
            return !(a == b);
        }
    }
}
