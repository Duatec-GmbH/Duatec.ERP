using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    internal class OrderListEntry
    {
        public static class Relations
        {
            public const string OrderList = "order_list_entry_order_list";
            public const string Article = "order_list_entry_article";
        }

        public const string Entity = "order_list_entry";
        public const string Article = "article_id";
        public const string OrderList = "order_list_id";
        public const string Order = "order_id";
        public const string Amount = "amount";
    }
}
