using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.PartLists
{
    using Row = (string PartNumber, bool Import, decimal Amount);

    [HookAttachment(key: HookKeys.PartList.Import)]
    internal class PartListImportHook : IPageHook
    {
        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            if (!pageModel.Request.Query.TryGetValue("plId", out var listVal) || !Guid.TryParse(listVal, out var listId))
                return pageModel.BadRequest();

            if (!TryGetRows(pageModel, out var rows))
                return pageModel.BadRequest();

            if (rows.Count == 0)
                return PartListDetail(pageModel, listId);

            var partNumbers = rows
                .Select(r => r.PartNumber)
                .Distinct()
                .ToArray();

            var recMan = new RecordManager();
            var articleLookup = new ArticleRepository(recMan).FindMany(partNumbers: partNumbers!);
            var oldEntries = new PartListRepository(recMan).FindManyEntriesByPartList(listId);

            if (articleLookup.Any(kp => kp.Value == null))
                return Error(pageModel, "Some articles are not present anymore in database please try again");

            if (oldEntries.Any(ple => articleLookup.Values.Any(a => a!.Id == ple.ArticleId)))
                return Error(pageModel, "Some articles have been inserted meanwhile you tried to import please try again");

            var entries = rows
                .GroupBy(r => r.PartNumber)
                .Select(g => ListEntryRecord(g, articleLookup!, listId))
                .ToArray();

            var repo = new PartListRepository(recMan);
            if(repo.InsertManyEntries(entries).Count != entries.Length)
            {
                pageModel.PutMessage(ScreenMessageType.Error, "Could not create part list entries");
                return null;
            }

            return PartListDetail(pageModel, listId);
        }

        private static bool TryGetRows(BaseErpPageModel pageModel, out List<Row> rows)
        {
            var partNumbers = pageModel.GetFormValues(Article.Fields.PartNumber);
            var importValues = pageModel.GetFormValues("import");
            var amounts = pageModel.GetFormValues(PartListEntry.Fields.Amount);

            rows = new List<Row>(partNumbers.Length);

            if (partNumbers.Length != importValues.Length || partNumbers.Length != amounts.Length)
                return false;

            for (var i = 0; i < partNumbers.Length; i++)
            {
                if (!bool.TryParse(importValues[i], out var import))
                    return false;

                if (!int.TryParse(amounts[i], out var amount))
                    return false;

                if (import && amount > 0)
                    rows.Add(new(partNumbers[i], import, amount));
            }

            return true;
        }

        private static LocalRedirectResult PartListDetail(BaseErpPageModel pageModel, Guid listId)
        {
            if (!string.IsNullOrEmpty(pageModel.ReturnUrl))
                return pageModel.LocalRedirect(pageModel.ReturnUrl);

            var context = pageModel.ErpRequestContext;
            var url = $"/{context.App?.Name}/part-lists/part-lists/r/{listId}";

            return pageModel.LocalRedirect(url);
        }

        private static IActionResult? Error(BaseErpPageModel pageModel, string message)
        {
            pageModel.PutMessage(ScreenMessageType.Error, message);
            return null;
        }

        private static PartListEntry ListEntryRecord(IGrouping<string, Row> g, Dictionary<string, Article> articleLookup, Guid partListId)
        {
            return new PartListEntry()
            {
                Id = Guid.NewGuid(),
                PartListId = partListId,
                ArticleId = articleLookup[g.Key].Id!.Value,
                DeviceTag = string.Empty,
                Amount = g.Sum(r => r.Amount)
            };
        }
    }
}
