using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.TypedRecords.Hooks.Base;
using WebVella.TypedRecords.Validation;

namespace WebVella.TypedRecords.Hooks
{
    public class TypedValidatedCreateHook<T> : ValidatedModificationHookBase<T, RecordCreatePageModel>, IRecordCreatePageHook
        where T : TypedEntityRecordWrapper, new()
    {
        protected override string ActionNameInPastTense => "created";

        protected override List<ValidationError> Validate(T record, Entity entity)
            => ValidationService.ValidateOnCreate(record);

        public virtual IActionResult? OnPostCreateRecord(T record, Entity entity, RecordCreatePageModel pageModel)
            => OnPostModification(record, entity, pageModel);

        public IActionResult? OnPreCreateRecord(T record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
            => Execute(record, entity, pageModel, validationErrors);

        IActionResult? IRecordCreatePageHook.OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
            => OnPostCreateRecord(TypedEntityRecordWrapper.Wrap<T>(record), entity, pageModel);

        IActionResult? IRecordCreatePageHook.OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
            => OnPreCreateRecord(TypedEntityRecordWrapper.Wrap<T>(record), entity, pageModel, validationErrors);
    }
}
