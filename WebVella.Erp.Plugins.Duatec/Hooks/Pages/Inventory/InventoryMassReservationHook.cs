using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.DataSource;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.TypedRecords.Hooks.Page;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Inventory
{
    using FormValues = (Guid ArticleId, decimal Amount, int Index);
    using ArticleInfo = (ArticleType Type, decimal AvailableAmount);

    [HookAttachment(key: HookKeys.Inventory.MassReservation)]
    internal class InventoryMassReservationHook : TypedValidatedManageHook<Project>, IPageHook
    {
        const string entryKey = "entries";

        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record") ?? new EntityRecord();
            if (!rec.Properties.ContainsKey(entryKey))
                rec[entryKey] = new List<EntityRecord>(AvailableInventoryEntries4Project.Execute((Guid)rec["id"]));

            pageModel.DataModel.SetRecord(rec);
            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
            => null;

        protected override IActionResult? OnPreUpdate(Project record, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var projectId = record.Id!.Value;
            var formData = GetFormData(pageModel);

            if(formData.Count == 0 || formData.TrueForAll(fv => fv.Amount == 0))
                return Info(pageModel, "Nothing to do here");

            var availableArticles = AvailableInventoryEntries4Project.Execute(projectId);
            var articleInfo = availableArticles
                .GroupBy(ie => ie.Article)
                .ToDictionary(g => g.Key, g => new ArticleInfo(
                    g.First().GetArticle().GetArticleType(),
                    g.Sum(ie => (decimal)ie[AvailableInventoryEntries4Project.FieldExtensions.AvailableAmount])));

            validationErrors.AddRange(Validate(formData, articleInfo));
            if(validationErrors.Count > 0)
            {

            }

            var transactionalAction = BuildAction(projectId, formData);

            if (Transactional.TryExecute(pageModel, transactionalAction))
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
            if (amount == available)
                MoveAll(recMan, projectId, availableEntries);
            else
            {
                var availableWithinLocation = availableEntries.Where(
                    ae => Array.Exists(reservedEntries, re => re.WarehouseLocation == ae.WarehouseLocation));

                var current = Reserve(recMan, projectId, amount, 0m, availableWithinLocation);
                Reserve(recMan, projectId, amount, current, availableEntries);
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

            MoveAll(recMan, projectId, toMove);
            if (toSplit != null)
            {
                MovePartial(recMan, projectId, toSplit, amount - current);
                current = 0;
            }
            return current;
        }

        private static void MoveAll(RecordManager recMan, Guid projectId, IEnumerable<InventoryEntry> entries)
        {
            foreach (var entry in entries)
                Move(recMan, projectId, entry);
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


        private static IEnumerable<ValidationError> Validate(List<FormValues> formData, Dictionary<Guid, ArticleInfo> articleInfos)
        {
            foreach(var (articleId, amount, index) in formData)
            {
                ArticleType? type = null;
                decimal available = 0m;

                if(articleInfos.TryGetValue(articleId, out var articleInfo))
                    (type, available) = articleInfo;

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
