using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Validators;

namespace WebVella.Erp.Plugins.Duatec.Hooks.PartLists
{
    [HookAttachment(key: HookKeys.PartList.Update)]
    internal class PartListUpdateHook : UpdateHookBase<EntityRecord>
    {
        private static readonly PartListValidator _validator = new();

        protected override IRecordValidator<EntityRecord> Validator => _validator;

        protected override EntityRecord WrapRecord(EntityRecord record) => record;
    }
}
