using System.Text;
using WebVella.Erp.Api;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Utilities;
using Entity = WebVella.Erp.Plugins.Duatec.Persistance.Entities.InventoryEntry;


namespace DbPatcher.Scripts
{

    internal class Inventory
    {
        public static void ExportReservedAmountsForProjects(string filePath, Guid projectId, RecordManager? recMan = null)
        {
            recMan ??= new();

            var repo = new InventoryRepository(recMan);
            var entries = repo.FindManyByProject(projectId, $"*, ${Entity.Relations.Article}.*, ${Entity.Relations.Location}.*");

            ExportAmounts(filePath, entries, recMan);
        }
        public static void ExportAvailableAmounts(string filePath, RecordManager? recMan = null)
        {
            recMan ??= new();

            var entries = new InventoryRepository(recMan).FindManyByProject(null, $"*, ${Entity.Relations.Article}.*, ${Entity.Relations.Location}.*");
            ExportAmounts(filePath, entries, recMan);
        }

        public static void ExportTakenAmountsForProjects(string filePath, Guid projectId, RecordManager? recMan = null)
        {
            var sb = new StringBuilder();
            recMan ??= new();

            var groups = new InventoryRepository(recMan).FindManyBookingsByProject(projectId)
                .GroupBy(b => b.ArticleId)
                .ToDictionary(g => g.Key, g => g.ToList());

            var articles = new ArticleRepository(recMan).FindMany($"*, ${WebVella.Erp.Plugins.Duatec.Persistance.Entities.Article.Relations.Type}.*", [..groups.Keys]);

            var types = new ArticleRepository(recMan).FindManyTypes()
                .ToDictionary(t => t.Id!.Value);

            foreach(var group in groups)
            {
                var article = articles[group.Key];
                var type = article!.GetArticleType();
                var amount = 0m;

                if (!type.IsDivisible)
                {
                    amount = group.Value.Sum(e =>
                    {
                        if (e.Kind == InventoryBookingKind.Take && e.ProjectId == projectId)
                            return e.Amount;
                        else if (e.Kind == InventoryBookingKind.Store && e.ProjectSourceId == projectId)
                            return -e.Amount;
                        return 0m;
                    });
                }
                else
                {
                    amount = group.Value.Sum(e =>
                    {
                        if ((e.Kind == InventoryBookingKind.Take || e.Kind == InventoryBookingKind.Slice) && e.ProjectId == projectId)
                            return e.Amount * (e.Denomination <= 0 ? 1 : e.Denomination);
                        else if (e.Kind == InventoryBookingKind.Store && e.ProjectSourceId == projectId)
                            return -e.Amount * (e.Denomination <= 0 ? 1 : e.Denomination);
                        return 0m;
                    });
                }

                var pn = article.PartNumber;
                var tn = article.TypeNumber;
                var on = article.OrderNumber;
                var des = article.Designation.Replace('\n', ' ').Replace("\r", string.Empty).Replace('\t', ' ');

                sb.AppendLine($"{pn}\t{tn}\t{on}\t{des}\t{amount}\t{type.Unit}");
            }

            using var fs = File.Create(filePath);

            using var writer = new StreamWriter(fs);

            writer.Write(sb.ToString());

        }

        private static void ExportAmounts(string filePath, List<Entity> entries, RecordManager? recMan = null)
        {
            var sb = new StringBuilder();

            recMan ??= new RecordManager();
            var typeLookup = new ArticleRepository(recMan).FindManyTypes()
                .ToDictionary(t => t.Id!.Value);

            var manufacturerLookup = new CompanyRepository(recMan).FindMany("*", [.. entries.Select(ie => ie.GetArticle().ManufacturerId).Distinct()]);
            var warehouseLookup = new WarehouseRepository(recMan).FindMany("*", [.. entries.Select(ie => ie.GetWarehouseLocation().Warehouse).Distinct()]);

            foreach (var entry in entries)
            {
                var article = entry.GetArticle();
                var type = typeLookup[article.TypeId]!;
                var manufacturer = manufacturerLookup[article.ManufacturerId]!;
                var warehouse = warehouseLookup[entry.GetWarehouseLocation().Warehouse]!;

                var pn = article.PartNumber;
                if (type.IsDivisible)
                    pn += $" ({entry.Denomination} {type.Unit})";

                var tn = article.TypeNumber;
                var on = article.OrderNumber;
                var man = manufacturer!.Name;
                var des = article.Designation.Replace('\n', ' ').Replace("\r", string.Empty).Replace('\t', ' ');
                var w = warehouse.Designation;
                var wl = entry.GetWarehouseLocation().Designation;

                sb.AppendLine($"{pn}\t{tn}\t{on}\t{man}\t{des}\t{w}\t{wl}\t{type.Label}\t{entry.Amount}");
            }


            using var fs = File.Create(filePath);

            using var writer = new StreamWriter(fs);

            writer.Write(sb.ToString());
        }

    }
}
