using WebVella.Erp.Plugins.Duatec.Hooks;
using WebVella.Erp.Plugins.Duatec.Snippets.Base.HookCalls;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Warehouses
{
    [Snippet]
    public class WarehouseDeleteSnippet : RecordIdHookCallSnippetBase
    {
        protected override string HookKey => HookKeys.Warehouse.Delete;
    }
}