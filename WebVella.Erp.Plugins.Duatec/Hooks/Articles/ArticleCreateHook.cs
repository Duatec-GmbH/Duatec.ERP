using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles
{
    [HookAttachment(key: HookKeys.Article.Create)]
    public class ArticleCreateHook : IRecordCreatePageHook
    {
        private static readonly ArticleValidator _articleValidator = new();

        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            var entry = new Article(record);

            var errors = _articleValidator.ValidateOnCreate(entry);
            validationErrors.AddRange(errors);

            if (errors.Count > 0)
                return null;

            var shortName = entry.PartNumber;
            shortName = shortName[..shortName.IndexOf('.')];

            var manufacturerId = Manufacturer.FindId(shortName)!.Value;
            entry.Manufacturer = manufacturerId;

            return null;
        }
    }
}
