using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Articles
{
    [HookAttachment(key: HookKeys.Article.ImportHook)]
    public class ArticleImportHook : ArticleCreateHook
    {
        protected override IActionResult? OnValidationSuccess(Article record, RecordCreatePageModel pageModel)
        {
            var result = base.OnValidationSuccess(record, pageModel);
            if (result != null)
                return result;

            var searchValue = $"{pageModel.Request.Form["search_value"]}";

            void TransactionalAction()
            {
                if (new ArticleRepository().Insert(record) == null)
                    throw new DbException("Could not create record");
            }

            if(Transactional.TryExecute(pageModel, TransactionalAction))
                pageModel.PutMessage(ScreenMessageType.Success, $"Successfully imported Article '{record.PartNumber}'.");

            record["search_value"] = searchValue;
            pageModel.DataModel.SetRecord(record);
            return pageModel.Page();
        }
    }
}
