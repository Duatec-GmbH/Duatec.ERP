﻿using Microsoft.CodeAnalysis;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Persistance;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    internal class GoodsReceivingRepository : TypedListRepositoryBase<GoodsReceiving, GoodsReceivingEntry>
    {
        public GoodsReceivingRepository(RecordManager? recordManager = null)
            : base(recordManager) { }

        protected override string EntryParentIdPath => GoodsReceivingEntry.Fields.GoodsReceiving;

        public override GoodsReceiving? Delete(Guid id)
        {
            var deliveryNotes = FindManyDeliveryNotesByGoodsReceiving(id, "id")
                .Select(r => r.Id!.Value)
                .ToArray();

            if (deliveryNotes.Length == 0)
                return base.Delete(id);

            var response = RecordManager.DeleteRecords(DeliveryNote.Entity, deliveryNotes);
            if (response.Success)
                return base.Delete(id);

            return null;
        }

        public List<GoodsReceiving> FindManyByOrder(Guid orderId, string select = "*")
            => FindManyBy(GoodsReceiving.Fields.Order, orderId, select);

        public List<GoodsReceiving> FindManyByProject(Guid projectId, string select = "*")
        {
            var subQuery = new OrderRepository(RecordManager).FindManyByProject(projectId, $"id")
                .Select(o => o.Id!.Value)
                .Distinct()
                .Select(oId => new QueryObject()
                {
                    FieldName = GoodsReceiving.Fields.Order,
                    FieldValue = oId,
                    QueryType = QueryType.EQ,
                }).ToList();

            if (subQuery.Count == 0)
                return [];

            var query = subQuery.Count == 1 ? subQuery[0] : new QueryObject()
            {
                QueryType = QueryType.OR,
                SubQueries = subQuery,
            };

            return FindManyByQuery(query, select);
        }

        public List<GoodsReceiving> FindManyByOrders(string select = "*", params Guid[] orders)
        {
            var subQuery = orders
                .Select(oId => new QueryObject()
                {
                    FieldName = GoodsReceiving.Fields.Order,
                    FieldValue = oId,
                    QueryType = QueryType.EQ,

                }).ToList();

            if (subQuery.Count == 0)
                return [];

            var query = subQuery.Count == 1 ? subQuery[0] : new QueryObject()
            {
                QueryType = QueryType.OR,
                SubQueries = subQuery,
            };

            return FindManyByQuery(query, select);
        }

        public List<GoodsReceivingEntry> FindManyEntriesByOrder(Guid orderId, string select = "*")
        {
            var subQuery = FindManyByOrder(orderId, "id")
                .Select(gr => gr.Id!.Value)
                .Distinct()
                .Select(id => new QueryObject()
                {
                    FieldName = GoodsReceivingEntry.Fields.GoodsReceiving,
                    FieldValue = id,
                    QueryType = QueryType.EQ,
                }).ToList();

            if (subQuery.Count == 0)
                return [];

            var query = subQuery.Count == 1 ? subQuery[0] : new QueryObject()
            {
                QueryType = QueryType.OR,
                SubQueries = subQuery,
            };

            return FindManyEntriesByQuery(query, select);
        }

        public List<GoodsReceivingEntry> FindManyEntriesByOrders(string select = "*", params Guid[] orders)
        {
            var subQuery = FindManyByOrders("id", orders)
                .Select(gr => gr.Id)
                .Distinct()
                .Select(grId => new QueryObject()
                {
                    FieldName = GoodsReceivingEntry.Fields.GoodsReceiving,
                    FieldValue = grId,
                    QueryType = QueryType.EQ,
                }).ToList();

            if (subQuery.Count == 0)
                return [];

            var query = subQuery.Count == 1 ? subQuery[0] : new QueryObject()
            {
                QueryType = QueryType.OR,
                SubQueries = subQuery,
            };

            return FindManyEntriesByQuery(query, select);
        }

        public List<GoodsReceivingEntry> FindManyEntriesByGoodsReceiving(Guid goodsReceivingId, string select = "*")
            => FindManyEntriesBy(GoodsReceivingEntry.Fields.GoodsReceiving, goodsReceivingId, select);

        public List<GoodsReceivingEntry> FindManyEntriesByProject(Guid projectId, string select = "*")
        {
            var query = GetFindManyEntriesByProjectQuery(projectId);
            if (query == null)
                return [];
            return FindManyEntriesByQuery(query, select);
        }

        public List<GoodsReceivingEntry> FindManyByProjectAndArticle(Guid projectId, Guid articleId, string select = "*")
        {
            var projectQuery = GetFindManyEntriesByProjectQuery(projectId);
            if(projectQuery == null) 
                return [];

            var query = new QueryObject()
            {
                QueryType = QueryType.AND,
                SubQueries =
                [
                    new QueryObject()
                    {
                        QueryType = QueryType.EQ,
                        FieldName = GoodsReceivingEntry.Fields.Article,
                        FieldValue = articleId
                    },
                    projectQuery
                ]
            };

            return FindManyEntriesByQuery(query, select);
        }

        public bool EntryExists(Guid goodsReceiving, Guid article, Guid? excluded = null)
        {
            var query = new QueryObject()
            {
                QueryType = QueryType.AND,
                SubQueries =
                [
                    new QueryObject()
                    {
                        QueryType = QueryType.EQ,
                        FieldName = GoodsReceivingEntry.Fields.GoodsReceiving,
                        FieldValue = goodsReceiving
                    },
                    new QueryObject()
                    {
                        QueryType = QueryType.EQ,
                        FieldName = GoodsReceivingEntry.Fields.Article,
                        FieldValue = article
                    }
                ]
            };
            if (excluded.HasValue)
                query.SubQueries.Add(ExcludeIdQuery(excluded.Value));

            return EntryExistsByQuery(query);
        }

        private QueryObject? GetFindManyEntriesByProjectQuery(Guid projectId)
        {
            var subQuery = FindManyByProject(projectId, "id")
                .Select(gr => gr.Id!.Value)
                .Distinct()
                .Select(grId => new QueryObject()
                {
                    QueryType = QueryType.EQ,
                    FieldName = GoodsReceivingEntry.Fields.GoodsReceiving,
                    FieldValue = grId
                }).ToList();

            if (subQuery.Count == 0)
                return null;

            return subQuery.Count == 1 ? subQuery[0] : new QueryObject()
            {
                QueryType = QueryType.OR,
                SubQueries = subQuery,
            };
        }

        public DeliveryNote? FindDeliveryNote(Guid id, string select = "*")
            => TypedEntityRecordWrapper.WrapElseDefault<DeliveryNote>(RepositoryHelper.Find(RecordManager, DeliveryNote.Entity, id, select));

        public List<DeliveryNote> FindManyDeliveryNotesByGoodsReceiving(Guid goodsReceivingId, string select = "*")
        {
            return RepositoryHelper.FindManyBy(RecordManager, DeliveryNote.Entity, DeliveryNote.Fields.GoodsReceiving, goodsReceivingId, select)
                .Select(TypedEntityRecordWrapper.Wrap<DeliveryNote>)
                .ToList();
        }

        public DeliveryNote? InsertDeliveryNote(DeliveryNote record)
            => TypedEntityRecordWrapper.WrapElseDefault<DeliveryNote>(RepositoryHelper.Insert(RecordManager, DeliveryNote.Entity, record));

        public DeliveryNote? DeleteDeliveryNote(Guid id)
            => TypedEntityRecordWrapper.WrapElseDefault<DeliveryNote>(RepositoryHelper.Delete(RecordManager, DeliveryNote.Entity, id));
    }
}
