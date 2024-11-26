using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    internal class OrderList
    {
        public static class Relations
        {
            public const string Entries = "order_list_entry_order_list";
            public const string Project = "order_list_project";
        }

        public const string Entity = "order_list";
        public const string Project = "project_id";

        public static EntityRecord? Find(Guid id)
            => Record.Find(Entity, id);

        public static EntityRecord? ByProject(Guid projectId)
            => Record.FindBy(Entity, Project, projectId);

        public static List<EntityRecord> Entries(Guid id)
            => Record.FindManyBy(OrderListEntry.Entity, OrderListEntry.OrderList, id);
    }
}
