using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Services;

namespace WebVella.Erp.Web.Pages
{
	[AllowAnonymous]
	public class LoginModel : BaseErpPageModel
	{
		[BindProperty]
		public string Username { get; set; }

		[BindProperty]
		public string Password { get; set; }

		[BindProperty(Name = "returnUrl")]
		public new string ReturnUrl { get; set; }

		[BindProperty]
		public string Error { get; set; }

		public bool IsMobile { get; private set; }

		public string BrandLogo { get; set; }

		public LoginModel([FromServices]ErpRequestContext reqCtx) { ErpRequestContext = reqCtx; }

		public IActionResult OnGet([FromServices]AuthService authService)
		{
			var initResult = Init();
			if (initResult != null) 
				return initResult;

			if (ExecutePageHooksOnGet() is IActionResult res)
				return res;

			IsMobile = ErpRequestContext.IsNonDesktopDevice;

			if (CurrentUser != null)
			{
				if (!string.IsNullOrWhiteSpace(ReturnUrl))
					return new LocalRedirectResult(ReturnUrl);
				else
					return new LocalRedirectResult("/");
			}

			var appContext = ErpAppContext.Current;
			var currentApp = ErpRequestContext.App;
			var theme = appContext.Theme;
			BrandLogo = theme.BrandLogo;
			if (!String.IsNullOrWhiteSpace(ErpSettings.NavLogoUrl))
			{
				BrandLogo = ErpSettings.NavLogoUrl;
			}
			BeforeRender();
			return Page();
		}

		public IActionResult OnPost([FromServices]AuthService authService)
		{
			if (!ModelState.IsValid) throw new Exception("Antiforgery check failed.");

			var initResult = Init();
			if (initResult != null) return initResult;

			if (ExecutePageHooksOnPost() is IActionResult res)
				return res;

			var hookInstances = HookManager.GetHookedInstances<ILoginPageHook>(HookKey);
			foreach (var inst in hookInstances)
			{
				var result = inst.OnPostPreLogin(this);
				if (result != null) return result;
			}

			ErpUser user = authService.Authenticate(Username, Password);

			foreach (var inst in hookInstances)
			{
				var result = inst.OnPostAfterLogin(user, this);
				if (result != null) return result;
			}

			if (user == null)
			{
				Error = "Invalid username or password";
				BeforeRender();
				return Page();
			}

			if (!string.IsNullOrWhiteSpace(ReturnUrl))
				return new LocalRedirectResult(ReturnUrl);
			else
				return new LocalRedirectResult("/");

		}
	}
}
/*
 * system actions: OnPost: success,error
 * custom actions: none
 */
