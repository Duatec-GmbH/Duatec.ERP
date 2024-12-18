﻿using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Warehouses
{
    [HookAttachment(key: HookKeys.Warehouse.Manage)]
    public class WarehouseManageHook : ManageOnListHookBase
    {
        protected override EntityRecord? Find(Guid id) 
            => Warehouse.Find(id);
    }
}
