using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Database;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Web.Utils;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Inventory
{
    [HookAttachment(key: HookKeys.Inventory.TakeOut)]
    internal class InventoryTakeOutHook : TypedValidatedManageHook<InventoryEntry>
    {
        protected override List<ValidationError> Validate(InventoryEntry record, InventoryEntry unmodified, RecordManagePageModel pageModel)
        {
            var result = base.Validate(record, unmodified, pageModel);

            if (record.Amount > unmodified.Amount)
                result.Add(new ValidationError(InventoryEntry.Fields.Amount, "Can't take out more than stocked amount"));

            return result;
        }

        protected override IActionResult? OnValidationSuccess(InventoryEntry record, InventoryEntry unmodified, RecordManagePageModel pageModel)
        {
            var repo = new InventoryRepository();

            var amount = unmodified.Amount - record.Amount;
            InventoryEntry? result = null;


            void TransactionalAction()
            {
                if (amount <= 0.005m)
                    result = repo.Delete(record.Id!.Value);
                else
                    result = repo.MovePartial(record);

                if (result == null)
                    throw new DbException("Could not make database action");

                var booking = new InventoryBooking()
                {
                    Amount = amount,
                    ArticleId = record.Article,
                    ProjectId = record.Project,
                    UserId = pageModel.CurrentUser.Id
                };
                if (repo.InsertBooking(booking) == null)
                    throw new DbException("Could not insert booking");
            }

            if (!Transactional.TryExecute(pageModel, TransactionalAction))
                return pageModel.Page();

            OnPostUpdate(record, pageModel);
            return pageModel.LocalRedirect(pageModel.EntityDetailUrl(result!.Id!.Value));
        }
    }
}
