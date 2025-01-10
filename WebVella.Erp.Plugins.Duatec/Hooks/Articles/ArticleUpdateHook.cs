using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles
{
    [HookAttachment(key: HookKeys.Article.Update)]
    internal class ArticleUpdateHook : IRecordManagePageHook
    {
        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
        {
            var recordId = (Guid)record["id"];

            var oldAlternatives = RepositoryService.Article.FindAlternativeIds(recordId);
            var currentAlternatives = pageModel.GetFormValue("equivalents")
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(Guid.Parse)
                .ToArray();

            var toDelete = oldAlternatives
                .Where(g => !currentAlternatives.Contains(g))
                .ToArray();

            var toAdd = currentAlternatives
                .Where(g => !oldAlternatives.Contains(g))
                .ToArray();

            if (toDelete.Length == 0 && toAdd.Length == 0)
                return null;

            void TransactionalAction()
            {
                foreach (var id in toDelete)
                    RepositoryService.Article.DeleteAlternativeMapping(recordId, id);

                foreach (var id in toAdd)
                    RepositoryService.Article.InsertAlternativeMapping(recordId, id);
            }

            Transactional.TryExecute(pageModel, TransactionalAction);

            return null;
        }

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            return null;
        }
    }
}
