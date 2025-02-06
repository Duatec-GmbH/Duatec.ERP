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

		public static bool SequenceEquals(this IEnumerable col, IEnumerable other)
		{
			var itA = col.GetEnumerator();
			var itB = other.GetEnumerator();

			while (itA.MoveNext())
			{
				if (!itB.MoveNext())
					return false;

				if (itA.Current == null ^ itB.Current == null)
					return false;

				if (itA.Current != null)
				{
					if (itA.Current is IEnumerable enA)
					{
						if (itB.Current is not IEnumerable enB)
							return false;

						if (!SequenceEquals(enA, enB))
							return false;
					}
					else if (!itA.Current.Equals(itB.Current))
						return false;
				}
			}
			return itB.MoveNext();
		}
	}
}
