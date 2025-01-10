namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public class ArticleType : TypedEntityRecordWrapper
    {
        public const string Entity = "article_type";

        public static class Fields
        {
            public const string Label = "label";
            public const string Unit = "unit";
            public const string IsInteger = "is_integer";
        }

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
