using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance;

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

            validationErrors.AddRange(_articleValidator.ValidateOnCreate(entry));
            if (validationErrors.Count > 0)
                return null;

            var shortName = entry.PartNumber;
            shortName = shortName[..shortName.IndexOf('.')];

            entry.Manufacturer = Repository.Company.FindByShortName(shortName)!.Id!.Value;
            return null;
        }
    }
}
