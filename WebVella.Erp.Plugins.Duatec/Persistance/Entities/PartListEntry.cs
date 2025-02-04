using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
    internal class PartListEntry : TypedEntityRecordWrapper
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

        public override string EntityName => Entity;

        public Guid PartListId
        {
            get => Get<Guid>(Fields.PartList);
            set => Properties[Fields.PartList] = value;
        }

        public Guid ArticleId
        {
            get => Get<Guid>(Fields.Article);
            set => Properties[Fields.Article] = value;
        }

        public string? DeviceTag
        {
            get => Get<string?>(Fields.DeviceTag);
            set => Properties[Fields.DeviceTag] = value;
        }

        public decimal Amount
        {
            get => Get(Fields.Amount, decimal.MinValue); 
            set => Properties[Fields.Amount] = value;
        }

        public Article GetArticle()
            => GetSingleByRelation<Article>(Relations.Article)!;
    }
}
