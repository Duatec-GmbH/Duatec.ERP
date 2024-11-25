namespace WebVella.Erp.Plugins.Duatec.Entities
{
    internal static class OrderEntry
    {
        public static class Relations
        {
            public static string Article = "order_entry_article";
            public static string Order = "order_entry_order";
        }

        public const string Entity = "order_entry";
        public const string Article = "article_id";
        public const string Order = "order_id";
        public const string Amount = "amount";
    }
}
