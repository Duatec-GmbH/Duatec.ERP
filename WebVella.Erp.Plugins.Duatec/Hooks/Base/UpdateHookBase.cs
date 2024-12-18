using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Base
{
    internal abstract class UpdateHookBase<T> : IRecordManagePageHook where T : EntityRecord
    {
        protected abstract IRecordValidator<T> Validator { get; }

        protected abstract T WrapRecord(EntityRecord record);

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var errors = Validator.ValidateOnUpdate(WrapRecord(record));
            validationErrors.AddRange(errors);

            return null;
        }
    }
}
