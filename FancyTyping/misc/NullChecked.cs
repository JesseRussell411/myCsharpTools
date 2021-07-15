using System;

namespace JesseRussell.FancyTyping
{
    /// <summary>
    /// Attempts to guarantee a non null value. In practice it is possible to store a null
    /// value in this data type by using its default constructor or the default keyword which is
    /// why a null check is performed when accessing the Value property. The real goal of this 
    /// type is really to catch a null reference as early as possible. In most cases this will be
    /// at instantiation, but sometimes it will occur later.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public readonly struct NullChecked<T>
    {
        public readonly T NullableValue;
        public T Value => NullableValue ?? throw new NullReferenceException();

        public NullChecked(T value)
        {
            NullableValue = value ?? throw new NullReferenceException();
        }

        public static implicit operator NullChecked<T>(T value) => new NullChecked<T>(value);
        public static implicit operator T(NullChecked<T> value) => value.Value;

        // obligatory object methods:
        public override string ToString() => Value.ToString();
        public override int GetHashCode() => Value.GetHashCode();
        public override bool Equals(object obj) => Value.Equals(obj);
    }
}
