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
    using UpdateInfo = (Guid ArticleId, decimal Amount, int Index);

    [HookAttachment(key: HookKeys.GoodsReceiving.Book)]
    class GoodsReceivingBookGoodsHook : TypedValidatedManageHook<Order>, IPageHook
    {
        public IActionResult? OnPost(BaseErpPageModel pageModel)
            => null;

        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            var record = pageModel.TryGetDataSourceProperty<EntityRecord>("Record")!;

            var key = $"${Order.Relations.Entries}";
            if (!record.Properties.TryGetValue(key, out var l) || l == null)
                record[key] = InitializedGoods.Execute((Guid)record["id"]);

            return null;
        }

        protected override IActionResult? OnPreUpdate(Order record, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var demandedEntries = InitializedGoods.Execute(record.Id!.Value)
                .Select(TypedEntityRecordWrapper.Wrap<OrderEntry>)
                .ToDictionary(oe => oe.Article, oe => oe);

            var updateInfos = GetUpdateInfo(pageModel)
                .ToArray();

            validationErrors.AddRange(Validate(demandedEntries, updateInfos));

            if (validationErrors.Count > 0)
            {
                SetUpErrorPage(record, pageModel, demandedEntries.Values, updateInfos);
                return null;
            }

            var goodsReceiving = new GoodsReceiving()
            {
                Id = Guid.NewGuid(),
                Order = record.Id.Value,
                TimeStamp = DateTime.Now,
            };

            var entries = updateInfos
                .Where(t => t.Amount > 0)
                .Select(t => new GoodsReceivingEntry()
                {
                    Amount = t.Amount,
                    Article = t.ArticleId,
                    StoredAmount = 0m,
                    GoodsReceiving = goodsReceiving.Id.Value
                });

            void TransactionalAction()
            {
                var repo = new GoodsReceivingRepository();

                if(repo.Insert(goodsReceiving) == null)
                    throw new DbException("Could not insert goods receiving record");

                foreach(var entry in entries)
                {
                    if(repo.InsertEntry(entry) == null)
                        throw new DbException("Could not insert goods receiving entry record");
                }
            }

            if (!Transactional.TryExecute(pageModel, TransactionalAction))
            {
                SetUpErrorPage(record, pageModel, demandedEntries.Values, updateInfos);
                return pageModel.Page();
            }

            var context = pageModel.ErpRequestContext;
            return pageModel.LocalRedirect($"/{context.App?.Name}/{context.SitemapArea?.Name}/" +
                $"goods-receiving/m/{goodsReceiving.Id}/store-goods?hookKey={HookKeys.GoodsReceiving.Store}");
        }

        private static void SetUpErrorPage(Order record, BaseErpPageModel pageModel, IEnumerable<OrderEntry> demandedEntries, UpdateInfo[] updateInfos)
        {
            foreach (var entry in demandedEntries.Where(e => Array.Exists(updateInfos, t => t.ArticleId == e.Article)))
                entry.Amount = Array.Find(updateInfos, t => t.ArticleId == entry.Article).Amount;

            record.SetEntries(demandedEntries.OrderBy(e => e.GetArticle().PartNumber));
            pageModel.DataModel.SetRecord(record);
        }

        private static IEnumerable<ValidationError> Validate(Dictionary<Guid, OrderEntry> demandedEntries, UpdateInfo[] updateInfos)
        {
            if (!Array.Exists(updateInfos, t => t.Amount > 0))
                yield return new ValidationError(string.Empty, "Something must be selected");

            foreach (var (articleId, amount, index) in updateInfos)
            {
                if (articleId == Guid.Empty)
                    yield return ArticleError(index, "Article must not be empty");

                else if (!demandedEntries.TryGetValue(articleId, out var orderEntry) && amount > 0)
                    yield return ArticleError(index, "There is no demand on this article");

                else
                {
                    if (amount > orderEntry!.Amount)
                        yield return AmountError(index, $"Amount must not be greater than ordered amount ({orderEntry.Amount})");

                    var isInt = orderEntry.GetArticle().GetArticleType().IsInteger;
                    if (isInt && amount % 1 != 0)
                        yield return AmountError(index, "Amount is expected to be an integer value");
                }
            }
        }

        private static ValidationError ArticleError(int index, string message)
            => new($"article_id[{index}]", message);

        private static ValidationError AmountError(int index, string message)
            => new($"amount[{index}]", message);

        private static IEnumerable<UpdateInfo> GetUpdateInfo(BaseErpPageModel pageModel)
        {
            var i = 0;
            while(pageModel.Request.Form.TryGetValue($"article_id[{i}]", out var articleIdVal))
            {
                var articleId = Guid.TryParse(articleIdVal, out var id) 
                    ? id : Guid.Empty;

                var amount = decimal.TryParse(pageModel.Request.Form[$"amount[{i}]"], out var d) 
                    ? d : 0m;

                yield return (articleId, amount, i);

                i++;
            }
        }
    }
}
