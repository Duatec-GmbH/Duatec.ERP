using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Stocks.Reservations
{
    [HookAttachment(key: HookKeys.Article.Stock.Reservations.MassReservation)]
    internal class ArticleStockReservationMassReservationHook : IRecordDetailsPageHook
    {
        public IActionResult? OnPost(RecordDetailsPageModel pageModel)
        {
            var partNumbers = pageModel.GetFormValues("part_number");
            var amounts = pageModel.GetFormValues("amount");
            var autoReserve = pageModel.GetFormValues("auto_reserve");

            if (partNumbers.Length != amounts.Length || partNumbers.Length != autoReserve.Length)
                return pageModel.BadRequest();

            return null;
        }
    }
}
