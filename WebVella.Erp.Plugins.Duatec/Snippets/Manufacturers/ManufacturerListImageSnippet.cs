using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers
{
    [Snippet]
    public class ManufacturerListImageSnippet : ImageSnippetBase
    {
        protected override int? Height => 45;

        protected override string Property => Manufacturer.LogoUrl;

        protected override string RecordProperty => "RowRecord";
    }
}