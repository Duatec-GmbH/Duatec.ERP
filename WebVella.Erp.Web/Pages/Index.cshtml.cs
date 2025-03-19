using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using WebVella.Erp.Diagnostics;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Web.Pages
{
	public class HomePageModel : BaseErpPageModel
	{
		public HomePageModel([FromServices] ErpRequestContext reqCtx) { ErpRequestContext = reqCtx; }

		public IActionResult OnGet()
		{
			try
			{
				var initResult = Init();
				if (initResult != null)
				{
					return initResult;
				}

				if (ErpRequestContext.Page == null) return NotFound();

				if (ExecutePageHooksOnGet() is IActionResult res)
					return res;

				foreach (var inst in HookManager.GetHookedInstances<IHomePageHook>(HookKey))
				{
					var result = inst.OnGet(this);
					if (result != null) return result;
				}

				BeforeRender();
				return Page();
			}
			catch (Exception ex)
			{
				new Log().Create(LogType.Error, "HomePageModel Error on GET", ex);
				BeforeRender();
				return Page();
			}

		}

		public IActionResult OnPost()
		{
			try
			{
				if (!ModelState.IsValid) throw new Exception("Antiforgery check failed.");
				var initResult = Init();
				if (initResult != null) return initResult;
				if (ErpRequestContext.Page == null) return NotFound();

				if (ExecutePageHooksOnPost() is IActionResult res)
					return res;

				foreach (var inst in HookManager.GetHookedInstances<IHomePageHook>(HookKey))
				{
					var result = inst.OnPost(this);
					if (result != null) return result;
				}

				BeforeRender();
				return Page();
			}
			catch (ValidationException valEx)
			{
				Validation.Message = valEx.Message;
				Validation.Errors.AddRange(valEx.Errors);
				BeforeRender();
				return Page();
			}
			catch (Exception ex)
			{
				new Log().Create(LogType.Error, "HomePageModel Error on POST", ex);
				BeforeRender();
				return Page();
			}
		}
	}
}

