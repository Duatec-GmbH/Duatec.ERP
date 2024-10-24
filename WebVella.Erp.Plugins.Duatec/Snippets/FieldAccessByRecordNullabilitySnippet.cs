using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;
using WebVella.TagHelpers.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets
{
    [Snippet]
    public class FieldAccessByRecordNullabilitySnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            if (pageModel.TryGetDataSourceProperty<EntityRecord>("Record") != null)
                return WvFieldAccess.Full;
            return WvFieldAccess.ReadOnly;
        }
    }
}