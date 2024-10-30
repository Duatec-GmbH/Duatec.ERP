using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles
{
    [HookAttachment(key: HookKeys.Article.Update)]
    internal class ArticleUpdateHook : IRecordManagePageHook
    {
        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
        {
            var recordId = (Guid)record["id"];

            var oldEquivalents = ArticleEquivalent.AllTargetsForSource(recordId);

            var current = pageModel.GetFormValue("equivalents").Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(Guid.Parse)
                .ToArray();

            var toDelete = oldEquivalents.Where(g => !current.Contains(g)).ToArray();
            var toAdd = current.Where(g => !oldEquivalents.Contains(g)).ToArray();

            if (toDelete.Length == 0 && toAdd.Length == 0)
                return null;

            using var dbCtx = DbContext.CreateContext(ErpSettings.ConnectionString);
            using var connection = dbCtx.CreateConnection();
            connection.BeginTransaction();

            try
            {
                foreach (var id in toDelete)
                    ArticleEquivalent.DeleteMapping(recordId, id);

                foreach (var id in toAdd)
                    ArticleEquivalent.InsertMapping(recordId, id);

                connection.CommitTransaction();
            }
            catch (Exception ex)
            {
                connection.RollbackTransaction();
                pageModel.PutMessage(ScreenMessageType.Error, $"Error: {ex.Message}");
            }

            return null;
        }

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            return null;
        }
    }
}
