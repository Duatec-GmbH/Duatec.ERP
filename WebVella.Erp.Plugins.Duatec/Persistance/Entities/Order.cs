﻿using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
    public class Order : TypedEntityRecordWrapper
    {
        public const string Entity = "order";

        public static class Relations
        {
            public const string Project = "order_project";
            public const string Entries = OrderEntry.Relations.Order;
        }

        public static class Fields
        {
            public const string Number = "order_number";
            public const string Project = "project_id";
            public const string Order = "order";
            public const string Offer = "offer";
            public const string Confirmation = "confirmation";
        }

        public override string EntityName => Entity;

        public string Number
        {
            get => Get(Fields.Number, string.Empty);
            set => Properties[Fields.Number] = value;
        }

        public string OfferFile
        {
            get => Get(Fields.Offer, string.Empty);
            set => Properties[Fields.Offer] = value;
        }

        public string OrderFile
        {
            get => Get(Fields.Order, string.Empty);
            set => Properties[Fields.Order] = value;
        }

        public string ConfirmationFile
        {
            get => Get(Fields.Confirmation, string.Empty);
            set => Properties[Fields.Confirmation] = value;
        }

        public Guid Project
        {
            get => Get<Guid>(Fields.Project);
            set => Properties[Fields.Project] = value;
        }

        public Project GetProject()
            => GetSingleByRelation<Project>(Relations.Project)!;

        public IEnumerable<OrderEntry> GetEntries()
            => GetManyByRelation<OrderEntry>(Relations.Entries);


        public void SetEntries(IEnumerable<OrderEntry> entries)
            => SetRelationValues(Relations.Entries, entries);
    }
}
