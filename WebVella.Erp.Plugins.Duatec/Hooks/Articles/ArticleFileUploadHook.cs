using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Eplan;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles
{
    [HookAttachment(key: HookKeys.Article.FileUpload)]
    internal class ArticleFileUploadHook : IPageHook
    {
        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
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

            rec[Article.Fields.PartNumber] = article.PartNumber;
            rec[Article.Fields.OrderNumber] = article.OrderNumber;
            rec[Article.Fields.TypeNumber] = article.TypeNumber;
            rec[Article.Fields.Designation] = article.Designation;
            rec[Article.Fields.Type] = article.Type;
            rec["import_state"] = article.ImportState;
            rec["action"] = article.Action;
            rec["available_actions"] = GetAvailableActions(article.AvailableActions);

            return rec;
        }

        private static SelectOption? GetAction(string action)
        {
            if (string.IsNullOrEmpty(action))
                return null;

            var option = new SelectOption
            {
                Label = action,
                Value = action
            };

            return option;
        }

        private static List<SelectOption> GetAvailableActions(string[] actions)
        {
            var result = new List<SelectOption>(actions.Length);

            foreach (var action in actions)
            {
                var rec = GetAction(action);
                if(rec != null)
                    result.Add(rec);
            }
            return result;
        }
    }
}
