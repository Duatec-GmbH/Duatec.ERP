using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Services.Eplan.DataModel;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers
{
    [Snippet]
    public class ManufacturerListImportButtonVisibilitySnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var record = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");
            var rec = TypedEntityRecordWrapper.Cast<Company>(record);
            if (rec == null)
                return false;

            if (!long.TryParse(rec.EplanId, out var eplanId) || string.IsNullOrEmpty(rec.ShortName) || string.IsNullOrEmpty(rec.Name))
                return false;

            var dto = new DataPortalManufacturer(eplanId, rec.ShortName, rec.Name, null, null);
            return RepositoryService.Company.CanBeImported(dto);
        }
    }
}