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
                .ToDictionary(sia => sia.ArticleId);

            if (superfluousArticleLookup.Values.All(sia => sia.AvailableAmount == sia.SelectedAmount))
                return Info(pageModel, "Nothing to do here");

            validationErrors.AddRange(Validate(formData, superfluousArticleLookup));

            if (validationErrors.Count > 0)
            {
                pageModel.Validation.Errors = validationErrors;
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
                    if(superfluousArticleLookup.TryGetValue(articleId, out var articleInfo))
                    {
                        var diff = articleInfo.AvailableAmount - amount;
                        if(diff > 0)
                        {
                            var reseredInventoryEntries = projectInventoryLookup[articleId];
                            var availableInventoryEntries = availableInventoryEntryLookup.TryGetValue(articleId, out var arr)
                                ? arr : [];

                            MoveInventory(recMan, diff, availableInventoryEntries, reseredInventoryEntries, pageModel.CurrentUser.Id);
                        }
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
            InventoryEntry[] availableEntries, InventoryEntry[] reservedEntries,
            Guid userId)
        {
            if (amount == 0)
            {
                foreach (var entry in availableEntries)
                    Move(recMan, null, entry, userId);
            }
            else
            {
                var availableWithinLocation = reservedEntries.Where(
                    rie => Array.Exists(availableEntries, aie => aie.WarehouseLocation == rie.WarehouseLocation));

                var otherAvailables = reservedEntries.Where(
                    rie => !Array.Exists(availableEntries, aie => aie.WarehouseLocation == rie.WarehouseLocation));

                amount = MoveInventory(recMan, amount, null, availableWithinLocation, userId);
                amount = MoveInventory(recMan, amount, null, otherAvailables, userId);

                if (amount != 0)
                    throw new DbException($"Could not unreserve all entries");
            }
        }

        private static void BuildErrorPage(Guid projectId, BaseErpPageModel pageModel,
            List<FormValues> formValues, Dictionary<Guid, SuperfluousInventoryArticle> superfluousArticleInfo)
        {
            var records = new List<EntityRecord>(formValues.Count);

            foreach (var (articleId, amount, _) in formValues)
            {
                var availableAmount = 0m;
                var relativeDemand = 0m;
                Article? article = null;

                if (superfluousArticleInfo.TryGetValue(articleId, out var sai))
                {
                    availableAmount = sai.AvailableAmount;
                    relativeDemand = sai.RelativeDemand;
                    article = sai.GetArticle();
                }

                var rec = new SuperfluousInventoryArticle()
                {
                    ArticleId = articleId,
                    SelectedAmount = amount,
                    AvailableAmount = availableAmount,
                    RelativeDemand = relativeDemand,
                };

                rec.SetArticle(article);
                records.Add(rec);
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
                var available = 0m;
                var relativeDemand = 0m;

                if (superfluousArticleLookup.TryGetValue(articleId, out var articleInfo))
                {
                    type = articleInfo.GetArticle().GetArticleType();
                    available = articleInfo.AvailableAmount;
                    relativeDemand = articleInfo.RelativeDemand;
                }

                foreach (var error in ValidateAmount(amount, available, relativeDemand, type, index))
                    yield return error;
            }
        }

        private static IEnumerable<ValidationError> ValidateAmount(decimal amount, decimal available, decimal relativeDemand, ArticleType? type, int index)
        {
            var field = $"amount[{index}]";
            var isInt = type?.IsInteger is true;
            var errors = new NumberFormatValidator("inventory_article", SuperfluousInventoryArticle.Fields.SelectedAmount, isInt, true)
                .Validate(amount, field);

            foreach (var error in errors)
                yield return error;

            if (amount > available)
                yield return new ValidationError(field, $"amount must not be greater than available amount ({available})");

            if (amount < relativeDemand)
                yield return new ValidationError(field, $"amount must not be smaller than relative demand ({relativeDemand})");
        }
    }
}
