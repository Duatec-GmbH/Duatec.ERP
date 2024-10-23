using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Compartments
{
    [HookAttachment(key: HookKeys.Compartment.Create)]
    internal class CompartmentCreateHook : CreateOnListHookBase
    {
        protected override string ManageHook => HookKeys.Compartment.Manage;

        protected override EntityRecord CreateRecord(BaseErpPageModel pageModel)
        {
            var rec = new EntityRecord();
            rec[Compartment.Designation] = string.Empty;
            rec[Compartment.Shelf] = null;
            return rec;
        }
    }
}
