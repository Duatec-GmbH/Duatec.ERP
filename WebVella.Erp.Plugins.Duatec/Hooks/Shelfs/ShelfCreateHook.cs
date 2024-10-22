using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Shelfs
{
    [HookAttachment(key: HookKeys.Shelf.Create)]
    internal class ShelfCreateHook : CreateOnListHookBase
    {
        protected override string ManageHook => HookKeys.Shelf.Manage;

        protected override EntityRecord CreateRecord(BaseErpPageModel pageModel)
        {
            var rec = new EntityRecord();
            rec[Shelf.Designation] = string.Empty;
            return rec;
        }
    }
}
