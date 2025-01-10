using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Services.EplanTypes.DataModel;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.PartLists
{
    using Key = (string PartNumber, string TypeNumber, string OrderNumber, string Description);

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
            var parts = EplanXmlService.GetParts(stream);

            fsRepository.Delete(filePath);

            var partNumbers = parts
                .Select(p => p.PartNumber)
                .Distinct()
                .ToArray();

            var articleLookup = RepositoryService.ArticleRepository.FindMany(partNumbers: partNumbers);

            if (articleLookup.Any(kp => kp.Value == null))
                return Error(pageModel, articleLookup);

            var entries = parts
                .GroupBy(Key)
                .Select(g => ListEntryRecord(g, articleLookup!, listId));

            void TransactionalAction()
            {
                foreach(var rec in entries)
                {
                    if (!RepositoryService.PartListRepository.Insert(rec).HasValue)
                        throw new DbException($"Could not create part list entries");
                }
            }

            if (!Transactional.TryExecute(pageModel, TransactionalAction))
                return null;

            var context = pageModel.ErpRequestContext;
            var url = $"/{context.App?.Name}/part-lists/part-lists/r/{listId}";
            return pageModel.LocalRedirect(url);
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

            if(partNumbers.Length == 1)
                message += $" with part number {partNumbers[0]}";
            else
                message += $"s with part numbers {{ {string.Join(", ", partNumbers)} }}";

            return Error(pageModel, message);
        }

        private static Key Key(EplanPartDto part)
            => (part.PartNumber, part.TypeNumber, part.OrderNumber, part.Description);
        

        private static PartListEntry ListEntryRecord(IGrouping<Key, EplanPartDto> group, Dictionary<string, Article> articleLookup, Guid partListId)
        {
            return new PartListEntry()
            {
                Id = Guid.NewGuid(),
                PartList = partListId,
                Article = articleLookup[group.Key.PartNumber].Id!.Value,
                DeviceTag = ListAgg(group),
                Amount = group.Count()
            };
        }

        private static string ListAgg(IGrouping<Key, EplanPartDto> group)
        {
            var entries = group
                .Select(g => g.DeviceTag?.Trim())
                .Where(t => !string.IsNullOrEmpty(t))
                .Order();

            return string.Join(Environment.NewLine, entries);
        }
    }
}
