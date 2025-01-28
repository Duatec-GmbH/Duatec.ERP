using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Services.EplanTypes;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.PartLists
{
    [HookAttachment(key: HookKeys.PartList.Upload)]
    internal class PartListUploadHook : IPageHook
    {
        public IActionResult? OnGet(BaseErpPageModel pageModel)
            => null;

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            if (!pageModel.Request.Query.TryGetValue("plId", out var listVal) || !Guid.TryParse(listVal, out var listId))
                return pageModel.BadRequest();

            var filePath = pageModel.GetFormValue("file");

            if (string.IsNullOrEmpty(filePath))
                return Error(pageModel, "File must not be empty");

            var fsRepository = new DbFileRepository();

            if (!filePath.EndsWith(".xml"))
                return Error(pageModel, "Only xml files are supported");

            var file = fsRepository.Find(filePath);
            if (file == null)
                return Error(pageModel, "File not found");

            using var stream = new MemoryStream(file.GetBytes());
            var articles = EplanXml.GetArticles(stream);

            fsRepository.Delete(filePath);

            if (articles.Count == 0)
                return Error(pageModel, "File does not contain any articles");

            if (articles.DistinctBy(a => a.PartNumber).Count() != articles.Count)
                return pageModel.BadRequest();

            var record = new EntityRecord();
            var list = new EntityRecordList { TotalCount = articles.Count };

            record["articles"] = list;

            var importResult = ArticleImportResult.FromEplanArticles(articles);
            foreach (var res in importResult.OrderBy(r => r.ImportState).ThenBy(r => r.PartNumber))
                list.Add(GetRecord(res));

            pageModel.DataModel.SetRecord(record);

            return null;
        }

        private static IActionResult? Error(BaseErpPageModel pageModel, string message)
        {
            pageModel.PutMessage(ScreenMessageType.Error, message);
            pageModel.DataModel.SetRecord(null);
            return null;
        }

        private static EntityRecord GetRecord(ArticleImportResult article)
        {
            var rec = new EntityRecord();

            var deviceTag = string.Join(Environment.NewLine, article.DeviceTags);
            if (string.IsNullOrWhiteSpace(deviceTag))
                deviceTag = "-";

            rec[Article.Fields.PartNumber] = article.PartNumber;
            rec[Article.Fields.OrderNumber] = article.OrderNumber;
            rec[Article.Fields.TypeNumber] = article.TypeNumber;
            rec[Article.Fields.Designation] = article.Designation;
            rec[PartListEntry.Fields.DeviceTag] = deviceTag;
            rec[PartListEntry.Fields.Amount] = article.Amount;
            rec["import_state"] = article.ImportState;
            rec["import"] = GetDefaultImportValueFromState(article.ImportState);

            return rec;
        }

        private static bool GetDefaultImportValueFromState(ArticleImportState state)
        {
            return state switch
            {
                ArticleImportState.DbArticle => true,
                ArticleImportState.InvalidDbArticle => true,
                _ => false
            };
        }
    }
}
