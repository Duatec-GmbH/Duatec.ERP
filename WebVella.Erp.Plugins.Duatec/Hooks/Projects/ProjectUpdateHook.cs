using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Validators;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Projects
{
    [HookAttachment(key: HookKeys.Project.Update)]
    internal class ProjectUpdateHook : UpdateHookBase<EntityRecord>
    {
        private static readonly ProjectValidator _validator = new();

        protected override IRecordValidator<EntityRecord> Validator => _validator;

        protected override EntityRecord WrapRecord(EntityRecord record) => record;
    }
}
