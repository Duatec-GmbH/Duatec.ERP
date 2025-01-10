using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Stocks
{
    [HookAttachment(key: HookKeys.Article.Stock.Create)]
    internal class ArticleStockCreateHook : IRecordCreatePageHook
    {
        private static readonly InventoryEntryValidator _validator = new();

        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
            => null;

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            var rec = TypedEntityRecordWrapper.Wrap<InventoryEntry>(record);

            var errors = _validator.ValidateOnCreate(rec);
            validationErrors.AddRange(errors);

            if (errors.Count > 0)
                return null;

            if(RepositoryService.InventoryRepository.Insert(rec) is not Guid id)
            {
                validationErrors.Add(new ValidationError(string.Empty, "Could not create inventory entry"));
                return null;
            }

            return pageModel.LocalRedirect(pageModel.EntityDetailUrl(id));
        }
    }
}
