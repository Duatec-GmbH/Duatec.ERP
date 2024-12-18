using WebVella.Erp.Plugins.Duatec.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base.HookCalls;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers
{
    [Snippet]
    public class ManufacturerListImportSnippet : ListIdHookCallSnippetBase
    {
        protected override string HookKey => HookKeys.Manufacturer.EplanImport;

        protected override string IdParameter => "hEplanId";

        protected override string IdProperty => Manufacturer.EplanId;
    }
}