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

    }
}
