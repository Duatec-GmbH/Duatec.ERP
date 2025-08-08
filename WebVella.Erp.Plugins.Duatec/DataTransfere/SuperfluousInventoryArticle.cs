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
            public const string AvailableAmount = "available_amount";
            public const string SelectedAmount = "selected_amount";
            public const string Demand = "demand";
            public const string Denomination = "denomination";
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

        public decimal Denomination
        {
            get => Get(Fields.Denomination, 0m);
            set => Properties[Fields.Denomination] = value;
        }

        public decimal RelativeDemand
        {
            get => Get<decimal>(Fields.Demand);
            set => Properties[Fields.Demand] = value;
        }

        public decimal AvailableAmount
        {
            get => Get<decimal>(Fields.AvailableAmount);
            set => Properties[Fields.AvailableAmount] = value;
        }

        public decimal SelectedAmount
        {
            get => Get<decimal>(Fields.SelectedAmount);
            set => Properties[Fields.SelectedAmount] = value;
        }

        public Article GetArticle()
            => GetSingleByRelation<Article>(Relations.Article)!;

        public void SetArticle(Article? article)
            => SetRelationValue(Relations.Article, article);
    }
}
