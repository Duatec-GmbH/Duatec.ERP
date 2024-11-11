using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Eplan;
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
            {
                fsRepository.Delete(filePath);
                return Error(pageModel, "Only xml files are supported");
            }

            var file = fsRepository.Find(filePath);

            var text = Encoding.UTF8.GetString(file.GetBytes());
            var articles = EplanXml.GetArticles(text);

            fsRepository.Delete(filePath);

            if (articles.Count == 0)
                return Error(pageModel, "File does not contain any articles");

            if (articles.DistinctBy(a => a.PartNumber).Count() != articles.Count)
                return pageModel.BadRequest();

            var record = new EntityRecord();
            var list = new EntityRecordList { TotalCount = articles.Count };

            record["articles"] = list;
            record["project"] = null;            

            var importResult = ArticleImportResult.FromEplanArticles(articles);
            foreach (var res in importResult.OrderBy(r => r.PartNumber))
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

            rec[Article.PartNumber] = article.PartNumber;
            rec[Article.OrderNumber] = article.OrderNumber;
            rec[Article.TypeNumber] = article.TypeNumber;
            rec["demand"] = article.Demand;
            rec["import_state"] = GetImportStateElement(article.ImportState);
            rec["action"] = article.Action;
            rec["available_actions"] = GetAvailableActions(article.AvailableActions);

            return rec;
            
        }

        private static string GetImportStateElement(ArticleImportState state)
        {
            return Text.FancyfyPascalCase(state.ToString());
        }

        private static EntityRecordList GetAvailableActions(string[] actions)
        {
            var result = new EntityRecordList { TotalCount = actions.Length };

            foreach (var action in actions)
            {
                var rec = new EntityRecord();
                rec["action"] = action;
                result.Add(rec);
            }
            return result;
        }
    }
}
