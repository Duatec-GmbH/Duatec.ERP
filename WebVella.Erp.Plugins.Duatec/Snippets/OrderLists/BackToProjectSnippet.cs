using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists
{
    [Snippet]
    internal class BackToProjectSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var id = pageModel.RecordId;
            var appName = pageModel.ErpRequestContext.App.Name;
            var area = pageModel.ErpRequestContext?.SitemapArea?.Name;

            return $"{appName}/{area}/projects/r/{id}";
        }
    }
}
