namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class OrderEntry
    {
        public static class Relations
        {
            public const string Article = "order_entry_article";
            public const string Order = "order_entry_order";
        }

        public const string Entity = "order_entry";
        public const string Article = "article_id";
        public const string Order = "order_id";
        public const string Amount = "amount";
    }
}
