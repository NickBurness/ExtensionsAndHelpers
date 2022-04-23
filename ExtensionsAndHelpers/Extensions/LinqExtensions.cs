namespace ExtensionsAndHelpers
{
    public static class LinqExtensions
    {
		public static bool None<T>(this IEnumerable<T> source)
		{
			return source.Any() == false;
		}

		public static bool None<T>(this IEnumerable<T> source, Func<T, bool> query)
		{
			return source.Any(query) == false;
		}

		public static bool Many<T>(this IEnumerable<T> source)
		{
			return source.Count() > 1;
		}

		public static bool Many<T>(this IEnumerable<T> source, Func<T, bool> query)
		{
			return source.Count(query) > 1;
		}

		public static bool OneOf<T>(this IEnumerable<T> source)
		{
			return source.Count() == 1;
		}

		public static bool OneOf<T>(this IEnumerable<T> source, Func<T, bool> query)
		{
			return source.Count(query) == 1;
		}

		public static bool XOf<T>(this IEnumerable<T> source, int count)
		{
			return source.Count() == count;
		}

		public static bool XOf<T>(this IEnumerable<T> source, Func<T, bool> query, int count)
		{
			return source.Count(query) == count;
		}
	}
}
