using System;
using System.Collections.Generic;
using System.Text;

namespace JesseRussell.LinqExtension
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Adds the items in the stream to the Collection.
        /// </summary>
        public static void Fill<T>(this ICollection<T> collection, IEnumerable<T> stream) { foreach (T i in stream) collection.Add(i); }

        /// <summary>
        /// Clears the Collection.Then adds the items in the stream to it.
        /// </summary>
        public static void Refill<T>(this ICollection<T> collection, IEnumerable<T> stream)
        {
            collection.Clear();
            collection.Fill(stream);
        }
    }
}
