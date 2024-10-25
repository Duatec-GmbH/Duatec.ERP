using WebVella.Erp.Plugins.Duatec.Hooks;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Warehouses
{
    [Snippet]
    public class WarehouseCreateSnippet : ListCreateSnippetBase
    {
        protected override string HookKey => HookKeys.Warehouse.Create;
    }
}