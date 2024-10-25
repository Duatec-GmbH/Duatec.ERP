using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Warehouses
{
    [HookAttachment(key: HookKeys.Warehouse.Manage)]
    public class WarehouseManageHook : ManageOnListHook
    {
        protected override EntityRecord? Find(Guid id) 
            => Warehouse.Find(id);
    }
}
