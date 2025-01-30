using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords.Hooks;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Manufacturers
{
    [Obsolete]
    [HookAttachment(key: HookKeys.Manufacturer.Update)]
    internal class ManufacturerUpdateHook : TypedValidatedManageHook<Company>
    {

    }
}
