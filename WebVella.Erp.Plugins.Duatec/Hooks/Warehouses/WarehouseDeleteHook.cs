using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Warehouses
{
    [HookAttachment(key: HookKeys.Warehouse.Delete)]
    internal class WarehouseDeleteHook : DeleteOnListHookBase
    {
        protected override string Entity => Warehouse.Entity;

        protected override string? RecordLabel(Guid id)
            => RepositoryService.Warehouse.Find(id)?.Designation;
    }
}
