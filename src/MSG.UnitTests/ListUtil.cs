using System;
using System.Collections.Generic;

namespace MSG.UnitTests
{
    public static class ListUtil
    {
        /// <summary>
        /// Replace the List item at the specified index with the specified item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public static void ReplaceAt<T>(this IList<T> source, int index, T item)
        {
            // Note that some of these exceptions are already handled by Insert. They were added for
            // educational purposes.

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (index > source.Count - 1)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            source.Insert(index, item);
            source.RemoveAt(++index);
        }
    }
}
