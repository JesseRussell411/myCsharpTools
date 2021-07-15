using System;
using System.Collections.Generic;
using System.Linq;

namespace JesseRussell.LinqExtension
{
    public static class LinqExtensions
    {
        // Clone of javascript's ForEach. Like select but with no return value. Runs the given action on each item in the stream.
        public static void ForEach<T>(this IEnumerable<T> stream, Action<T> action)
        {
            foreach(T item in stream)
            {
                action(item);
            }
        }

        // Prints the called-on object with Console.WriteLine by default.
        public static void PrintSelf(this object self, Action<object> printFunction = null) => (printFunction ?? Console.WriteLine)(self);

        // Produces a dictionary form a stream of KeyValuePairs
        public static Dictionary<K, V> ToDictionary<K, V>(this IEnumerable<KeyValuePair<K, V>> stream) => stream.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
}
