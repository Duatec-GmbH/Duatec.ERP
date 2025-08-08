using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.DataTransfere
{
    internal class PartListEntryDiff : TypedEntityRecordWrapper
    {
        public static class Fields
        {
            public const string Article = Persistance.Entities.Article.AsForeignKey;
            public const string Diff = "diff";
            public const string Amount1 = "part_list1_amount";
            public const string Amount2 = "part_list2_amount";
            public const string Denomination = "denomination";
        }

        public static class Relations
        {
            public const string Article = "article";
        }

        public override string EntityName => string.Empty;

        public Guid ArticleId
        {
            get => Get<Guid>(Fields.Article);
            set => Properties[Fields.Article] = value;
        }

        public decimal Denomination
        {
            get => Get(Fields.Denomination, 0m);
            set => Properties[Fields.Denomination] = value;
        }

        public decimal Diff
        {
            get => Get<decimal>(Fields.Diff);
            set => Properties[Fields.Diff] = value;
        }

        public decimal Amount1
        {
            get => Get<decimal>(Fields.Amount1);
            set => Properties[Fields.Amount1] = value;
        }

        public decimal Amount2
        {
            get => Get<decimal>(Fields.Amount2);
            set => Properties[Fields.Amount2] = value;
        }

        public Article GetArticle()
            => GetSingleByRelation<Article>(Relations.Article)!;

        public void SetArticle(Article? article)
            => SetRelationValue(Relations.Article, article);
    }
}
