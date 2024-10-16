using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validations;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks
{
    [HookAttachment("article_type_create")]
    internal class ArticleTypeCreateHook : IRecordCreatePageHook
    {

        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            const string labelField = "label";
            const string unitField = "unit";

            var label = pageModel.GetFormValue(labelField);
            var unit = pageModel.GetFormValue(unitField);

            ArticleTypeValidations.LabelIsValid(label, labelField, validationErrors);
            ArticleTypeValidations.UnitIsValid(unit, unitField, validationErrors);

            // TODO Redirect on page itself
            return null!;
        }
    }
}
