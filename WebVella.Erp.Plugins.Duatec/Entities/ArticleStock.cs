namespace WebVella.Erp.Plugins.Duatec.Entities
{
    internal static class ArticleStock
    {
        public static class Relations
        {
            public const string Article = "article";
            public const string Project = "project";
            public const string Location = "warehouse_location";
        }

        public const string Entity = "article_stock";
        public const string WarehouseLocation = "warehouse_location_id";
        public const string Article = "article_id";
        public const string Project = "project_id";
        public const string Amount = "amount";
    }
}
