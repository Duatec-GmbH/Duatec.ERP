using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validations;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Plugins.Duatec.Entities;

namespace WebVella.Erp.Plugins.Duatec.Hooks
{
    [HookAttachment(key: "article_create")]
    public class ArticleCreateHook : IRecordCreatePageHook
    {
        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            const string partNumberField = "part_number";
            var partNumber = pageModel.GetFormValue(partNumberField);

            if(!ArticleValidations.PartNumberFormatIsValid(partNumber, partNumberField, validationErrors))
                return null;

            if (!ArticleValidations.PartNumberIsNotTaken(partNumber, partNumberField, validationErrors))
                return null;

            var manufacturerShortName = ArticleValidations.ExtractManufacturerShortName(partNumber);
            if (!ManufacturerValidations.ManufacturerWithShortNameExists(manufacturerShortName, partNumberField, validationErrors))
                return null;

            var manufacturerId = Db.GetManufacturerIdByShortName(manufacturerShortName)!;
            record[Article.ManufacturerId] = manufacturerId.Value;

            return null;
        }
    }
}
