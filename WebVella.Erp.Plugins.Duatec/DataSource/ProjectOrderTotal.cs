using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{

    internal class ProjectOrderTotal : CodeDataSource
    {
        public static class Arguments
        {
            public const string Project = "project";
            public const string OrderType = "order_type";
        }

        public ProjectOrderTotal()
        {
            Id = new Guid("429506b4-f25d-4f2b-b4bd-d06241e5841a");
            Description = "Total of orders within project";
            Name = nameof(ProjectOrderTotal);
            ResultModel = "Decimal";

            Parameters.Add(new() { Name = Arguments.Project, Type = "Guid", Value = "null" });
            Parameters.Add(new() { Name = Arguments.OrderType, Type = "Guid", Value = "null" });
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var project = arguments[Arguments.Project] as Guid? ?? Guid.Empty;
            var orderType = arguments[Arguments.OrderType] as Guid?;
            return Execute(project, orderType);
        }

        public static decimal Execute(Guid projectId, Guid? orderType = null)
        {
            IEnumerable<Order> orders = new OrderRepository().FindManyByProject(projectId, $"id, {Order.Fields.Total}");

            if (orderType == Guid.Empty)
                orders = orders.Where(o => !o.Type.HasValue || o.Type == Guid.Empty);

            else if (orderType.HasValue)
                orders = orders.Where(o => o.Type == orderType);

            return orders.Aggregate(0m, (sum, o) => sum + o.Total);
        }
    }
}
