using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles
{
    [HookAttachment(key: HookKeys.Article.Create)]
    public class ArticleCreateHook : TypedValidatedCreateHook<Article>
    {
        protected override IActionResult? OnValidationSuccess(Article record, RecordCreatePageModel pageModel)
        {
            var shortName = record.PartNumber;
            shortName = shortName[..shortName.IndexOf('.')];
            record.ManufacturerId = new CompanyRepository().FindByShortName(shortName)!.Id!.Value;

            return base.OnValidationSuccess(record, pageModel);
        }
    }
}
