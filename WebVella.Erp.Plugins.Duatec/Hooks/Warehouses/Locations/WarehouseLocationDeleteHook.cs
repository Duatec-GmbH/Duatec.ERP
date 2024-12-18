using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Warehouses.Locations
{
    [HookAttachment(key: HookKeys.Warehouse.Location.Delete)]
    internal class WarehouseLocationDeleteHook : DeleteOnListHookBase
    {
        protected override string Entity => WarehouseLocation.Entity;

        protected override string? RecordLabel(Guid id)
            => WarehouseLocation.Find(id)?[WarehouseLocation.Designation] as string;
    }
}
