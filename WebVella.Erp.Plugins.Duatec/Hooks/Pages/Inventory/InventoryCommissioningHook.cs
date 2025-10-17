using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.DataSource;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Inventory
{
    using FormValue = (Guid ArticleId, decimal Denomination, Guid LocationId, decimal Amount);

    [HookAttachment(key: HookKeys.Inventory.Commissioning)]
    internal class InventoryCommissioningHook : IPageHook
    {
        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            var projectId = Guid.TryParse(pageModel.Request.Query["project_id"], out var id) ? id : Guid.Empty;
            var partListId = Guid.TryParse(pageModel.Request.Query["part_list_id"], out id) ? id : Guid.Empty;

            if (projectId == Guid.Empty)
                return null;

            var list = new List<EntityRecord>();
            list.AddRange(GetDefaultEntries(projectId, partListId));

            var record = new EntityRecord();

            record["id"] = Guid.Empty;
            record["comment"] = string.Empty;
            record["entries"] = list;

            pageModel.DataModel.SetRecord(record);

            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            return null;
        }

        private static List<CommissioningInventoryEntry> GetDefaultEntries(Guid projectId, Guid partListId, RecordManager? recMan = null, Dictionary<(Guid ArticleId, decimal Denomination), decimal>? partListLookup = null)
        {
            recMan ??= new();
            partListLookup ??= GetPartListLookup(partListId, recMan);

            var inventoryEntries = new InventoryRepository(recMan).FindAll()
                .Include($"${InventoryEntry.Relations.Location}.${WarehouseLocation.Relations.Warehouse}")
                .Include($"${InventoryEntry.Relations.Article}.${Article.Relations.Type}")
                .OrderBy(ie => ie.GetArticle().PartNumber)
                .ThenBy(ie => ie.GetWarehouseLocation().GetWarehouse().Designation)
                .ThenBy(ie => ie.GetWarehouseLocation().Designation);

            var result = new List<CommissioningInventoryEntry>();
            var availableAmountLookup = new Dictionary<(Guid ArticleId, decimal Denomination, Guid Location), decimal>();

            foreach(var entry in inventoryEntries)
            {
                if(entry.Project == projectId && (partListId == Guid.Empty || partListLookup.ContainsKey((entry.Article, entry.Denomination))))
                {
                    var commEntry = new CommissioningInventoryEntry();

                    foreach (var kp in entry.Properties)
                        commEntry.Properties[kp.Key] = kp.Value;

                    commEntry.ReservedAmount = entry.Amount;
                    commEntry.Amount = 0m;

                    result.Add(commEntry);
                }

                if(entry.Project == null || entry.Project == Guid.Empty || entry.Project == projectId)
                {
                    var amount = availableAmountLookup.TryGetValue((entry.Article, entry.Denomination, entry.WarehouseLocation), out var d) ? d : 0m;

                    availableAmountLookup[(entry.Article, entry.Denomination, entry.WarehouseLocation)] = amount + entry.Amount;
                }
            }

            foreach(var entry in result)
            {
                entry.AvailableAmount = availableAmountLookup[(entry.Article, entry.Denomination, entry.WarehouseLocation)];
                entry.PartListAmount = partListLookup.TryGetValue((entry.Article, entry.Denomination), out var d) ? d : 0m;
            }
            
            return result;
        }

        private static Dictionary<(Guid ArticleId, decimal Denomination), decimal> GetPartListLookup(Guid partListId, RecordManager? recMan = null)
        {
            return new PartListRepository(recMan)
                .FindManyEntriesByPartList(partListId)
                .GroupBy(ple => (ple.ArticleId, ple.Denomination))
                .ToDictionary(g => (g.Key.ArticleId, g.Key.Denomination), g => g.Sum(ple => ple.Amount));
        }
    }
}
