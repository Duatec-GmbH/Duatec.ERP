using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Api.ChangeTracking
{
    internal enum ChangeTrackingAction
    {
        Delete,
        Update,
        Insert,
    }

    internal class ChangeTrackingHook : IErpPostCreateRecordHook, IErpPostDeleteRecordHook, IErpPostUpdateRecordHook
    {
        public void OnPostCreateRecord(string entityName, EntityRecord record)
            => Track(record, entityName, ChangeTrackingAction.Insert);

        public void OnPostDeleteRecord(string entityName, EntityRecord record)
            => Track(record, entityName, ChangeTrackingAction.Delete);

        public void OnPostUpdateRecord(string entityName, EntityRecord record)
            => Track(record, entityName, ChangeTrackingAction.Update);

        private static void Track(EntityRecord record, string entityName, ChangeTrackingAction action)
        {
            var recMan = new RecordManager(ignoreSecurity: true, executeHooks: false);
            var entMan = new EntityManager();

            var entry = new ChangeTrackingEntry()
            {
                Id = Guid.NewGuid(),
                Action = action.ToString().ToLower(),
                Object = record.ToJson(),
                UserId = SecurityContext.CurrentUser.Id,
                Timestamp = DateTime.UtcNow,
                EntityId = entMan.ReadEntities().Object.Find(e => e.Name == entityName)!.Id
            };

            var response = recMan.CreateRecord(ChangeTrackingEntry.Entity, entry);
            if (!response.Success)
                throw new DbException("Could not track changes");
        }
    }
}
