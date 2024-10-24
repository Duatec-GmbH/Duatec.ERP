using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Warehouses.Locations
{
    [HookAttachment(key: HookKeys.Warehouse.Location.Manage)]
    public class WarehouseLocationManageHook : ManageOnListHook
    {
        protected override string IdProperty => "wlId";

        protected override EntityRecord? Find(Guid id)
            => WarehouseLocation.Find(id);
    }
}
