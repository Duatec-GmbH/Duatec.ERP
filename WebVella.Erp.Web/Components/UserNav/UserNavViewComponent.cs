using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebVella.Erp.Api;
using WebVella.Erp.Web.Services;

namespace WebVella.Erp.Web.Components
{

	public class UserNavViewComponent : ViewComponent
	{
		protected ErpRequestContext ErpRequestContext { get; set; }

		public UserNavViewComponent([FromServices]ErpRequestContext coreReqCtx)
		{
			ErpRequestContext = coreReqCtx;
		}

		public async Task<IViewComponentResult> InvokeAsync( )
		{
			var pageContext = ErpRequestContext.PageContext;
			ViewBag.CurrentUser = AuthService.GetUser(UserClaimsPrincipal);
			ViewBag.PageId = null;
			ViewBag.ReturnUrlEncoded = HttpUtility.UrlEncode(pageContext.HttpContext.Request.Path + pageContext.HttpContext.Request.QueryString);
			if (ErpRequestContext.Page != null) {
				ViewBag.PageId = ErpRequestContext.Page.Id;
			}

			return await Task.FromResult<IViewComponentResult>(View("UserNav.Default"));
		}
	}
}
