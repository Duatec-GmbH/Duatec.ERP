using Microsoft.CodeAnalysis;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class ArticlesToOrder : CodeDataSource
    {
        public static class Arguments
        {
            public const string Article = "article";
            public const string Manufacturer = "manufacturer";
            public const string Page = "page";
            public const string PageSize = "pageSize";
        }

        public ArticlesToOrder() : base()
        {
            Id = new Guid("3db10541-2733-4f3a-bfd2-bcb22615af73");
            Name = nameof(ArticlesToOrder);
            Description = "List of all articles which need to be ordered due to stock control";
            ResultModel = "EntityRecordList";

            Parameters.Add(new DataSourceParameter { Name = Arguments.Article, Type = "text", Value = "null" });
            Parameters.Add(new DataSourceParameter { Name = Arguments.Manufacturer, Type = "text", Value = "null" });
            Parameters.Add(new DataSourceParameter { Name = Arguments.Page, Type = "int", Value = "1" });
            Parameters.Add(new DataSourceParameter { Name = Arguments.PageSize, Type = "int", Value = "10" });
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var page = (int)arguments[Arguments.Page];
            var pageSize = (int)arguments[Arguments.PageSize];
            var articleQuery = arguments[Arguments.Article] as string;
            var manufacturerQuery = arguments[Arguments.Manufacturer] as string;

            if (pageSize <= 0)
            {
                pageSize = int.MaxValue;
                page = 1;
            }

            var result = new EntityRecordList();

            var all = Execute(articleQuery, manufacturerQuery).Skip((page - 1) * pageSize).ToList();
            result.AddRange(all.Skip((page - 1) * pageSize).Take(pageSize));

            result.TotalCount = all.Count;

            return result;
        }

        public static IEnumerable<ArticleStockControlEntry> Execute(string? articleQuery = null, string? manufacturerQuery = null, RecordManager? recMan = null)
        {
            recMan ??= new();

            var projectRepo = new ProjectRepository(recMan);
            var orderRepo = new OrderRepository(recMan);
            var articleRepo = new ArticleRepository(recMan);
            var inventoryRepo = new InventoryRepository(recMan);
            var goodsReceivingRepo = new GoodsReceivingRepository(recMan);

            var stockControlledArticles = articleRepo.FindManyByStockControl(true, $"*, ${Article.Relations.Type}.*, ${Article.Relations.Manufacturer}.*");
            var articleLookup = stockControlledArticles.ToDictionary(a => a.Id!.Value, a => a);

            var inventoryEntries = inventoryRepo.FindManyByArticles("*", [.. articleLookup.Keys])
                .Where(ie => ie.Project == null || ie.Project == Guid.Empty)
                .Where(ie => articleLookup.ContainsKey(ie.Article))
                .ToList();

            var inventoryAmountLookup = inventoryEntries.GroupBy(ie => ie.Article)
                .ToDictionary(g => g.Key, g => g.Sum(ie => 
                {
                    var article = articleLookup[ie.Article];
                    var type = article.GetArticleType();

                    if (!type.IsDivisible)
                        return ie.Amount;

                    return (ie.Denomination == 0 ? 1 : ie.Denomination) * ie.Amount;
                }));


            var openOrdersLookup = OpenOrders.Execute($"*, ${Order.Relations.Project}.*", recMan)
                .Where(o =>
                {
                    var project = o.GetProject();
                    return project != null && project.IsInventoryProject && !project.ReserveStoredArticles;
                })
                .ToDictionary(o => o.Id!.Value);

            var receivedAmountLookup = new GoodsReceivingRepository(recMan).FindManyEntriesByOrders("*", [.. openOrdersLookup.Keys])
                .Where(gre => articleLookup.ContainsKey(gre.Article))
                .GroupBy(gre => gre.Article)
                .ToDictionary(g => g.Key, g => g.Sum(gre =>
                {
                    var article = articleLookup[gre.Article];
                    var type = article.GetArticleType();

                    if (!type.IsDivisible)
                        return gre.Amount;

                    return (gre.Denomination == 0 ? 1 : gre.Denomination) * gre.Amount;
                }));

            var orderEntries = new OrderRepository(recMan).FindManyEntriesByOrders("*", [..openOrdersLookup.Keys])
                .Where(oe => articleLookup.ContainsKey(oe.Article));

            var outstandingAmountLookup = orderEntries
                .GroupBy(ie => ie.Article)
                .ToDictionary(g => g.Key, g => g.Sum(oe =>
                {
                    var article = articleLookup[oe.Article];
                    var type = article.GetArticleType();

                    var receivedAmount = receivedAmountLookup.TryGetValue(oe.Article, out var d) ? d : 0m;

                    if (!type.IsDivisible)
                        return oe.Amount - receivedAmount;

                    return (oe.Denomination == 0 ? 1 : oe.Denomination) * oe.Amount - receivedAmount;
                }));

            var result = stockControlledArticles.Select(a => 
                {
                    var availableAmount = inventoryAmountLookup.TryGetValue(a.Id!.Value, out var d) ? d : 0;
                    var outstandingAmount = outstandingAmountLookup.TryGetValue(a.Id.Value, out d) ? d : 0;
                    if (outstandingAmount < 0)
                        outstandingAmount = 0;

                    var entry = new ArticleStockControlEntry()
                    {
                        Id = Guid.NewGuid(),
                        ArticleId = a.Id!.Value,
                        AvailableAmount = availableAmount,
                        OutstandingAmount = outstandingAmount,
                        Demand = a.MinimumStock - availableAmount - outstandingAmount
                    };

                    entry.SetArticle(a);
                    return entry;

                }).ToList()
                .Where(e => e.Demand > 0);

            const StringComparison comparison = StringComparison.OrdinalIgnoreCase;

            if (!string.IsNullOrWhiteSpace(articleQuery))
            {
                result = result.Where(e =>
                {
                    var a = e.GetArticle();
                    return a.PartNumber.Contains(articleQuery, comparison)
                        || a.TypeNumber.Contains(articleQuery, comparison)
                        || a.OrderNumber.Contains(articleQuery, comparison)
                        || a.Designation.Contains(articleQuery, comparison)
                        || a.Id.HasValue && $"{a.Id}".Equals(articleQuery, comparison);
                });
            }

            if (!string.IsNullOrWhiteSpace(manufacturerQuery))
            {
                result = result.Where(e => e.GetArticle().GetManufacturer().Name.Contains(manufacturerQuery, comparison));
            }

            return result.OrderBy(ase => ase.GetArticle().PartNumber);
        }
    }
}
