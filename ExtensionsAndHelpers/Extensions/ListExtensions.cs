namespace ExtensionsAndHelpers
{
    public static class ListExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="condition"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<T> AddIf<T>(this List<T> list, bool condition, T item)
        {
            if (condition)
            {
                list.Add(item);
            }

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="condition"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static List<T> AddRangeIf<T>(this List<T> list, bool condition, IEnumerable<T> items)
        {
            if (condition)
            {
                list.AddRange(items);
            }

            return list;
        }
    }
}
