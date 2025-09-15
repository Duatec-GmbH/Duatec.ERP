using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.TypedRecords.Validation;
using WebVella.Erp.Web.Models;
using WebVella.Erp.TypedRecords.Util;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Web.Utils;
using System.Web;

namespace WebVella.Erp.TypedRecords.Hooks.Page
{
    public class TypedValidatedCreateHook<T> : IRecordCreatePageHook
        where T : TypedEntityRecordWrapper, new()
    {
        protected virtual string ActionNameInPastTense => "created";

        protected virtual string DetailPageName => "detail";

        IActionResult? IRecordCreatePageHook.OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
            => OnPostCreate(TypedEntityRecordWrapper.Wrap<T>(record), pageModel);

        IActionResult? IRecordCreatePageHook.OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
            => OnPreCreate(TypedEntityRecordWrapper.Wrap<T>(record), pageModel, validationErrors);

        protected virtual IActionResult? OnPreValidate(T record, RecordCreatePageModel pageModel)
            => null;

        protected virtual IActionResult? OnValidationFailure(T record, RecordCreatePageModel pageModel)
            => null;

        protected virtual IActionResult? OnValidationSuccess(T record, RecordCreatePageModel pageModel)
            => null;

        protected virtual List<ValidationError> Validate(T record, RecordCreatePageModel pageModel)
            => ValidationService.ValidateOnCreate(record);


        protected virtual IActionResult? OnPreCreate(T record, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            var result = OnPreValidate(record, pageModel);
            if (result != null)
                return result;

            validationErrors.AddRange(Validate(record, pageModel));

            if (validationErrors.Count > 0)
                return OnValidationFailure(record, pageModel);

            return OnValidationSuccess(record, pageModel);
        }

        protected virtual IActionResult? OnPostCreate(T record, RecordCreatePageModel pageModel)
        {
            var msg = SuccessMessage(record.EntityName);
            pageModel.PutMessage(ScreenMessageType.Success, msg);
            return pageModel.LocalRedirect(GetReturnUrl(pageModel, record.Id!.Value));
        }

        protected string SuccessMessage(string entity)
        {
            entity = EntityExtensions.FancyfySnakeCase(entity);
            return $"Successfully {ActionNameInPastTense} {entity}";
        }

        protected string GetReturnUrl(RecordCreatePageModel pageModel, Guid recordId)
        {
            var url = pageModel.EntityDetailUrl(recordId, DetailPageName);

            if (!string.IsNullOrEmpty(pageModel.ReturnUrl))
                url += $"?returnUrl={HttpUtility.UrlEncode(pageModel.ReturnUrl)}";

            return url;
        }
    }
}
