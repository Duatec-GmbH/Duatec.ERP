using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;
using WebVella.TagHelpers.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Eplan
{
    [Snippet]
    internal class FieldAccessByRecordIsFromEplanSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            try
            {
                var id = pageModel.TryGetDataSourceProperty<EntityRecord>("Record")?["eplan_id"] as string;
                return string.IsNullOrEmpty(id)
                    ? WvFieldAccess.Full
                    : WvFieldAccess.ReadOnly;
            }
            catch
            {
                return WvFieldAccess.ReadOnly;
            }
        }
    }
}
