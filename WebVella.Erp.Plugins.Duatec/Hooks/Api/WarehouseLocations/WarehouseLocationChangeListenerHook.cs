using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.TypedRecords.Hooks.Api;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Api.WarehouseLocations
{
    [HookAttachment(key: WarehouseLocation.Entity)]
    internal class WarehouseLocationChangeListenerHook : ITypedPostCreateHook<WarehouseLocation>, ITypedPostDeleteHook<WarehouseLocation>, ITypedPostUpdateHook<WarehouseLocation>
    {
        public string EntityName => WarehouseLocation.Entity;

        public bool ExecuteOnPostCreateMany => true;

        public bool ExecuteOnPostDeleteMany => true;

        public bool ExecuteOnPostUpdateMany => true;

        public void OnPostCreateRecord(WarehouseLocation record)
        {
            ChangeDetection.LastWarehouseLocationChangeTimeUtc = DateTime.UtcNow;
        }

        public void OnPostDeleteRecord(WarehouseLocation record)
        {
            ChangeDetection.LastWarehouseLocationChangeTimeUtc = DateTime.UtcNow;
        }

        public void OnPostUpdateRecord(WarehouseLocation record)
        {
            ChangeDetection.LastWarehouseLocationChangeTimeUtc = DateTime.UtcNow;
        }
    }
}
