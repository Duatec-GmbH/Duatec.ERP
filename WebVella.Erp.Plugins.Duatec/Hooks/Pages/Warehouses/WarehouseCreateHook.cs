using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Pages.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Warehouses
{
    [HookAttachment(key: HookKeys.Warehouse.Create)]
    internal class WarehouseCreateHook : CreateOnListHookBase
    {
        protected override string ManageHook => HookKeys.Warehouse.Manage;

        protected override EntityRecord CreateRecord(BaseErpPageModel pageModel)
        {
            return new Warehouse()
            {
                Designation = string.Empty
            };
        }
    }
}
