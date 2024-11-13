using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Validators;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Projects
{
    [HookAttachment(key: HookKeys.Project.Create)]
    internal class ProjectCreateHook : CreateHookBase
    {
        private static readonly ProjectValidator _validator = new();

        protected override IRecordValidator Validator => _validator;
    }
}
