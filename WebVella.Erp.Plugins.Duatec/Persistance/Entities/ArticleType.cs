using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
    public class ArticleType : TypedEntityRecordWrapper
    {
        public const string Entity = "article_type";

        public static class Fields
        {
            public const string Label = "label";
            public const string Unit = "unit";
            public const string IsInteger = "is_integer";
        }

        public override string EntityName => Entity;

        public string Label
        {
            get => Get(Fields.Label, string.Empty);
            set => Properties[Fields.Label] = value;
        }

        public string Unit
        {
            get => Get(Fields.Unit, string.Empty);
            set => Properties[Fields.Unit] = value;
        }

        public bool IsInteger
        {
            get => Get<bool>(Fields.IsInteger);
            set => Properties[Fields.IsInteger] = value;
        }
    }
}
