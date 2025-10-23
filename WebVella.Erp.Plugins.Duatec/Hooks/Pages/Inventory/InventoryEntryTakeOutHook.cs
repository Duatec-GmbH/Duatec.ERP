using Microsoft.AspNetCore.Mvc;
using System.Web;
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
                result.Add(new ValidationError(InventoryEntry.Fields.Amount, $"Amount must not be greater than {unmodified.Amount}"));

            if (!IsStockTaking(pageModel) && (!record.Project.HasValue || record.Project == Guid.Empty))
                result.Add(new ValidationError(InventoryEntry.Fields.Project, $"Project is required"));

            return result;
        }

        protected static bool IsStockTaking(BaseErpPageModel pageModel)
        {
            var comment = pageModel.GetFormValue("comment");

            if (string.IsNullOrWhiteSpace(comment))
                return false;

            comment = comment.Trim();

            return comment.Equals("inventur", StringComparison.OrdinalIgnoreCase) // German
                || comment.Equals("stocktaking", StringComparison.OrdinalIgnoreCase) // English
                ;
        }

        protected override IActionResult? OnValidationFailure(InventoryEntry record, InventoryEntry unmodified, RecordManagePageModel pageModel)
        {
            pageModel.DataModel.SetRecord(record);
            return null;
        }

        protected override IActionResult? OnValidationSuccess(InventoryEntry record, InventoryEntry unmodified, RecordManagePageModel pageModel)
        {
            var repo = new InventoryRepository();
            var amount = record.Amount = Math.Max(0m, Math.Round(record.Amount, 2));
            var comment = pageModel.GetFormValue("comment");
            var isDeleted = false;

            if (!record.GetArticle().GetArticleType().IsDivisible)
                record.Denomination = 0;

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
                    TaggedRecordId = null,
                    TaggedEntityName = null,
                };

                if (amount >= unmodified.Amount)
                {
                    if (repo.Delete(record.Id!.Value) == null)
                        throw new DbException("Could not delete inventory entry");
                    isDeleted = true;
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
                OnValidationFailure(record, unmodified, pageModel);
                pageModel.BeforeRender();
                return pageModel.Page();
            }

            pageModel.PutMessage(ScreenMessageType.Success, "Successfully took out articles");

            if (!string.IsNullOrEmpty(pageModel.ReturnUrl))
            {
                var url = pageModel.ReturnUrl;
                if (isDeleted)
                {
                    const string phrase = "returnUrl=";
                    var start = url.IndexOf(phrase);

                    if (start < 0)
                        url = pageModel.EntityListUrl();
                    else
                    {
                        url = HttpUtility.UrlDecode(url[(start + phrase.Length)..]);

                        if (!url.StartsWith("/" + pageModel.AppName))
                            url = pageModel.EntityListUrl();
                    }
                }

                return pageModel.LocalRedirect(url);
            }
            return pageModel.LocalRedirect(pageModel.EntityListUrl());
        }
    }
}
