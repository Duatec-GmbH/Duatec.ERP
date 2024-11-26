using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Validators;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceiving
{
    [HookAttachment(key: HookKeys.GoodsReceiving.Update)]
    internal class GoodsReceivingUpdateHook : UpdateHookBase
    {
        private static readonly GoodsReceivingValidator _validator = new();

        protected override IRecordValidator Validator => _validator;
    }
}
