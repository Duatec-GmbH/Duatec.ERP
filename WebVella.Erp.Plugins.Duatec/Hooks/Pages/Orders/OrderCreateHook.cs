using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Validation;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Orders
{
    [HookAttachment(HookKeys.Order.Create)]
    internal class OrderCreateHook : OrderHookBase<RecordCreatePageModel>, IRecordCreatePageHook
    {
        protected override string ActionNameInPastTense => "created";

        protected override List<ValidationError> ValidateRecord(Order record)
            => ValidationService.ValidateOnCreate(record);

        protected override IEnumerable<ValidationError> ValidateEntries(Order record, List<OrderEntry> entries)
        {
            foreach (var error in base.ValidateEntries(record, entries))
                yield return error;

            var partListRepos = new PartListRepository();

            var demands = partListRepos.FindManyEntriesByProject(record.Project, true)
                .Select(ple => ple.ArticleId)
                .Distinct()
                .ToHashSet();

            for (var i = 0; i < entries.Count; i++)
            {
                var article = entries[i].Article;
                if (article != Guid.Empty && !demands.Contains(article))
                    yield return Error(OrderEntry.Fields.Article, i, "There is no demand for this article");
            }
        }

        protected override void PersistanceAction(Order record, List<OrderEntry> entries)
        {
            foreach (var entry in entries)
                entry.Order = record.Id!.Value;

            var repository = new OrderRepository();

            if (repository.Insert(record) == null)
                throw new DbException("Could not create order record");

            foreach (var entry in entries)
            {
                if (repository.InsertEntry(entry) == null)
                    throw new DbException("Could not create order entry record");
            }
        }

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
            => Execute(TypedEntityRecordWrapper.Wrap<Order>(record), entity, pageModel, validationErrors);

        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
            => null;
    }
}
