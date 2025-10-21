using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.DataTransfere
{
    public class OrderListEntry : TypedEntityRecordWrapper
    {
        public static class Relations
        {
            public const string Article = "order_list_entry_article";
            public const string Order = "order_list_entry_order";
        }

        public static class Fields
        {
            public const string Article = Persistance.Entities.Article.AsForeignKey;
            public const string Demand = "demand";
            public const string OrderedAmount = "ordered_amount";
            public const string ReceivedAmount = "received_amount";
            public const string InventoryAmount = "inventory_amount";
            public const string ToOrder = "to_order";
            public const string State = "state";
            public const string Denomination = "denomination";
        }

        public override string EntityName => string.Empty;

        public Guid ArticleId
        {
            get => Get<Guid>(Fields.Article);
            set => Properties[Fields.Article] = value;
        }

        public decimal Denomination
        {
            get => Get(Fields.Denomination, 0m);
            set => Properties[Fields.Denomination] = value;
        }

        public decimal Demand
        {
            get => Get<decimal>(Fields.Demand);
            set => Properties[Fields.Demand] = value;
        }

        public decimal OrderedAmount
        {
            get => Get<decimal>(Fields.OrderedAmount);
            set => Properties[Fields.OrderedAmount] = value;
        }

        public decimal ReceivedAmount
        {
            get => Get<decimal>(Fields.ReceivedAmount);
            set => Properties[Fields.ReceivedAmount] = value;
        }

        public decimal InventoryAmount
        {
            get => Get<decimal>(Fields.InventoryAmount);
            set => Properties[Fields.InventoryAmount] = value;
        }

        public decimal ToOrder
        {
            get => Get<decimal>(Fields.ToOrder);
            set => Properties[Fields.ToOrder] = value;
        }

        public OrderListEntryState State
        {
            get => Get<OrderListEntryState>(Fields.State);
            set => Properties[Fields.State] = value;
        }

        public Article GetArticle()
            => GetSingleByRelation<Article>(Relations.Article)!;

        public void SetArticle(Article? article)
            => SetRelationValue(Relations.Article, article);

        public IEnumerable<Order> GetOrders()
            => GetManyByRelation<Order>(Relations.Order);

        public void SetOrders(IEnumerable<Order> orders)
            => SetRelationValues(Relations.Order, orders);
    }
}
