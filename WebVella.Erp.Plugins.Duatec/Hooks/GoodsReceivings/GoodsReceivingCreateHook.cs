using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceivings
{
    [HookAttachment(key: HookKeys.GoodsReceiving.Create)]
    internal class GoodsReceivingCreateHook : CreateHookBase<GoodsReceiving>
    {
        private static readonly GoodsReceivingValidator _validator = new();

        protected override IRecordValidator<GoodsReceiving> Validator => _validator;
    }
}
