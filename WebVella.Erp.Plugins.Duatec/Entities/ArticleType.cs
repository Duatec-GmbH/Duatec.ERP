using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class ArticleType
    {
        public const string Entity = "article_type";
        public const string Label = "label";
        public const string Unit = "unit";

        public static EntityRecord? Find(Guid id)
            => Record.Find(Entity, id);
    }
}
