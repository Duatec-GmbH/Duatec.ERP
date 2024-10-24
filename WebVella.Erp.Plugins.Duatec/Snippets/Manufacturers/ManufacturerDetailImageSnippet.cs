using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers
{
    [Snippet]
    public class ManufacturerDetailImageSnippet : ImageSnippetBase
    {
        protected override int? Width => 200;

        protected override string Property => Manufacturer.LogoUrl;

        protected override string RecordProperty => "Record";
    }
}