using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Hooks.Page;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.GoodsReceivings
{
    using UpdateInfo = (Guid? ProjectId, Guid ArticleId, Guid WarehouseLocationId, decimal Amount, int Index);

    [HookAttachment(key: HookKeys.GoodsReceiving.Store)]
    internal class GoodsReceivingStoreGoodsHook : TypedValidatedManageHook<GoodsReceiving>, IPageHook
    {
        const string entryKey = $"${GoodsReceiving.Relations.Entries}";

        public IActionResult? OnPost(BaseErpPageModel pageModel)
            => null;

        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            var record = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
            
            if (!record.Properties.TryGetValue(entryKey, out var l) || l == null)
            {
                var gr = TypedEntityRecordWrapper.Wrap<GoodsReceiving>(record);

                var records = GetDefaultEntries(gr)
                    .Select(ie => (EntityRecord)ie)
                    .ToList();

                gr[entryKey] = records;

                pageModel.DataModel.SetRecord(gr);
            }

            return null;
        }

        protected override IActionResult? OnPreUpdate(GoodsReceiving record, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var recMan = new RecordManager();
            var goodsReceivingRepo = new GoodsReceivingRepository(recMan);

            record = goodsReceivingRepo.Find(pageModel.RecordId!.Value, $"*, ${GoodsReceiving.Relations.Order}.*")!;

            var projectId = record.GetOrder().Project;
            var userId = pageModel.CurrentUser.Id;

            var defaultEntries = GetDefaultEntries(record, recMan)
                .GroupBy(ie => ie.Article)
                .ToDictionary(g => g.Key, g => g.ToArray());

            var updateInfos = GetUpdateInfo(pageModel)
                .ToArray();

            if (defaultEntries.Keys.Except(updateInfos.Select(ui => ui.ArticleId).Distinct()).Any())
                return pageModel.BadRequest();

            validationErrors.AddRange(Validate(updateInfos, defaultEntries));

            if(validationErrors.Count > 0)
            {
                SetUpErrorPage(record, pageModel, defaultEntries, updateInfos);
                return null;
            }

            void TransactionalAction()
            {
                var inventoryRepo = new InventoryRepository(recMan);
                var entries = BuildInventoryEntries(updateInfos)
                    .ToArray();

                var timestamp = DateTime.Now;
                var bookings = entries.Select(e => new InventoryBooking()
                {
                    Amount = e.Amount,
                    ArticleId = e.Article,
                    Kind = InventoryBookingKind.Store,
                    ProjectId = projectId,
                    ProjectSourceId = projectId,
                    WarehouseLocationId = e.WarehouseLocation,
                    WarehouseLocationSourceId = e.WarehouseLocation,
                    Timestamp = timestamp,
                    UserId = userId,
                    Comment = "Goods Receiving Store"

                }).ToArray(); // must be collected, otherwhise amounts will be updated

                record.HasBeenStored = true;
                if (goodsReceivingRepo.Update(record) == null)
                    throw new DbException("Could not update record");

                if (inventoryRepo.InsertMany(entries).Count != entries.Length)
                    throw new DbException("Could not create inventory entries");

                if (inventoryRepo.InsertManyBookings(bookings).Count != entries.Length)
                    throw new DbException("Could not insert bookings");
            }

            if(!Transactional.TryExecute(pageModel, TransactionalAction))
            {
                SetUpErrorPage(record, pageModel, defaultEntries, updateInfos);
                return pageModel.Page();
            }

            pageModel.PutMessage(ScreenMessageType.Success, "Successfully stored goods");
            var context = pageModel.ErpRequestContext;

            if (!string.IsNullOrEmpty(pageModel.ReturnUrl))
                return pageModel.LocalRedirect(pageModel.ReturnUrl);

            return pageModel.LocalRedirect($"/{context.App?.Name}/{context.SitemapArea?.Name}/open-orders/r/{record.Order}/detail");
        }


        private static IEnumerable<InventoryEntry> GetDefaultEntries(GoodsReceiving record, RecordManager? recMan = null)
        {
            if (record.HasBeenStored)
                yield break;

            recMan ??= new RecordManager();
            var inventoryRepo = new InventoryRepository(recMan);
            var receivingRepo = new GoodsReceivingRepository(recMan);
            var articleRepo = new ArticleRepository(recMan);

            const string entrySelect = "*, " +
                $"${GoodsReceivingEntry.Relations.Article}.*";

            var unstoredEntries = receivingRepo.FindManyEntriesByGoodsReceiving(record.Id!.Value, entrySelect);

            var articleIds = unstoredEntries
                .Select(e => e.Article)
                .Distinct()
                .ToArray();

            const string articleSelect = "*, " +
                $"${Article.Relations.Type}.*, " +
                $"${Article.Relations.Manufacturer}.name";

            var articleLookup = articleRepo.FindMany(articleSelect, articleIds);
            var projectId = record.GetOrder().Project;

            foreach (var entry in unstoredEntries)
            {
                var inventoryEntry = new InventoryEntry()
                {
                    Id = Guid.NewGuid(),
                    Amount = entry.Amount,
                    Article = entry.Article,
                    Project = projectId,
                };

                inventoryEntry.SetArticle(articleLookup[entry.Article]);
                inventoryEntry.WarehouseLocation
                    = SmartWarehouseLocationSelection(inventoryRepo, entry.Article, projectId);

                yield return inventoryEntry;
            }
        }

        private static Guid SmartWarehouseLocationSelection(InventoryRepository repo, Guid articleId, Guid? projectid)
        {
            return repo.FindManyByArticleAndProject(articleId, projectid)
                .FirstOrDefault()?.WarehouseLocation ?? Guid.Empty;
        }

        private static IEnumerable<InventoryEntry> BuildInventoryEntries(UpdateInfo[] updateInfos)
        {
            return updateInfos.Where(t => t.Amount > 0)
                .Select(t => new InventoryEntry()
                {
                    Project = t.ProjectId,
                    Article = t.ArticleId,
                    WarehouseLocation = t.WarehouseLocationId,
                    Amount = t.Amount,
                });
        }

        private static IEnumerable<ValidationError> Validate(UpdateInfo[] updateInfos, Dictionary<Guid, InventoryEntry[]> defaultLookup)
        {
            var projectSetPoint = defaultLookup
                .First().Value[0].Project;

            foreach (var (projectId, articleId, warehouseLocationId, amount, index) in updateInfos)
            {
                if (warehouseLocationId == Guid.Empty)
                    yield return WarehouseLocationError(index, "Warehouse location is required");

                if (projectId != Guid.Empty && projectId != null && projectId != projectSetPoint)
                    yield return ProjectError(index, "Fatal error project id missmatch");

                if (amount <= 0)
                    yield return AmountError(index, "Positive value expected");

                if (articleId == Guid.Empty)
                    yield return ArticleError(index, "Article is required");

                else if (!defaultLookup.TryGetValue(articleId, out var entries) || entries.Length == 0)
                    yield return ArticleError(index, "Article is not defined in goodsreceiving");

                else
                {
                    var isInt = entries[0].GetArticle().GetArticleType().IsInteger;
                    if (isInt && amount % 1 != 0)
                        yield return AmountError(index, "Amount is expected to be an integer value");
                    else
                    {
                        var equivalentArticles = updateInfos
                            .Where(t => t.ArticleId == articleId)
                            .ToArray();

                        var totalAmount = equivalentArticles
                            .Aggregate(0m, (sum, current) => sum + current.Amount);

                        var max = entries.Sum(t => t.Amount);

                        if (totalAmount != max)
                            yield return AmountError(index, $"Sum of amounts for given article must be equal to booked amount ({max})");
                    }
                }
            }
        }

        private static ValidationError ArticleError(int index, string message)
            => new($"article_id[{index}]", message);

        private static ValidationError WarehouseLocationError(int index, string message)
            => new($"warehouse_location_id[{index}]", message);

        private static ValidationError AmountError(int index, string message)
            => new($"amount[{index}]", message);

        private static ValidationError ProjectError(int index, string message)
            => new($"project_id[{index}]", message);

        private static void SetUpErrorPage(
            GoodsReceiving record,  BaseErpPageModel pageModel, 
            Dictionary<Guid, InventoryEntry[]> bookedEntries, UpdateInfo[] updateInfos)
        {
            var entries = updateInfos.Select(t => new InventoryEntry()
            {
                Id = Guid.NewGuid(),
                Article = t.ArticleId,
                Project = t.ProjectId,
                WarehouseLocation = t.WarehouseLocationId,
                Amount = t.Amount,

            }).ToList();

            foreach(var entry in entries)
            {
                if (bookedEntries.TryGetValue(entry.Article, out var gre))
                    entry.SetArticle(gre[0].GetArticle());
            }

            record[entryKey] = entries
                .Select(ie => (EntityRecord)ie)
                .ToList();

            pageModel.DataModel.SetRecord(record);
            pageModel.BeforeRender();
        }

        private static IEnumerable<UpdateInfo> GetUpdateInfo(BaseErpPageModel pageModel)
        {
            var i = 0;
            var form = pageModel.Request.Form;
            while (form.TryGetValue($"article_id[{i}]", out var articleIdVal))
            {
                var articleId = Guid.TryParse(articleIdVal, out var id)
                    ? id : Guid.Empty;

                Guid? projectId = Guid.TryParse(form[$"project_id[{i}]"], out id) && id != Guid.Empty
                    ? id : null;

                var warehouseLocationId = Guid.TryParse(form[$"warehouse_location_id[{i}]"], out id)
                    ? id : Guid.Empty;

                var amount = decimal.TryParse(form[$"amount[{i}]"], out var d)
                    ? d : 0m;

                yield return (projectId, articleId, warehouseLocationId, amount, i);

                i++;
            }
        }
    }
}
