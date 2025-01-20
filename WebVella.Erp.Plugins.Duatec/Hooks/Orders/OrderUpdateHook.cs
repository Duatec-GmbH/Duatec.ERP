using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Orders
{
    [HookAttachment(HookKeys.Order.Update)]
    internal class OrderUpdateHook : TypedValidatedUpdateHook<Order>
    {
        protected override List<ValidationError> Validate(Order record, Entity entity, RecordManagePageModel pageModel)
        {
            var result = base.Validate(record, entity, pageModel);

            var articles = pageModel.GetFormValues("article_id");
            var amounts = pageModel.GetFormValues("amount");

            result.Add(new ValidationError(string.Empty, "Test error"));

            if (articles.Length != amounts.Length)
                throw new InvalidDataException("Articles and amounts are inequally long");

            return result;
        }

        protected override IActionResult? OnValidationSuccess(Order record, Entity entity, RecordManagePageModel pageModel)
        {
            // TODO make update manual here

            return base.OnValidationSuccess(record, entity, pageModel);
        }
    }
}
