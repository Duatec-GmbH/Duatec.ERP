using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Base
{
    public abstract class UpdateOnListHookBase<T> : IPageHook where T : TypedEntityRecordWrapper, new()
    {
        protected virtual string IdParameter => "hId";

        protected string EntityName => Text.FancyfySnakeCase(Entity);

        protected abstract string Entity { get; }

        protected abstract string LabelProperty { get; }

        protected abstract IRecordValidator<T> Validator { get; }

        protected abstract T CreateRecord(BaseErpPageModel pageModel);

        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            var rec = CreateRecord(pageModel);
            var idVal = pageModel.Request.Query[IdParameter];
            var isCreate = idVal == StringValues.Empty;

            var success = isCreate
                ? CreateSucceeds(pageModel, rec)
                : UpdateSucceeds(pageModel, rec, idVal);

            if (!success)
            {
                pageModel.DataModel.SetRecord(rec);
                return null;
            }

            var url = Url.RemoveParameter(pageModel.CurrentUrl, "hookKey");
            url = Url.RemoveParameter(url, IdParameter);

            return pageModel.LocalRedirect(url);
        }

        private bool UpdateSucceeds(BaseErpPageModel pageModel, T rec, StringValues idVal)
        {
            if (!Guid.TryParse(idVal, out var id))
            {
                pageModel.PutMessage(ScreenMessageType.Error, $"Invalid format at hook argument '{IdParameter}'");
                pageModel.DataModel.SetRecord(rec);
                return false;
            }
            rec["id"] = id;
            var success = RecordIsValidUpdate(pageModel, rec) && TryUpdate(pageModel, rec);

            if (success)
                pageModel.PutMessage(ScreenMessageType.Success, $"Successfully updated {EntityName} '{rec[LabelProperty]}'");
            return success;
        }

        private bool CreateSucceeds(BaseErpPageModel pageModel, T rec)
        {
            var success = RecordIsValidCreate(pageModel, rec) && TryCreate(pageModel, rec);

            if (success)
                pageModel.PutMessage(ScreenMessageType.Success, $"Successfully created {EntityName} '{rec[LabelProperty]}'");
            return success;
        }

        private bool TryCreate(BaseErpPageModel pageModel, T rec)
        {
            rec["id"] = Guid.NewGuid();
            var response = new RecordManager().CreateRecord(Entity, rec);
            var result = HandleResponse(pageModel, response);
            if (!result)
                rec["id"] = null;
            return result;
        }

        private bool RecordIsValidCreate(BaseErpPageModel pageModel, T rec)
        {
            pageModel.Validation.Errors ??= [];
            pageModel.Validation.Errors.AddRange(Validator.ValidateOnCreate(rec));
            return pageModel.Validation.Errors.Count == 0;
        }

        private bool RecordIsValidUpdate(BaseErpPageModel pageModel, T rec)
        {
            pageModel.Validation.Errors ??= [];
            pageModel.Validation.Errors.AddRange(Validator.ValidateOnUpdate(rec));
            return pageModel.Validation.Errors.Count == 0;
        } 

        private bool TryUpdate(BaseErpPageModel pageModel, T rec)
        {
            var response = new RecordManager().UpdateRecord(Entity, rec);
            return HandleResponse(pageModel, response);
        }

        private static bool HandleResponse(BaseErpPageModel pageModel, QueryResponse response)
        {
            if (!response.Success)
                pageModel.PutMessage(ScreenMessageType.Error, response.GetMessage());
            return response.Success;
        }
    }
}
