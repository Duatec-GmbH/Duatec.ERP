using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace WebVella.Erp.Web.Hooks
{
	internal class ParameterizedHook
	{
		public static Dictionary<string, string?> GetArguments(IParameterizedPageHook hook, IQueryCollection query)
		{
			return hook.Parameters
				.ToDictionary(p => p, p => query.TryGetValue(p, out var value) ? $"{value}" : null);
		} 
	}
}
