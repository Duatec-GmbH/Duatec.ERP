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
    [HookAttachment(key: HookKeys.Article.Stock.Create)]
    internal class ArticleStockCreateHook : IRecordCreatePageHook
    {
        private static readonly ArticleStockValidator _validator = new();

        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
            => null;

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            var rec = new InventoryEntry(record);

            var errors = _validator.ValidateOnCreate(rec);
            validationErrors.AddRange(errors);

            if (errors.Count > 0)
                return null;

            if(Repository.Inventory.Insert(rec) is not Guid id)
            {
                validationErrors.Add(new ValidationError(string.Empty, "Could not create inventory entry"));
                return null;
            }

            return pageModel.LocalRedirect(PageUrl.EntityDetail(pageModel, id));
        }
    }
}
