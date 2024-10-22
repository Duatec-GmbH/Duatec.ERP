using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Shelfs
{
    [HookAttachment(key: HookKeys.Shelf.Manage)]
    public class ShelfManageHook : ManageOnListHook
    {
        protected override EntityRecord? Find(Guid id) 
            => Shelf.Find(id);
    }
}
