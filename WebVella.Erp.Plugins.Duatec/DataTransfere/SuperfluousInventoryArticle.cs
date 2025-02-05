using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.DataTransfere
{
    internal class SuperfluousInventoryArticle : TypedEntityRecordWrapper
    {
        public SuperfluousInventoryArticle()
        {
            Id = Guid.Empty;
        }

        public static class Fields
        {
            public const string ArticleId = "article_id";
            public const string Demand = "demand";
            public const string ReservedAmount = "reserved_amount";
            public const string Amount = "amount";
        }

        public static class Relations
        {
            public const string Article = "article";
        }

        public override string EntityName => string.Empty;

        public Guid ArticleId
        {
            get => Get<Guid>(Fields.ArticleId);
            set => Properties[Fields.ArticleId] = value;
        }

        public decimal Amount
        {
            get => Get<decimal>(Fields.Amount);
            set => Properties[Fields.Amount] = value;
        }

        public decimal ReservedAmount
        {
            get => Get<decimal>(Fields.ReservedAmount);
            set => Properties[Fields.ReservedAmount] = value;
        }

        public decimal Demand
        {
            get => Get<decimal>(Fields.Demand);
            set => Properties[Fields.Demand] = value;
        }

        public Article GetArticle()
            => GetSingleByRelation<Article>(Relations.Article)!;

        public void SetArticle(Article article)
            => SetRelationValue(Relations.Article, article);
    }
}
