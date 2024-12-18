using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Warehouses
{
    [HookAttachment(key: HookKeys.Warehouse.Delete)]
    internal class WarehouseDeleteHook : DeleteOnListHookBase
    {
        protected override string Entity => Warehouse.Entity;

        protected override string? RecordLabel(Guid id)
            => Warehouse.Find(id)?[Warehouse.Designation] as string;
    }
}
