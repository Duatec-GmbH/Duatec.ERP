﻿using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
    internal class InventoryReservationList : TypedEntityRecordWrapper
    {
        public const string Entity = "inventory_reservation";

        public static class Relations
        {
            public const string Project = "inventory_reservation_project";
        }

        public static class Fields
        {
            public const string Project = "project_id";
        }

        public override string EntityName => Entity;

        public Guid Project
        {
            get => Get<Guid>(Fields.Project);
            set => Properties[Fields.Project] = value;
        }
    }
}
