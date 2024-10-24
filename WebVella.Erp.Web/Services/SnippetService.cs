using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Web.Services
{
	internal static class SnippetService
	{
		public static Dictionary<string, ICodeVariable> Snippets { get; } = [];

		static SnippetService()
		{
			var types = AppDomain.CurrentDomain.GetAssemblies()
				.Where(a => a.FullName.StartsWith("WebVella.Erp.Plugins"))
				.SelectMany(t => t.GetTypes().Where(t => t.GetCustomAttributes<SnippetAttribute>().Any()));

			foreach(var type in types)
			{
				if (Activator.CreateInstance(type) is ICodeVariable instance)
					Snippets.Add(type.FullName, instance);
			}
		}

		public static ICodeVariable? GetSnippet(string name)
		{
			if (!Snippets.TryGetValue(name, out var variable))
				return null;
			return variable;
		}
	}
}
