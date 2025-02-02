﻿using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords.Persistance;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    internal class OrderRepository : TypedListRepositoryBase<Order, OrderEntry>
    {
        public OrderRepository(RecordManager? recordManager = null)
            : base(recordManager) { }

        protected override string EntryParentIdPath => OrderEntry.Fields.Order;

        public List<Order> FindManyByProject(Guid projectId, string select = "*")
            => FindManyBy(Order.Fields.Project, projectId, select);

        public List<Order> FindManyByProjectAndArticle(Guid projectId, Guid articleId, string select = "*")
        {
            var entries = FindManyEntriesByProjectAndArticle(projectId, articleId)
                .Select(e => e.Order)
                .Distinct()
                .ToArray();

            if (entries.Length == 0)
                return [];

            var query = new QueryObject()
            {
                QueryType = QueryType.OR,
                SubQueries = entries.Select(id => new QueryObject()
                    {
                        QueryType = QueryType.EQ,
                        FieldName = "id",
                        FieldValue = id,
                    }).ToList()
            };

            return FindManyByQuery(query, select);
        }

        public OrderEntry? FindEntryByOrderAndArticle(Guid orderId, Guid articleId, Guid? excludedId = null, string select = "*")
        {
            var query = new QueryObject()
            {
                QueryType = QueryType.AND,
                SubQueries =
                [
                    new QueryObject()
                    {
                        QueryType = QueryType.EQ,
                        FieldName = OrderEntry.Fields.Order,
                        FieldValue = orderId,
                    },
                    new QueryObject()
                    {
                        QueryType = QueryType.EQ,
                        FieldName = OrderEntry.Fields.Article,
                        FieldValue = articleId,
                    }
                ]
            };
            if (excludedId.HasValue && excludedId != Guid.Empty)
                query.SubQueries.Add(ExcludeIdQuery(excludedId.Value));

            return FindEntryByQuery(query, select);
        }

        public List<OrderEntry> FindManyEntriesByOrder(Guid orderId, string select = "*")
            => FindManyEntriesBy(OrderEntry.Fields.Order, orderId, select);

        public List<OrderEntry> FindManyEntriesByProject(Guid projectId, string select = "*")
        {
            var query = OrdersByProjectQuery(projectId);
            if (query == null)
                return [];
            return FindManyEntriesByQuery(query, select);
        }

        public List<OrderEntry> FindManyEntriesByProjectAndArticle(Guid projectId, Guid articleId, string select = "*")
        {
            var ordersByProjectQuery = OrdersByProjectQuery(projectId);
            if (ordersByProjectQuery == null)
                return [];

            var query = new QueryObject()
            {
                QueryType = QueryType.AND,
                SubQueries =
                [
                    new()
                    {
                        QueryType = QueryType.EQ,
                        FieldName = OrderEntry.Fields.Article,
                        FieldValue = articleId
                    },
                    ordersByProjectQuery
                ]
            };

            return FindManyEntriesByQuery(query, select);
        }

        private QueryObject? OrdersByProjectQuery(Guid projectId)
        {
            var subQuery = FindManyByProject(projectId)
                .Select(o => new QueryObject()
                {
                    QueryType = QueryType.EQ,
                    FieldName = OrderEntry.Fields.Order,
                    FieldValue = o.Id!.Value
                }).ToList();

            if (subQuery.Count == 0)
                return null;

            return subQuery.Count == 1 ? subQuery[0] : new()
            {
                QueryType = QueryType.OR,
                SubQueries = subQuery
            };
        }
    }
}
