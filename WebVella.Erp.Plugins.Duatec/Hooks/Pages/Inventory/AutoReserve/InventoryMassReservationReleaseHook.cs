using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.DataSource;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Hooks.Pages.Inventory.AutoReserve.Common;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Inventory.AutoReserve
{
    using FormValues = (Guid ArticleId, decimal Amount, int Index);

    [HookAttachment(key: HookKeys.Inventory.MassRelease)]
    internal class InventoryMassReservationReleaseHook : AutoReserveHook
    {
        protected override IEnumerable<EntityRecord> GetEntries(Guid projectId)
            => InventoryEntriesToRelease4Project.Execute(projectId);

        public override IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var projectId = pageModel.RecordId!.Value;
            var formData = GetFormData(pageModel);

            if (formData.Count == 0)
                return Info(pageModel, "Nothing to do here");

            var superfluousArticleLookup = InventoryEntriesToRelease4Project.Execute(projectId)
                .ToDictionary(sai => sai.ArticleId);

            if (formData.TrueForAll(fd => superfluousArticleLookup.TryGetValue(fd.ArticleId, out var rie) && fd.Amount == rie.ReservedAmount))
                return Info(pageModel, "Nothing to do here");

            validationErrors.AddRange(Validate(formData, superfluousArticleLookup));

            if (validationErrors.Count > 0)
            {
                BuildErrorPage(projectId, pageModel, formData, superfluousArticleLookup);
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
                foreach (var (articleId, amount, _) in formData)
                {
                    var reseredInventoryEntries = projectInventoryLookup[articleId];
                    var diff = reseredInventoryEntries.Sum(rie => rie.Amount) - amount;

                    if (diff < 0)
                        throw new DbException("Fatal amount can not be smaller than sum of reserved amount");
                    else if (diff > 0)
                    {
                        var availableInventoryEntries = availableInventoryEntryLookup.TryGetValue(articleId, out var arr)
                            ? arr : [];

                        MoveInventory(recMan, diff, availableInventoryEntries, reseredInventoryEntries);

                        var entry = inventoryRepo.FindReservationEntryByProjectAndArticle(projectId, articleId)!;
                        if (inventoryRepo.Unreserve(entry, diff) == null)
                            throw new DbException("Could not unreserve inventory");
                    }
                }
            }

            if (Transactional.TryExecute(pageModel, TransactionalAction))
                return Success(pageModel);

            BuildErrorPage(projectId, pageModel, formData, superfluousArticleLookup);
            return pageModel.Page();
        }

        private static void MoveInventory(
            RecordManager recMan, decimal amount,
            InventoryEntry[] availableEntries, InventoryEntry[] reservedEntries)
        {
            var reserved = reservedEntries.Sum(rie => rie.Amount);
            if (amount == reserved)
            {
                foreach (var entry in availableEntries)
                    Move(recMan, null, entry);
            }
            else
            {
                var availableWithinLocation = reservedEntries.Where(
                    rie => Array.Exists(availableEntries, aie => aie.WarehouseLocation == rie.WarehouseLocation));

                var otherAvailables = reservedEntries.Where(
                    rie => !Array.Exists(availableEntries, aie => aie.WarehouseLocation == rie.WarehouseLocation));

                var current = MoveInventory(recMan, amount, amount, availableWithinLocation);
                current = MoveInventory(recMan, amount, current, otherAvailables);

                if (current != 0)
                    throw new DbException("Could not unreserve all entries");
            }
        }

        private static decimal MoveInventory(
            RecordManager recMan, decimal amount, decimal current,
            IEnumerable<InventoryEntry> availableInventoryEntries)
        {
            if (current <= 0)
                return current;

            foreach (var entry in availableInventoryEntries)
            {
                var demand = amount - current;

                if (entry.Amount <= demand)
                {
                    Move(recMan, null, entry);
                    current -= entry.Amount;

                    if (current <= 0)
                        return current;
                }
                else
                {
                    MovePartial(recMan, null, entry, demand);
                    return 0;
                }
            }
            return current;
        }

        private static void BuildErrorPage(Guid projectId, BaseErpPageModel pageModel,
            List<FormValues> formValues, Dictionary<Guid, SuperfluousInventoryArticle> superfluousArticleInfo)
        {
            var records = new List<EntityRecord>(formValues.Count);

            foreach (var (articleId, amount, _) in formValues)
            {
                if (superfluousArticleInfo.TryGetValue(articleId, out var sai))
                {
                    var entry = new SuperfluousInventoryArticle()
                    {
                        ArticleId = articleId,
                        Amount = amount,
                        Demand = sai.Demand,
                        ReservedAmount = sai.ReservedAmount,
                    };
                    entry.SetArticle(sai.GetArticle());
                    records.Add(entry);
                }
            }

            var project = new ProjectRepository().Find(projectId)!;
            project[entryKey] = records;

            pageModel.DataModel.SetRecord(project);
            pageModel.BeforeRender();
        }

        private static IEnumerable<ValidationError> Validate(List<FormValues> formData, Dictionary<Guid, SuperfluousInventoryArticle> superfluousArticleLookup)
        {
            foreach (var (articleId, amount, index) in formData)
            {
                ArticleType? type = null;
                var demand = 0m;

                if (superfluousArticleLookup.TryGetValue(articleId, out var articleInfo))
                {
                    type = articleInfo.GetArticle().GetArticleType();
                    demand = articleInfo.Demand;
                }

                foreach (var error in ValidateAmount(amount, demand, type, index))
                    yield return error;
            }
        }

        private static IEnumerable<ValidationError> ValidateAmount(decimal amount, decimal demand, ArticleType? type, int index)
        {
            var field = $"amount[{index}]";
            var isInt = type?.IsInteger is true;
            var errors = new NumberFormatValidator(InventoryReservationEntry.Entity, InventoryReservationEntry.Fields.Amount, isInt, true)
                .Validate(amount, field);

            foreach (var error in errors)
                yield return error;

            if (amount > demand)
                yield return new ValidationError(field, $"amount must not be greater than demand ({demand})");
        }
    }
}
