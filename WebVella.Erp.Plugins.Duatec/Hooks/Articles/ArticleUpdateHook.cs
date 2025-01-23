using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.TypedRecords.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles
{
    [HookAttachment(key: HookKeys.Article.Update)]
    internal class ArticleUpdateHook : TypedValidatedUpdateHook<Article>
    {
        protected override IActionResult? OnPostModification(Article record, Entity entity, RecordManagePageModel pageModel)
        {
            var recordId = record.Id!.Value;
            var articleRepo = new ArticleRepository();
            var oldAlternatives = articleRepo.FindAlternativeIds(recordId);

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

            if (toDelete.Length != 0 || toAdd.Length != 0)
            {
                void TransactionalAction()
                {
                    foreach (var id in toDelete)
                        articleRepo.DeleteAlternativeMapping(recordId, id);

                    foreach (var id in toAdd)
                        articleRepo.InsertAlternativeMapping(recordId, id);
                }

                Transactional.TryExecute(pageModel, TransactionalAction);
            }

            return base.OnPostModification(record, entity, pageModel);
        }
    }
}
