﻿using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    internal class OrderRepository : RepositoryBase<Order>
    {
        public override string Entity => Order.Entity;

        protected override Order? MapToTypedRecord(EntityRecord? record)
            => Order.Create(record);

        public List<Order> FindManyByProject(Guid projectId, string select = "*")
            => FindManyBy(Order.Fields.Project, projectId, select);

        public List<Order> FindManyByProjectAndArticle(Guid projectId, Guid articleId, string select = "*")
        {
            var entries = FindManyEntriesByProjectAndArticle(projectId, articleId);
            if (entries.Count == 0)
                return [];

            var query = new QueryObject()
            {
                QueryType = QueryType.OR,
                SubQueries = entries
                    .Select(e => e.Order)
                    .Distinct()
                    .Select(id => new QueryObject()
                    {
                        QueryType = QueryType.EQ,
                        FieldName = "id",
                        FieldValue = id,
                    }).ToList()
            };

            return FindManyByQuery(query);
        }

        public List<OrderEntry> FindManyEntriesByProject(Guid projectId, string select = "*")
        {
            var query = OrdersByProjectQuery(projectId);
            return FindManyEntriesByQuery(query, select);
        }

        public List<OrderEntry> FindManyEntriesByProjectAndArticle(Guid projectId, Guid articleId, string select = "*")
        {
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
                    OrdersByProjectQuery(projectId)
                ]
            };

            return FindManyEntriesByQuery(query, select);
        }

        private static List<OrderEntry> FindManyEntriesByQuery(QueryObject query, string select)
        {
            return Record.FindManyByQuery(OrderEntry.Entity, query, select)
                .Select(OrderEntry.Create)
                .ToList()!;
        }

        private QueryObject OrdersByProjectQuery(Guid projectId)
        {
            return new()
            {
                QueryType = QueryType.OR,
                SubQueries = FindManyByProject(projectId)
                    .Select(o => new QueryObject()
                    {
                        QueryType = QueryType.EQ,
                        FieldName = OrderEntry.Fields.Order,
                        FieldValue = o.Id!.Value
                    }).ToList()
            };
        }
    }
}
