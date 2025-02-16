using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.FileImports;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.PartLists
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

            if (!filePath.EndsWith(".xml") && !filePath.EndsWith(".csv"))
                return Error(pageModel, "Only xml and csv files are supported");

            var file = fsRepository.Find(filePath);
            if (file == null)
                return Error(pageModel, "File not found");

            using var stream = new MemoryStream(file.GetBytes());

            var importResult = filePath.EndsWith(".xml")
                ? FromXml(stream)
                : FromCsv(stream);

            if (importResult.Count == 0)
                return Error(pageModel, "File does not contain any articles");

            var list = new EntityRecordList { TotalCount = importResult.Count };

            foreach (var res in importResult.OrderBy(r => r.ImportState).ThenBy(r => r.PartNumber))
                list.Add(GetRecord(res));

            fsRepository.Delete(filePath);

            var record = new EntityRecord();
            record["articles"] = list;
            pageModel.DataModel.SetRecord(record);

            return null;
        }

        private static List<ArticleImportResult> FromXml(Stream stream)
        {
            var articles = EplanXml.GetArticles(stream);

            return ArticleImportResultList.FromEplanArticles(articles);
        }

        private static List<ArticleImportResult> FromCsv(Stream stream)
        {
            var articles = Csv.GetArticles(stream);

            return ArticleImportResultList.FromCsvArticles(articles);
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
            var partNumber = string.IsNullOrWhiteSpace(article.PartNumber)
                ? "-" : article.PartNumber;

            rec[Article.Fields.PartNumber] = partNumber;
            rec[Article.Fields.OrderNumber] = article.OrderNumber;
            rec[Article.Fields.TypeNumber] = article.TypeNumber;
            rec[Article.Fields.Designation] = article.Designation;
            rec[PartListEntry.Fields.DeviceTag] = deviceTag;
            rec[PartListEntry.Fields.Amount] = article.Amount;
            rec["import_state"] = article.ImportState;
            rec["import"] = GetDefaultImportState(article.ImportState, article.Amount);

            return rec;
        }

        private static bool GetDefaultImportState(ArticleImportState state, decimal amount)
        {
            return amount > 0
                && (state == ArticleImportState.DbArticle || state == ArticleImportState.InvalidDbArticle);
        }
    }
}
