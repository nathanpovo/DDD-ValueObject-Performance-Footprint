using System;
using System.Collections.Generic;
using System.Reflection;

namespace DDD.ValueObject
{
    /// <summary>
    /// Implementation of DDD value object from Jimmy Bogard:
    /// http://grabbagoft.blogspot.com/2007/06/generic-value-object-equality.html
    /// </summary>
    public abstract class ValueObject_JB<T> : IEquatable<T>
            where T : ValueObject_JB<T>
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            T other = obj as T;

            return Equals(other);
        }

        public override int GetHashCode()
        {
            IEnumerable<FieldInfo> fields = GetField();

            int startValue = 17;
            int multiplier = 59;

            int hashcode = startValue;
            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(this);

                if (value != null)
                    hashcode = hashcode * multiplier + value.GetHashCode();
            }

            return hashcode;
        }

        public virtual bool Equals(T other)
        {
            if (other == null)
                return false;

            Type t = GetType();
            Type otherType = other.GetType();

            if (t != otherType)
                return false;

            FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (FieldInfo field in fields)
            {
                object value1 = field.GetValue(other);
                object value2 = field.GetValue(this);

                if (value1 == null)
                {
                    if (value2 != null)
                        return false;
                }
                else if (!value1.Equals(value2))
                    return false;
            }

            return true;
        }

        private IEnumerable<FieldInfo> GetField()
        {
            Type t = GetType();
            List<FieldInfo> fields = new List<FieldInfo>();

            while (t != typeof(object))
            {
                fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
                t = t.BaseType;
            }

            return fields;
        }

        public static bool operator ==(ValueObject_JB<T> x, ValueObject_JB<T> y)
        {
            return x.Equals(y);
        }
        public static bool operator !=(ValueObject_JB<T> x, ValueObject_JB<T> y)
        {
            return !(x == y);
        }
    }
}
