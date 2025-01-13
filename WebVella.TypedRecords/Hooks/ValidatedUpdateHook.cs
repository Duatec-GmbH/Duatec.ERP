using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.TypedRecords.Hooks.Base;
using WebVella.TypedRecords.Validation;

namespace WebVella.TypedRecords.Hooks
{
    [HookAttachment(key: "validated-update")]
    internal class ValidatedUpdateHook : ValidatedModificationHookBase<EntityRecord, RecordManagePageModel>, IRecordManagePageHook
    {
        protected override string ActionNameInPastTense => "updated";

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
            => OnPostModification(record, entity, pageModel);

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
            => Execute(record, entity, pageModel, validationErrors);

        protected override List<ValidationError> Validate(EntityRecord record, Entity? entity)
            => ValidationService.ValidateOnUpdate(record, entity!.Name);
    }
}
