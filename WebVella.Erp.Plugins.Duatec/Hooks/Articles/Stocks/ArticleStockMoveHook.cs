using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Web.Utils;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks;
using WebVella.Erp.Api;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Stocks
{
    [HookAttachment(key: HookKeys.Article.Stock.Move)]
    internal class ArticleStockMoveHook : TypedValidatedUpdateHook<InventoryEntry>
    {
        const decimal eps = 0.005m;

        protected override string ActionNameInPastTense => "moved";

        protected override IActionResult? OnPreValidate(InventoryEntry record, Entity entity, RecordManagePageModel pageModel)
        {
            var unchanged = new InventoryRepository().Find(record.Id!.Value)!;

            record.Project = unchanged.Project;
            record.Article = unchanged.Article;

            return null;
        }


        protected override List<ValidationError> Validate(InventoryEntry record, Entity entity, RecordManagePageModel pageModel)
        {
            var result = base.Validate(record, entity, pageModel);

            var recMan = new RecordManager();
            var inventoryRepo = new InventoryRepository(recMan);
            var unchanged = inventoryRepo.Find(record.Id!.Value)!;

            if (OriginAndTargetAreSame(record, unchanged))
                result.Add(new ValidationError(string.Empty, "Can not move article without changes at project and/or location"));

            var max = unchanged.Amount;
            var amount = record.Amount;

            if (amount >= max + eps)
            {
                var articleRepo = new ArticleRepository(recMan);

                var type = articleRepo.FindTypeByArticleId(unchanged.Article)!;
                var isInt = type.IsInteger;
                var maxVal = isInt ? $"{max:0}" : $"{max:0.00}";
                result.Add(new ValidationError(InventoryEntry.Fields.Amount, $"Amount must not be greater than {maxVal} {type.Unit}"));
            }

            return result;
        }

        protected override IActionResult? OnValidationSuccess(InventoryEntry record, Entity entity, RecordManagePageModel pageModel)
        {
            var recMan = new RecordManager();
            var repo = new InventoryRepository(recMan);

            var unchanged = repo.Find(record.Id!.Value)!;

            var result = record.Amount >= unchanged.Amount - eps
                ? CompleteMove(repo, record, pageModel)
                : PartialMove(repo, record, pageModel);

            if (result != null)
                return result;

            pageModel.PutMessage(ScreenMessageType.Success, SuccessMessage(entity));
            return pageModel.LocalRedirect(pageModel.EntityDetailUrl(record.Id!.Value));
        }


        private static bool OriginAndTargetAreSame(InventoryEntry a, InventoryEntry b)
        {
            return a.WarehouseLocation == b.WarehouseLocation
                && !(a.Project.HasValue ^ b.Project.HasValue) 
                && a.Project.HasValue && a.Project.Value == b.Project!.Value;
        }

        private static LocalRedirectResult? CompleteMove(InventoryRepository inventoryRepo, InventoryEntry record, BaseErpPageModel pageModel)
        {
            if(inventoryRepo.Update(record) != null)
                return null;

            pageModel.PutMessage(ScreenMessageType.Error, "Could not update inventory entry");
            return pageModel.LocalRedirect(pageModel.CurrentUrl);
        }

        private static LocalRedirectResult? PartialMove(InventoryRepository inventoryRepo, InventoryEntry record, BaseErpPageModel pageModel)
        {
            if(inventoryRepo.MovePartial(record) != null)
                return null;

            pageModel.PutMessage(ScreenMessageType.Error, "Could not move inventory entry");
            return pageModel.LocalRedirect(pageModel.CurrentUrl);
        }
    }
}
