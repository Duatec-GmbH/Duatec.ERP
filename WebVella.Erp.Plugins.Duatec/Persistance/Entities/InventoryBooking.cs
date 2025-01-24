using WebVella.Erp.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    internal class InventoryBooking : TypedEntityRecordWrapper
    {
        public const string Entity = "inventory_booking";

        public override string EntityName => Entity;

        public static class Fields
        {
            public const string ProjectId = "project_id";
            public const string ArticleId = "article_id";
            public const string UserId = "user_id";
            public const string Amount = "amount";
        }

        public static class Relations
        {
            public const string Project = "inventory_booking_project";
            public const string Article = "inventory_booking_article";
            public const string User = "inventory_booking_user";
        }

        public Guid? ProjectId
        {
            get => Get<Guid?>(Fields.ProjectId);
            set => Properties[Fields.ProjectId] = value;
        }

        public Guid ArticleId
        {
            get => Get<Guid>(Fields.ArticleId);
            set => Properties[Fields.ArticleId] = value;
        }

        public Guid UserId
        {
            get => Get<Guid>(Fields.UserId);
            set => Properties[Fields.UserId] = value;
        }

        public decimal Amount
        {
            get => Get<decimal>(Fields.Amount);
            set => Properties[Fields.Amount] = value;
        }
    }
}
