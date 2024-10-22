using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Compartments
{
    [HookAttachment(key: HookKeys.Compartment.Delete)]
    internal class CompartmentDeleteHook : DeleteOnListHookBase
    {
        protected override string Entity => Compartment.Entity;

        protected override string? RecordLabel(Guid id)
            => Compartment.Find(id)?[Compartment.Designation] as string;
    }
}
