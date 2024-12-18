using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class OrderListEntryDetail : CodeDataSource
    {
        public static class Parameter
        {
            public const string Project = "project";
            public const string Article = "article";
        }

        public OrderListEntryDetail() : base()
        {
            Id = new Guid("3471802f-cf42-4416-a2c5-2fca639619d3");
            Name = nameof(OrderListEntries4Project);
            Description = "Order List Entry detail for given project and article";
            ResultModel = nameof(EntityRecord);

            Parameters.Add(new() { Name = Parameter.Project, Type = "guid", Value = "null" });
            Parameters.Add(new() { Name = Parameter.Article, Type = "guid", Value = "null" });
        }

        public override object? Execute(Dictionary<string, object> arguments)
        {
            var projectId = arguments[Parameter.Project] as Guid?;
            var articleId = arguments[Parameter.Article] as Guid?;
            if (!projectId.HasValue || projectId.Value == Guid.Empty || !articleId.HasValue || articleId == Guid.Empty)
                return null;

            var ds = new OrderListEntries4Project(articleId.Value);
            var args = BuildDataSourceArguments(ds, projectId.Value);

            return (ds.Execute(args) as EntityRecordList)?.SingleOrDefault();
        }

        private static Dictionary<string, object> BuildDataSourceArguments(OrderListEntries4Project ds, Guid projectId)
        {
            var result = ds.GetDefaultArgs();
            result[OrderListEntries4Project.Parameter.Project] = projectId;
            return result;
        }
    }
}
