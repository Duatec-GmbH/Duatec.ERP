namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    internal class OrderListEntry
    {
        public static class Relations
        {
            public const string Project = "order_list_entry_project";
            public const string Article = "order_list_entry_article";
            public const string Order = "order_list_entry_order";
        }

        public const string Project = "project_id";
        public const string Article = "article_id";
        public const string Demand = "demand";
        public const string OrderedAmount = "ordered_amount";
        public const string ReceivedAmount = "received_amount";
        public const string InventoryAmount = "inventory_amount";
        public const string State = "state";
    }
}
