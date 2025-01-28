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

            if (string.IsNullOrEmpty(deviceTag))
                return string.Empty;

            var tags = deviceTag.Split('\n')
                .Select(dt => dt.TrimEnd('\r').Trim())
                .ToArray();

            if (tags.Length > 3)
                return string.Join("<br/>", tags.Take(3)) + " ...";

            return string.Join("<br/>", tags);
        }
    }
}
