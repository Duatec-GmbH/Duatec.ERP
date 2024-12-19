using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Stocks
{
    [HookAttachment(key: HookKeys.Article.Stock.Update)]
    internal class ArticleStockUpdateHook : IRecordManagePageHook
    {
        private static readonly ArticleStockValidator _validator = new();

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var modified = new InventoryEntry(record);
            var id = modified.Id!.Value;

            if (modified.Amount == 0)
            {
                if (Repository.Inventory.Delete(id))
                    return pageModel.LocalRedirect(PageUrl.EntityList(pageModel));

                validationErrors.Add(new ValidationError(string.Empty, "Could not delete record"));
                return null;
            }

            var unmodified = Repository.Inventory.Find(id)!;
            modified.Article = unmodified.Article;
            modified.Project = unmodified.Project;
            modified.WarehouseLocation = unmodified.WarehouseLocation;

            validationErrors.AddRange(_validator.ValidateOnUpdate(modified));

            return null;
        }
    }
}
