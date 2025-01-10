using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.TypedRecords;
using WebVella.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Base
{
    [Obsolete]
    internal abstract class CreateHookBase<T> : IRecordCreatePageHook where T : TypedEntityRecordWrapper, new()
    {
        protected abstract IRecordValidator<T> Validator { get; }

        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            var rec = TypedEntityRecordWrapper.WrapElseDefault<T>(record)!;
            var errors = Validator.ValidateOnCreate(rec);
            validationErrors.AddRange(errors);

            return null;
        }
    }
}
