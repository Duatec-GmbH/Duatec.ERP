using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks
{
    [Snippet]
    internal class ArticleStockMoveSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
            => Url.ReplacePageKind(pageModel.CurrentUrl, 'm') + "/move";
    }
}
