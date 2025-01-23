using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class OrderList4Project : CodeDataSource
    {
        public static class Arguments
        {
            public const string Project = "project";
        }

        public OrderList4Project() : base()
        {
            Id = new Guid("2ad2d93b-3877-42d9-b0ee-ba793d3429d9");
            Name = nameof(OrderList4Project);
            Description = "List of all order lists for given project";
            ResultModel = nameof(EntityRecordList);

            Parameters.Add(new() { Name = Arguments.Project, Type = "guid", Value = "null" });
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var projectId = arguments[Arguments.Project] as Guid?;
            if (!projectId.HasValue || projectId.Value == Guid.Empty)
                return new EntityRecordList();

            var project = new ProjectRepository().Find(projectId.Value);
            if (project == null)
                return new EntityRecordList();

            var rec = new EntityRecord();
            rec["id"] = projectId.Value;
            rec["name"] = $"{project.Number} - Order List";

            var result = new EntityRecordList { rec };
            result.TotalCount = 1;

            return result;
        }
    }
}
