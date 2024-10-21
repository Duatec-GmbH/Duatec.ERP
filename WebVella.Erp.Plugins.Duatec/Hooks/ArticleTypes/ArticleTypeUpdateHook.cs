using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validations;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.ArticleTypes
{
    [HookAttachment(key: "article_type_update")]
    internal class ArticleTypeUpdateHook : IPageHook
    {
        const string labelField = "label";
        const string unitField = "unit";

        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            var rec = CreateRecord(pageModel);
            var idVal = pageModel.Request.Query["hId"];
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
            url = Url.RemoveParameter(url, "hId");

            return pageModel.LocalRedirect(url);
        }

        private static EntityRecord CreateRecord(BaseErpPageModel pageModel)
        {
            var label = pageModel.GetFormValue(labelField) ?? string.Empty;
            var unit = pageModel.GetFormValue(unitField) ?? string.Empty;

            var rec = new EntityRecord();
            rec[ArticleType.Label] = label;
            rec[ArticleType.Unit] = unit;

            return rec;
        }

        private static bool UpdateSucceeds(BaseErpPageModel pageModel, EntityRecord rec, StringValues idVal)
        {
            if (!Guid.TryParse(idVal, out var id))
            {
                pageModel.PutMessage(ScreenMessageType.Error, $"Invalid format at hook argument 'hId'");
                pageModel.DataModel.SetRecord(rec);
                return false;
            }
            rec["id"] = id;
            var success = UpdateValidationSucceeds(pageModel, rec)
                && TryUpdate(pageModel, rec);

            if(success)
                pageModel.PutMessage(ScreenMessageType.Success, $"Successfully updated article type '{rec[ArticleType.Label]}'");
            return success;
        }

        private static bool CreateSucceeds(BaseErpPageModel pageModel, EntityRecord rec)
        {
            var success = CreateValidationSucceeds(pageModel, rec)
                && TryCreate(pageModel, rec);

            if (success)
                pageModel.PutMessage(ScreenMessageType.Success, $"Successfully created article type '{rec[ArticleType.Label]}'");
            return success;
        }


        private static bool UpdateValidationSucceeds(BaseErpPageModel pageModel, EntityRecord rec)
        {
            var id = (Guid)rec["id"];
            var label = (string)rec[ArticleType.Label];
            var unit = (string)rec[ArticleType.Unit];

            pageModel.Validation.Errors ??= [];
            CommonValidations.NameIsValid(label, labelField, pageModel.Validation.Errors, "Article type label");
            ArticleTypeValidations.UnitIsValid(unit, unitField, pageModel.Validation.Errors);

            if(pageModel.Validation.Errors.Count == 0 && ArticleType.FindAll().Exists(t => (Guid)t["id"] != id
                && t[ArticleType.Label]?.ToString()?.Equals(label, StringComparison.OrdinalIgnoreCase) is true))
            {
                pageModel.Validation.Errors.Add(new ValidationError(labelField, $"Article type with label '{label}' already exists"));
                return false;
            }
            return pageModel.Validation.Errors.Count == 0;
        }

        private static bool CreateValidationSucceeds(BaseErpPageModel pageModel, EntityRecord rec)
        {
            var label = (string)rec[ArticleType.Label];
            var unit = (string)rec[ArticleType.Unit];

            pageModel.Validation.Errors ??= [];
            ArticleTypeValidations.LabelIsValid(label, labelField, pageModel.Validation.Errors);
            ArticleTypeValidations.UnitIsValid(unit, unitField, pageModel.Validation.Errors);

            return pageModel.Validation.Errors.Count == 0;
        }

        private static bool TryUpdate(BaseErpPageModel pageModel, EntityRecord rec)
        {
            var response = new RecordManager().UpdateRecord(ArticleType.Entity, rec);
            return HandleResponse(pageModel, response);
        }

        private static bool TryCreate(BaseErpPageModel pageModel, EntityRecord rec)
        {
            rec["id"] = Guid.NewGuid();
            var response = new RecordManager().CreateRecord(ArticleType.Entity, rec);
            var result = HandleResponse(pageModel, response);
            if (!result)
                rec["id"] = null;
            return result;
        }

        private static bool HandleResponse(BaseErpPageModel pageModel, QueryResponse response)
        {
            var errors = response.Errors.Select(e => e.Message).Append(response.Message);
            if (!response.Success)
                pageModel.PutMessage(ScreenMessageType.Error, string.Join(Environment.NewLine, errors));
            return response.Success;
        }
    }
}
