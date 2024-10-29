using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Warehouses
{
    [HookAttachment(key: HookKeys.Warehouse.Delete)]
    internal class WarehouseDeleteHook : DeleteHookBase
    {
        protected override string Entity => Warehouse.Entity;

        protected override string? RecordLabel(Guid id)
            => Warehouse.Find(id)?[Warehouse.Designation] as string;
    }
}
