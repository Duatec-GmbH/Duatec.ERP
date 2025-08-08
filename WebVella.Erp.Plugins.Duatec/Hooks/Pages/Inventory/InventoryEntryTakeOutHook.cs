using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Database;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks.Page;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Web.Utils;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Inventory
{
    [HookAttachment(key: HookKeys.Inventory.TakeOut)]
    internal class InventoryEntryTakeOutHook : TypedValidatedManageHook<InventoryEntry>
    {
        protected override List<ValidationError> Validate(InventoryEntry record, InventoryEntry unmodified, RecordManagePageModel pageModel)
        {
            var result = base.Validate(record, unmodified, pageModel);

            if (record.Amount > unmodified.Amount)
                result.Add(new ValidationError(InventoryEntry.Fields.Amount, $"Can't take out more than amount in inventory ({unmodified.Amount})"));

            return result;
        }

        protected override IActionResult? OnValidationSuccess(InventoryEntry record, InventoryEntry unmodified, RecordManagePageModel pageModel)
        {
            var repo = new InventoryRepository();
            var amount = record.Amount = Math.Max(0m, Math.Round(record.Amount, 2));
            var comment = pageModel.GetFormValue("comment");

            void TransactionalAction()
            {
                var booking = new InventoryBooking()
                {
                    Amount = amount,
                    Denomination = record.Denomination,
                    ArticleId = unmodified.Article,
                    ProjectId = record.Project,
                    ProjectSourceId = unmodified.Project,
                    WarehouseLocationId = record.WarehouseLocation,
                    WarehouseLocationSourceId = unmodified.WarehouseLocation,
                    UserId = pageModel.CurrentUser.Id,
                    Timestamp = DateTime.Now,
                    Kind = InventoryBookingKind.Take,
                    Comment = comment,
                };

                if (amount >= unmodified.Amount)
                {
                    if (repo.Delete(record.Id!.Value) == null)
                        throw new DbException("Could not delete inventory entry");
                }
                else
                {
                    record.Amount = unmodified.Amount - amount;
                    record.Project = unmodified.Project;
                    if (repo.Update(record) == null)
                        throw new DbException("Could not update inventory entry");
                }

                if (repo.InsertBooking(booking) == null)
                    throw new DbException("Could not insert booking");
            }

            if (!Transactional.TryExecute(pageModel, TransactionalAction))
            {
                pageModel.BeforeRender();
                return pageModel.Page();
            }

            pageModel.PutMessage(ScreenMessageType.Success, "Successfully took out articles");
            if (!string.IsNullOrEmpty(pageModel.ReturnUrl))
                return pageModel.LocalRedirect(pageModel.ReturnUrl);
            return pageModel.LocalRedirect(pageModel.EntityListUrl());
        }
    }
}
