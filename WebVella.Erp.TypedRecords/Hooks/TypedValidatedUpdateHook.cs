using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.TypedRecords.Hooks.Base;
using WebVella.Erp.TypedRecords.Validation;

namespace WebVella.Erp.TypedRecords.Hooks
{
    public class TypedValidatedUpdateHook<T> : ValidatedModificationHookBase<T, RecordManagePageModel>, IRecordManagePageHook
        where T : TypedEntityRecordWrapper, new()
    {
        protected override string ActionNameInPastTense => "updated";

        protected override List<ValidationError> Validate(T record, Entity entity, RecordManagePageModel pageModel)
            => ValidationService.ValidateOnUpdate(record);

        public IActionResult? OnPostManageRecord(T record, Entity entity, RecordManagePageModel pageModel)
            => OnPostModification(record, entity, pageModel);

        public IActionResult? OnPreManageRecord(T record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
            => Execute(record, entity, pageModel, validationErrors);

        IActionResult? IRecordManagePageHook.OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
            => OnPostManageRecord(TypedEntityRecordWrapper.Wrap<T>(record), entity, pageModel);

        IActionResult? IRecordManagePageHook.OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
            => OnPreManageRecord(TypedEntityRecordWrapper.Wrap<T>(record), entity, pageModel, validationErrors);
    }
}
