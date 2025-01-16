using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
    public class Article : TypedEntityRecordWrapper
    {
        public const string Entity = "article";
        public const string AsForeignKey = "article_id";

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

        public override string EntityName => Entity;

        public string EplanId
        {
            get => Get(Fields.EplanId, string.Empty);
            set => Properties[Fields.EplanId] = value;
        }

        public string PartNumber
        {
            get => Get(Fields.PartNumber, string.Empty);
            set => Properties[Fields.PartNumber] = value;
        }

        public string TypeNumber
        {
            get => Get(Fields.TypeNumber, string.Empty);
            set => Properties[Fields.TypeNumber] = value;
        }

        public string OrderNumber
        {
            get => Get(Fields.OrderNumber, string.Empty);
            set => Properties[Fields.OrderNumber] = value;
        }

        public string Designation
        {
            get => Get(Fields.Designation, string.Empty);
            set => Properties[Fields.Designation] = value;
        }

        public Guid TypeId
        {
            get => Get<Guid>(Fields.Type);
            set => Properties[Fields.Type] = value;
        }

        public Guid ManufacturerId
        {
            get => Get<Guid>(Fields.Manufacturer);
            set => Properties[Fields.Manufacturer] = value;
        }

        public string? Image
        {
            get => Get<string?>(Fields.Image);
            set => Properties[Fields.Image] = value;
        }

        public bool IsBlocked
        {
            get => Get<bool>(Fields.IsBlocked);
            set => Properties[Fields.IsBlocked] = value;
        }

        public ArticleType GetArticleType()
            => GetSingleByRelation<ArticleType>(Relations.Type)!;

        public Company GetManufacturer()
            => GetSingleByRelation<Company>(Relations.Manufacturer)!;
    }
}
