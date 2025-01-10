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
    internal abstract class UpdateHookBase<T> : IRecordManagePageHook where T : TypedEntityRecordWrapper, new()
    {
        protected abstract IRecordValidator<T> Validator { get; }

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var rec = TypedEntityRecordWrapper.WrapElseDefault<T>(record)!;

            var errors = Validator.ValidateOnUpdate(rec);
            validationErrors.AddRange(errors);

            return null;
        }
    }
}
