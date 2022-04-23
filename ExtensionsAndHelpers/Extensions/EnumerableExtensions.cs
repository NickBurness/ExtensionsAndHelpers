namespace ExtensionsAndHelpers
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Processes items in a collection until the end condition is true.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="condition">The condition that returns true if iteration should stop.</param>
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            return collection.TakeWhile(item => !condition(item));
        }
    }
}
