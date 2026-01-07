using System.Text;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using Entity = WebVella.Erp.Plugins.Duatec.Persistance.Entities.InventoryEntry;
using WebVella.Erp.Api;


namespace DbPatcher.Scripts
{

    internal class Inventory
    {
        public static void ExportAvailableAmounts(string filePath, RecordManager? recMan = null)
        {
            var sb = new StringBuilder();

            recMan ??= new RecordManager();
            var entries = new InventoryRepository(recMan).FindManyByProject(null, $"*, ${Entity.Relations.Article}.*, ${Entity.Relations.Location}.*");
            var typeLookup = new ArticleRepository(recMan).FindManyTypes()
                .ToDictionary(t => t.Id!.Value);

            var manufacturerLookup = new CompanyRepository(recMan).FindMany("*", [.. entries.Select(ie => ie.GetArticle().ManufacturerId).Distinct()]);
            var warehouseLookup = new WarehouseRepository(recMan).FindMany("*", [.. entries.Select(ie => ie.GetWarehouseLocation().Warehouse).Distinct()]);

            foreach(var entry in entries)
            {
                if (!(entry.Project == null || entry.Project == Guid.Empty))
                    throw new Exception("Only unreserved inventory entries are allowed");

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
