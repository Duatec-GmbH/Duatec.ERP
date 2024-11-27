using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.OrderLists;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.OrderLists.Entries
{
    [HookAttachment(key: HookKeys.OrderList.Entry.Update)]
    internal class OrderListEntryUpdateHook : IRecordManagePageHook
    {
        private static readonly OrderListEntryValidator _validator = new();

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
        {
            var url = $"{new ReturnToOrderListSnippet().Evaluate(pageModel)}";
            return pageModel.LocalRedirect(url);
        }

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var oldRec = OrderListEntry.Find((Guid)record["id"]);
            record[OrderListEntry.OrderList] = oldRec![OrderListEntry.OrderList];
            record[OrderListEntry.IsFromPartList] = oldRec![OrderListEntry.IsFromPartList];

            validationErrors.AddRange(_validator.ValidateOnUpdate(record));

            return null;
        }
    }
}
