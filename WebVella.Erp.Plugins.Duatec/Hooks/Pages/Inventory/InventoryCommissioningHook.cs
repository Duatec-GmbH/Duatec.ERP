using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Persistance;
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
            list.AddRange(GetCommissioningEntries(projectId, partListId));

            var record = new EntityRecord();

            record["id"] = Guid.Empty;
            record["comment"] = string.Empty;
            record["entries"] = list;

            pageModel.DataModel.SetRecord(record);

            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            var recMan = new RecordManager();

            var projectId = Guid.TryParse(pageModel.Request.Query["project_id"], out var id) ? id : Guid.Empty;
            var partListId = Guid.TryParse(pageModel.Request.Query["part_list_id"], out id) ? id : Guid.Empty;
            var formValues = GetFormValues(pageModel);
            var commissioningEntries = GetCommissioningEntries(projectId, partListId, formValues, recMan);
            var validationErrors = ValidateEntries(commissioningEntries);

            if(validationErrors.Count > 0)
            {
                pageModel.Validation.Errors = validationErrors;
                SetUpErrorPage(pageModel, commissioningEntries);
                return pageModel.Page();
            }

            var comment = $"{pageModel.Request.Form["comment"]}";

            var toDelete = new List<Guid>();
            var toUpdate = new List<InventoryEntry>();
            var bookings = new List<InventoryBooking>();

            foreach (var entry in commissioningEntries)
            {
                if (entry.Amount < entry.ReservedAmount)
                {
                    // update
                }
                else if (entry.Amount == entry.ReservedAmount)
                {
                    // just delete
                }
                else if (entry.Amount == entry.AvailableAmount)
                {
                    // delete all
                }
                else
                {
                    // delete reserved
                    // update available
                }
            }

            void TransactionalAction()
            {
                var updateMessage = "Could not take out articles";
                var repo = new InventoryRepository(recMan);

                if (repo.DeleteMany([.. toDelete]).Count != toDelete.Count)
                    throw new DbException(updateMessage);

                foreach(var rec in toUpdate)
                {
                    if (repo.Update(rec) == null)
                        throw new DbException(updateMessage);
                }

                if (repo.InsertManyBookings(bookings).Count != bookings.Count)
                    throw new DbException($"Could not insert bookings");
            }

            if(!Transactional.TryExecute(pageModel, TransactionalAction))
            {
                SetUpErrorPage(pageModel, commissioningEntries);
                return pageModel.Page();
            }

            pageModel.PutMessage(ScreenMessageType.Success, "Successfully took out articles from inventory.");

            if (!string.IsNullOrEmpty(pageModel.ReturnUrl))
                return pageModel.LocalRedirect(pageModel.ReturnUrl);

            return pageModel.LocalRedirect($"/{pageModel.AppName}/inventory/inventory/l/all?returnUrl=%2f");
        }

        private static void SetUpErrorPage(BaseErpPageModel pageModel, List<CommissioningInventoryEntry> defaultEntries)
        {
            var entries = new List<EntityRecord>();
            entries.AddRange(defaultEntries);

            var record = new EntityRecord();

            record["id"] = Guid.Empty;
            record["comment"] = $"{pageModel.Request.Form["comment"]}";
            record["entries"] = entries;

            pageModel.DataModel.SetRecord(record);
            pageModel.BeforeRender();
        }


        private static List<FormValue> GetFormValues(BaseErpPageModel pageModel)
        {
            var result = new List<FormValue>();
            var form = pageModel.Request.Form;

            for (var i = 0; i < int.MaxValue; i++)
            {
                if (!form.TryGetValue($"article_id[{i}]", out var articleIdText))
                    break;

                var articleId = Guid.TryParse(articleIdText, out var id) ? id : Guid.Empty;
                var denomination = decimal.TryParse(form[$"denomination[{i}]"], out var d) ? d : 0m;
                var location = Guid.TryParse(form[$"warehouse_location_id[{i}]"], out id) ? id : Guid.Empty;
                var amount = decimal.TryParse(form[$"amount[{i}]"], out d) ? d : 0m;

                result.Add(new FormValue(articleId, denomination, location, amount));
            }

            return result;
        }

        private static List<ValidationError> ValidateEntries(List<CommissioningInventoryEntry> commissioningEntries)
        {
            var result = new List<ValidationError>();
            var index = 0;

            foreach(var entry in commissioningEntries)
            {
                var amountField = $"amount[{index}]";

                if (entry.Amount != 0 && (entry.Article == Guid.Empty || entry.WarehouseLocation == Guid.Empty))
                    result.Add(new ValidationError(amountField, $"Entry is not available anymore"));

                else if (entry.Amount < 0)
                    result.Add(new ValidationError(amountField, $"Amount must not be smaller than '0'"));

                else if (entry.Amount > entry.AvailableAmount)
                    result.Add(new ValidationError(amountField, $"Amount must not be greater than available amount ({entry.AvailableAmount})"));

                index++;
            }

            return result;
        }

        private static List<CommissioningInventoryEntry> GetCommissioningEntries(Guid projectId, Guid partListId, RecordManager? recMan = null)
        {
            recMan ??= new();
            var partListLookup = GetPartListLookup(partListId, recMan);

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

        private static List<CommissioningInventoryEntry> GetCommissioningEntries(Guid projectId, Guid partListId, List<FormValue> formValues, RecordManager? recMan = null)
        {
            recMan ??= new();

            var formValueLookup = formValues
                .Select(fv => (fv.ArticleId, fv.Denomination, fv.LocationId))
                .ToHashSet();

            var inventoryLookup = new InventoryRepository(recMan).FindAll()
                .Where(ie => formValueLookup.Contains((ie.Article, ie.Denomination, ie.WarehouseLocation)))
                .Include($"${InventoryEntry.Relations.Location}.${WarehouseLocation.Relations.Warehouse}")
                .Include($"${InventoryEntry.Relations.Article}.${Article.Relations.Type}")
                .GroupBy(ie => (ie.Article, ie.Denomination, ie.WarehouseLocation))
                .ToDictionary(g => g.Key, g => g.ToArray());

            var availableAmountLookup = new Dictionary<(Guid ArticleId, decimal Denomination, Guid Location), decimal>();
            var partListLookup = GetPartListLookup(partListId, recMan);

            var result = new List<CommissioningInventoryEntry>();
            var toResolve = new List<CommissioningInventoryEntry>();

            foreach (var (articleId, denomination, locationId, amount) in formValues)
            {
                var partListAmount = partListLookup.TryGetValue((articleId, denomination), out var d) ? d : 0m;

                if (inventoryLookup.TryGetValue((articleId, denomination, locationId), out var localEntries))
                {
                    var reserved = localEntries.Where(e => e.Project == projectId).Aggregate(0m, (sum, e) => sum + e.Amount);
                    var available = localEntries.Sum(e => e.Amount);

                    var entry = new CommissioningInventoryEntry();

                    var first = localEntries.FirstOrDefault(e => e.Project == projectId) ?? localEntries[0];

                    foreach (var kp in first.Properties)
                        entry[kp.Key] = kp.Value;

                    if (first.Project != projectId)
                        entry.Id = Guid.Empty;

                    entry.ReservedAmount = reserved;
                    entry.AvailableAmount = available;
                    entry.PartListAmount = partListAmount;
                    entry.Amount = amount;
                    entry.Project = projectId;

                    result.Add(entry);
                }
                else
                {
                    var entry = new CommissioningInventoryEntry
                    {
                        Id = Guid.Empty,
                        ReservedAmount = 0m,
                        AvailableAmount = 0m,
                        PartListAmount = partListAmount,
                        Amount = amount,
                        Project = projectId,
                        Article = articleId,
                        Denomination = denomination,
                        WarehouseLocation = locationId
                    };

                    result.Add(entry);
                    toResolve.Add(entry);
                }
            }

            if (toResolve.Count > 0)
            {
                var articleIds = toResolve
                    .Select(e => e.Article)
                    .Distinct()
                    .ToArray();

                var locationIds = toResolve
                    .Select(e => e.WarehouseLocation)
                    .Distinct()
                    .ToArray();

                var articleLookup = new ArticleRepository(recMan)
                    .FindMany($"*, ${Article.Relations.Type}.*", articleIds);

                var locationLookup = new WarehouseRepository(recMan)
                    .FindManyEntries($"*, ${WarehouseLocation.Relations.Warehouse}.*", locationIds);

                foreach (var rec in toResolve)
                {
                    if (articleLookup.TryGetValue(rec.Article, out var article) && article != null)
                        rec.SetArticle(article);
                    else
                        rec.Article = Guid.Empty;

                    if (locationLookup.TryGetValue(rec.WarehouseLocation, out var location) && location != null)
                        rec.SetWarehouseLocation(location);
                    else
                        rec.WarehouseLocation = Guid.Empty;
                }
            }

            return result;
        }


        private static Dictionary<(Guid ArticleId, decimal Denomination), decimal> GetPartListLookup(Guid partListId, RecordManager? recMan = null)
        {
            if (partListId == Guid.Empty)
                return [];

            return new PartListRepository(recMan)
                .FindManyEntriesByPartList(partListId)
                .GroupBy(ple => (ple.ArticleId, ple.Denomination))
                .ToDictionary(g => (g.Key.ArticleId, g.Key.Denomination), g => g.Sum(ple => ple.Amount));
        }
    }
}
