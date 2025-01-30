using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.DataSource;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Hooks;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.GoodsReceivings
{
    using UpdateInfo = (Guid ArticleId, Guid WarehouseLocation, decimal Amount, int Index);

    [HookAttachment(key: HookKeys.GoodsReceiving.Store)]
    internal class GoodsReceivingStoreGoodsHook : TypedValidatedManageHook<GoodsReceiving>, IPageHook
    {
        public IActionResult? OnPost(BaseErpPageModel pageModel)
            => null;

        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            var record = pageModel.TryGetDataSourceProperty<EntityRecord>("Record")!;

            var key = $"${GoodsReceiving.Relations.Entries}";
            if (!record.Properties.TryGetValue(key, out var l) || l == null)
                record[key] = InitializedGoodsToStore.Execute((Guid)record["id"]);

            return null;
        }

        protected override IActionResult? OnPreUpdate(GoodsReceiving record, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var demandedEntries = InitializedGoodsToStore.Execute(record.Id!.Value)
                .Select(TypedEntityRecordWrapper.Wrap<GoodsReceivingEntry>)
                .ToDictionary(gre => gre.Article, gre => gre);

            var updateInfos = GetUpdateInfo(pageModel)
                .ToArray();

            validationErrors.AddRange(Validate(demandedEntries, updateInfos));

            if(validationErrors.Count > 0)
            {
                SetUpErrorPage(record, pageModel, demandedEntries, updateInfos);
                return null;
            }

            // TODO fix this shit
            var projectId = record.GetOrder().Project;

            var entries = updateInfos
                .Where(t => t.Amount > 0)
                .GroupBy(t => (t.ArticleId, t.WarehouseLocation))
                .Select(g => new InventoryEntry()
                {
                    Amount = g.Sum(t => t.Amount),
                    Article = g.Key.ArticleId,
                    WarehouseLocation = g.Key.WarehouseLocation,
                    Project = projectId,
                    Id = Guid.NewGuid()
                });

            void TransactionalAction()
            {
                var repo = new InventoryRepository();
                foreach(var entry in entries)
                {
                    if (repo.Insert(entry) == null)
                        throw new DbException("Could not insert inventory entry record");
                }
            }

            if(!Transactional.TryExecute(pageModel, TransactionalAction))
            {
                SetUpErrorPage(record, pageModel, demandedEntries, updateInfos);
                return pageModel.Page();
            }

            var context = pageModel.ErpRequestContext;
            return pageModel.LocalRedirect($"/{context.App?.Name}/{context.SitemapArea?.Name}/orders/l/orders");
        }

        private static IEnumerable<ValidationError> Validate(Dictionary<Guid, GoodsReceivingEntry> demandedEntries, UpdateInfo[] updateInfos)
        {
            if (!Array.Exists(updateInfos, t => t.Amount > 0))
                yield return new ValidationError(string.Empty, "Something must be selected");

            foreach (var (articleId, warehouseLocationId, amount, index) in updateInfos.Where(t => t.Amount > 0))
            {
                if (articleId == Guid.Empty)
                    yield return ArticleError(index, "Article is required");

                if (warehouseLocationId == Guid.Empty)
                    yield return WarehouseLocationError(index, "Warehouse location is required");

                var duplicates = updateInfos
                    .Where(t => t.Amount > 0 && t.ArticleId == articleId && t.Index != index);

                var totalAmount = duplicates.Aggregate(amount, (val, cur) => val + cur.Amount);

                if (!demandedEntries.TryGetValue(articleId, out var gre) && totalAmount > 0)
                    yield return ArticleError(index, "There is no goods receiving entry for this article");
                else
                {
                    if (totalAmount > gre!.Amount)
                        yield return AmountError(index, $"$Amount must not be greater than ordered amount ({gre.Amount})");

                    var isInt = gre.GetArticle().GetArticleType().IsInteger;
                    if (isInt && amount % 1 != 0)
                        yield return AmountError(index, "Amount is expected to be an integer value");
                }
            }
        }

        private static ValidationError ArticleError(int index, string message)
            => new($"article_id[{index}]", message);

        private static ValidationError WarehouseLocationError(int index, string message)
            => new($"warehouse_location_id[{index}]", message);

        private static ValidationError AmountError(int index, string message)
            => new($"amount[{index}]", message);

        private static void SetUpErrorPage(GoodsReceiving record, BaseErpPageModel pageModel, Dictionary<Guid, GoodsReceivingEntry> demandedEntries, UpdateInfo[] updateInfos)
        {
            var entries = updateInfos.Select(t => new GoodsReceivingEntry()
            {
                Id = Guid.NewGuid(),
                Amount = t.Amount,
                Article = t.ArticleId,
                GoodsReceiving = record.Id!.Value,
                StoredAmount = 0,
            }).ToList();

            foreach(var entry in entries)
            {
                if (demandedEntries.TryGetValue(entry.Article, out var gre) && gre?.GetArticle() is Article article)
                    entry.SetArticle(article);
            }

            record.SetEntries(entries.OrderBy(e => e.GetArticle().PartNumber));
            pageModel.DataModel.SetRecord(record);
        }

        private static IEnumerable<UpdateInfo> GetUpdateInfo(BaseErpPageModel pageModel)
        {
            var i = 0;
            while (pageModel.Request.Form.TryGetValue($"article_id[{i}]", out var articleIdVal))
            {
                var articleId = Guid.TryParse(articleIdVal, out var id)
                    ? id : Guid.Empty;

                var warehouseLocationId = Guid.TryParse(pageModel.Request.Form[$"warehouse_location_id[{i}]"], out var g)
                    ? g : Guid.Empty;

                var amount = decimal.TryParse(pageModel.Request.Form[$"amount[{i}]"], out var d)
                    ? d : 0m;

                yield return (articleId, warehouseLocationId, amount, i);

                i++;
            }
        }
    }
}
