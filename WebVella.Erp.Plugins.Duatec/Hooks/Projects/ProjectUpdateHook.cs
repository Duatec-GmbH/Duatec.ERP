using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Validators;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Projects
{
    [HookAttachment(key: HookKeys.Project.Update)]
    internal class ProjectUpdateHook : UpdateHookBase
    {
        private static readonly ProjectValidator _validator = new();

        protected override IRecordValidator Validator => _validator;
    }
}
