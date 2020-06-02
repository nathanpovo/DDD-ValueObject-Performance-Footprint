using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.ValueObject
{
    /// <summary>
    /// Implementation of DDD value object from Vladimir Khorikov:
    /// https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
    /// </summary>
    public abstract class ValueObject_VK_Better
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            var valueObject = (ValueObject_VK_Better)obj;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(1, (current, obj) =>
                {
                    unchecked
                    {
                        return current * 23 + (obj?.GetHashCode() ?? 0);
                    }
                });
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public static bool operator ==(ValueObject_VK_Better a, ValueObject_VK_Better b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject_VK_Better a, ValueObject_VK_Better b)
        {
            return !(a == b);
        }
    }
}
