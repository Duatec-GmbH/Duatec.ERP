using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class ArticleType
    {
        public const string Entity = "article_type";
        public const string Label = "label";
        public const string Unit = "unit";
        public const string IsInteger = "is_integer";

        public static EntityRecord? Find(Guid id)
            => Record.Find(Entity, id);

        public static EntityRecord? FromArticle(Guid articleId)
        {
            if (Article.Find(articleId)?[Article.Type] is not Guid id)
                return null;
            return Find(id);
        }
    }
}
