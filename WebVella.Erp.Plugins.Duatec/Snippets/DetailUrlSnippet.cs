using WebVella.Erp.Web.Models;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

namespace WebVella.Erp.Plugins.Duatec.Snippets
{
    [Snippet]
    public class DetailUrlSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            return Url.ReplacePageKind(pageModel, 'r');
        }
    }
}