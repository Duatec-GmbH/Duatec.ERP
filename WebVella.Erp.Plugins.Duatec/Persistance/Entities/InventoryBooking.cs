﻿using WebVella.Erp.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public enum InventoryBookingKind
    {
        Undefined = 0,
        Take = 1,
        Store = 2,
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

        public decimal Amount
        {
            get => Get<decimal>(Fields.Amount);
            set => Properties[Fields.Amount] = value;
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
    }
}
