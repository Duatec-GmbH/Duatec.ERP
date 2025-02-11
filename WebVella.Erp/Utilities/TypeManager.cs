using System;
using System.Collections.Generic;
using System.Linq;

namespace WebVella.Erp.Utilities
{
	public static class TypeManager
	{
		private static readonly Dictionary<string, Type> _types = new();

		public static Type? GetEnum(string name)
		{
			var type = GetType(name);

			if (type != null && !type.IsEnum)
				type = null;

			return type;
		}

		public static Type? GetType(string name)
		{
			if (_types.TryGetValue(name, out var type))
				return type;

			var allTypes = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(a => a.GetTypes())
				.ToArray();

			type = allTypes.FirstOrDefault(t => t.FullName == name);

			if (type == null)
			{
				var types = allTypes.Where(t => t.Name == name)
				.ToArray();

				if (types.Length == 1)
					type = types[0];
			}

			_types.Add(name, type);
			return type;
		}
	}
}
