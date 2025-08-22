using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords.Validation;
using WebVella.Erp.TypedRecords;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Hooks;
using WebVella.Erp.Api;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Orders
{
    [HookAttachment(key: HookKeys.Order.Update)]
    internal class OrderUpdateHook : OrderHookBase<RecordManagePageModel>, IRecordManagePageHook
    {
        protected override string ActionNameInPastTense => "updated";

        protected override List<ValidationError> ValidateRecord(Order record)
            => ValidationService.ValidateOnUpdate(record);

        protected override void PersistanceAction(RecordManagePageModel pageModel, Order record, List<OrderEntry> entries)
        {
            foreach (var entry in entries)
                entry.Order = record.Id!.Value;

            var repository = new OrderRepository();

            if (repository.Update(record) == null)
                throw new DbException("Could not update order record");

            var oldEntries = repository.FindManyEntriesByOrder(record.Id!.Value);

            var newArticleIds = entries
                .Select(e => (e.Article, e.Denomination))
                .ToHashSet();

            DeleteEntries(repository, oldEntries, newArticleIds);
            UpdateEntries(repository, entries, newArticleIds, oldEntries);

            var oldArticleIds = oldEntries
                .Select(e => (e.Article, e.Denomination))
                .ToHashSet();

            AddEntries(repository, entries, oldArticleIds);

            var confirmations = GetConfirmations(record, pageModel);
            if(repository.UpdateConfirmations(record.Id.Value, confirmations).Count != confirmations.Count)
                throw new DbException("Could not insert confirmation files");

            var bills = GetBills(record, pageModel);
            if (repository.UpdateBills(record.Id.Value, bills).Count != bills.Count)
                throw new DbException("Could not insert bill files");
        }

        protected override IEnumerable<ValidationError> ValidateEntries(Order record, List<OrderEntry> entries)
        {
            foreach (var error in base.ValidateEntries(record, entries))
                yield return error;

            if (record.Project == null || record.Project == Guid.Empty || !record.GetProject()!.RequiresPartList)
                yield break;

            var recMan = new RecordManager();
            var orderRepo = new OrderRepository(recMan);
            var partListRepo = new PartListRepository(recMan);

            var oldEntries = orderRepo.FindManyEntriesByOrder(record.Id!.Value)
                .Select(r => (r.Article, r.Denomination))
                .Distinct()
                .ToHashSet();

            var demands = partListRepo.FindManyEntriesByProject(record.Project.Value, true)
                .Select(ple => (ple.ArticleId, ple.Denomination))
                .Distinct()
                .ToHashSet();

            var index = 0;
            foreach(var (article, denomination) in entries.Select(e => (e.Article, e.Denomination)))
            {
                // only check on new entries
                if (article != Guid.Empty && !oldEntries.Contains((article, denomination)) && !demands.Contains((article, denomination)))
                    yield return Error(OrderEntry.Fields.Article, index, "There is no demand on given article");
                index++;
            }
        }

        private static void DeleteEntries(OrderRepository repository, List<OrderEntry> oldEntries, HashSet<(Guid Article, decimal Denomination)> newArticleIds)
        {
            var toDelete = oldEntries
                .Where(oe => !newArticleIds.Contains((oe.Article, oe.Denomination)))
                .Select(oe => oe.Id!.Value)
                .ToArray();

            if (repository.DeleteManyEntries(toDelete).Count != toDelete.Length)
                throw new DbException("Could not delete entries");
        }

        private static void AddEntries(OrderRepository repository, List<OrderEntry> entries, HashSet<(Guid Article, decimal Denomination)> oldArticleIds)
        {
            var newEntries = entries.Where(e => !oldArticleIds.Contains((e.Article, e.Denomination))).ToArray();

            if(repository.InsertManyEntries(newEntries).Count != newEntries.Length)
                throw new DbException("Could not add entries");
        }

        private static void UpdateEntries(OrderRepository repository, List<OrderEntry> entries, HashSet<(Guid Article, decimal Denomination)> newArticleIds, List<OrderEntry> oldEntries)
        {
            foreach (var entry in oldEntries.Where(oe => newArticleIds.Contains((oe.Article, oe.Denomination))))
            {
                var newEntry = entries.Single(e => e.Article == entry.Article && e.Denomination == entry.Denomination);

                entry.Amount = newEntry.Amount;
                entry.ExpectedArrival = newEntry.ExpectedArrival;

                if (repository.UpdateEntry(entry) == null)
                    throw new DbException("Could not update entry");
            }
        }

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
            => Execute(TypedEntityRecordWrapper.Wrap<Order>(record), entity, pageModel, validationErrors);

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
            => null;
    }
}
