using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Validators;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceiving
{
    [HookAttachment(key: HookKeys.GoodsReceiving.Create)]
    internal class GoodsReceivingCreateHook : CreateHookBase<EntityRecord>
    {
        private static readonly GoodsReceivingValidator _validator = new();

        protected override IRecordValidator<EntityRecord> Validator => _validator;

        protected override EntityRecord WrapRecord(EntityRecord rec) => rec;
    }
}
