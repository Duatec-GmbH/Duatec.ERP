using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Projects
{
    [HookAttachment(key: HookKeys.Project.Update)]
    internal class ProjectUpdateHook : UpdateHookBase<Project>
    {
        private static readonly ProjectValidator _validator = new();

        protected override IRecordValidator<Project> Validator => _validator;

        protected override Project WrapRecord(EntityRecord record) => new(record);
    }
}
