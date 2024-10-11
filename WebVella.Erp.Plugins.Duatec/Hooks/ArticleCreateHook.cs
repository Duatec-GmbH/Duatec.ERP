using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using static WebVella.Erp.Plugins.Duatec.DataModel.EntityInfo;

namespace WebVella.Erp.Plugins.Duatec.Hooks
{
    [HookAttachment(key: "article_create")]
    public class ArticleCreateHook : IRecordCreatePageHook
    {
        const string partNumberField = "part_number";

        public IActionResult OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
        {
            return null!;
        }

        public IActionResult OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            var partNumber = GetFormField(pageModel, partNumberField);
            if(!ValidatePartNumberFormat(partNumber, validationErrors))
                return null!;

            if (!ValidateArticleConflict(partNumber, validationErrors))
                return null!;

            if (!ValidateManufacturer(partNumber, validationErrors))
                return null!;

            var manufacturerShortName = GetManufacturerShortName(partNumber);
            var manufacturerId = Db.GetManufacturerIdByShortName(manufacturerShortName)!;

            record[Article.ManufacturerId] = manufacturerId.Value;

            return null!;
        }

        private static string GetManufacturerShortName(string partNumber) => partNumber[..partNumber.IndexOf('.')];

        private static bool ValidatePartNumberFormat(string partNumber, List<ValidationError> validationErrors)
        {
            if(partNumber.Length == 0)
            {
                validationErrors.Add(new ValidationError(partNumberField, "Part number must not be empty"));
                return false;
            }

            var result = true;
            if (partNumber.Any(char.IsWhiteSpace))
            {
                result = false;
                validationErrors.Add(new ValidationError(partNumberField, "Part number must not contain any white spaces"));
            }
            if(partNumber.Any(c => !CharIsAllowed(c)))
            {
                result = false;
                validationErrors.Add(new ValidationError(partNumberField, "Part number contains invalid characters"));
            }
            if (!partNumber.Contains('.'))
            {
                validationErrors.Add(new ValidationError(partNumberField, "Part number must contain '.'"));
                return false;
            }
            return result;
        }

        private static bool CharIsAllowed(char c)
        {
            return c >= '!' && c <= '~'; 
            // TODO maybe restrict this more
        }

        private static bool ValidateArticleConflict(string partNumber, List<ValidationError> validationErrors)
        {
            if (Db.GetArticleIdByPartNumber(partNumber) != null)
                validationErrors.Add(new ValidationError(partNumberField, $"Article with part number '{partNumber}' already exists"));
            else if (EplanDataPortal.GetArticleByPartNumber(partNumber) != null)
                validationErrors.Add(new ValidationError(partNumberField, $"Article with part number '{partNumber}' is an EPLAN article use EPLAN import instead"));
            else return true;

            return false;
        }

        private static bool ValidateManufacturer(string partNumber, List<ValidationError> validationErrors)
        {
            var manufacturerShortName = partNumber[..partNumber.IndexOf('.')];

            if(Db.GetManufacturerIdByShortName(manufacturerShortName) == null)
            {
                validationErrors.Add(new ValidationError(partNumberField, $"Manufacturer with short name '{manufacturerShortName}' does not exist"));
                return false;
            }

            return true;
        }

        private static string GetFormField(BaseErpPageModel pageModel, string id)
        {
            var form = pageModel.Request.Form;
            if (form.ContainsKey(id) && !string.IsNullOrWhiteSpace(form[id]))
                return form[id]!;
            return string.Empty;
        }
    }
}
