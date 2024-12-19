using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities.Base;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public class Article : TypedEntityRecord
    {
        public const string Entity = "article";

        public static class Relations
        {
            public const string Manufacturer = "article_manufacturer";
            public const string Type = "article_article_type";
        }

        public static class Fields
        {
            public const string EplanId = "eplan_id";
            public const string PartNumber = "part_number";
            public const string TypeNumber = "type_number";
            public const string OrderNumber = "order_number";
            public const string Designation = "designation";
            public const string Type = "article_type";
            public const string Manufacturer = "manufacturer_id";
            public const string Image = "preview";
            public const string IsBlocked = "is_blocked";
        }

        public static Guid DefaultType { get; } = new Guid("14a2d274-c18e-46f8-a920-2814ea5faa2d");

        public Article(EntityRecord? record = null) 
            : base(record) { }

        public static Article? Create(EntityRecord? record)
            => record == null ? null : new Article(record);

        public string EplanId
        {
            get => TryGet(Fields.EplanId, string.Empty);
            set => Properties[Fields.EplanId] = value;
        }

        public string PartNumber
        {
            get => TryGet(Fields.PartNumber, string.Empty);
            set => Properties[Fields.PartNumber] = value;
        }

        public string TypeNumber
        {
            get => TryGet(Fields.TypeNumber, string.Empty);
            set => Properties[Fields.TypeNumber] = value;
        }

        public string OrderNumber
        {
            get => TryGet(Fields.OrderNumber, string.Empty);
            set => Properties[Fields.OrderNumber] = value;
        }

        public string Designation
        {
            get => TryGet(Fields.Designation, string.Empty);
            set => Properties[Fields.Designation] = value;
        }

        public Guid Type
        {
            get => TryGet<Guid>(Fields.Type);
            set => Properties[Fields.Type] = value;
        }

        public Guid Manufacturer
        {
            get => TryGet<Guid>(Fields.Manufacturer);
            set => Properties[Fields.Manufacturer] = value;
        }

        public string? Image
        {
            get => TryGet<string?>(Fields.Image);
            set => Properties[Fields.Image] = value;
        }

        public bool IsBlocked
        {
            get => TryGet<bool>(Fields.IsBlocked);
            set => Properties[Fields.IsBlocked] = value;
        }
    }
}
