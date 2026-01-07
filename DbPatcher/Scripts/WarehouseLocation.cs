using System.Text;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace DbPatcher.Scripts
{
    public static class WarehouseLocation
    {
        public static void ExportAll(string filePath)
        {
            var repo = new WarehouseRepository();

            var sb = new StringBuilder();

            foreach (var location in repo.FindAllEntries($"*, ${WebVella.Erp.Plugins.Duatec.Persistance.Entities.WarehouseLocation.Relations.Warehouse}.*").OrderBy(w => w.GetWarehouse().Designation).ThenBy(w => w.Designation))
                sb.AppendLine($"{location.Id}\t{location.GetWarehouse().Designation}\t{location.Designation}");

            File.WriteAllText(filePath, sb.ToString());
        }
    }
}
