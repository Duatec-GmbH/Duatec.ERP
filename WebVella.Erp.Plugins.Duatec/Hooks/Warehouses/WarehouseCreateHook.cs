using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Warehouses
{
    [HookAttachment(key: HookKeys.Warehouse.Create)]
    internal class WarehouseCreateHook : CreateOnListHookBase
    {
        protected override string ManageHook => HookKeys.Warehouse.Manage;

        protected override EntityRecord CreateRecord(BaseErpPageModel pageModel)
        {
            var rec = new EntityRecord();
            rec[Warehouse.Designation] = string.Empty;
            return rec;
        }
    }
}
