using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using WebVella.TypedRecords.Validation;

namespace WebVella.TypedRecords.Hooks
{
    [HookAttachment(key: "validated-create")]
    public class ValidatedCreateHook : IRecordCreatePageHook
    {
        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
            => null;

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            var result = OnPreValidate(record, entity, pageModel);
            if (result != null)
                return result;
            var errors = ValidationService.ValidateOnCreate(record, entity.Name);
            validationErrors.AddRange(errors);

            if(validationErrors.Count > 0)
                return OnValidationFailure(record, entity, pageModel, validationErrors);
            return OnValidationSuccess(record, entity, pageModel);
        }

        protected virtual IActionResult? OnPreValidate(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
            => null;

        protected virtual IActionResult? OnValidationSuccess(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
        {
            pageModel.PutMessage(ScreenMessageType.Success, $"Successfully created {entity.FancyName()}");
            return null;
        }

        protected virtual IActionResult? OnValidationFailure(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
            => null;

    }
}
