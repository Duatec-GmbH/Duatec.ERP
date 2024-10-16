using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Services;

namespace WebVella.Erp.Web.Pages
{
	public class LogoutModel : BaseErpPageModel
	{
		public LogoutModel([FromServices]ErpRequestContext reqCtx) { ErpRequestContext = reqCtx; }

		public IActionResult OnGet([FromServices]AuthService authService)
        {
			var initResult = Init();
			if (initResult != null) return initResult;
			authService.Logout();

			if (ExecutePageHooksOnGet() is IActionResult res)
				return res;

			foreach (var inst in HookManager.GetHookedInstances<ILogoutPageHook>(HookKey))
			{
				var result = inst.OnGet(this);
				if (result != null) return result;
			}

			return new LocalRedirectResult("/");
		}

		public IActionResult OnPost([FromServices]AuthService authService)
		{
			var initResult = Init();
			if (initResult != null) return initResult;
			authService.Logout();

			if (ExecutePageHooksOnPost() is IActionResult res)
				return res;

			foreach (var inst in HookManager.GetHookedInstances<ILogoutPageHook>(HookKey))
			{
				var result = inst.OnPost(this);
				if (result != null) return result;
			}

			return new LocalRedirectResult("/");
		}
	}
}
