using WebVella.Erp.Plugins.Duatec.Hooks;
using WebVella.Erp.Plugins.Duatec.Snippets.Base.HookCalls;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Warehouses.Locations
{
    [Snippet]
    public class WarehouseLocationManageSnippet : ListIdHookCallSnippetBase
    {
        protected override string HookKey => HookKeys.Warehouse.Location.Manage;
    }
}