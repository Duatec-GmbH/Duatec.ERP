using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets
{
    [Snippet]
    public class RecordIsNotNullSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
            => pageModel.TryGetDataSourceProperty<EntityRecord>("Record") != null;
    }
}