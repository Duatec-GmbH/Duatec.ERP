using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks.Page;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Articles
{
    [HookAttachment(key: HookKeys.Article.Create)]
    public class ArticleCreateHook : TypedValidatedCreateHook<Article>
    {
        protected override IActionResult? OnValidationSuccess(Article record, RecordCreatePageModel pageModel)
        {
            var shortName = record.PartNumber;
            shortName = shortName[..shortName.IndexOf('.')];
            record.ManufacturerId = new CompanyRepository().FindByShortName(shortName)!.Id!.Value;

            if (!string.IsNullOrWhiteSpace(record.Image))
            {
                var file = Images.GetOrDownload(record.Image, pageModel.CurrentUser.Id);
                if(string.IsNullOrEmpty(file))
                {
                    pageModel.PutMessage(ScreenMessageType.Error, "Could not download image");
                    pageModel.DataModel.SetRecord(record);
                    pageModel.BeforeRender();
                    return pageModel.Page();
                }
                record.Image = file;
            }

            return base.OnValidationSuccess(record, pageModel);
        }
    }
}
