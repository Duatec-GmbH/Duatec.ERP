using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks.Page;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Api;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Articles
{
    using Images = Duatec.Images;

    [HookAttachment(key: HookKeys.Article.Update)]
    internal class ArticleUpdateHook : TypedValidatedManageHook<Article>
    {
        protected override List<ValidationError> Validate(Article record, Article unmodified, RecordManagePageModel pageModel)
        {
            var result = base.Validate(record, unmodified, pageModel);

            if(record.Id.HasValue && record.TypeId != unmodified.TypeId)
            {
                var type = unmodified.GetArticleType();

                if(type != null && type.IsDivisible)
                {
                    var recMan = new RecordManager();

                    if(new PartListRepository(recMan).FindManyEntriesByArticle(record.Id.Value).Exists(ple => ple.Denomination != 0)
                        || new OrderRepository(recMan).FindManyEntriesByArticle(record.Id.Value).Exists(oe => oe.Denomination != 0)
                        || new InventoryRepository(recMan).FindManyByArticle(record.Id.Value).Exists(ie => ie.Denomination != 0)
                        || new InventoryRepository(recMan).FindManyBookingsByArticle(record.Id.Value).Exists(ibe => ibe.Denomination != 0)
                        || new GoodsReceivingRepository(recMan).FindManyEntriesByArticle(record.Id.Value).Exists(gre => gre.Denomination != 0))
                    {
                        result.Add(new ValidationError(Article.Fields.Type, "When denominatable articles are used within part lists, orders, inventory or in inventory history, type can not be changed anymore"));
                    }
                }
            }

            return result;
        }

        protected override IActionResult? OnValidationSuccess(Article record, Article unmodified, RecordManagePageModel pageModel)
        {
            if(record.Image != unmodified.Image)
            {
                var hasChanged = true;

                if (!string.IsNullOrWhiteSpace(record.Image))
                {
                    var file = Images.GetOrDownload(record.Image, pageModel.CurrentUser.Id);
                    if (string.IsNullOrEmpty(file))
                    {
                        pageModel.PutMessage(ScreenMessageType.Error, "Could not download image");
                        pageModel.DataModel.SetRecord(record);
                        pageModel.BeforeRender();
                        return pageModel.Page();
                    }
                    hasChanged = unmodified.Image != file;
                    record.Image = file;
                }

                if (hasChanged)
                {
                    var repo = new ArticleRepository();
                    repo.DeletePreviewIfUnused(unmodified.Image, unmodified.Id);
                }
            }

            return base.OnValidationSuccess(record, unmodified, pageModel);
        }

        protected override IActionResult? OnPostUpdate(Article record, RecordManagePageModel pageModel)
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

            return base.OnPostUpdate(record, pageModel);
        }
    }
}
