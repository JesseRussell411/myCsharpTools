using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace JesseRussell.LinqExtension
{
    public static class LinqExtensions
    {
        // Clone of javascript's ForEach. Like select but with no return value. Runs the given action on each item in the stream.
        public static void ForEach<T>(this IEnumerable<T> stream, Action<T> action)
        {
            foreach (T item in stream)
            {
                action(item);
            }
        }

        // Prints the called-on object with Console.WriteLine by default.
        public static void PrintSelf(this object self, Action<object> printFunction = null) => (printFunction ?? Console.WriteLine)(self);

        // Produces a dictionary from a stream of KeyValuePairs
        public static Dictionary<K, V> ToDictionary<K, V>(this IEnumerable<KeyValuePair<K, V>> stream) => stream.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> stream, int times)
        {
            bool toCache()
            {
                // to cache or not to cache, that is the question.
                if (times <= 1) return false;
                if (stream is string) return false;
                return true;
            }

            IEnumerable<T> streamToUse = toCache() ? stream : stream.ToArray();
            
            for(int i = 0; i < times; ++i)
                foreach(T item in streamToUse)
                    yield return item;
        }
        public static string BuildString(this IEnumerable<char> charStream)
        {
            StringBuilder resultBuilder = new StringBuilder();

            foreach (char c in charStream)
                resultBuilder.Append(c);

            return resultBuilder.ToString();
        }

        public static string BuildString(this IEnumerable<string> stream)
        {
            StringBuilder resultBuilder = new StringBuilder();

            foreach (string s in stream)
                resultBuilder.Append(s);

            return resultBuilder.ToString();
        }
    }
}
