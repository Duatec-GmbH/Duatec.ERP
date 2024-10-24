using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;
using WebVella.Erp.Plugins.Duatec.Entities;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers
{
    [Snippet]
    public class ManufacturerListImportButtonVisibilitySnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");
            if (rec == null)
                return false;

            var id = $"{rec[Manufacturer.EplanId]}";
            var shortName = $"{rec[Manufacturer.ShortName]}";
            var name = $"{rec[Manufacturer.Name]}";

            if (!long.TryParse(id, out var eplanId) || string.IsNullOrEmpty(shortName) || string.IsNullOrEmpty(name))
                return false;

            var dto = new ManufacturerDto(eplanId, shortName, name, null, null);

            return Manufacturer.CanBeImported(dto);
        }
    }
}