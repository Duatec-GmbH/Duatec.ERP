using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets
{
    [Snippet]
    public class ListUrlSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var context = pageModel.ErpRequestContext;
            return $"/{context?.App?.Name}/{context?.SitemapArea?.Name}/{context?.SitemapNode?.Name}/l/";
        }
    }
}
