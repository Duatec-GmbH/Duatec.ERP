using WebVella.Erp.Plugins.Duatec.Hooks;
using WebVella.Erp.Plugins.Duatec.Snippets.Base.HookCalls;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Warehouses.Locations
{
    [Snippet]
    public class WarehouseLocationDeleteSnippet : RecordIdHookCallSnippetBase
    {
        protected override string HookKey => HookKeys.Warehouse.Location.Delete;
    }
}