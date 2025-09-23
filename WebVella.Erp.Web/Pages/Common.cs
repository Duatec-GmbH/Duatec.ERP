using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace WebVella.Erp.Web.Pages
{
	internal class Common
	{
		public static IActionResult TryRedirectToListFromReturnUrl(ErpRequestContext reqContext)
		{
			if (reqContext?.PageContext?.HttpContext?.Request?.Query.TryGetValue("returnUrl", out var returnUrlVal) is true)
			{
				var returnUrl = $"{returnUrlVal}";
				var listPage = $"/{reqContext.App.Name}/{reqContext.SitemapArea.Name}/{reqContext.SitemapNode.Name}/l/";

				while (!string.IsNullOrWhiteSpace(returnUrl) && !returnUrl.StartsWith(listPage))
				{
					const string pattern = "returnUrl=";
					var returnUrlIndex = returnUrl.IndexOf(pattern);

					if (returnUrlIndex >= 0)
						returnUrl = HttpUtility.UrlDecode(returnUrl[(returnUrlIndex + pattern.Length)..]);

					else returnUrl = string.Empty;
				}

				if (!string.IsNullOrWhiteSpace(returnUrl))
					return new LocalRedirectResult(returnUrl);
			}

			return new NotFoundResult(); 
		}
	}
}
