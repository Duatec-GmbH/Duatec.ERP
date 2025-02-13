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

    internal class ChangeTrackingHook : IErpPostCreateRecordHook, IErpPostDeleteRecordHook, IErpPostUpdateRecordHook, IErpPostDeleteManyRecordsHook, IErpPostCreateManyRecordsHook
    {
        private readonly RecordManager _recMan;

        public ChangeTrackingHook(RecordManager? recMan)
        {
            _recMan = recMan ?? new(ignoreSecurity: true, executeHooks: false);
        }

        public ChangeTrackingHook() 
            : this(null) 
        { }

        public bool ExecuteOnPostDeleteMany => false;

        public bool ExecuteOnPostCreateMany => false;

        public bool ExecuteOnPostUpdateMany => false;

        public void OnPostCreateRecord(string entityName, EntityRecord record)
            => Track(record, entityName, ChangeTrackingAction.Insert);

        public void OnPostDeleteRecord(string entityName, EntityRecord record)
            => Track(record, entityName, ChangeTrackingAction.Delete);

        public void OnPostUpdateRecord(string entityName, EntityRecord record)
            => Track(record, entityName, ChangeTrackingAction.Update);

        public void OnPostCreateRecords(string entityName, IEnumerable<EntityRecord> records)
            => TrackMany(records, entityName, ChangeTrackingAction.Insert);

        public void OnPostUpdateRecords(string entityName, IEnumerable<EntityRecord> records)
            => TrackMany(records, entityName, ChangeTrackingAction.Update);

        public void OnPostDeleteRecords(string entityName, IEnumerable<EntityRecord> records)
            => TrackMany(records, entityName, ChangeTrackingAction.Delete);

        private void Track(EntityRecord record, string entityName, ChangeTrackingAction action)
        {
            var entry = CreateEntry(record, entityName, action);

            var response = _recMan.CreateRecord(ChangeTrackingEntry.Entity, entry);
            if (!response.Success)
                throw new DbException("Could not track changes");
        }

        private void TrackMany(IEnumerable<EntityRecord> records, string entityName, ChangeTrackingAction action)
        {
            var timeStamp = DateTime.UtcNow;
            var entries = records
                .Select(r => CreateEntry(r, entityName, action, timeStamp))
                .ToList();

            var response = _recMan.CreateRecords(ChangeTrackingEntry.Entity, entries);
            if (!response.Success)
                throw new DbException("Could not track changes");
        }

        private ChangeTrackingEntry CreateEntry(EntityRecord record, string entityName, ChangeTrackingAction action, DateTime? timestamp = null)
        {
            var ts = timestamp ?? DateTime.UtcNow;

            return new ChangeTrackingEntry()
            {
                Id = Guid.NewGuid(),
                Action = action.ToString().ToLower(),
                Object = record.ToJson(),
                UserId = SecurityContext.CurrentUser.Id,
                Timestamp = ts,
                EntityId = _recMan.EntityManager.ReadEntities().Object.Find(e => e.Name == entityName)!.Id
            };
        }
    }
}
