using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Web.Hooks
{
#nullable enable

	[Hook("Global page hooks")]
	public interface IParameterizedPageHook
	{
		string[] Parameters { get; }

		IActionResult? OnGet(BaseErpPageModel pageModel, Dictionary<string, string?> args);

		IActionResult? OnPost(BaseErpPageModel pageModel, Dictionary<string, string?> args);
	}
#nullable restore
}
