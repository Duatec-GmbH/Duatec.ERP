using System;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Web.Utils
{
	public static class PageModelExtensions
	{
#nullable enable

		public static string EntityListUrl(this BaseErpPageModel pageModel, string? pageName = null)
			=> EntityPage(pageModel, 'l', pageName);

		public static string EntityDetailUrl(this BaseErpPageModel pageModel, Guid id, string? pageName = null)
			=> EntityGuidPage(pageModel, 'r', id, pageName);

		public static string EntityManageUrl(this BaseErpPageModel pageModel, Guid id, string? pageName = null)
			=> EntityGuidPage(pageModel, 'm', id, pageName);

		public static string EntityCreateUrl(this BaseErpPageModel pageModel, string? pageName = null)
			=> EntityPage(pageModel, 'c', pageName);


		private static string EntityPage(BaseErpPageModel pageModel, char pageKind, string? pageName = null)
		{
			var ctx = pageModel.ErpRequestContext;
			var result = $"/{ctx?.App?.Name}/{ctx?.SitemapArea?.Name}/{ctx?.SitemapNode?.Name}/{pageKind}";

			if (!string.IsNullOrEmpty(pageName))
				result += '/' + pageName;
			return result;
		}

		private static string EntityGuidPage(BaseErpPageModel pageModel, char pageKind, Guid id, string? pageName = null)
		{
			var result = EntityPage(pageModel, pageKind) + $"/{id}";
			if (!string.IsNullOrEmpty(pageName))
				result += '/' + pageName;
			return result;
		}
#nullable restore
	}
}
