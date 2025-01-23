using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class OrderArticleSelectOptions : CodeDataSource
    {
        public static class Arguments
        {
            public const string OrderId = "order";
        }

        public OrderArticleSelectOptions() : base()
        {
            Id = new Guid("d353d904-5127-48b5-b986-9b6d339ff6c6");
            Name = nameof(OrderArticleSelectOptions);
            Description = "Select options for articles available in order";
            ResultModel = "List<SelectOption>";

            Parameters.Add(new() { Name = Arguments.OrderId, Type = "guid", Value = "null" });
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var orderId = arguments[Arguments.OrderId] as Guid?;
            if (!orderId.HasValue || orderId.Value == Guid.Empty)
                return new List<SelectOption>();

            var recMan = new RecordManager();

            var projectId = new OrderRepository(recMan).Find(orderId.Value)?.Project;
            if (!projectId.HasValue || projectId.Value == Guid.Empty)
                return new List<SelectOption>();

            return new PartListRepository(recMan).FindManyEntriesByProject(projectId.Value, true, $"*, ${PartListEntry.Relations.Article}.*")
                .Select(ple => ple.GetArticle())
                .Where(a => a != null && a.Id.HasValue)
                .DistinctBy(a => a!.Id)
                .OrderBy(a => a!.PartNumber)
                .Select(a => new SelectOption($"{a!.Id}", $"{a.PartNumber} - {a.Designation}"))
                .ToList();
        }
    }
}
