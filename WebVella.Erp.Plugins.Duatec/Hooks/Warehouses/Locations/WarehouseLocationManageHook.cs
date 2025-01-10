using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Services;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Warehouses.Locations
{
    [HookAttachment(key: HookKeys.Warehouse.Location.Manage)]
    public class WarehouseLocationManageHook : ManageOnListHookBase
    {
        protected override EntityRecord? Find(Guid id)
            => RepositoryService.Warehouse.FindEntry(id);
    }
}
