﻿using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.PartLists
{
    using Row = (string PartNumber, string DeviceTag, bool Import, decimal Amount);

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

            var context = pageModel.ErpRequestContext;
            var url = $"/{context.App?.Name}/part-lists/part-lists/r/{listId}";

            if (rows.Count == 0)
                return pageModel.LocalRedirect(url);

            var partNumbers = rows
                .Select(r => r.PartNumber)
                .Distinct()
                .ToArray();

            var recMan = new RecordManager();
            var articleLookup = new ArticleRepository(recMan).FindMany(partNumbers: partNumbers!);

            if (articleLookup.Any(kp => kp.Value == null))
                return Error(pageModel, articleLookup);

            var entries = rows
                .GroupBy(r => r.PartNumber)
                .Select(g => ListEntryRecord(g, articleLookup!, listId));

            var repo = new PartListRepository(recMan);

            void TransactionalAction()
            {
                foreach (var rec in entries)
                {
                    if (repo.InsertEntry(rec) == null)
                        throw new DbException($"Could not create part list entries");
                }
            }

            if (!Transactional.TryExecute(pageModel, TransactionalAction))
                return null;

            return pageModel.LocalRedirect(url);
        }

        private static bool TryGetRows(BaseErpPageModel pageModel, out List<Row> rows)
        {
            var partNumbers = pageModel.GetFormValues(Article.Fields.PartNumber);
            var importValues = pageModel.GetFormValues("import");
            var deviceTags = pageModel.GetFormValues(PartListEntry.Fields.DeviceTag);
            var amounts = pageModel.GetFormValues(PartListEntry.Fields.Amount);

            rows = new List<Row>(partNumbers.Length);

            if (partNumbers.Length != importValues.Length || partNumbers.Length != deviceTags.Length || partNumbers.Length != amounts.Length)
                return false;

            for (var i = 0; i < partNumbers.Length; i++)
            {
                if (!bool.TryParse(importValues[i], out var import))
                    return false;

                if (!int.TryParse(amounts[i], out var amount))
                    return false;

                if (import && amount > 0)
                    rows.Add(new(partNumbers[i], deviceTags[i], import, amount));
            }

            return true;
        }

        private static IActionResult? Error(BaseErpPageModel pageModel, string message)
        {
            pageModel.PutMessage(ScreenMessageType.Error, message);
            return null;
        }

        private static IActionResult? Error(BaseErpPageModel pageModel, Dictionary<string, Article?> articleLookup)
        {
            var partNumbers = articleLookup
                .Where(kp => kp.Value == null)
                .Select(kp => $"'{kp.Key}'")
                .ToArray();

            var message = "Error during import:" + Environment.NewLine
                + "Could not find article";

            if (partNumbers.Length == 1)
                message += $" with part number {partNumbers[0]}";
            else
                message += $"s with part numbers {{ {string.Join(", ", partNumbers)} }}";

            return Error(pageModel, message);
        }

        private static PartListEntry ListEntryRecord(IGrouping<string, Row> g, Dictionary<string, Article> articleLookup, Guid partListId)
        {
            return new PartListEntry()
            {
                Id = Guid.NewGuid(),
                PartListId = partListId,
                ArticleId = articleLookup[g.Key].Id!.Value,
                DeviceTag = AggregateDeviceTags(g),
                Amount = g.Sum(r => r.Amount)
            };
        }

        private static string AggregateDeviceTags(IEnumerable<Row> group)
        {
            var entries = group
                .SelectMany(r => r.DeviceTag.Split('\n')
                    .Select(s => s.TrimEnd('\r').Trim())
                    .Where(s => s != "-"))
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .Order();

            return string.Join(Environment.NewLine, entries);
        }
    }
}
