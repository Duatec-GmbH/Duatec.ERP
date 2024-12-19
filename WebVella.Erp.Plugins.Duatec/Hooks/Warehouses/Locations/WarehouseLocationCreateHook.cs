using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Warehouses.Locations
{
    [HookAttachment(key: HookKeys.Warehouse.Location.Create)]
    internal class WarehouseLocationCreateHook : CreateOnListHookBase
    {
        protected override string ManageHook => HookKeys.Warehouse.Location.Manage;

        protected override EntityRecord CreateRecord(BaseErpPageModel pageModel)
            => new WarehouseLocation() { Designation = string.Empty };
    }
}
