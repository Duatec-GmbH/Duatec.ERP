using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Compartments
{
    [HookAttachment(key: HookKeys.Compartment.Manage)]
    public class CompartmentManageHook : ManageOnListHook
    {
        protected override EntityRecord? Find(Guid id) 
            => Compartment.Find(id);
    }
}
