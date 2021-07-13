using System;
using System.Collections.Generic;
using System.Text;

namespace JesseRussell.LinqExtension
{
    public static class SetExtensions
    {
        /// <summary>
        /// Adds the items in the stream to the Set.
        /// </summary>
        public static void Fill<T>(this ISet<T> set, IEnumerable<T> stream) { foreach (T i in stream) set.Add(i); }
        /// <summary>
        /// Clears the Set.Then adds the items in the stream to it.
        /// </summary>
        public static void Refill<T>(this ISet<T> set, IEnumerable<T> stream)
        {
            set.Clear();
            set.Fill(stream);
        }
    }
}
