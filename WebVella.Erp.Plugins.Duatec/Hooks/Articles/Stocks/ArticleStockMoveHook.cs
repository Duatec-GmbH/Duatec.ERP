using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Web.Utils;
using WebVella.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Stocks
{
    [HookAttachment(key: HookKeys.Article.Stock.Move)]
    internal class ArticleStockMoveHook : IRecordManagePageHook
    {
        private static readonly InventoryEntryValidator _validator = new();

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            const decimal eps = 0.005m;

            var entry = TypedEntityRecordWrapper.WrapElseDefault<InventoryEntry>(record)!;
            var unchanged = RepositoryService.InventoryRepository.Find(entry.Id!.Value)!;

            if (OriginAndTargetAreSame(entry, unchanged))
                validationErrors.Add(new ValidationError(string.Empty, "Can not move article without changes at project and/or location"));

            entry.Article = unchanged.Article;
            validationErrors.AddRange(_validator.ValidateOnCreate(entry));

            var max = unchanged.Amount;
            var amount = entry.Amount;

            if (amount >= max + eps)
            {
                var type = RepositoryService.ArticleRepository.FindTypeByArticleId(unchanged.Article)!;
                var isInt = type.IsInteger;
                var maxVal = isInt ? $"{max:0}" : $"{max:0.00}";
                validationErrors.Add(new ValidationError(InventoryEntry.Fields.Amount, $"Amount must not be greater than {maxVal} {type.Unit}"));
            }

            if (validationErrors.Count > 0)
                return null;

            var result = amount >= max - eps
                ? CompleteMove(entry, pageModel, validationErrors)
                : PartialMove(entry, pageModel, validationErrors);

            if(result != null)
                pageModel.PutMessage(ScreenMessageType.Success, "Successfully moved articles");
            return result;
        }

        private static bool OriginAndTargetAreSame(InventoryEntry a, InventoryEntry b)
        {
            return a.WarehouseLocation == b.WarehouseLocation
                && !(a.Project.HasValue ^ b.Project.HasValue) 
                && a.Project.HasValue && a.Project.Value == b.Project!.Value;
        }

        private static LocalRedirectResult? CompleteMove(InventoryEntry record, BaseErpPageModel pageModel, List<ValidationError> validationErrors)
        {
            if(RepositoryService.InventoryRepository.Update(record) != null)
                return pageModel.LocalRedirect(pageModel.EntityDetailUrl(record.Id!.Value));

            validationErrors.Add(new ValidationError(string.Empty, "Could not update inventory entry"));
            return null;
        }

        private static LocalRedirectResult? PartialMove(InventoryEntry record, BaseErpPageModel pageModel, List<ValidationError> validationErrors)
        {
            if(RepositoryService.InventoryRepository.MovePartial(record)?.Id is Guid id)
                return pageModel.LocalRedirect(pageModel.EntityDetailUrl(id));

            validationErrors.Add(new ValidationError(string.Empty, "Could not move inventory entry"));
            return null;
        }
    }
}
