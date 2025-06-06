﻿using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Web.Models;
using WebVella.Erp.TypedRecords.Util;

namespace WebVella.Erp.TypedRecords.Hooks.Page.Base
{
    public abstract class ValidatedModificationHookBase<TRecord, TModel>
        where TRecord : EntityRecord
        where TModel : BaseErpPageModel
    {
        protected abstract string ActionNameInPastTense { get; }

        protected abstract List<ValidationError> Validate(TRecord record, Entity entity, TModel pageModel);

        protected virtual IActionResult? Execute(TRecord record, Entity entity, TModel pageModel, List<ValidationError> validationErrors)
        {
            var result = OnPreValidate(record, entity, pageModel);
            if (result != null)
                return result;

            validationErrors.AddRange(Validate(record, entity, pageModel));

            if (validationErrors.Count > 0)
                return OnValidationFailure(record, entity, pageModel, validationErrors);

            return OnValidationSuccess(record, entity, pageModel);
        }

        protected virtual IActionResult? OnPreValidate(TRecord record, Entity entity, TModel pageModel)
            => null;

        protected virtual IActionResult? OnPostModification(TRecord record, Entity entity, TModel pageModel)
        {
            var msg = SuccessMessage(entity);
            pageModel.PutMessage(ScreenMessageType.Success, msg);
            return null;
        }

        protected virtual IActionResult? OnValidationFailure(TRecord record, Entity entity, TModel pageModel, List<ValidationError> validationErrors)
            => null;

        protected virtual IActionResult? OnValidationSuccess(TRecord record, Entity entity, TModel pageModel)
            => null;


        protected string SuccessMessage(Entity entity)
            => $"Successfully {ActionNameInPastTense} {entity.FancyName()}";
    }
}
