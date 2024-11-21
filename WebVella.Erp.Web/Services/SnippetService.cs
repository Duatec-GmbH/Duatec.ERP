using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Web.Services
{
	internal static class SnippetService
	{
		private static readonly Dictionary<string, ICodeVariable> _snippets = [];

		public static IReadOnlyDictionary<string, ICodeVariable> Snippets => _snippets;

		static SnippetService()
		{
			lock (_snippets)
			{
				var types = AppDomain.CurrentDomain.GetAssemblies()
					.Where(a => a.FullName.StartsWith("WebVella.Erp.Plugins"))
					.SelectMany(t => t.GetTypes().Where(t => t.GetCustomAttributes<SnippetAttribute>().Any()));

				foreach (var type in types)
				{
					if (Activator.CreateInstance(type) is ICodeVariable instance)
						_snippets.Add(type.FullName, instance);
				}
			}
		}

		public static ICodeVariable? GetSnippet(string name)
		{
			if (!_snippets.TryGetValue(name, out var variable))
				return null;
			return variable;
		}
	}
}
