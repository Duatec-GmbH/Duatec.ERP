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
using static WebVella.Erp.Plugins.Duatec.Hooks.HookKeys.PartList;

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

            var oldEntryInfos = OrderList.Entries((Guid)listRec["id"])
                .GroupBy(r => (Guid)r[OrderListEntry.Article])
                .ToDictionary(g => g.Key, g => new { Total = g.Sum(r => (decimal)r[OrderListEntry.Amount]), Records = g.ToArray() });

            var orderListEntries = PartListEntry.FindManyByProject(projectId)
                .GroupBy(pl => (Guid)pl[PartListEntry.Article])
                .Select(g => RecordFromGroup(g, projectId))
                .ToList();

            if (orderListEntries.Count == 0)
                return null;

            void TransactionalAction()
            {
                var recMan = new RecordManager();
                foreach(var entry in orderListEntries)
                {
                    if (!oldEntryInfos.TryGetValue((Guid)entry[OrderListEntry.Article], out var entryInfo))
                        CreateEntry(recMan, entry);
                    else
                    {
                        var curAmount = (decimal)entry[OrderListEntry.Amount];
                        var diff = curAmount - entryInfo.Total;

                        if (diff > 0)
                        {
                            var notOrdered = entryInfo.Records
                                .FirstOrDefault(r => r[OrderListEntry.Order] == null);

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
                        else if (diff < 0)
                        {
                            var notOrdered = entryInfo.Records
                                .FirstOrDefault(r => r[OrderListEntry.Order] == null);

                            if(notOrdered != null)
                            {
                                var amount = (decimal)notOrdered[OrderListEntry.Amount];

                                if (amount + diff > 0)
                                {
                                    notOrdered[OrderListEntry.Amount] = amount + diff;
                                    var response = recMan.UpdateRecord(PartListEntry.Entity, notOrdered);
                                    if (!response.Success)
                                        throw new DbException(response.GetMessage());
                                    break;
                                }
                                else
                                {
                                    DeleteEntry(recMan, notOrdered);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            Transactional.TryExecute(pageModel, TransactionalAction);
            return null;
        }

        private static void CreateEntry(RecordManager recMan, EntityRecord rec)
        {
            var response = recMan.CreateRecord(PartListEntry.Entity, rec);
            if (!response.Success)
                throw new DbException(response.GetMessage());
        }

        private static void DeleteEntry(RecordManager recMan, EntityRecord rec)
        {
            var response = recMan.DeleteRecord(PartListEntry.Entity, (Guid)rec["id"]);
            if (!response.Success)
                throw new DbException(response.GetMessage());
        }

        private static void UpdateEntry(RecordManager recMan, EntityRecord rec)
        {
            var response = recMan.UpdateRecord(PartListEntry.Entity, rec);
            if (!response.Success)
                throw new DbException(response.GetMessage());
        }

        private static EntityRecord RecordFromGroup(IGrouping<Guid, EntityRecord> grouping, Guid orderList)
        {
            var rec = new EntityRecord();
            rec[OrderListEntry.Order] = null;
            rec[OrderListEntry.Article] = grouping.Key;
            rec[OrderListEntry.OrderList] = orderList;
            rec[OrderListEntry.Amount] = grouping
                .Sum(g => (decimal)g[PartListEntry.Amount]);
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
