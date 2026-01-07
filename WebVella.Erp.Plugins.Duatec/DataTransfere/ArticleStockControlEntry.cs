using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.DataTransfere
{
    public class ArticleStockControlEntry : TypedEntityRecordWrapper
    {
        public ArticleStockControlEntry()
        {
            Id = Guid.Empty;
        }

        public static class Fields
        {
            public const string ArticleId = "article_id";
            public const string AvailableAmount = "available_amount";
            public const string OutstandingAmount = "outstanding_amount";
            public const string Demand = "demand";
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

        public decimal AvailableAmount
        {
            get => Get<decimal>(Fields.AvailableAmount);
            set => Properties[Fields.AvailableAmount] = value;
        }

        public decimal OutstandingAmount
        {
            get => Get<decimal>(Fields.OutstandingAmount);
            set => Properties[Fields.OutstandingAmount] = value;
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
