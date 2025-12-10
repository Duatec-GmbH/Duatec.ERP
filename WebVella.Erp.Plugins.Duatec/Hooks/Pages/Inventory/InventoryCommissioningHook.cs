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
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.TypedRecords.Util;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Inventory
{
    using FormValue = (Guid ArticleId, decimal Denomination, Guid LocationId, decimal Amount);

    [HookAttachment(key: HookKeys.Inventory.Commissioning)]
    internal class InventoryCommissioningHook : IPageHook
    {
        private static List<Guid> GetPartListIds(BaseErpPageModel pageModel)
        {
            return [.. $"{pageModel.Request.Query["part_list_id"]}".Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(s => Guid.TryParse(s, out var id) ? id : Guid.Empty)
                .Where(id => id != Guid.Empty)];
        }

        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            var projectId = Guid.TryParse(pageModel.Request.Query["project_id"], out var id) ? id : Guid.Empty;
            var partListIds = GetPartListIds(pageModel);

            if (projectId == Guid.Empty)
                return null;

            var list = new List<EntityRecord>();
            list.AddRange(GetCommissioningEntries(projectId, partListIds));

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
            var partListIds = GetPartListIds(pageModel);

            var formValues = GetFormValues(pageModel);
            var significantInventoryEntries = GetSignificantInventoryEntries(projectId, formValues, recMan);
            var commissioningEntries = GetCommissioningEntries(projectId, partListIds, formValues, significantInventoryEntries, recMan);

            var validationErrors = ValidateEntries(commissioningEntries, significantInventoryEntries);

            if(validationErrors.Count > 0)
            {
                pageModel.Validation.Errors = validationErrors;
                SetUpErrorPage(pageModel, commissioningEntries);
                return pageModel.Page();
            }

            var inventoryLookup = significantInventoryEntries
                .GroupBy(ie => (ie.Article, ie.Denomination, ie.WarehouseLocation))
                .ToDictionary(g => g.Key, g => g.ToArray());

            var comment = $"{pageModel.Request.Form["comment"]}";
            if (string.IsNullOrWhiteSpace(comment))
                comment = "Commissioning";

            var toDelete = new List<Guid>();
            var toUpdate = new List<InventoryEntry>();
            var bookings = new List<InventoryBooking>();

            void TransactionalAction()
            {
                var timestamp = DateTime.UtcNow;

                foreach (var entry in commissioningEntries)
                {
                    if (entry.Amount > 0)
                    {
                        var inventoryEntries = inventoryLookup[(entry.Article, entry.Denomination, entry.WarehouseLocation)];

                        if (entry.Amount < entry.ReservedAmount)
                        {
                            // update reserved

                            var inventoryEntry = inventoryEntries.FirstOrDefault(ie => ie.Project == projectId);

                            if (inventoryEntry == null || inventoryEntry.Amount <= entry.Amount)
                                throw new DbException($"Could not take out article '{entry.GetArticle().PartNumber}'");

                            inventoryEntry.Amount -= entry.Amount;

                            toUpdate.Add(inventoryEntry);
                            bookings.Add(TakeBooking(inventoryEntry, timestamp, comment, pageModel.CurrentUser.Id, entry.Amount));
                        }
                        else if (entry.Amount == entry.ReservedAmount)
                        {
                            // delete reserved

                            var inventoryEntry = inventoryEntries.FirstOrDefault(ie => ie.Project == projectId);

                            if (inventoryEntry == null || inventoryEntry.Amount != entry.Amount)
                                throw new DbException($"Could not take out article '{entry.GetArticle().PartNumber}'");

                            toDelete.Add(inventoryEntry.Id!.Value);
                            bookings.Add(TakeBooking(inventoryEntry, timestamp, comment, pageModel.CurrentUser.Id));
                        }
                        else if (entry.Amount < entry.AvailableAmount)
                        {
                            // delete reserved
                            // update available

                            var reserved = inventoryEntries.FirstOrDefault(ie => ie.Project == projectId);
                            var available = inventoryEntries.FirstOrDefault(ie => ie.Project != projectId);

                            if (reserved == null || available == null || reserved.Amount + available.Amount <= entry.Amount)
                                throw new DbException($"Could not take out article '{entry.GetArticle().PartNumber}'");

                            var toMove = entry.Amount - reserved.Amount;
                            available.Amount -= toMove;

                            toDelete.Add(reserved.Id!.Value);
                            bookings.Add(TakeBooking(reserved, timestamp, comment, pageModel.CurrentUser.Id));
                            toUpdate.Add(available);
                            bookings.Add(MoveAndTakeBooking(projectId, available, timestamp, comment, pageModel.CurrentUser.Id, toMove));
                        }
                        else if (entry.Amount == entry.AvailableAmount)
                        {
                            // delete all

                            var amount = inventoryEntries.Sum(ie => ie.Amount);

                            if (amount != entry.Amount)
                                throw new DbException($"Could not take out article '{entry.GetArticle().PartNumber}'");

                            toDelete.AddRange(inventoryEntries.Select(ie => ie.Id!.Value));
                            bookings.AddRange(inventoryEntries.Select(ie => ie.Project == projectId
                                ? TakeBooking(ie, timestamp, comment, pageModel.CurrentUser.Id)
                                : MoveAndTakeBooking(projectId, ie, timestamp, comment, pageModel.CurrentUser.Id)));
                        }
                        else throw new DbException($"Could not take out article '{entry.GetArticle().PartNumber}'");
                    }
                }

                var updateMessage = "Could not take out articles";
                var repo = new InventoryRepository(recMan);

                if (repo.DeleteMany([.. toDelete]).Count != toDelete.Count)
                    throw new DbException(updateMessage);

                foreach(var rec in toUpdate)
                {
                    if (repo.Update(rec.WithoutRelations()) == null)
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

            if(bookings.Count > 0)
                pageModel.PutMessage(ScreenMessageType.Success, "Successfully took out articles from inventory.");

            if (!string.IsNullOrEmpty(pageModel.ReturnUrl))
                return pageModel.LocalRedirect(pageModel.ReturnUrl);

            return pageModel.LocalRedirect($"/{pageModel.AppName}/inventory/inventory/l/all?returnUrl=%2f");
        }

        private static InventoryBooking MoveAndTakeBooking(Guid projectId, InventoryEntry entry, DateTime timestamp, string comment, Guid userId, decimal amount = -1)
        {
            if (amount < 0)
                amount = entry.Amount;

            return new InventoryBooking()
            {
                Amount = amount,
                Denomination = entry.Denomination,
                ArticleId = entry.Article,
                Comment = comment,
                Id = Guid.NewGuid(),
                Kind = InventoryBookingKind.Take,
                ProjectId = projectId,
                ProjectSourceId = entry.Project,
                Timestamp = timestamp,
                WarehouseLocationId = entry.WarehouseLocation,
                WarehouseLocationSourceId = entry.WarehouseLocation,
                TaggedRecordId = null,
                TaggedEntityName = null,
                TaggedObject = null,
                UserId = userId,
            };
        }

        private static InventoryBooking TakeBooking(InventoryEntry entry, DateTime timestamp, string comment, Guid userId, decimal amount = -1)
        {
            if (amount < 0)
                amount = entry.Amount;

            return new InventoryBooking()
            {
                Amount = amount,
                Denomination = entry.Denomination,
                ArticleId = entry.Article,
                Comment = comment,
                Id = Guid.NewGuid(),
                Kind = InventoryBookingKind.Take,
                ProjectId = entry.Project,
                ProjectSourceId = entry.Project,
                Timestamp = timestamp,
                WarehouseLocationId = entry.WarehouseLocation,
                WarehouseLocationSourceId = entry.WarehouseLocation,
                TaggedRecordId = null,
                TaggedEntityName = null,
                TaggedObject = null,
                UserId = userId,
            };
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

        private static List<ValidationError> ValidateEntries(List<CommissioningInventoryEntry> commissioningEntries, List<InventoryEntry> significantInventoryEntries)
        {
            var inventoryLookup = significantInventoryEntries
                .Select(ie => (ie.Article, ie.Denomination, ie.WarehouseLocation))
                .Distinct()
                .ToHashSet();

            var result = new List<ValidationError>();
            var index = 0;

            var amountValidator = new NumberFormatValidator(InventoryEntry.Fields.Amount, true, true, true);

            foreach(var entry in commissioningEntries)
            {
                var amountField = $"amount[{index}]";

                if (entry.Amount != 0 && !inventoryLookup.Contains((entry.Article, entry.Denomination, entry.WarehouseLocation)))
                    result.Add(new ValidationError(amountField, $"Entry is not available anymore"));

                else
                    result.AddRange(amountValidator.Validate(entry.Amount, amountField));

                index++;
            }

            return result;
        }

        private static List<CommissioningInventoryEntry> GetCommissioningEntries(Guid projectId, List<Guid> partListIds, RecordManager? recMan = null)
        {
            recMan ??= new();
            var partListLookup = GetPartListLookup(partListIds, recMan);

            var inventoryEntries = new InventoryRepository(recMan).FindAll()
                .Include($"${InventoryEntry.Relations.Location}.${WarehouseLocation.Relations.Warehouse}")
                .Include($"${InventoryEntry.Relations.Article}.${Article.Relations.Type}")
                .OrderBy(ie => ie.GetWarehouseLocation().GetWarehouse().Designation)
                .ThenBy(ie => ie.GetWarehouseLocation().Designation)
                .ThenBy(ie => ie.GetArticle().PartNumber);

            var result = new List<CommissioningInventoryEntry>();
            var availableAmountLookup = new Dictionary<(Guid ArticleId, decimal Denomination, Guid Location), decimal>();

            foreach(var entry in inventoryEntries)
            {
                if(entry.Project == projectId && (partListIds.Count == 0 || partListLookup.ContainsKey((entry.Article, entry.Denomination))))
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

        private static List<CommissioningInventoryEntry> GetCommissioningEntries(Guid projectId, List<Guid> partListIds, List<FormValue> formValues, List<InventoryEntry> significantInventoryEntries, RecordManager? recMan = null)
        {
            recMan ??= new();

            var inventoryLookup = significantInventoryEntries
                .GroupBy(ie => (ie.Article, ie.Denomination, ie.WarehouseLocation))
                .ToDictionary(g => g.Key, g => g.ToArray());

            var availableAmountLookup = new Dictionary<(Guid ArticleId, decimal Denomination, Guid Location), decimal>();
            var partListLookup = GetPartListLookup(partListIds, recMan);

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

        private static List<InventoryEntry> GetSignificantInventoryEntries(Guid projectId, List<FormValue> formValues, RecordManager? recMan = null)
        {
            recMan ??= new();

            var formValueLookup = formValues
                .Select(fv => (fv.ArticleId, fv.Denomination, fv.LocationId))
                .ToHashSet();

            return [..new InventoryRepository(recMan).FindAll()
                .Where(ie => formValueLookup.Contains((ie.Article, ie.Denomination, ie.WarehouseLocation)))
                .Where(ie => !ie.Project.HasValue || ie.Project == Guid.Empty || ie.Project == projectId)
                .Include($"${InventoryEntry.Relations.Location}.${WarehouseLocation.Relations.Warehouse}")
                .Include($"${InventoryEntry.Relations.Article}.${Article.Relations.Type}")];
        }


        private static Dictionary<(Guid ArticleId, decimal Denomination), decimal> GetPartListLookup(List<Guid> partListIds, RecordManager? recMan = null)
        {
            if (partListIds.Count == 0)
                return [];

            var repo = new PartListRepository(recMan);
            var result = new Dictionary<(Guid ArticleId, decimal Denomination), decimal>();

            foreach(var id in partListIds)
            {
                foreach(var g in repo.FindManyEntriesByPartList(id).GroupBy(ple => (ple.ArticleId, ple.Denomination)))
                {
                    if (!result.TryGetValue(g.Key, out var value))
                        result.Add(g.Key, g.Sum(ple => ple.Amount));

                    else
                        result[g.Key] = value + g.Sum(ple => ple.Amount);
                }
            }

            return result;
        }
    }
}
