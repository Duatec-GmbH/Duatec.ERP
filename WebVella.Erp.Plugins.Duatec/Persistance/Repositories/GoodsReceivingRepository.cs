﻿using Microsoft.CodeAnalysis;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories.Base;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    internal class GoodsReceivingRepository : ListRepositoryBase<GoodsReceiving, GoodsReceivingEntry>
    {
        protected override string EntryParentIdPath => GoodsReceivingEntry.Fields.GoodsReceiving;

        public List<GoodsReceiving> FindManyByOrder(Guid orderId, string select = "*")
            => FindManyBy(GoodsReceiving.Fields.Order, orderId, select);

        public List<GoodsReceiving> FindManyByProject(Guid projectId, string select = "*")
        {
            var subQuery = RepositoryService.OrderRepository.FindManyByProject(projectId, $"id")
                .Select(o => o.Id!.Value)
                .Distinct()
                .Select(oId => new QueryObject()
                {
                    FieldName = GoodsReceiving.Fields.Order,
                    FieldValue = oId,
                    QueryType = QueryType.EQ,
                }).ToList();

            var query = new QueryObject()
            {
                QueryType = QueryType.OR,
                SubQueries = subQuery,
            };

            return FindManyByQuery(query, select);
        }

        public List<GoodsReceivingEntry> FindManyEntriesByGoodsReceiving(Guid goodsReceivingId, string select = "*")
            => FindManyEntriesBy(GoodsReceivingEntry.Fields.GoodsReceiving, goodsReceivingId, select);

        public List<GoodsReceivingEntry> FindManyEntriesByProject(Guid projectId, string select = "*")
            => FindManyEntriesByQuery(GetFindManyEntriesByProjectQuery(projectId), select);

        public List<GoodsReceivingEntry> FindManyByProjectAndArticle(Guid projectId, Guid articleId, string select = "*")
        {
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
                    GetFindManyEntriesByProjectQuery(projectId)
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

        private QueryObject GetFindManyEntriesByProjectQuery(Guid projectId)
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

            return new QueryObject()
            {
                QueryType = QueryType.OR,
                SubQueries = subQuery,
            };
        }

#pragma warning disable CA1822 // Mark members as static

        public DeliveryNote? FindDeliveryNote(Guid id, string select = "*")
            => TypedEntityRecordWrapper.WrapElseDefault<DeliveryNote>(RepositoryHelper.Find(DeliveryNote.Entity, id, select));

        public DeliveryNote? InsertDeliveryNote(DeliveryNote record)
            => TypedEntityRecordWrapper.WrapElseDefault<DeliveryNote>(RepositoryHelper.Insert(DeliveryNote.Entity, record));

        public DeliveryNote? DeleteDeliveryNote(Guid id)
            => TypedEntityRecordWrapper.WrapElseDefault<DeliveryNote>(RepositoryHelper.Delete(DeliveryNote.Entity, id));

#pragma warning restore CA1822 // Mark members as static
    }
}
