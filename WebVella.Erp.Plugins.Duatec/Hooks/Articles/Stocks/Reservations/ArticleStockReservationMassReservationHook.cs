using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Stocks.Reservations
{
    using FormValues = (string PartNumber, decimal Amount, bool PerformReserve);


    [HookAttachment(key: HookKeys.Article.Stock.Reservations.MassReservation)]
    internal class ArticleStockReservationMassReservationHook : IRecordDetailsPageHook
    {
        public IActionResult? OnPost(RecordDetailsPageModel pageModel)
        {
            var partNumbers = pageModel.GetFormValues("part_number");
            var amounts = GetAmounts(pageModel);
            var autoReserve = GetReserveFlags(pageModel);

            if (partNumbers.Distinct().Count() != partNumbers.Length)
                return pageModel.BadRequest();

            if (!pageModel.RecordId.HasValue)
                return pageModel.BadRequest();

            if(partNumbers.Length != autoReserve.Length)
                return pageModel.BadRequest();

            if (partNumbers.Length != amounts.Length)
                return Error(pageModel, "Amount can not be empty");

            if (partNumbers.Length == 0 || amounts.All(d => d <= 0))
                return Info(pageModel, "Nothing to do here");

            if (amounts.Any(d => d < 0))
                return Error(pageModel, "Amount must be greater than or equal '0'");

            var projectId = pageModel.RecordId.Value;
            if (!RepositoryService.ProjectRepository.Exists(projectId))
                return pageModel.BadRequest();

            var formData = new List<FormValues>(partNumbers.Length);

            for (int i = 0; i < partNumbers.Length; i++)
            {
                var amount = amounts[i];
                if (amount > 0m)
                    formData.Add((partNumbers[i], amount, autoReserve[i]));
            }

            var transactionalAction = BuildAction(projectId, formData);

            if (Transactional.TryExecute(pageModel, transactionalAction))
                return Success(pageModel);

            return ReturnToProject(pageModel);
        }


        private static Action BuildAction(Guid projectId, List<FormValues> formData)
        {
            var partNumbersToProcess = formData
                .Select(v => v.PartNumber)
                .ToArray();

            const string select = $"*, " +
                $"${Article.Relations.Manufacturer}.{Company.Fields.Name}, " +
                $"${Article.Relations.Type}.*";

            var articleLookup = RepositoryService.ArticleRepository.FindMany(select, partNumbersToProcess);
            var reservationsLookup = RepositoryService.InventoryRepository
                .FindManyReservationEntriesByProjectAndArticle(projectId, partNumbersToProcess);

            var demandLookup = GetDemandLookup(projectId, articleLookup, reservationsLookup);
            var reservedInventoryLookup = GetInventoryLookup(projectId, articleLookup);
            var availableInventoryLookup = GetInventoryLookup(null, articleLookup);

            var list = RepositoryService.InventoryRepository.FindReservationListByProject(projectId);

            return () =>
            {
                list ??= CreateList(projectId);
                var listId = (Guid)list["id"];

                foreach (var (partNumber, amount, performReserve) in formData)
                {
                    var article = articleLookup[partNumber]
                        ?? throw new DbException($"Article with part number '{partNumber}' does not exist");

                    var type = GetArticleType(article)
                        ?? throw new DbException($"Article with part number '{partNumber}' is in invalid state");

                    Validate(amount, type);

                    var demand = demandLookup[partNumber];

                    if (demand <= 0m)
                        throw new DbException($"There is no demand on article '{partNumber}'");

                    if (amount > demand)
                        throw new DbException($"Amount can not be greater than demand");

                    var reservation = reservationsLookup[partNumber];

                    if (reservation == null)
                        CreateNewEntry(listId, (Guid)article["id"], amount);
                    else
                        IncreaseAmount(reservation, amount);

                    if (performReserve)
                    {
                        var availableInventory = availableInventoryLookup[partNumber];
                        var reservedInventory = reservedInventoryLookup[partNumber];

                        ReserveInventory(projectId, amount, availableInventory, reservedInventory);
                    }
                }
            };
        }


        private static void ReserveInventory(Guid projectId, decimal amount, InventoryEntry[] availableEntries, InventoryEntry[] reservedEntries)
        {
            var available = availableEntries.Aggregate(0m, (sum, entry) => sum + entry.Amount);
            if (amount == available)
                MoveAll(projectId, availableEntries);
            else
            {
                var availableWithinLocation = availableEntries
                    .Where(ae => reservedEntries.Any(re => re.WarehouseLocation == ae.WarehouseLocation));

                var current = Reserve(projectId, amount, 0m, availableWithinLocation);
                Reserve(projectId, amount, current, availableEntries);
            }
        }

        private static decimal Reserve(Guid projectId, decimal amount, decimal current, IEnumerable<InventoryEntry> availableEntries)
        {
            if (current >= amount)
                return current;

            IEnumerable<InventoryEntry> toMove = [];
            InventoryEntry? toSplit = null;

            foreach(var entry in availableEntries)
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

            MoveAll(projectId, toMove);
            if (toSplit != null)
            {
                MovePartial(projectId, toSplit, amount - current);
                current = 0;
            }
            return current;
        }

        private static void MoveAll(Guid projectId, IEnumerable<InventoryEntry> entries)
        {
            foreach (var entry in entries)
                Move(projectId, entry);
        }

        private static void Move(Guid projectId, InventoryEntry entry)
        {
            entry.Project = projectId;
            if (!RepositoryService.InventoryRepository.Update(entry))
                throw new DbException("Could not move inventory entry");
        }

        private static void MovePartial(Guid projectId, InventoryEntry entry, decimal amount)
        {
            entry.Project = projectId;
            entry.Amount = amount;
            if (!RepositoryService.InventoryRepository.MovePartial(entry).HasValue)
                throw new DbException("Could not partially move inventory entry");
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

        private static Dictionary<string, InventoryEntry[]> GetInventoryLookup(Guid? projectId, Dictionary<string, Article?> articleLookup)
        {
            var ids = articleLookup.Values
                .Where(a => a?.Id != null)
                .Select(a => a!.Id!.Value)
                .ToHashSet();

            var available = RepositoryService.InventoryRepository.FindManyByProject(projectId)
                .Where(i => ids.Contains(i.Article))
                .GroupBy(i => i.Article)
                .ToDictionary(g => g.Key, g => g.ToArray());

            var result = new Dictionary<string, InventoryEntry[]>(articleLookup.Count);

            foreach(var (key, value) in articleLookup)
            {
                if (value?.Id == null || !available.TryGetValue(value.Id.Value, out var entries))
                    result[key] = [];
                else
                    result[key] = entries;
            }

            return result;
        }

        private static Dictionary<string, decimal> GetDemandLookup(
            Guid projectId, 
            Dictionary<string, Article?> articleLookup, 
            Dictionary<string, InventoryReservationEntry?> reservationLookup)
        {
            var ids = articleLookup.Values
                .Where(a => a?.Id != null)!
                .Select(a => a!.Id!.Value)
                .ToHashSet();

            var totalDemands = RepositoryService.PartListRepository.FindManyEntriesByProject(projectId, true)
                .Where(e => ids.Contains(e.Article))
                .GroupBy(e => e.Article)
                .ToDictionary(g => g.Key, g => g.Sum(e => e.Amount));

            var result = new Dictionary<string, decimal>();

            foreach(var (key, value) in articleLookup)
            {
                if (value?.Id == null)
                    result[key] = 0m;
                else
                {
                    var alreadyReserved = reservationLookup.TryGetValue(key, out var entry) && entry != null 
                        ? entry.Amount : 0m;

                    var totalDemand = totalDemands.TryGetValue(value.Id.Value, out var total) 
                        ? total : 0m;

                    result[key] = Math.Max(0m, totalDemand - alreadyReserved);
                }
            }

            return result;
        }

        private static void Validate(decimal amount, ArticleType type)
        {
            var errors = new NumberFormatValidator(InventoryReservationEntry.Entity, InventoryReservationEntry.Fields.Amount, type.IsInteger, true)
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
            return TypedEntityRecordWrapper.Cast<ArticleType>(type);
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
            var id = pageModel.RecordId;
            var appName = pageModel.ErpRequestContext.App.Name;
            var area = pageModel.ErpRequestContext?.SitemapArea?.Name;

            return pageModel.LocalRedirect($"/{appName}/{area}/projects/r/{id}");
        }
    }
}
