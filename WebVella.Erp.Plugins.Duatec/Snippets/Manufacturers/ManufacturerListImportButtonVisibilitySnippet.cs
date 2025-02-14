using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.FileImports.EplanTypes.DataModel;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers
{
    [Snippet]
    public class ManufacturerListImportButtonVisibilitySnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var record = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");
            var rec = TypedEntityRecordWrapper.WrapElseDefault<Company>(record);
            if (rec == null)
                return false;

            if (!long.TryParse(rec.EplanId, out var eplanId) || string.IsNullOrEmpty(rec.ShortName) || string.IsNullOrEmpty(rec.Name))
                return false;

            var dto = new DataPortalManufacturerDto(eplanId, rec.ShortName, rec.Name, null, null);
            return new CompanyRepository().CanBeImported(dto);
        }
    }
}