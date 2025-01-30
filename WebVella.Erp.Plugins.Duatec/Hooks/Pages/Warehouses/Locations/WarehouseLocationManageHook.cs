using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Pages.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Warehouses.Locations
{
    [HookAttachment(key: HookKeys.Warehouse.Location.Manage)]
    public class WarehouseLocationManageHook : ManageOnListHookBase
    {
        protected override EntityRecord? Find(Guid id)
            => new WarehouseRepository().FindEntry(id);
    }
}
