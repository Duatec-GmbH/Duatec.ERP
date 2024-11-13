using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Validators;

namespace WebVella.Erp.Plugins.Duatec.Hooks.PartLists
{
    [HookAttachment(key: HookKeys.PartList.Create)]
    internal class PartListCreateHook : CreateHookBase
    {
        private static readonly PartListValidator _validator = new();

        protected override IRecordValidator Validator => _validator;
    }
}
