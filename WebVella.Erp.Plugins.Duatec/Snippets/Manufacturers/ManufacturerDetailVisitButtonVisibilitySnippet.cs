using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers
{
    [Snippet]
    public class ManufacturerDetailVisitButtonVisibilitySnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var url = $"{pageModel.TryGetDataSourceProperty<EntityRecord>("Record")?[Manufacturer.WebsiteUrl]}";
            return !string.IsNullOrEmpty(url);
        }
    }
}