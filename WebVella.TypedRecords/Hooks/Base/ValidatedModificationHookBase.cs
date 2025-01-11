using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Web.Models;

namespace WebVella.TypedRecords.Hooks.Base
{
    public abstract class ValidatedModificationHookBase<TRecord, TModel> 
        where TRecord : EntityRecord
        where TModel : BaseErpPageModel
    {
        protected abstract string ActionNameInPastTense { get; }

        protected abstract List<ValidationError> Validate(TRecord record, Entity? entity);

        protected IActionResult? Execute(TRecord record, Entity? entity, TModel pageModel, List<ValidationError> validationErrors)
        {
            var result = OnPreValidate(record, entity, pageModel);
            if (result != null)
                return result;

            validationErrors.AddRange(Validate(record, entity));

            if (validationErrors.Count > 0)
                return OnValidationFailure(record, entity, pageModel, validationErrors);
            return OnValidationSuccess(record, entity, pageModel, validationErrors);
        }

        protected virtual IActionResult? OnPreValidate(TRecord record, Entity? entity, TModel pageModel)
            => null;

        protected virtual IActionResult? OnValidationSuccess(TRecord record, Entity? entity, TModel pageModel, List<ValidationError> validationErrors)
        {
            var msg = SuccessMessage(record, entity, pageModel);

            pageModel.PutMessage(ScreenMessageType.Success, msg);
            return null;
        }

        protected virtual string SuccessMessage(TRecord record, Entity? entity, TModel pageModel)
            => entity == null ? "Success" : $"Successfully {ActionNameInPastTense} {entity.FancyName()}";

        protected virtual IActionResult? OnValidationFailure(TRecord record, Entity? entity, TModel pageModel, List<ValidationError> validationErrors)
            => null;
    }
}
