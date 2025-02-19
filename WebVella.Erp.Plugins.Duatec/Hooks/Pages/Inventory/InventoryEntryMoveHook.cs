using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Web.Utils;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks.Page;
using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec.Persistance;

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
            void TransactionalAction()
            {
                var repo = new InventoryRepository();
                record = (record.Amount >= unmodified.Amount - eps
                    ? repo.Update(record)
                    : repo.MovePartial(record))!;

                if (record == null)
                    throw new DbException("Could not move inventory entry");
            }

            if(!Transactional.TryExecute(pageModel, TransactionalAction))
            {
                pageModel.BeforeRender();
                return pageModel.Page();
            }

            pageModel.PutMessage(ScreenMessageType.Success, SuccessMessage(record.EntityName));
            if (!string.IsNullOrEmpty(pageModel.ReturnUrl))
                return pageModel.LocalRedirect(pageModel.ReturnUrl);
            return pageModel.LocalRedirect(pageModel.EntityDetailUrl(record.Id!.Value));
        }


        private static bool OriginAndTargetAreSame(InventoryEntry a, InventoryEntry b)
        {
            return a.WarehouseLocation == b.WarehouseLocation
                && (NullOrEmpty(a.Project) && NullOrEmpty(b.Project)
                || a.Project == b.Project);
        }

        private static bool NullOrEmpty(Guid? id)
            => !id.HasValue || id.Value == Guid.Empty;
    }
}
