using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.TypedRecords.Hooks.Api;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Api.Warehouses
{
    [HookAttachment(key: Warehouse.Entity)]
    internal class WarehouseChangeListenerHook : ITypedPostCreateHook<Warehouse>, ITypedPostDeleteHook<Warehouse>, ITypedPostUpdateHook<Warehouse>
    {
        public string EntityName => Warehouse.Entity;

        public bool ExecuteOnPostCreateMany => true;

        public bool ExecuteOnPostDeleteMany => true;

        public bool ExecuteOnPostUpdateMany => true;

        public void OnPostCreateRecord(Warehouse record)
        {
            ChangeDetection.LastWarehouseChangeTimeUtc = DateTime.UtcNow;
        }

        public void OnPostDeleteRecord(Warehouse record)
        {
            ChangeDetection.LastWarehouseChangeTimeUtc = DateTime.UtcNow;
        }

        public void OnPostUpdateRecord(Warehouse record)
        {
            ChangeDetection.LastWarehouseChangeTimeUtc = DateTime.UtcNow;
        }
    }
}
