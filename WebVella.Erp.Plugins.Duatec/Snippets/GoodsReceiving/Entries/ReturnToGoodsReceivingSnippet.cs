using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.GoodsReceiving.Entries
{
    [Snippet]
    internal class ReturnToGoodsReceivingSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var listId = GetListId(pageModel);

            var context = pageModel.ErpRequestContext;
            return $"/{context?.App?.Name}/{context?.SitemapArea?.Name}/goods-receiving/r/{listId}";
        }

        private static Guid? GetListId(BaseErpPageModel pageModel)
        {
            Guid? id = null;
            if(Try.Get(() => pageModel.TryGetDataSourceProperty<EntityRecord>("Record")?[GoodsReceivingEntry.GoodsReceiving] as Guid?, out var recId))
                id = recId;

            id ??= pageModel.Request?.Query.TryGetValue("grId", out var idArg) == true && Guid.TryParse(idArg, out var listId) 
                ? listId : null;
            return id;
        }
    }
}
