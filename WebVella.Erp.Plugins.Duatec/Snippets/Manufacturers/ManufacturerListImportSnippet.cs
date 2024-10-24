using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers
{
    [Snippet]
    public class ManufacturerListImportSnippet : ParameterizedHookFromListSnippetBase
    {
        protected override string HookKey => HookKeys.Manufacturer.EplanImport;

        protected override (string HookParameter, string RecordParameter)[] ParameterInfos =>
            [("hEplanId", Manufacturer.EplanId)];
    }
}