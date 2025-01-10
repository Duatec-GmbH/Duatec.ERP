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
    [HookAttachment(key: HookKeys.Article.Stock.Update)]
    internal class ArticleStockUpdateHook : IRecordManagePageHook
    {
        private static readonly InventoryEntryValidator _validator = new();

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var modified = TypedEntityRecordWrapper.WrapElseDefault<InventoryEntry>(record)!;
            var unmodified = RepositoryService.InventoryRepository.Find(modified.Id!.Value)!;

            modified.Article = unmodified.Article;
            modified.Project = unmodified.Project;
            modified.WarehouseLocation = unmodified.WarehouseLocation;

            validationErrors.AddRange(_validator.ValidateOnUpdate(modified));

            return null;
        }
    }
}
