using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.PartLists.Entries
{
    [Snippet]
    internal class DeviceTagSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var deviceTag = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")?
                [PartListEntry.Fields.DeviceTag] as string;

            return deviceTag?
                .Replace("\r", string.Empty)
                .Replace("\n", "<br/>");
        }
    }
}
