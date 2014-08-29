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
            source.Insert(index, item);
            source.RemoveAt(++index);
        }
    }
}
