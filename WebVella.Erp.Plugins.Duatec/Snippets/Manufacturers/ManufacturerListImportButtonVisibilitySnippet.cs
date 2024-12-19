using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance;

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

            var man = new Company(rec);

            if (!long.TryParse(man.EplanId, out var eplanId) || string.IsNullOrEmpty(man.ShortName) || string.IsNullOrEmpty(man.Name))
                return false;

            var dto = new DataPortalManufacturer(eplanId, man.ShortName, man.Name, null, null);

            return Repository.Company.CanBeImported(dto);
        }
    }
}