using WebVella.Erp.Plugins.Duatec.Hooks;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Warehouses
{
    [Snippet]
    public class WarehouseManageSnippet : ListManageSnippetBase
    {
        protected override string IdProperty => "wId";

        protected override string HookKey => HookKeys.Warehouse.Manage;
    }
}
