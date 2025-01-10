﻿using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceivings.Entries
{
    [HookAttachment(key: HookKeys.GoodsReceiving.Entry.Create)]
    internal class GoodsReceivingEntryCreateHook : IRecordCreatePageHook
    {
        private const string listArg = "grId";
        private static readonly GoodsReceivingEntryValidator _validator = new();

        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
        {
            var listId = Guid.Parse(pageModel.Request.Query[listArg]!);

            var url = Url.RemoveParameters(pageModel.CurrentUrl) + $"?{listArg}={listId}";
            pageModel.PutMessage(Web.Models.ScreenMessageType.Success, "Successfully created goods receiving entry");

            return pageModel.LocalRedirect(url);
        }

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            if (!pageModel.Request.Query.TryGetValue(listArg, out var idVal) || !Guid.TryParse(idVal, out var listId))
                return pageModel.BadRequest();

            var rec = TypedEntityRecordWrapper.WrapElseDefault<GoodsReceivingEntry>(record);
            rec!.GoodsReceiving = listId;

            validationErrors.AddRange(_validator.ValidateOnCreate(rec));
            return null;
        }
    }
}
