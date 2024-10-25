using WebVella.Erp.Plugins.Duatec.Hooks;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Warehouses.Locations
{
    [Snippet]
    public class WarehouseLocationCreateSnippet : ListCreateSnippetBase
    {
        protected override string HookKey => HookKeys.Warehouse.Location.Create;
    }
}