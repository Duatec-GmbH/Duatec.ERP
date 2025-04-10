﻿using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Pages.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Warehouses.Locations
{
    [HookAttachment(key: HookKeys.Warehouse.Location.Delete)]
    internal class WarehouseLocationDeleteHook : DeleteOnListHookBase
    {
        protected override string Entity => WarehouseLocation.Entity;

        protected override string? RecordLabel(Guid id)
            => new WarehouseRepository().FindEntry(id)?.Designation;
    }
}
