using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets
{
    [Snippet]
    internal class CreateUrlSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
            => pageModel.EntityCreateUrl();
    }
}
