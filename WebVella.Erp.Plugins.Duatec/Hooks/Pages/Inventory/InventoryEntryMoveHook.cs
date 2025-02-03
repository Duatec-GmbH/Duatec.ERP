using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Web.Utils;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks.Page;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Inventory
{
    [HookAttachment(key: HookKeys.Inventory.Move)]
    internal class InventoryEntryMoveHook : TypedValidatedManageHook<InventoryEntry>
    {
        const decimal eps = 0.005m;

        protected override string ActionNameInPastTense => "moved";

        protected override List<ValidationError> Validate(InventoryEntry record, InventoryEntry unmodified, RecordManagePageModel pageModel)
        {
            var result = base.Validate(record, unmodified, pageModel);

            if (OriginAndTargetAreSame(record, unmodified))
                result.Add(new ValidationError(string.Empty, "Can not move article without changes at project and/or location"));

            var max = unmodified.Amount;
            var amount = record.Amount;

            if (amount >= max + eps)
            {
                var articleRepo = new ArticleRepository();

                var type = articleRepo.FindTypeByArticleId(unmodified.Article)!;
                var isInt = type.IsInteger;
                var maxVal = isInt ? $"{max:0}" : $"{max:0.00}";
                result.Add(new ValidationError(InventoryEntry.Fields.Amount, $"Amount must not be greater than {maxVal} {type.Unit}"));
            }

            return result;
        }

        protected override IActionResult? OnValidationSuccess(InventoryEntry record, InventoryEntry unmodified, RecordManagePageModel pageModel)
        {
            var result = record.Amount >= unmodified.Amount - eps
                ? CompleteMove(record, pageModel)
                : PartialMove(record, pageModel);

            if (result != null)
                return result;

            pageModel.PutMessage(ScreenMessageType.Success, SuccessMessage(record.EntityName));
            return pageModel.LocalRedirect(pageModel.EntityDetailUrl(record.Id!.Value));
        }


        private static bool OriginAndTargetAreSame(InventoryEntry a, InventoryEntry b)
        {
            return a.WarehouseLocation == b.WarehouseLocation
                && !(a.Project.HasValue ^ b.Project.HasValue)
                && a.Project.HasValue && a.Project.Value == b.Project!.Value;
        }

        private static LocalRedirectResult? CompleteMove(InventoryEntry record, BaseErpPageModel pageModel)
        {
            if (new InventoryRepository().Update(record) != null)
                return null;

            pageModel.PutMessage(ScreenMessageType.Error, "Could not update inventory entry");
            return pageModel.LocalRedirect(pageModel.CurrentUrl);
        }

        private static LocalRedirectResult? PartialMove(InventoryEntry record, BaseErpPageModel pageModel)
        {
            if (new InventoryRepository().MovePartial(record) != null)
                return null;

            pageModel.PutMessage(ScreenMessageType.Error, "Could not move inventory entry");
            return pageModel.LocalRedirect(pageModel.CurrentUrl);
        }
    }
}
