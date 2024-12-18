using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers
{
    [Snippet]
    public class ManufacturerListImageSnippet : ImageSnippetBase
    {
        protected override int? Height => 45;

        protected override string? Url(BaseErpPageModel pageModel)
            => pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")?[Manufacturer.LogoUrl]?.ToString();
    }
}