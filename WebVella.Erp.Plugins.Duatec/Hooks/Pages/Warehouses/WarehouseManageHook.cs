using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Pages.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Warehouses
{
    [HookAttachment(key: HookKeys.Warehouse.Manage)]
    public class WarehouseManageHook : ManageOnListHookBase
    {
        protected override EntityRecord? Find(Guid id)
            => new WarehouseRepository().Find(id);
    }
}
