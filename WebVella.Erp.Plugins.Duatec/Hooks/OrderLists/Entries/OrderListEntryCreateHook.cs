using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.OrderLists.Entries
{
    [HookAttachment(key: HookKeys.OrderList.Entry.Create)]
    internal class OrderListEntryCreateHook : IRecordCreatePageHook
    {
        private static readonly OrderListEntryValidator _validator = new();

        const string listArg = "olId";

        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
        {
            var listId = Guid.Parse(pageModel.Request.Query[listArg]!);

            var url = Url.RemoveParameters(pageModel.CurrentUrl) + $"?{listArg}={listId}";
            pageModel.PutMessage(Web.Models.ScreenMessageType.Success, "Successfully created order list entry");

            return pageModel.LocalRedirect(url);
        }

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            if (!pageModel.Request.Query.TryGetValue(listArg, out var idVal) || !Guid.TryParse(idVal, out var listId))
                return pageModel.BadRequest();

            record[OrderListEntry.OrderList] = listId;
            record[OrderListEntry.Order] = null;
            record[OrderListEntry.IsFromPartList] = false;

            validationErrors.AddRange(_validator.ValidateOnCreate(record));
            return null;
        }
    }
}
