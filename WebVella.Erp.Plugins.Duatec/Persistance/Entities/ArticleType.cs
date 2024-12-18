using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public class ArticleType : TypedEntityRecord
    {
        public const string Entity = "article_type";

        public static class Fields
        {
            public const string Label = "label";
            public const string Unit = "unit";
            public const string IsInteger = "is_integer";
        }

        public ArticleType()
            : base() { }

        public ArticleType(EntityRecord rec)
            : base(rec) { }

        public static ArticleType? Create(EntityRecord? rec)
            => rec == null ? null : new ArticleType(rec);

        public string Label
        {
            get => TryGet(Fields.Label, string.Empty);
            set => Properties[Fields.Label] = value;
        }

        public string Unit
        {
            get => TryGet(Fields.Unit, string.Empty);
            set => Properties[Fields.Unit] = value;
        }

        public bool IsInteger
        {
            get => TryGet<bool>(Fields.IsInteger);
            set => Properties[Fields.IsInteger] = value;
        }
    }
}
