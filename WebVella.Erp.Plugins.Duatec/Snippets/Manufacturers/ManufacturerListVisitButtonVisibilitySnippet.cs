using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers
{
    [Snippet]
    public class ManufacturerListVisitButtonVisibilitySnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var url = $"{pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")?[Manufacturer.WebsiteUrl]}";
            return !string.IsNullOrEmpty(url);
        }
    }
}