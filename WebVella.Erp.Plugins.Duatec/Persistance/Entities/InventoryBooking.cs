using WebVella.Erp.Api.Models;
using WebVella.Erp.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public enum InventoryBookingKind
    {
        [SelectOption(IsVisible = false)]
        Undefined = 0,
        [SelectOption(Label = "Take", SelectOptionType = SelectOptionType.String)]
        Take = 1,
        [SelectOption(Label = "Store", SelectOptionType = SelectOptionType.String)]
        Store = 2,
        [SelectOption(Label = "Move", SelectOptionType = SelectOptionType.String)]
        Move = 3,
    }

    internal class InventoryBooking : TypedEntityRecordWrapper
    {
        public const string Entity = "inventory_booking";

        public override string EntityName => Entity;

        public static class Fields
        {
            public const string ProjectId = "project_id";
            public const string ProjectSourceId = "project_source_id";
            public const string ArticleId = "article_id";
            public const string WarehouseLocationId = "warehouse_location_id";
            public const string WarehouseLocationSourceId = "warehouse_location_source_id";
            public const string Timestamp = "timestamp";
            public const string UserId = "user_id";
            public const string Amount = "amount";
            public const string Kind = "kind";
            public const string Comment = "comment";
            public const string Denomination = "denomination";
            public const string TaggedRecordId = "tagged_record_id";
            public const string TaggedEntityName = "tagged_entity_name";
        }

        public static class Relations
        {
            public const string Project = "inventory_booking_project";
            public const string SourceProject = "inventory_booking_source_project";
            public const string Article = "inventory_booking_article";
            public const string User = "inventory_booking_user";
        }

        public Guid? ProjectId
        {
            get => Get<Guid?>(Fields.ProjectId);
            set => Properties[Fields.ProjectId] = value;
        }

        public Guid? ProjectSourceId
        {
            get => Get<Guid?>(Fields.ProjectSourceId);
            set => Properties[Fields.ProjectSourceId] = value;
        }

        public Guid? WarehouseLocationId
        {
            get => Get<Guid?>(Fields.WarehouseLocationId);
            set => Properties[Fields.WarehouseLocationId] = value;
        }

        public Guid? WarehouseLocationSourceId
        {
            get => Get<Guid?>(Fields.WarehouseLocationSourceId);
            set => Properties[Fields.WarehouseLocationSourceId] = value;
        }

        public Guid ArticleId
        {
            get => Get<Guid>(Fields.ArticleId);
            set => Properties[Fields.ArticleId] = value;
        }

        public Guid UserId
        {
            get => Get<Guid>(Fields.UserId);
            set => Properties[Fields.UserId] = value;
        }

        public Guid? TaggedRecordId
        {
            get => Get<Guid?>(Fields.TaggedRecordId);
            set => Properties[Fields.TaggedRecordId] = value;
        }

        public string? TaggedEntityName
        {
            get => Get<string?>(Fields.TaggedEntityName);
            set => Properties[Fields.TaggedEntityName] = value;
        }

        public decimal Amount
        {
            get => Get<decimal>(Fields.Amount);
            set => Properties[Fields.Amount] = value;
        }

        public decimal Denomination
        {
            get => Get(Fields.Denomination, 0m);
            set => Properties[Fields.Denomination] = value;
        }

        public DateTime Timestamp
        {
            get => Get<DateTime>(Fields.Timestamp);
            set => Properties[Fields.Timestamp] = value;
        }

        public InventoryBookingKind Kind
        {
            get => GetEnumValueFromString(Fields.Kind, InventoryBookingKind.Undefined, true);
            set => Properties[Fields.Kind] = value.ToString();
        }

        public string Comment
        {
            get => Get(Fields.Comment, string.Empty);
            set => Properties[Fields.Comment] = value;
        }
    }
}
