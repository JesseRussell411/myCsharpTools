using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Linq;

namespace JesseRussell.LinqExtension
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Ensures that the given key is in the dictionary, inserting the key paired with the value parameter if the key was not found.
        /// </summary>
        /// <typeparam name="K">Key type</typeparam>
        /// <typeparam name="V">Value type</typeparam>
        /// <param name="value">The value that will be inserted if the given key was not found. If the given key was found, the current value will not be modified and this parameter will not be used.</param>
        /// <returns>True if the key was found in the dictionary and False if the key was not found and needed to be inserted.</returns>
        public static bool EnsureKey<K, V>(this Dictionary<K, V> self, K key, V value = default)
        {
            if (self.ContainsKey(key)) { return true; }
            else
            {
                self.Add(key, value);
                return false;
            }
        }
        /// <summary>
        /// Adds the items in the stream to the Dictionary.
        /// </summary>
        public static void Fill<K, V>(this IDictionary<K, V> dict, IEnumerable<KeyValuePair<K, V>> stream) { foreach (KeyValuePair<K, V> p in stream) dict.Add(p); }
        /// <summary>
        /// Clears the Dictionary. Then, adds the items in the stream to it.
        /// </summary>
        public static void Refill<K, V>(this IDictionary<K, V> dict, IEnumerable<KeyValuePair<K, V>> stream)
        {
            dict.Clear();
            dict.Fill(stream);
        }

        /// <summary>
        /// Returns the value at the given key, or the given alternative if the key was not found.
        /// </summary>
        public static V GetValueOrAlternative<K, V>(this Dictionary<K, V> self, K key, V alternative)
        {
            if (self.TryGetValue(key, out V result))
                return result;
            else
                return alternative;
        }

        /// <summary>
        /// Returns the value at the given key, or the value provided by the alternative getter if the key was not found.
        /// </summary>
        public static V GetValueOrGetAlternative<K, V>(this Dictionary<K, V> self, K key, Func<V> getAlternative)
        {
            if (self.TryGetValue(key, out V result))
                return result;
            else
                return getAlternative();
        }

        /// <summary>
        /// Returns the value at the given key, or the given alternative if the key was not found.
        /// </summary>
        public static V GetValueOrAlternative<K, V>(this ImmutableDictionary<K, V> self, K key, V alternative)
        {
            if (self.TryGetValue(key, out V result))
                return result;
            else
                return alternative;
        }

        /// <summary>
        /// Returns the value at the given key, or the value provided by the alternative getter if the key was not found.
        /// </summary>
        public static V GetValueOrGetAlternative<K, V>(this ImmutableDictionary<K, V> self, K key, Func<V> getAlternative)
        {
            if (self.TryGetValue(key, out V result))
                return result;
            else
                return getAlternative();
        }

        /// <summary>
        /// Converts the collection of tuple pairs to KeyValuePairs
        /// </summary>
        public static IEnumerable<KeyValuePair<K, V>> ToKeyValuePairs<K, V>(this IEnumerable<(K key, V value)> tupleEnum) =>
            tupleEnum.Select(t => new KeyValuePair<K, V>(t.key, t.value));

        /// <summary>
        /// Converts the collection of tuple pairs to a Dictionary
        /// </summary>
        public static Dictionary<K, V> ToDictionary<K, V>(IEnumerable<(K key, V value)> tupleEnum) =>
            tupleEnum.ToKeyValuePairs().ToDictionary();

        /// <summary>
        /// Converts the collection of tuple pairs to an ImmutableDictionary
        /// </summary>
        public static ImmutableDictionary<K, V> ToImmutableDictionary<K, V>(IEnumerable<(K key, V value)> tupleEnum) =>
            tupleEnum.ToKeyValuePairs().ToImmutableDictionary();
    }
}
