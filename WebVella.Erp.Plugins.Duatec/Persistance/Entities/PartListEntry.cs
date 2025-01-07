using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities.Base;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    internal class PartListEntry : TypedEntityRecord
    {
        public const string Entity = "part_list_entry";

        public static class Relations
        {
            public const string PartsList = "part_list_entry_part_list";
            public const string Article = "part_list_entry_article";
        }

        public static class Fields
        {
            public const string PartList = "part_list_id";
            public const string Article = Entities.Article.AsForeignKey;
            public const string DeviceTag = "device_tag";
            public const string Amount = "amount";
        }

        public PartListEntry(EntityRecord? record = null)
            : base(record) { }

        public static PartListEntry? Create(EntityRecord? record)
            => record == null ? null : new PartListEntry(record);

        public Guid PartList
        {
            get => TryGet<Guid>(Fields.PartList);
            set => Properties[Fields.PartList] = value;
        }

        public Guid Article
        {
            get => TryGet<Guid>(Fields.Article);
            set => Properties[Fields.Article] = value;
        }

        public string? DeviceTag
        {
            get => TryGet<string?>(Fields.DeviceTag);
            set => Properties[Fields.DeviceTag] = value;
        }

        public decimal Amount
        {
            get => TryGet(Fields.Amount, decimal.MinValue); 
            set => Properties[Fields.Amount] = value;
        }
    }
}
