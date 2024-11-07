using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Util
{
    internal static class PageUrl
    {
        public static string EntityList(BaseErpPageModel pageModel, string? pageName = null)
            => EntityPage('l', pageModel, pageName);

        public static string EntityDetail(BaseErpPageModel pageModel, Guid id, string? pageName = null)
            => EntityGuidPage('r', pageModel, id, pageName);

        public static string EntityManage(BaseErpPageModel pageModel, Guid id, string? pageName = null)
            => EntityGuidPage('m', pageModel, id, pageName);

        public static string EntityCreate(BaseErpPageModel pageModel, string? pageName = null)
            => EntityPage('c', pageModel, pageName);


        private static string EntityPage(char pageKind, BaseErpPageModel pageModel, string? pageName = null)
        {
            var context = pageModel.ErpRequestContext;
            var result = $"/{context?.App?.Name}/{context?.SitemapArea?.Name}/{context?.SitemapNode?.Name}/{pageKind}";

            if (!string.IsNullOrEmpty(pageName))
                result += '/' + pageName;
            return result;
        }

        private static string EntityGuidPage(char pageKind, BaseErpPageModel pageModel, Guid id, string? pageName = null)
        {
            var result = EntityPage(pageKind, pageModel) + $"/{id}";
            if (!string.IsNullOrEmpty(pageName))
                result += '/' + pageName;
            return result;
        }
    }
}
