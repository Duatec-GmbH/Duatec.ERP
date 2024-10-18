using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validations;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Manufacturers
{
    [HookAttachment("manufacturer_create")]
    internal class ManufacturerCreateHook : IRecordCreatePageHook
    {
        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            const string nameField = "name";
            const string shortNameField = "short_name";

            var name = pageModel.GetFormValue(nameField);
            var shortName = pageModel.GetFormValue(shortNameField);

            ManufacturerValidations.ValidateShortName(shortName, shortNameField, validationErrors);
            ManufacturerValidations.ValidateName(name, nameField, validationErrors);

            return null;
        }
    }
}
