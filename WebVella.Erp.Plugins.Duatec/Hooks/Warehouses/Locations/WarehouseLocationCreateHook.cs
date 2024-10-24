﻿using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Warehouses.Locations
{
    [HookAttachment(key: HookKeys.Warehouse.Location.Create)]
    internal class WarehouseLocationCreateHook : CreateOnListHookBase
    {
        protected override string IdProperty => "wlId";

        protected override string ManageHook => HookKeys.Warehouse.Location.Manage;

        protected override EntityRecord CreateRecord(BaseErpPageModel pageModel)
        {
            var rec = new EntityRecord();
            rec[WarehouseLocation.Designation] = string.Empty;
            rec[WarehouseLocation.Warehouse] = null;
            return rec;
        }
    }
}
