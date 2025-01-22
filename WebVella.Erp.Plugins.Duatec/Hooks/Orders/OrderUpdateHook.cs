using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.TypedRecords.Validation;
using WebVella.Erp.TypedRecords;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Hooks;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Orders
{
    [HookAttachment(key: HookKeys.Order.Update)]
    internal class OrderUpdateHook : OrderHookBase<RecordManagePageModel>, IRecordManagePageHook
    {
        protected override string ActionNameInPastTense => "updated";

        protected override List<ValidationError> ValidateRecord(Order record)
            => ValidationService.ValidateOnUpdate(record);

        protected override void PersistanceAction(Order record, List<OrderEntry> entries)
        {
            foreach (var entry in entries)
                entry.Order = record.Id!.Value;

            var repository = RepositoryService.OrderRepository;

            if (repository.Update(record) == null)
                throw new DbException("Could not update order record");

            var oldEntries = repository.FindManyEntriesByOrder(record.Id!.Value);

            var newArticleIds = entries
                .Select(e => e.Article)
                .ToHashSet();

            DeleteEntries(repository, oldEntries, newArticleIds);
            UpdateEntries(repository, entries, newArticleIds, oldEntries);

            var oldArticleIds = oldEntries
                .Select(e => e.Article)
                .ToHashSet();

            AddEntries(repository, entries, oldArticleIds);
        }

        private static void DeleteEntries(OrderRepository repository, List<OrderEntry> oldEntries, HashSet<Guid> newArticleIds)
        {
            var toDelete = oldEntries
                .Where(oe => !newArticleIds.Contains(oe.Article))
                .Select(oe => oe.Id!.Value)
                .ToArray();

            if (repository.DeleteManyEntries(toDelete).Count != toDelete.Length)
                throw new DbException("Could not delete entries");
        }

        private static void AddEntries(OrderRepository repository, List<OrderEntry> entries, HashSet<Guid> oldArticleIds)
        {
            foreach (var entry in entries.Where(e => !oldArticleIds.Contains(e.Article)))
            {
                if (repository.InsertEntry(entry) == null)
                    throw new DbException("Could not add entry");
            }
        }

        private static void UpdateEntries(OrderRepository repository, List<OrderEntry> entries, HashSet<Guid> newArticleIds, List<OrderEntry> oldEntries)
        {
            foreach (var entry in oldEntries.Where(oe => newArticleIds.Contains(oe.Article)))
            {
                entry.Amount = entries.Single(e => e.Article == entry.Article).Amount;
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
