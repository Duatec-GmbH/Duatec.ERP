using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.TypedRecords.Hooks;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceivings.Entries
{
    [HookAttachment(key: HookKeys.GoodsReceiving.Entry.Create)]
    internal class GoodsReceivingEntryCreateHook : TypedValidatedCreateHook<GoodsReceivingEntry>
    {
        private const string listArg = "grId";

        protected override IActionResult? OnPostCreate(GoodsReceivingEntry record, RecordCreatePageModel pageModel)
        {
            base.OnPostCreate(record, pageModel);

            var listId = Guid.Parse(pageModel.Request.Query[listArg]!);
            var url = Url.RemoveParameters(pageModel.CurrentUrl) + $"?{listArg}={listId}";
            return pageModel.LocalRedirect(url);
        }

        protected override IActionResult? OnPreValidate(GoodsReceivingEntry record, RecordCreatePageModel pageModel)
        {
            if (!pageModel.Request.Query.TryGetValue(listArg, out var idVal) || !Guid.TryParse(idVal, out var listId))
                return pageModel.BadRequest();

            record.GoodsReceiving = listId;
            return null;
        }
    }
}
