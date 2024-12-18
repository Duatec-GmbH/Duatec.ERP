using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Stocks
{
    [HookAttachment(key: HookKeys.Article.Stock.Move)]
    internal class ArticleStockMoveHook : IRecordManagePageHook
    {
        private static readonly ArticleStockValidator _validator = new();

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var repo = new InventoryRepository();

            var entry = new InventoryEntry(record);
            var unchanged = repo.Find(entry.Id!.Value)!;

            if (OriginAndTargetAreSame(entry, unchanged))
                validationErrors.Add(new ValidationError(string.Empty, "Can not move article without changes at project and/or location"));

            entry.Article = unchanged.Article;
            validationErrors.AddRange(_validator.ValidateOnCreate(entry));

            if (entry[InventoryEntry.Fields.Amount] == null)
                entry.Amount = 0m;

            Common.RoundAmount(entry);
            var max = unchanged.Amount;
            var amount = entry.Amount;

            if (amount > max + 0.001m)
            {
                var type = new ArticleRepository().FindTypeByArticleId(unchanged.Article)!;
                var isInt = type.IsInteger;
                var maxVal = isInt ? $"{max:0}" : $"{max:0.00}";
                validationErrors.Add(new ValidationError(InventoryEntry.Fields.Amount, $"Amount must not be greater than {maxVal} {type.Unit}"));
            }

            if (validationErrors.Count > 0)
                return null;

            var result = amount > max - 0.001m
                ? CompleteMove(entry, pageModel, validationErrors)
                : PartialMove(entry, pageModel, validationErrors);

            if(result != null)
                pageModel.PutMessage(ScreenMessageType.Success, "Successfully moved articles");
            return result;
        }

        private static bool OriginAndTargetAreSame(InventoryEntry a, InventoryEntry b)
        {
            var projA = a.Project;
            var projB = b.Project;

            return a.WarehouseLocation == b.WarehouseLocation
                && !(projA.HasValue ^ projB.HasValue) 
                && projA.HasValue && projA.Value == projB!.Value;
        }

        private static LocalRedirectResult? CompleteMove(InventoryEntry record, BaseErpPageModel pageModel, List<ValidationError> validationErrors)
        {
            try
            {
                Common.CompleteMove(record);
                return pageModel.LocalRedirect(PageUrl.EntityDetail(pageModel, (Guid)record["id"]));
            }
            catch (Exception ex)
            {
                validationErrors.Add(new ValidationError(string.Empty, ex.Message));
                return null;
            }
        }

        private static LocalRedirectResult? PartialMove(InventoryEntry record, BaseErpPageModel pageModel, List<ValidationError> validationErrors)
        {
            var id = (Guid)record["id"];
            try
            {
                Common.PartialMove(record);
                return pageModel.LocalRedirect(PageUrl.EntityManage(pageModel, id, "move"));
            }
            catch (Exception ex)
            {
                validationErrors.Add(new ValidationError(string.Empty, ex.Message));
                return null;
            }
        }
    }
}
