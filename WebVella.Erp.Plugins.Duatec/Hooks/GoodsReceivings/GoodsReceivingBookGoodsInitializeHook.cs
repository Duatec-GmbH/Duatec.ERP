using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.DataSource;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceivings
{
    using UpdateInfo = (Guid ArticleId, decimal Amount);

    [HookAttachment(key: HookKeys.GoodsReceiving.Initialize)]
    class GoodsReceivingBookGoodsInitializeHook : IPageHook
    {
        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            if(!TryGetId(pageModel, out var id))
                return pageModel.BadRequest();

            var record = new OrderRepository().Find(id);
            if (record == null)
                return pageModel.BadRequest();

            var entries = GetDemandedEntries(id);

            record.SetEntries(entries);
            var entity = new EntityManager().ReadEntity(Order.Entity).Object
                ?? throw new InvalidOperationException($"entity '{Order.Entity}' not found");

            pageModel.DataModel.SetEntity(entity);
            pageModel.DataModel.SetRecord(record);

            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            if (!TryGetId(pageModel, out var id))
                return pageModel.BadRequest();

            var entries = GetDemandedEntries(id)
                .ToDictionary(oe => oe.Article, oe => oe);

            foreach(var (articleId, amount) in GetUpdateInfo(pageModel))
            {
                // TODO
            }

            return pageModel.Page();
        }

        private static IEnumerable<UpdateInfo> GetUpdateInfo(BaseErpPageModel pageModel)
        {
            // TODO
            yield break;
        }


        private static bool TryGetId(BaseErpPageModel pageModel, out Guid id)
        {
            if(!pageModel.Request.Query.TryGetValue("oId", out var idString))
            {
                id = Guid.Empty;
                return false;
            }

            if (!Guid.TryParse(idString, out id) || id == Guid.Empty)
                return false;

            return true;
        }

        private static IEnumerable<OrderEntry> GetDemandedEntries(Guid id)
        {
            var dataSource = new InitializedGoods();
            var args = dataSource.GetDefaultArgs();

            args[InitializedGoods.Arguments.Order] = id;
            args[InitializedGoods.Arguments.PageSize] = int.MaxValue;

            var records = dataSource.Execute(args) as List<EntityRecord>
                ?? throw new InvalidCastException($"datasource '{dataSource.Name}' does not return List<EntityRecord>");

            return records.Select(TypedEntityRecordWrapper.Wrap<OrderEntry>);
        }
    }
}
