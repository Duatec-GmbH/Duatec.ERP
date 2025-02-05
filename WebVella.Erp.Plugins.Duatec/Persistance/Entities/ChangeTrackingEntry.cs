using WebVella.Erp.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    internal class ChangeTrackingEntry : TypedEntityRecordWrapper
    {
        public static class Fields
        {
            public const string UserId = "user_id";
            public const string EntityId = "entity_id";
            public const string Object = "object";
            public const string Action = "action";
            public const string Timestamp = "timestamp";
        }

        public static class Relations
        {
            public const string User = "change_tracking_entry_user";
        }

        public const string Entity = "change_tracking_entry";

        public override string EntityName => Entity;

        public Guid UserId
        {
            get => Get<Guid>(Fields.UserId);
            set => Properties[Fields.UserId] = value;
        }

        public Guid EntityId
        {
            get => Get<Guid>(Fields.EntityId);
            set => Properties[Fields.EntityId] = value;
        }

        public DateTime Timestamp
        {
            get => Get<DateTime>(Fields.Timestamp);
            set => Properties[Fields.Timestamp] = value;
        }

        public string Action
        {
            get => Get<string>(Fields.Action);
            set => Properties[Fields.Action] = value;
        }

        public string Object
        {
            get => Get<string>(Fields.Object);
            set => Properties[Fields.Object] = value;
        }
    }
}
