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

        protected static void Move(RecordManager recMan, Guid? projectId, InventoryEntry entry)
        {
            entry.Project = projectId;
            if (new InventoryRepository(recMan).Update(entry) == null)
                throw new DbException("Could not move inventory entry");
        }

        protected static void MovePartial(RecordManager recMan, Guid? projectId, InventoryEntry entry, decimal amount)
        {
            entry.Project = projectId;
            entry.Amount = amount;
            if (new InventoryRepository(recMan).MovePartial(entry) == null)
                throw new DbException("Could not partially move inventory entry");
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
            var id = pageModel.RecordId;
            var appName = pageModel.ErpRequestContext.App.Name;
            var area = pageModel.ErpRequestContext?.SitemapArea?.Name;

            return pageModel.LocalRedirect($"/{appName}/{area}/projects/r/{id}");
        }
    }
}
