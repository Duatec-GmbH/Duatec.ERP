using WebVella.Erp.Plugins.Duatec.Hooks;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class WarehouseLocationManageSnippet : ListManageSnippetBase
{
    protected override string IdProperty => "wlId";

    protected override string HookKey => HookKeys.Warehouse.Location.Manage;
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime
