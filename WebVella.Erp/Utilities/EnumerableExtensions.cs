using System;
using System.Collections;

namespace WebVella.Erp.Utilities
{
    public static class EnumerableExtensions
    {
		public static bool Any(this IEnumerable en, Func<object, bool> fun)
		{
			foreach (var obj in en)
				if (fun(obj))
					return true;
			return false;
		}

		public static bool Any(this IEnumerable en)
		{
			foreach (var _ in en)
				return true;
			return false;
		}
	}
}
