using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Eplan
{
    [Snippet]
    internal class ListCheckIfFromEplanSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var eplanId = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")?["eplan_id"]?.ToString();
            if (string.IsNullOrEmpty(eplanId))
                return null;

            return $"<i class=\"fas fa-check go-green\"/>";
        }
    }
}
