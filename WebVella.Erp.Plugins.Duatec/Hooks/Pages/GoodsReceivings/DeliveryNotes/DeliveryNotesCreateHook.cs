﻿using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.TypedRecords.Hooks.Page;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.GoodsReceivings.DeliveryNotes
{
    [HookAttachment(key: HookKeys.GoodsReceiving.DeliveryNotes.Create)]
    internal class DeliveryNotesCreateHook : TypedValidatedCreateHook<DeliveryNote>
    {
        private const string listArg = "grId";

        protected override IActionResult? OnPostCreate(DeliveryNote record, RecordCreatePageModel pageModel)
        {
            var listId = pageModel.Request.Query[listArg];

            var context = pageModel.ErpRequestContext;
            var url = $"/{context.App?.Name}/{context.SitemapArea?.Name}/goods-receiving/r/{listId}/detail";
            pageModel.PutMessage(ScreenMessageType.Success, SuccessMessage(record.EntityName));

            return pageModel.LocalRedirect(url);
        }

        protected override IActionResult? OnPreValidate(DeliveryNote record, RecordCreatePageModel pageModel)
        {
            if (!pageModel.Request.Query.TryGetValue(listArg, out var idVal) || !Guid.TryParse(idVal, out var listId))
                return pageModel.BadRequest();
            record.GoodsReceiving = listId;
            return null;
        }
    }
}
