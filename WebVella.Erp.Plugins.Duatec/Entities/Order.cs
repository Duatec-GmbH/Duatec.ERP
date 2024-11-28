
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    internal static class Order
    {
        public static class Relations
        {
            public const string Supplier = "order_supplier";
            public const string Project = "order_project";
        }

        public const string Entity = "order";
        public const string Supplier = "supplier_id";
        public const string Number = "order_number";
        public const string Project = "project_id";

        internal static List<EntityRecord> FindManyByProject(Guid project)
            => Record.FindManyBy(Entity, Project, project);

    }
}
