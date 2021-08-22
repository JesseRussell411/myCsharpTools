using System;
using System.Collections.Generic;
using System.Text;

namespace JesseRussell.LinqExtension
{
    public static class ListExtensions
    {
        /// <summary>
        /// Adds the items in the stream to the List.
        /// </summary>
        public static void Fill<T>(this IList<T> list, IEnumerable<T> content) { foreach (T i in content) list.Add(i); }
        /// <summary>
        /// Clears the List.Then adds the items in the stream to it.
        /// </summary>
        public static void Refill<T>(this IList<T> list, IEnumerable<T> content)
        {
            list.Clear();
            list.Fill(content);
        }
        /// <summary>
        /// Returns whether the index is not out of bounds.
        /// </summary>
        public static bool ContainsIndex<T>(this IList<T> list, int index) => index < list.Count && index >= 0;

        /// <summary>
        /// Returns the value at the given index or a default value if the index is out of bounds.
        /// </summary>
        public static T GetValueOrDefault<T>(this IList<T> list, int index)
        {
            if (list.ContainsIndex(index))
                return list[index];
            else
                return default;
        }

        /// <summary>
        /// Tries to find the value at the given index.
        /// </summary>
        /// <param name="value">Returns the value if found.</param>
        /// <returns>Whether the value was found. If false: the index is out of bounds.</returns>
        public static bool TryGetValue<T>(this IList<T> list, int index, out T value)
        {
            if (list.ContainsIndex(index))
            {
                value = list[index];
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

    }
}
