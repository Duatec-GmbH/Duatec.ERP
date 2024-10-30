using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers
{
    [Snippet]
    public class ManufacturerDetailImageSnippet : ImageSnippetBase
    {
        protected override int? Width => 200;

        protected override string? Url(BaseErpPageModel pageModel)
            => pageModel.TryGetDataSourceProperty<EntityRecord>("Record")?[Manufacturer.LogoUrl]?.ToString();
    }
}