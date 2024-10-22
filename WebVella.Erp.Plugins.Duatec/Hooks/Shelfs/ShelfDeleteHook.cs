using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Shelfs
{
    [HookAttachment(key: HookKeys.Shelf.Delete)]
    internal class ShelfDeleteHook : DeleteOnListHookBase
    {
        protected override string Entity => Shelf.Entity;

        protected override string? RecordLabel(Guid id)
            => Shelf.Find(id)?[Shelf.Designation] as string;
    }
}
