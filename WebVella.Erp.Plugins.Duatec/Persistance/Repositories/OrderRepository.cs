using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords;
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

        public override Order? Delete(Guid id)
        {
            DeleteConfirmations(id);
            DeleteBills(id);
            return base.Delete(id);
        }

        public OrderEntry? FindEntryByOrderAndArticle(Guid orderId, Guid articleId, decimal denomination, Guid? excludedId = null, string select = "*")
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
                    },
                    new QueryObject()
                    {
                        QueryType = QueryType.EQ,
                        FieldName = OrderEntry.Fields.Denomination,
                        FieldValue = denomination,
                    }
                ]
            };
            if (excludedId.HasValue && excludedId != Guid.Empty)
                query.SubQueries.Add(ExcludeIdQuery(excludedId.Value));

            return FindEntryByQuery(query, select);
        }

        public List<OrderEntry> FindManyEntriesByArticle(Guid articleId, string select = "*")
        {
            var query = new QueryObject()
            {
                QueryType = QueryType.EQ,
                FieldName = OrderEntry.Fields.Article,
                FieldValue = articleId,
            };

            return FindManyEntriesByQuery(query, select);
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

        public List<OrderConfirmation> InsertConfirmations(List<OrderConfirmation> confirmations)
        {
            var result = new List<OrderConfirmation>(confirmations.Count);
            foreach(var confirmation in confirmations)
            {
                var rec = RepositoryHelper.Insert(RecordManager, OrderConfirmation.Entity, confirmation);
                result.Add(TypedEntityRecordWrapper.Wrap<OrderConfirmation>(rec));
            }
            return result;
        }

        public List<OrderConfirmation> UpdateConfirmations(Guid orderId, List<OrderConfirmation> confirmations)
        {
            if (confirmations.Count > 0)
            {
                if (!confirmations.TrueForAll(c => c.OrderId == orderId))
                    throw new DbException("confirmations must be from same order");
            }

            var oldConfirmations = FindConfirmations(orderId);

            var newConfirmations = confirmations
                .Where(c => !oldConfirmations.Exists(con => c.path == con.path))
                .ToList();

            var toDelete = oldConfirmations
                .Where(c => !confirmations.Exists(con => c.path == con.path))
                .ToList();

            var result = oldConfirmations
                .Where(c => confirmations.Exists(con => c.path == con.path))
                .ToList();

            foreach (var c in toDelete)
                RepositoryHelper.Delete(RecordManager, OrderConfirmation.Entity, c.Id!.Value);

            result.AddRange(InsertConfirmations(newConfirmations));

            return result;
        }

        private void DeleteConfirmations(Guid orderId)
        {
            var files = FindConfirmations(orderId);
            if (files.Count == 0)
                return;

            var ids = files.Select(f => f.Id!.Value)
                .ToArray();

            foreach (var id in ids)
                RepositoryHelper.Delete(RecordManager, OrderConfirmation.Entity, id);
        }
        
        private List<OrderConfirmation> FindConfirmations(Guid orderId)
        {
            return RepositoryHelper.FindManyBy(RecordManager, OrderConfirmation.Entity, OrderConfirmation.Fields.OrderId, orderId)
                .Select(TypedEntityRecordWrapper.Wrap<OrderConfirmation>)
                .ToList();
        }

        public List<OrderBill> InsertBills(List<OrderBill> bills)
        {
            var result = new List<OrderBill>(bills.Count);
            foreach (var bill in bills)
            {
                var rec = RepositoryHelper.Insert(RecordManager, OrderBill.Entity, bill);
                result.Add(TypedEntityRecordWrapper.Wrap<OrderBill>(rec));
            }
            return result;
        }

        public List<OrderBill> UpdateBills(Guid orderId, List<OrderBill> bills)
        {
            if (bills.Count > 0)
            {
                if (!bills.TrueForAll(c => c.OrderId == orderId))
                    throw new DbException("bills must be from same order");
            }

            var oldBills = FindBills(orderId);

            var newBills = bills
                .Where(bill => !oldBills.Exists(b => bill.path == b.path))
                .ToList();

            var toDelete = oldBills
                .Where(bill => !bills.Exists(b => bill.path == b.path))
                .ToList();

            var result = oldBills
                .Where(bill => bills.Exists(b => bill.path == b.path))
                .ToList();

            foreach (var bill in toDelete)
                RepositoryHelper.Delete(RecordManager, OrderBill.Entity, bill.Id!.Value);

            result.AddRange(InsertBills(newBills));

            return result;
        }

        private void DeleteBills(Guid orderId)
        {
            var files = FindBills(orderId);
            if (files.Count == 0)
                return;

            var ids = files.Select(f => f.Id!.Value)
                .ToArray();

            foreach (var id in ids)
                RepositoryHelper.Delete(RecordManager, OrderBill.Entity, id);
        }

        private List<OrderBill> FindBills(Guid orderId)
        {
            return [..RepositoryHelper.FindManyBy(RecordManager, OrderBill.Entity, OrderBill.Fields.OrderId, orderId)
                .Select(TypedEntityRecordWrapper.Wrap<OrderBill>)];
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
