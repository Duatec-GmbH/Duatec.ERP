using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class OrderListEntryDetail : CodeDataSource
    {
        public OrderListEntryDetail() : base()
        {
            Id = new Guid("3471802f-cf42-4416-a2c5-2fca639619d3");
            Name = nameof(OrderListEntries4Project);
            Description = "Order List Entry detail for given project and article";
            ResultModel = nameof(EntityRecord);

            Parameters.Add(new() { Name = "project", Type = "guid", Value = "null" });
            Parameters.Add(new() { Name = "article", Type = "guid", Value = "null" });
        }

        public override object? Execute(Dictionary<string, object> arguments)
        {
            var projectId = arguments["project"] as Guid?;
            var articleId = arguments["article"] as Guid?;
            if (!projectId.HasValue || projectId.Value == Guid.Empty || !articleId.HasValue || articleId == Guid.Empty)
                return null;

            var ds = new OrderListEntries4Project(articleId.Value);
            var args = BuildDataSourceArguments(ds, projectId.Value);

            return (ds.Execute(args) as EntityRecordList)?.SingleOrDefault();
        }

        private static Dictionary<string, object> BuildDataSourceArguments(CodeDataSource ds, Guid projectId)
        {
            var result = new Dictionary<string, object>(32);
            var dsMan = new DataSourceManager();

            foreach (var param in ds.Parameters)
                result[param.Name] = dsMan.GetDataSourceParameterValue(param);

            result["project"] = projectId;
            return result;
        }
    }
}
