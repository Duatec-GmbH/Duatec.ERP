using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Hooks.PartLists
{
    [Obsolete]
    [HookAttachment(key: HookKeys.PartList.Update)]
    internal class PartListUpdateHook : UpdateHookBase<PartList>
    {
        private static readonly PartListValidator _validator = new();

        protected override IRecordValidator<PartList> Validator => _validator;
    }
}
