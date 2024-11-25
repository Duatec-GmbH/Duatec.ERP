using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Eplan;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.PartLists
{
    using Key = (string PartNumber, string TypeNumber, string OrderNumber, string Description);

    [HookAttachment(key: HookKeys.PartList.Import)]
    internal class PartListImportHook : IPageHook
    {
        private static readonly PartListValidator _validator = new();

        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            var project = pageModel.GetFormValue(PartList.Project);
            var name = pageModel.GetFormValue(PartList.Name);

            var listRec = ListRecord(project, name);
            var errors = _validator.ValidateOnCreate(listRec);
            if (errors.Count > 0)
                return Error(pageModel, string.Join("; ", errors.Select(e => e.Message)));

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
            var parts = EplanXml.GetParts(stream);

            fsRepository.Delete(filePath);

            var partNumbers = parts
                .Select(p => p.PartNumber)
                .Distinct()
                .ToArray();

            var articleLookup = Article.FindMany(partNumbers);

            if (articleLookup.Any(kp => kp.Value == null))
                return Error(pageModel, articleLookup);

            var partListId = (Guid)listRec["id"];
            var entries = parts
                .GroupBy(Key)
                .Select(g => ListEntryRecord(g, articleLookup!, partListId));

            void TransactionalAction()
            {
                var recMan = new RecordManager();

                var result = recMan.CreateRecord(PartList.Entity, listRec);
                if (!result.Success)
                    throw new DbException($"Could not create part list: {result.GetMessage()}");

                foreach(var rec in entries)
                {
                    result = recMan.CreateRecord(PartListEntry.Entity, rec);
                    if (!result.Success)
                        throw new DbException($"Could not create part list entry: {result.GetMessage()}");
                }
            }

            if (!Transactional.TryExecute(pageModel, TransactionalAction))
                return null;

            var context = pageModel.ErpRequestContext;
            var url = $"/{context.App?.Name}/part-lists/part-lists/r/{listRec["id"]}";
            return pageModel.LocalRedirect(url);
        }

        private static EntityRecord ListRecord(string? project, string? name)
        {
            Guid? projectId = Guid.TryParse(project, out var id) && id != Guid.Empty
                ? id : null;

            var rec = new EntityRecord();
            rec["id"] = Guid.NewGuid();
            rec[PartList.Project] = projectId;
            rec[PartList.Name] = name;

            return rec;
        }

        private static IActionResult? Error(BaseErpPageModel pageModel, string message)
        {
            pageModel.PutMessage(ScreenMessageType.Error, message);
            return null;
        }

        private static IActionResult? Error(BaseErpPageModel pageModel, Dictionary<string, EntityRecord?> articleLookup)
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

        private static Key Key(EplanPart part)
            => (part.PartNumber, part.TypeNumber, part.OrderNumber, part.Description);
        

        private static EntityRecord ListEntryRecord(IGrouping<Key, EplanPart> group, Dictionary<string, EntityRecord> articleLookup, Guid partListId)
        {
            var rec = new EntityRecord();

            rec["id"] = Guid.NewGuid();
            rec[PartListEntry.PartList] = partListId;
            rec[PartListEntry.Article] = articleLookup[group.Key.PartNumber]["id"];
            rec[PartListEntry.DeviceTag] = ListAgg(group);
            rec[PartListEntry.Count] = group.Count();

            return rec;
        }

        private static string ListAgg(IGrouping<Key, EplanPart> group)
        {
            var entries = group
                .Select(g => g.DeviceTag?.Trim())
                .Where(t => !string.IsNullOrEmpty(t))
                .Distinct()
                .Order();

            return string.Join(Environment.NewLine, entries);
        }
    }
}
