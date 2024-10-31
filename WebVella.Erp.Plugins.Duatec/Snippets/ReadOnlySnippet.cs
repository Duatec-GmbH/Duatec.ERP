using WebVella.Erp.Web.Models;
using WebVella.TagHelpers.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets
{
    [Snippet]
    internal class ReadOnlySnippet : ICodeVariable
    {
        public object Evaluate(BaseErpPageModel pageModel)
            => WvFieldAccess.ReadOnly;
    }
}
