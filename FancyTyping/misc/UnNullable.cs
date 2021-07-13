using System;

namespace JesseRussell.FancyTyping
{
    public readonly struct Foo
    {

    }
    /// <summary>
    /// Attempts to guarantee a non null value. In practice it is possible to store a null
    /// value in this data type by using its default constructor or the default keyword which is
    /// why a null check is performed when accessing the Value property. The real goal of this 
    /// type is really to catch a null reference as early as possible. In most cases this will be
    /// at instantiation, but sometimes it will occur later.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public readonly struct UnNullable<T>
    {
        /// <summary>
        /// Unfortunately, It is possible for The value to be null if the UnNullable has been created using it's default constructor or the default keyword.
        /// In this case, a NullReferenceException will be thrown, not at instantiation, but when the value is accessed. If desired, the user can access this field instead to override the null check.
        /// </summary>
        public readonly T NullableValue;
        public T Value => NullableValue ?? throw new NullReferenceException();

        public UnNullable(T value)
        {
            NullableValue = value ?? throw new NullReferenceException();
        }

        public static explicit operator UnNullable<T>(T value) => new UnNullable<T>(value);
        public static implicit operator T(UnNullable<T> value) => value.Value;

        // obligatory object methods:
        public override string ToString() => Value.ToString();
        public override int GetHashCode() => Value.GetHashCode();
        public override bool Equals(object obj) => Value.Equals(obj);
    }

    public static class UnNullableExtensions
    {
        public static UnNullable<T> ToUnNullable<T>(this T self) => new UnNullable<T>(self);
    }
}
