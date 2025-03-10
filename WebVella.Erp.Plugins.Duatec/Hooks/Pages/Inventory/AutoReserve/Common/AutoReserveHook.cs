using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Inventory.AutoReserve.Common
{
    using FormValues = (Guid ArticleId, decimal Amount, int Index);

    internal abstract class AutoReserveHook : IRecordManagePageHook, IPageHook
    {
        protected const string entryKey = "$entries";

        protected abstract IEnumerable<EntityRecord> GetEntries(Guid projectId);

        public abstract IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors);

        public IActionResult? OnPost(BaseErpPageModel pageModel)
            => null;

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
            => null;

        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record") ?? new EntityRecord();
            if (!rec.Properties.TryGetValue(entryKey, out var l) || l == null)
                rec[entryKey] = new List<EntityRecord>(GetEntries(pageModel.RecordId!.Value));

            pageModel.DataModel.SetRecord(rec);
            return null;
        }

        protected static List<FormValues> GetFormData(BaseErpPageModel pageModel)
        {
            var form = pageModel.Request.Form;
            var i = 0;
            var result = new List<FormValues>();


            while (form.TryGetValue($"article_id[{i}]", out var articleIdVal))
            {
                var articleId = Guid.TryParse(articleIdVal, out var id) ? id : Guid.Empty;
                var amount = decimal.TryParse(form[$"amount[{i}]"], out var d) ? d : 0m;

                result.Add((articleId, amount, i));

                i++;
            }

            return result;
        }

        protected static decimal MoveInventory(
            RecordManager recMan, decimal amount, Guid? projectId,
            IEnumerable<InventoryEntry> availableInventoryEntries, Guid userId)
        {
            if (amount <= 0)
                return amount;

            foreach (var entry in availableInventoryEntries)
            {
                if (entry.Amount <= amount)
                {
                    amount -= entry.Amount;
                    Move(recMan, projectId, entry, userId);

                    if (amount <= 0)
                        return amount;
                }
                else
                {
                    MovePartial(recMan, projectId, entry, amount, userId);
                    return 0;
                }
            }
            return amount;
        }


        protected static void Move(RecordManager recMan, Guid? projectId, InventoryEntry entry, Guid userId)
        {
            var repo = new InventoryRepository(recMan);
            var booking = new InventoryBooking()
            {
                Amount = entry.Amount,
                Timestamp = DateTime.Now,
                ArticleId = entry.Article,
                Kind = InventoryBookingKind.Move,
                WarehouseLocationId = entry.WarehouseLocation,
                WarehouseLocationSourceId = entry.WarehouseLocation,
                ProjectSourceId = entry.Project,
                ProjectId = projectId,
                UserId = userId
            };

            entry.Project = projectId;
            if (repo.Update(entry) == null)
                throw new DbException("Could not move inventory entry");
            if (repo.InsertBooking(booking) == null)
                throw new DbException("Could not insert booking");
        }

        private static void MovePartial(RecordManager recMan, Guid? projectId, InventoryEntry entry, decimal amount, Guid userId)
        {
            var repo = new InventoryRepository(recMan);
            var booking = new InventoryBooking()
            {
                Amount = amount,
                Timestamp = DateTime.Now,
                ArticleId = entry.Article,
                Kind = InventoryBookingKind.Move,
                WarehouseLocationId = entry.WarehouseLocation,
                WarehouseLocationSourceId = entry.WarehouseLocation,
                ProjectSourceId = entry.Project,
                ProjectId = projectId,
                UserId = userId
            };

            entry.Project = projectId;
            entry.Amount = amount;
            if (repo.MovePartial(entry) == null)
                throw new DbException("Could not partially move inventory entry");
            if (repo.InsertBooking(booking) == null)
                throw new DbException("Could not insert booking");
        }

        protected static LocalRedirectResult Info(BaseErpPageModel pageModel, string message)
        {
            pageModel.PutMessage(ScreenMessageType.Info, message);
            return ReturnToProject(pageModel);
        }

        protected static LocalRedirectResult Success(BaseErpPageModel pageModel)
        {
            pageModel.PutMessage(ScreenMessageType.Success, "Successfully performed Inventory reservations");
            return ReturnToProject(pageModel);
        }

        protected static LocalRedirectResult ReturnToProject(BaseErpPageModel pageModel)
        {
            if (!string.IsNullOrEmpty(pageModel.ReturnUrl))
                return pageModel.LocalRedirect(pageModel.ReturnUrl);

            var id = pageModel.RecordId;
            var appName = pageModel.ErpRequestContext.App.Name;
            var area = pageModel.ErpRequestContext?.SitemapArea?.Name;

            return pageModel.LocalRedirect($"/{appName}/{area}/projects/r/{id}");
        }
    }
}
