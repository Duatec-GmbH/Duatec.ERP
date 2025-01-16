﻿using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.TypedRecords.Hooks.Base;
using WebVella.Erp.TypedRecords.Validation;

namespace WebVella.Erp.TypedRecords.Hooks
{
    [HookAttachment(key: "validated-create")]
    internal class ValidatedCreateHook : ValidatedModificationHookBase<EntityRecord, RecordCreatePageModel>, IRecordCreatePageHook
    {
        protected override string ActionNameInPastTense => "created";

        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
            => OnPostModification(record, entity, pageModel);

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
            => Execute(record, entity, pageModel, validationErrors);

        protected override List<ValidationError> Validate(EntityRecord record, Entity entity)
            => ValidationService.ValidateOnCreate(record, entity!.Name);
    }
}