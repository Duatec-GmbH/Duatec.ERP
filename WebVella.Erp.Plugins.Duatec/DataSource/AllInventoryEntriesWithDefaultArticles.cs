﻿using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class AllInventoryEntriesWithDefaultArticles : CodeDataSource
    {
        public static class Arguments
        {
            public const string Warehouse = "warehouse";
            public const string WarehouseLocation = "warehouseLocation";
            public const string Article = "article";
            public const string Manufacturer = "manufacturer";
            public const string Project = "project";
            public const string Page = "page";
            public const string PageSize = "pageSize";
        }

        public AllInventoryEntriesWithDefaultArticles() 
        {
            Id = new Guid("1304a84a-17eb-47c0-9dd9-2669a1efb561");
            Name = nameof(AllInventoryEntriesWithDefaultArticles);
            ResultModel = nameof(EntityRecordList);

            Parameters.Add(new() { Name = Arguments.Warehouse, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.WarehouseLocation, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Article, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Manufacturer, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Project, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Page, Type = "int", Value = "1" });
            Parameters.Add(new() { Name = Arguments.PageSize, Type = "int", Value = "10" });
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var recMan = new RecordManager();
            var inventoryRepo = new InventoryRepository(recMan);
            var articleRepo = new ArticleRepository(recMan);
            var warehouseRepo = new WarehouseRepository(recMan);

            const string inventoryEntrySelect = "*, $project.*";
            const string articleSelect = "*, $article_article_type.*, $article_manufacturer.name";
            const string locationSelect = "*, $warehouse.id, $warehouse.designation";

            var inventoryEntries = inventoryRepo.FindAll(inventoryEntrySelect);
            var locations = warehouseRepo.FindAllEntries(locationSelect)
                .ToDictionary(l => l.Id!.Value, l => l);

            var articles = articleRepo.FindAll(articleSelect)
                .ToDictionary(a => a.Id!.Value, a => a);

            var entryArticleIds = inventoryEntries
                .Select(e => e.Article)
                .Distinct()
                .ToHashSet();

            var entriesToAdd = articles.Values
                .Where(a => !entryArticleIds.Contains(a.Id!.Value)
                    && a.PreferedWarehouseLocation.HasValue
                    && a.PreferedWarehouseLocation != Guid.Empty)
                .Select(a => new InventoryEntry()
                {
                    Id = a.Id!.Value,
                    Article = a.Id!.Value,
                    Amount = 0,
                    WarehouseLocation = a.PreferedWarehouseLocation!.Value,
                    Project = null,
                });

            var all = inventoryEntries.Concat(entriesToAdd).ToList();

            foreach (var entry in all)
            {
                entry.SetWarehouseLocation(locations[entry.WarehouseLocation]);
                entry.SetArticle(articles[entry.Article]);
            }

            var filtered = Filter(arguments, all).ToList();
            var result = new EntityRecordList { TotalCount = filtered.Count };
            var pageSize = (int)arguments[Arguments.PageSize];

            if (pageSize <= 0 || pageSize >= all.Count)
                result.AddRange(filtered);
            else
            {
                var page = (int)arguments[Arguments.Page];
                result.AddRange(filtered.Skip((page - 1) * pageSize).Take(pageSize));
            }
            return result;
        }

        private static IEnumerable<InventoryEntry> Filter(Dictionary<string, object> arguments, IEnumerable<InventoryEntry> entries)
        {
            const StringComparison comparison = StringComparison.OrdinalIgnoreCase;

            var warehouse = arguments.TryGetValue(Arguments.Warehouse, out var s) ? s as string : null;
            var location = arguments.TryGetValue(Arguments.WarehouseLocation, out s) ? s as string : null;
            var article = arguments.TryGetValue(Arguments.Article, out s) ? s as string : null;
            var manufacturer = arguments.TryGetValue(Arguments.Manufacturer, out s) ? s as string : null;
            var project = arguments.TryGetValue(Arguments.Project, out s) ? s as string : null;

            if (!string.IsNullOrEmpty(warehouse))
                entries = entries.Where(e => e.GetWarehouseLocation().GetWarehouse().Designation.Contains(warehouse, comparison));

            if (!string.IsNullOrEmpty(location))
                entries = entries.Where(e => e.GetWarehouseLocation().Designation.Contains(location, comparison));

            if (!string.IsNullOrEmpty(article))
            {
                entries = entries.Where(e =>
                {
                    var a = e.GetArticle();
                    return a.PartNumber.Contains(article, comparison)
                        || a.TypeNumber.Contains(article, comparison)
                        || a.OrderNumber.Contains(article, comparison)
                        || a.Designation.Contains(article, comparison);
                });
            }

            if (!string.IsNullOrEmpty(manufacturer))
                entries = entries.Where(e => e.GetArticle().GetManufacturer().Name.Contains(manufacturer, comparison));

            if(!string.IsNullOrEmpty(project))
            {
                entries = entries.Where(e =>
                {
                    var p = e.GetProject();
                    return p != null 
                        && (p.Number.Contains(project, comparison) || p.Name.Contains(project, comparison));
                });
            }

            return entries.OrderBy(e => e.GetArticle().PartNumber)
                .ThenBy(e => e.GetWarehouseLocation().GetWarehouse().Designation)
                .ThenBy(e => e.GetWarehouseLocation().Designation);
        }
    }
}
