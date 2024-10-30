using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Eplan
{
    [Snippet]
    internal class TrueIfHasEplanIdSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            try
            {
                var id = pageModel.TryGetDataSourceProperty<EntityRecord>("Record")?["eplan_id"] as string;
                return !string.IsNullOrEmpty(id);
            }
            catch
            {
                return false;
            }
        }
    }
}
