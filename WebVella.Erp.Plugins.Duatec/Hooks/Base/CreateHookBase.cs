using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Base
{
    internal abstract class CreateHookBase<T> : IRecordCreatePageHook where T : EntityRecord
    {
        protected abstract IRecordValidator<T> Validator { get; }

        protected abstract T WrapRecord(EntityRecord rec);

        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            var errors = Validator.ValidateOnCreate(WrapRecord(record));
            validationErrors.AddRange(errors);

            return null;
        }
    }
}
