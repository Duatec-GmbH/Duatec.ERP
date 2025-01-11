using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.TypedRecords.Hooks.Base;
using WebVella.TypedRecords.Validation;

namespace WebVella.TypedRecords.Hooks
{
    public class TypedValidatedUpdateHook<T> : ValidatedModificationHookBase<T, RecordManagePageModel>, IRecordManagePageHook
        where T : TypedEntityRecordWrapper, new()
    {
        protected override string ActionNameInPastTense => "updated";

        protected override List<ValidationError> Validate(T record, Entity? entity)
            => ValidationService.ValidateOnUpdate(record);

        public virtual IActionResult? OnPostManageRecord(T record, Entity entity, RecordManagePageModel pageModel)
            => null;

        public virtual IActionResult? OnPreManageRecord(T record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
            => Execute(record, entity, pageModel, validationErrors);

        IActionResult? IRecordManagePageHook.OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
            => OnPostManageRecord(TypedEntityRecordWrapper.Wrap<T>(record), entity, pageModel);

        IActionResult? IRecordManagePageHook.OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
            => OnPreManageRecord(TypedEntityRecordWrapper.Wrap<T>(record), entity, pageModel, validationErrors);
    }
}
