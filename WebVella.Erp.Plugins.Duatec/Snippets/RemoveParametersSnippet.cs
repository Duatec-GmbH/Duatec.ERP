using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets
{
    [Snippet]
    internal class RemoveParametersSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
            => Url.RemoveParameters(pageModel.CurrentUrl);
    }
}
