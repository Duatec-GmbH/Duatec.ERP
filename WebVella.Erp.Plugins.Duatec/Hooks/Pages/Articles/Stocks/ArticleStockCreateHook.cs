using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Web.Utils;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Articles.Stocks
{
    [HookAttachment(key: HookKeys.Article.Stock.Create)]
    internal class ArticleStockCreateHook : TypedValidatedCreateHook<InventoryEntry>
    {
        protected override IActionResult? OnValidationSuccess(InventoryEntry record, RecordCreatePageModel pageModel)
        {
            var result = new InventoryRepository().Insert(record);

            if (result == null)
            {
                pageModel.PutMessage(ScreenMessageType.Error, "Could not create stock entry");
                return pageModel.LocalRedirect(Url.RemoveParameters(pageModel.CurrentUrl));
            }

            pageModel.PutMessage(ScreenMessageType.Success, SuccessMessage(record.EntityName));
            return pageModel.LocalRedirect(pageModel.EntityDetailUrl(result.Id!.Value));
        }
    }
}
