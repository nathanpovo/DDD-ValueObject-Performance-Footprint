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
    public abstract class ValueObject_VK_Better_Updated : IComparable, IComparable<ValueObject_VK_Better_Updated>
    {
        private int? _cachedHashCode;

        protected abstract IEnumerable<IComparable> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetUnproxiedType(this) != GetUnproxiedType(obj))
                return false;

            var valueObject = (ValueObject_VK_Better_Updated)obj;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            if (!_cachedHashCode.HasValue)
            {
                _cachedHashCode = GetEqualityComponents()
                    .Aggregate(1, (current, obj) =>
                    {
                        unchecked
                        {
                            return current * 23 + (obj?.GetHashCode() ?? 0);
                        }
                    });
            }

            return _cachedHashCode.Value;
        }

        
        public virtual int CompareTo(ValueObject_VK_Better_Updated other)
        {
            if (other is null)
                return 1;

            if (ReferenceEquals(this, other))
                return 0;

            Type thisType = GetUnproxiedType(this);
            Type otherType = GetUnproxiedType(other);
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
            return CompareTo(other as ValueObject_VK_Better_Updated);
        }

        public static bool operator ==(ValueObject_VK_Better_Updated a, ValueObject_VK_Better_Updated b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject_VK_Better_Updated a, ValueObject_VK_Better_Updated b)
        {
            return !(a == b);
        }

        internal static Type GetUnproxiedType(object obj)
        {
            const string EFCoreProxyPrefix = "Castle.Proxies.";
            const string NHibernateProxyPostfix = "Proxy";

            Type type = obj.GetType();
            string typeString = type.ToString();

            if (typeString.Contains(EFCoreProxyPrefix) || typeString.EndsWith(NHibernateProxyPostfix))
                return type.BaseType;

            return type;
        }
    }
}
