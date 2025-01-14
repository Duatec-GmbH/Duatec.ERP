﻿using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.TypedRecords.Hooks;

namespace WebVella.Erp.Plugins.Duatec.Hooks.PartLists.Entries
{
    [HookAttachment(key: HookKeys.PartList.Entry.Update)]
    internal class PartListEntryUpdateHook : TypedValidatedUpdateHook<PartListEntry>
    {
        protected override IActionResult? OnPostModification(PartListEntry record, Entity entity, RecordManagePageModel pageModel)
        {
            pageModel.PutMessage(ScreenMessageType.Success, SuccessMessage(entity));

            var context = pageModel.ErpRequestContext;
            var url = $"/{context.App?.Name}/{context.SitemapArea?.Name}/part-lists/r/{record.PartList}/detail";
            return pageModel.LocalRedirect(url);
        }

        protected override IActionResult? OnPreValidate(PartListEntry record, Entity entity, RecordManagePageModel pageModel)
        {
            var rec = RepositoryService.PartListRepository.FindEntry(pageModel.RecordId!.Value)!;
            record.PartList = rec.PartList;

            return null;
        }
    }
}
