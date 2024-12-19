using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.OrderLists;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Stocks.Reservations
{
    [HookAttachment(key: HookKeys.Article.Stock.Reservations.MassReservation)]
    internal class ArticleStockReservationMassReservationHook : IRecordDetailsPageHook
    {
        public IActionResult? OnPost(RecordDetailsPageModel pageModel)
        {
            var partNumbers = pageModel.GetFormValues("part_number");
            var amounts = GetAmounts(pageModel);
            var autoReserve = GetReserveFlags(pageModel);

            if (partNumbers.Length != amounts.Length || partNumbers.Length != autoReserve.Length)
                return Error(pageModel, "Amount can not be empty");

            if (partNumbers.Length == 0 || amounts.All(d => d <= 0))
                return Info(pageModel, "Nothing to do here");

            if (amounts.Any(d => d <= 0))
                return Error(pageModel, "Amount must be greater than or equal '0'");

            if (partNumbers.Distinct().Count() != partNumbers.Length)
                return pageModel.BadRequest();

            if (!pageModel.RecordId.HasValue)
                return pageModel.BadRequest();

            var projectId = pageModel.RecordId.Value;
            if (!Repository.Project.Exists(projectId))
                return pageModel.BadRequest();

            var data = new List<(string PartNumber, decimal Amount, bool PerformReserve)>(partNumbers.Length);

            for (int i = 0; i < partNumbers.Length; i++)
            {
                var amount = amounts[i];
                if (amount > 0m)
                    data.Add((partNumbers[i], amount, autoReserve[i]));
            }

            var partNumbersToProcess = data
                .Select(v => v.PartNumber)
                .ToArray();

            var articleLookup = Repository.Article.FindManyWithTypes(partNumbersToProcess);
            var demandLookup = GetDemandLookup(projectId, articleLookup);
            var inventoryLookup = GetInventoryLookup(projectId, articleLookup);
            var reservationsLookup = Repository.Inventory.FindManyReservationEntriesByProjectAndArticle(projectId, partNumbersToProcess);

            var list = Repository.Inventory.FindReservationListByProject(projectId);

            void TransactionalAction()
            {
                list ??= CreateList(projectId);
                var listId = (Guid)list["id"];

                foreach(var (partNumber, amount, performReserve) in data)
                {
                    var article = articleLookup[partNumber]
                        ?? throw new DbException($"Article with part number '{partNumber}' does not exist");

                    var type = GetArticleType(article)
                        ?? throw new DbException($"Article with part number '{partNumber}' is in invalid state");

                    Validate(amount, type);

                    if (!demandLookup.TryGetValue(partNumber, out var demand))
                        throw new DbException($"There is no demand on article '{partNumber}'");

                    if (amount > demand)
                        throw new DbException($"Amount can not be greater than demand");

                    var available = !inventoryLookup.TryGetValue(partNumber, out var inventoryEntries)
                        ? 0m
                        : inventoryEntries.Aggregate(0m, (sum, r) => sum += r.Amount);

                    if(amount > available)
                        throw new DbException($"Amount can not be greater than available amount");

                    var reservation = reservationsLookup[partNumber];

                    if (reservation == null)
                        CreateNewEntry(listId, (Guid)article["id"], amount);
                    else
                        IncreaseAmount(reservation, amount);

                    if (!performReserve)
                        continue;

                    // TODO

                }
            }

            if (Transactional.TryExecute(pageModel, TransactionalAction))
                return Success(pageModel);

            return ReturnToProject(pageModel);
        }

        private static InventoryReservationList CreateList(Guid projectId)
        {
            var list = new InventoryReservationList
            {
                Id = Guid.NewGuid(),
                Project = projectId
            };

            return Create(InventoryReservationList.Entity, list);
        }

        private static InventoryReservationEntry CreateNewEntry(Guid listId, Guid articleId, decimal amount)
        {
            var rec = new InventoryReservationEntry()
            {
                Id = Guid.NewGuid(),
                InventoryReservationList = listId,
                Article = articleId,
                Amount = amount
            };
            return Create(InventoryReservationEntry.Entity, rec);
        }

        private static InventoryReservationEntry IncreaseAmount(InventoryReservationEntry rec, decimal amount)
        {
            rec.Amount += amount;
            return Create(InventoryReservationEntry.Entity, rec);
        }

        private static T Create<T>(string entity, T rec) where T : EntityRecord
        {
            var recMan = new RecordManager();
            var response = recMan.CreateRecord(entity, rec);

            if (!response.Success)
                throw new DbException("Could not create record");
            return rec;
        }

        private static Dictionary<string, InventoryEntry[]> GetInventoryLookup(Guid projectId, Dictionary<string, Article?> articleLookup)
        {
            var ids = articleLookup.Values
                .Where(a => a != null)!
                .ToIdArray();

            // TODO
            return null!;
        }

        private static Dictionary<string, decimal> GetDemandLookup(Guid projectId, Dictionary<string, Article?> articleLookup)
        {
            var ids = articleLookup.Values
                .Where(a => a != null)!
                .ToIdArray();

            // TODO
            return null!;
        }

        private static void Validate(decimal amount, ArticleType type)
        {
            var isInt = type.IsInteger;
            var errors = new NumberFormatValidator(InventoryReservationEntry.Entity, InventoryReservationEntry.Fields.Amount, isInt, true)
                .Validate(amount, string.Empty);

            if (errors.Count > 0)
                throw new DbException(string.Join(Environment.NewLine, errors.Select(e => e.Message)));
        }

        private static decimal[] GetAmounts(BaseErpPageModel pageModel)
        {
            return pageModel.GetFormValues("amount")
                .Select(decimal.Parse)
                .ToArray();
        }

        private static bool[] GetReserveFlags(BaseErpPageModel pageModel)
        {
            return pageModel.GetFormValues("auto_reserve")
                .Select(bool.Parse)
                .ToArray();
        }

        private static ArticleType? GetArticleType(Article rec)
        {
            var type = (rec[$"${Article.Relations.Type}"] as List<EntityRecord>)?.FirstOrDefault();
            return type == null ? null : new ArticleType(type);
        }


        private static LocalRedirectResult Error(BaseErpPageModel pageModel, string message)
        {
            pageModel.PutMessage(ScreenMessageType.Error, message);
            return ReturnToProject(pageModel);
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
            var url = new BackToProjectSnippet().Evaluate(pageModel) as string ?? string.Empty;
            return pageModel.LocalRedirect(url);
        }
    }
}
