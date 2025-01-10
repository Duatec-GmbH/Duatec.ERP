using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceivings
{
    [Obsolete]
    [HookAttachment(key: HookKeys.GoodsReceiving.Update)]
    internal class GoodsReceivingUpdateHook : UpdateHookBase<GoodsReceiving>
    {
        private static readonly GoodsReceivingValidator _validator = new();

        protected override IRecordValidator<GoodsReceiving> Validator => _validator;
    }
}
