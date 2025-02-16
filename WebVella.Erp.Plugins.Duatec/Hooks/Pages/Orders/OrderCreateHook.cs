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

            if (!record.GetProject().RequiresPartList)
                yield break;

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

        protected override void PersistanceAction(RecordCreatePageModel pageModel, Order record, List<OrderEntry> entries)
        {
            foreach (var entry in entries)
                entry.Order = record.Id!.Value;

            var repository = new OrderRepository();

            record = repository.Insert(record)
                ?? throw new DbException("Could not create order record");

            if (repository.InsertManyEntries(entries).Count != entries.Count)
                throw new DbException("Could not create order entry records");

            var files = pageModel.Request.Form["confirmations"].ToString();
            if (!string.IsNullOrEmpty(files))
            {
                var confirmations = files.Split(',')
                    .Select(path => new OrderConfirmation()
                    {
                        File = path,
                        OrderId = record.Id!.Value,
                    }).ToList();

                if (repository.InsertConfirmations(confirmations).Count != confirmations.Count)
                    throw new DbException("Could not insert confirmation files");
            }
        }

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
            => Execute(TypedEntityRecordWrapper.Wrap<Order>(record), entity, pageModel, validationErrors);

        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
            => null;
    }
}
