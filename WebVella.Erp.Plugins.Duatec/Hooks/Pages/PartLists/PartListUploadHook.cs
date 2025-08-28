using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.FileImports;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
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

            var recMan = new RecordManager();
            var articlesWithinPartList = new PartListRepository(recMan).FindManyEntriesByPartList(listId)
                .Select(ple => (ple.GetArticle().PartNumber, ple.Denomination))
                .ToHashSet();

            var articleRepo = new ArticleRepository(recMan);
            var defaultType = articleRepo.FindType(Article.DefaultType)!;

            var articleSelect = $"*, ${Article.Relations.Type}.*";
            var articleLookup = articleRepo.FindMany(articleSelect, [.. importResult.Select(ir => ir.PartNumber)]);

            foreach (var res in importResult.OrderBy(r => r.ImportState).ThenBy(r => r.PartNumber).ThenBy(r => r.OrderNumber))
                list.Add(GetRecord(res, articlesWithinPartList, articleLookup, defaultType));

            var record = new EntityRecord();
            record["articles"] = list;
            record["count"] = list.Count;
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

        private static EntityRecord GetRecord(ArticleImportResult importResult, HashSet<(string PartNumber, decimal Denomination)> articlesWithinPartList, Dictionary<string, Article?> articleLookup, ArticleType defaultType)
        {
            var rec = new EntityRecord();
            var partNumber = string.IsNullOrWhiteSpace(importResult.PartNumber)
                ? "-" : importResult.PartNumber;

            var state = articlesWithinPartList.Contains((partNumber, importResult.Denomination)) 
                ? ArticleImportState.DuplicateArticle : importResult.ImportState;

            if (state == ArticleImportState.EplanArticle)
                state = ArticleImportState.InvalidEplanArticle;
            
            rec[Article.Fields.PartNumber] = partNumber;
            rec[Article.Fields.OrderNumber] = importResult.OrderNumber;
            rec[Article.Fields.TypeNumber] = importResult.TypeNumber;
            rec[Article.Fields.Designation] = importResult.Designation;
            // rec[PartListEntry.Fields.DeviceTag] = string.Join(Environment.NewLine, importResult.DeviceTags);
            rec[PartListEntry.Fields.Amount] = importResult.Amount;
            rec[PartListEntry.Fields.Denomination] = importResult.Denomination;
            rec[$"$type"] = articleLookup.TryGetValue(partNumber, out var article) ? article?.GetArticleType() ?? defaultType : defaultType;
            rec["import_state"] = state;
            rec["import"] = GetDefaultImportState(state, importResult.Amount);

            return rec;
        }

        private static bool GetDefaultImportState(ArticleImportState state, decimal amount)
        {
            return amount > 0
                && (state == ArticleImportState.DbArticle || state == ArticleImportState.InvalidDbArticle);
        }
    }
}
