using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Projects
{
    [HookAttachment(key: HookKeys.Project.OrderList)]
    internal class GenerateOrderListHook : IRecordDetailsPageHook
    {
        public IActionResult? OnPost(RecordDetailsPageModel pageModel)
        {
            if (!pageModel.RecordId.HasValue)
                return null;

            var projectId = pageModel.RecordId.Value;
            var listRec = GetOrAddOrderList(projectId);
            var listId = (Guid)listRec["id"];

            var orderListEntries = PartListEntry.FindManyByProject(projectId)
                .GroupBy(pl => (Guid)pl[PartListEntry.Article])
                .Select(g => OrderListEntryFromPartListEntryGroup(g, listId))
                .ToList();

            void TransactionalAction()
            {
                var recMan = new RecordManager();
                DeleteOldEntriesFromPartList(recMan, listId);
                if (orderListEntries.Count == 0)
                    return;

                var oldEntryInfos = OrderList.Entries(listId)
                    .GroupBy(r => (Guid)r[OrderListEntry.Article])
                    .ToDictionary(g => g.Key, g => new
                    {
                        Total = g.Sum(r => (decimal)r[OrderListEntry.Amount]),
                        Records = g.ToArray()
                    });

                foreach(var entry in orderListEntries)
                {
                    var articleId = (Guid)entry[OrderListEntry.Article];

                    if (!oldEntryInfos.TryGetValue(articleId, out var entryInfo))
                        CreateEntry(recMan, entry);
                    else
                    {
                        var curAmount = (decimal)entry[OrderListEntry.Amount];
                        var diff = curAmount - entryInfo.Total;

                        if (diff > 0)
                            IncreaseDemand(recMan, entry, diff, entryInfo.Records);
                        else if (diff < 0)
                            ReduceDemand(recMan, diff, entryInfo.Records);
                    }
                }
            }

            Transactional.TryExecute(pageModel, TransactionalAction);
            return null;
        }

        private static void DeleteOldEntriesFromPartList(RecordManager recMan, Guid listId)
        {
            var entries = OrderListEntry.FindMany(listId, "id");

            var toDelete = entries
                .Where(r => (bool)r[OrderListEntry.IsFromPartList] && r[OrderListEntry.Order] == null)
                .ToIdArray();

            if (toDelete.Length > 0)
            {
                var response = recMan.DeleteRecords(OrderListEntry.Entity, toDelete);
                if (!response.Success)
                    throw new DbException(response.GetMessage());
            }
        }

        private static void IncreaseDemand(RecordManager recMan, EntityRecord entry, decimal diff, IEnumerable<EntityRecord> demandEntries)
        {
            var notOrdered = demandEntries
                .SingleOrDefault(r => r[OrderListEntry.Order] == null && (bool)r[OrderListEntry.IsFromPartList]);

            if (notOrdered == null)
            {
                entry[OrderListEntry.Amount] = diff;
                CreateEntry(recMan, entry);
            }
            else
            {
                notOrdered[OrderListEntry.Amount] = (decimal)notOrdered[OrderListEntry.Amount] + diff;
                UpdateEntry(recMan, notOrdered);
            }
        }

        private static void ReduceDemand(RecordManager recMan, decimal diff, IEnumerable<EntityRecord> demandEntries)
        {
            var notOrdered = demandEntries
                .SingleOrDefault(r => r[OrderListEntry.Order] == null && (bool)r[OrderListEntry.IsFromPartList]);

            if (notOrdered == null)
                return;

            var demand = (decimal)notOrdered[OrderListEntry.Amount];

            if (demand + diff <= 0)
                DeleteEntry(recMan, notOrdered);
            else
            {
                notOrdered[OrderListEntry.Amount] = demand + diff;
                UpdateEntry(recMan, notOrdered);
            }
        }

        private static void CreateEntry(RecordManager recMan, EntityRecord rec)
        {
            var response = recMan.CreateRecord(OrderListEntry.Entity, rec);
            if (!response.Success)
                throw new DbException(response.GetMessage());
        }

        private static void DeleteEntry(RecordManager recMan, EntityRecord rec)
        {
            var response = recMan.DeleteRecord(OrderListEntry.Entity, (Guid)rec["id"]);
            if (!response.Success)
                throw new DbException(response.GetMessage());
        }

        private static void UpdateEntry(RecordManager recMan, EntityRecord rec)
        {
            var response = recMan.UpdateRecord(OrderListEntry.Entity, rec);
            if (!response.Success)
                throw new DbException(response.GetMessage());
        }

        private static EntityRecord OrderListEntryFromPartListEntryGroup(IGrouping<Guid, EntityRecord> grouping, Guid orderList)
        {
            var rec = new EntityRecord();
            rec["id"] = Guid.NewGuid();
            rec[OrderListEntry.Order] = null;
            rec[OrderListEntry.Article] = grouping.Key;
            rec[OrderListEntry.OrderList] = orderList;
            rec[OrderListEntry.IsFromPartList] = true;
            rec[OrderListEntry.Amount] = grouping
                .Sum(g => Math.Max(0m, (decimal)g[PartListEntry.Amount] - (decimal)g[PartListEntry.ProvidedAmount]));
            return rec;
        }

        private static EntityRecord GetOrAddOrderList(Guid projectId)
        {
            var rec = OrderList.ByProject(projectId);
            if (rec == null)
            {
                rec = new EntityRecord();
                rec["id"] = Guid.NewGuid();
                rec[OrderList.Project] = projectId;

                var response = new RecordManager().CreateRecord(OrderList.Entity, rec);
                if (!response.Success)
                    throw new DbException(response.GetMessage());
            }
            return rec;
        }
    }
}
