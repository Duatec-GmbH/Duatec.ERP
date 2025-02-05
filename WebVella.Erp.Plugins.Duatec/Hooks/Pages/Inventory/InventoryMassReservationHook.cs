using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.DataSource;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Inventory
{
    using FormValues = (Guid ArticleId, decimal Amount, int Index);

    [HookAttachment(key: HookKeys.Inventory.MassReservation)]
    internal class InventoryMassReservationHook : IRecordManagePageHook, IPageHook
    {
        const string entryKey = "$entries";

        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record") ?? new EntityRecord();
            if (!rec.Properties.TryGetValue(entryKey, out var l) || l == null)
                rec[entryKey] = new List<EntityRecord>(AvailableInventoryEntries4Project.Execute((Guid)rec["id"]));

            pageModel.DataModel.SetRecord(rec);
            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
            => null;

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
            => null;

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var projectId = pageModel.RecordId!.Value;
            var formData = GetFormData(pageModel);

            if(formData.Count == 0 || formData.TrueForAll(fv => fv.Amount == 0))
                return Info(pageModel, "Nothing to do here");

            var availableArticleLookup = AvailableInventoryEntries4Project.Execute(projectId)
                .ToDictionary(aie => aie.ArticleId, aie => aie);

            validationErrors.AddRange(Validate(formData, availableArticleLookup));

            if(validationErrors.Count > 0)
            {
                BuildErrorPage(projectId, pageModel, formData, availableArticleLookup);
                return pageModel.Page();
            }

            var recMan = new RecordManager();
            var inventoryRepo = new InventoryRepository(recMan);

            var availableInventoryEntryLookup = inventoryRepo.FindManyByProject(null)
                .GroupBy(aie => aie.Article)
                .ToDictionary(g => g.Key, g => g.ToArray());

            var projectInventoryLookup = inventoryRepo.FindManyByProject(projectId)
                .GroupBy(pie => pie.Article)
                .ToDictionary(g => g.Key, g => g.ToArray());

            void TransactionalAction()
            {
                var list = inventoryRepo.FindReservationListByProject(projectId)
                    ?? inventoryRepo.InsertReservationList(new InventoryReservation() { Project = projectId })
                    ?? throw new DbException("Could not create inventory reservation list record");

                foreach(var (articleId, amount, _) in formData.Where(t => t.Amount > 0))
                {
                    var reseredInventoryEntries = projectInventoryLookup.TryGetValue(articleId, out var arr) 
                        ? arr : [];

                    var availableInventoryEntries = availableInventoryEntryLookup.TryGetValue(articleId, out arr)
                        ? arr : [];

                    ReserveInventory(recMan, projectId, amount, availableInventoryEntries, reseredInventoryEntries);
                    var entry = inventoryRepo.FindReservationEntryByProjectAndArticle(projectId, articleId);

                    if (entry != null)                   
                    {
                        entry.Amount += amount;
                        if (inventoryRepo.UpdateReservationEntry(entry) == null)
                            throw new DbException("Could not update inventory reservation entry record");
                    }
                    else
                    {
                        entry = new InventoryReservationEntry()
                        {
                            Amount = amount,
                            Article = articleId,
                            InventoryReservationList = list.Id!.Value
                        };

                        if (inventoryRepo.InsertReservationEntry(entry) == null)
                            throw new DbException("Could not insert inventory reservation entry record");
                    }
                }
            }

            if (Transactional.TryExecute(pageModel, TransactionalAction))
                return Success(pageModel);

            return ReturnToProject(pageModel);
        }

        private static List<FormValues> GetFormData(BaseErpPageModel pageModel)
        {
            var form = pageModel.Request.Form;
            var i = 0;
            var result = new List<FormValues>();


            while(form.TryGetValue($"article_id[{i}]", out var articleIdVal))
            {
                var articleId = Guid.TryParse(articleIdVal, out var id) ? id : Guid.Empty;
                var amount = decimal.TryParse(form[$"amount[{i}]"], out var d) ? d : 0m;

                result.Add((articleId, amount, i));

                i++;
            }

            return result;
        }

        private static void ReserveInventory(RecordManager recMan, Guid projectId, decimal amount, InventoryEntry[] availableEntries, InventoryEntry[] reservedEntries)
        {
            var available = availableEntries.Aggregate(0m, (sum, entry) => sum + entry.Amount);

            if (amount > available)
                throw new DbException("Can not move more entries than available");

            if (amount == available)
            {
                foreach (var entry in availableEntries)
                    Move(recMan, projectId, entry);
            }
            else
            {
                var availableWithinLocation = availableEntries.Where(
                    ae => Array.Exists(reservedEntries, re => re.WarehouseLocation == ae.WarehouseLocation));

                var otherAvailables = availableEntries.Where(
                    ae => !Array.Exists(reservedEntries, re => re.WarehouseLocation == ae.WarehouseLocation));

                var current = Reserve(recMan, projectId, amount, 0m, availableWithinLocation);
                Reserve(recMan, projectId, amount, current, otherAvailables);
            }
        }

        private static decimal Reserve(
            RecordManager recMan, Guid projectId, 
            decimal amount, decimal current, 
            IEnumerable<InventoryEntry> availableEntries)
        {
            if (current >= amount)
                return current;

            IEnumerable<InventoryEntry> toMove = [];
            InventoryEntry? toSplit = null;

            foreach (var entry in availableEntries)
            {
                var demand = amount - current;

                if (entry.Amount <= demand)
                {
                    toMove = toMove.Append(entry);
                    current += entry.Amount;

                    if (current >= amount)
                        break;
                }
                else
                {
                    toSplit = entry;
                    break;
                }
            }

            foreach (var entry in toMove)
                Move(recMan, projectId, entry);

            if (toSplit != null)
            {
                MovePartial(recMan, projectId, toSplit, amount - current);
                current = 0;
            }
            return current;
        }

        private static void Move(RecordManager recMan, Guid projectId, InventoryEntry entry)
        {
            entry.Project = projectId;
            if (new InventoryRepository(recMan).Update(entry) == null)
                throw new DbException("Could not move inventory entry");
        }

        private static void MovePartial(RecordManager recMan, Guid projectId, InventoryEntry entry, decimal amount)
        {
            entry.Project = projectId;
            entry.Amount = amount;
            if (new InventoryRepository(recMan).MovePartial(entry) == null)
                throw new DbException("Could not partially move inventory entry");
        }

        private static void BuildErrorPage(Guid projectId, BaseErpPageModel pageModel,
            List<FormValues> formValues, Dictionary<Guid, AvailableInventoryArticle> availableArticleInfo)
        {
            var records = new List<EntityRecord>(formValues.Count);

            foreach(var (articleId, amount, _) in formValues)
            {
                var entry = new AvailableInventoryArticle()
                {
                    ArticleId = articleId,
                    Amount = amount,
                };

                if(availableArticleInfo.TryGetValue(articleId, out var aie))
                {
                    entry.SetArticle(aie.GetArticle());
                    entry.Demand = aie.Demand;
                    entry.AvailableAmount = aie.AvailableAmount;
                }

                records.Add(entry);
            }

            var project = new ProjectRepository().Find(projectId)!;
            project[entryKey] = records;

            pageModel.DataModel.SetRecord(project);
            pageModel.BeforeRender();
        }


        private static IEnumerable<ValidationError> Validate(List<FormValues> formData, Dictionary<Guid, AvailableInventoryArticle> availableArticleInfos)
        {
            foreach(var (articleId, amount, index) in formData)
            {
                ArticleType? type = null;
                decimal available = 0m;

                if(availableArticleInfos.TryGetValue(articleId, out var articleInfo))
                {
                    type = articleInfo.GetArticle().GetArticleType();
                    available = articleInfo.AvailableAmount;
                }

                foreach (var error in ValidateAmount(amount, available, type, index))
                    yield return error;
            }
        }

        private static IEnumerable<ValidationError> ValidateAmount(decimal amount, decimal max, ArticleType? type, int index)
        {
            var field = $"amount[{index}]";
            var isInt = type?.IsInteger is true;
            var errors = new NumberFormatValidator(InventoryReservationEntry.Entity, InventoryReservationEntry.Fields.Amount, isInt, true)
                .Validate(amount, field);

            foreach (var error in errors)
                yield return error;

            if(amount > max)
                yield return new ValidationError(field, $"amount must not be greater than available amount ({amount})");
        }

        private static LocalRedirectResult Info(BaseErpPageModel pageModel, string message)
        {
            pageModel.PutMessage(ScreenMessageType.Info, message);
            return ReturnToProject(pageModel);
        }

        private static LocalRedirectResult Success(BaseErpPageModel pageModel)
        {
            pageModel.PutMessage(ScreenMessageType.Success, "Successfully performed Inventory reservations");
            return ReturnToProject(pageModel);
        }

        private static LocalRedirectResult ReturnToProject(BaseErpPageModel pageModel)
        {
            var id = pageModel.RecordId;
            var appName = pageModel.ErpRequestContext.App.Name;
            var area = pageModel.ErpRequestContext?.SitemapArea?.Name;

            return pageModel.LocalRedirect($"/{appName}/{area}/projects/r/{id}");
        }
    }
}
