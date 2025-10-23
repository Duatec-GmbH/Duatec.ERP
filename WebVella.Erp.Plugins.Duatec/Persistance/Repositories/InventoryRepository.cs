using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Persistance;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    internal class InventoryRepository : TypedRepositoryBase<InventoryEntry>
    {
        public InventoryRepository(RecordManager? recordManager = null)
            : base(recordManager) { }

        public List<InventoryEntry> FindManyByArticle(Guid articleId)
            => FindManyBy(InventoryEntry.Fields.Article, articleId);

        public List<InventoryEntry> FindManyByProject(Guid? projectId, string select = "*")
            => FindManyBy(InventoryEntry.Fields.Project, projectId, select);

        public bool ExistsByProject(Guid projectId)
            => ExistsBy(InventoryEntry.Fields.Project, projectId);

        public override InventoryEntry? Insert(InventoryEntry record)
        {
            RoundNumbers(record);
            if (record.Amount <= 0)
                throw new ArgumentException("Can not insert inventory entry with amount smaller or equal '0'");

            if(Find(record.Article, record.Denomination, record.WarehouseLocation, record.Project) is InventoryEntry entry)
            {
                entry.Amount += record.Amount;

                if (Update(entry) == null)
                    return null;

                record.Amount = entry.Amount;
                record.Id = entry.Id;

                return record;
            }
            var result = base.Insert(record);

            return result;
        }

        public override List<InventoryEntry> InsertMany(IEnumerable<InventoryEntry> records)
            => records.Select(Insert).Where(ie => ie != null).ToList()!;

        public InventoryEntry? MovePartial(InventoryEntry record)
        {
            RoundNumbers(record);
            var unmodified = Find(record.Id!.Value)!;

            if (unmodified.Amount <= record.Amount)
                throw new ArgumentException("For a partial move the given amount must be smaller than unmodified record amount");

            unmodified.Amount -= record.Amount;

            if (Update(unmodified) != null)
            {
                record.Id = Guid.NewGuid();
                return Insert(record);
            }
            return null;
        }

        public override InventoryEntry? Update(InventoryEntry record)
        {
            RoundNumbers(record);
            if (record.Amount <= 0)
                return Delete(record.Id!.Value);

            var unmodified = Find(record.Id!.Value)!;

            if (unmodified.Project == record.Project
                && unmodified.Article == record.Article 
                && unmodified.WarehouseLocation == record.WarehouseLocation)
            {
                return base.Update(record);
            }

            if (Find(record.Article, record.Denomination, record.WarehouseLocation, record.Project) is InventoryEntry entry)
            {
                entry.Amount += record.Amount;

                if (Delete(record.Id.Value) == null)
                    return null;

                record.Id = entry.Id;
                record.Amount = entry.Amount;

                return base.Update(entry);
            }

            return base.Update(record);
        }

        public InventoryEntry? Find(Guid articleId, decimal denomination, Guid locationId, Guid? projectId, string select = "*")
        {
            var query = new QueryObject()
            {
                QueryType = QueryType.AND,
                SubQueries =
                [
                    new()
                    {
                        FieldName = InventoryEntry.Fields.Article, 
                        FieldValue = articleId, 
                        QueryType = QueryType.EQ
                    },
                    new()
                    {
                        FieldName = InventoryEntry.Fields.WarehouseLocation, 
                        FieldValue = locationId, 
                        QueryType = QueryType.EQ
                    },
                    new() 
                    { 
                        FieldName = InventoryEntry.Fields.Project, 
                        FieldValue = projectId, 
                        QueryType = QueryType.EQ 
                    },
                    new()
                    {
                        FieldName = InventoryEntry.Fields.Denomination,
                        FieldValue = denomination,
                        QueryType = QueryType.EQ,
                    }
                ]
            };
            return FindByQuery(query, select);
        }

        public InventoryBooking? InsertBooking(InventoryBooking record)
        {
            record.Amount = Math.Round(record.Amount, 2);
            return TypedEntityRecordWrapper.Wrap<InventoryBooking>(RepositoryHelper.Insert(RecordManager, record.EntityName, record));
        }

        public List<InventoryBooking> InsertManyBookings(IEnumerable<InventoryBooking> bookings)
        {
            return [.. RepositoryHelper.InsertMany(RecordManager, InventoryBooking.Entity, bookings)
                .Select(TypedEntityRecordWrapper.Wrap<InventoryBooking>)];
        }

        public InventoryBooking? DeleteBooking(Guid id)
            => TypedEntityRecordWrapper.WrapElseDefault<InventoryBooking>(RepositoryHelper.Delete(RecordManager, InventoryBooking.Entity, id));


        public InventoryBooking? ReverseBooking(Guid id)
        {
            var booking = FindBooking(id);
            if (booking == null)
                return null;

            var location = !booking.WarehouseLocationId.HasValue
                ? null : new WarehouseRepository(RecordManager).FindEntry(booking.WarehouseLocationId.Value);

            if (location == null)
                return null;

            if (booking.Kind == InventoryBookingKind.Take)
            {
                var entry = new InventoryEntry()
                {
                    Id = Guid.NewGuid(),
                    Amount = booking.Amount,
                    Article = booking.ArticleId,
                    Project = booking.ProjectSourceId,
                    WarehouseLocation = booking.WarehouseLocationId!.Value,
                    Denomination = booking.Denomination,
                };
                if (Insert(entry) == null)
                    return null;
            }
            else if (booking.Kind == InventoryBookingKind.Store)
            {
                var entry = Find(booking.ArticleId, booking.Denomination, booking.WarehouseLocationId!.Value, booking.ProjectId);

                if (entry == null || entry.Amount < booking.Amount)
                    return null;

                if(entry.Amount == booking.Amount)
                {
                    if (Delete(entry.Id!.Value) == null)
                        return null;
                }
                else
                {
                    entry.Amount -= booking.Amount;
                    if (Update(entry) == null)
                        return null;
                }
            }
            else if(booking.Kind == InventoryBookingKind.Move)
            {
                if (!booking.WarehouseLocationSourceId.HasValue)
                    return null;

                var entry = Find(booking.ArticleId, booking.Denomination, booking.WarehouseLocationId!.Value, booking.ProjectId);

                if (entry == null || entry.Amount < booking.Amount)
                    return null;

                if (entry.Amount == booking.Amount)
                {
                    if (Delete(entry.Id!.Value) == null)
                        return null;
                }
                else
                {
                    entry.Amount -= booking.Amount;
                    if (Update(entry) == null)
                        return null;
                }

                var rec = new InventoryEntry()
                {
                    Article = booking.ArticleId,
                    Amount = booking.Amount,
                    Project = booking.ProjectSourceId,
                    WarehouseLocation = booking.WarehouseLocationSourceId.Value,
                    Denomination = booking.Denomination,
                };

                if (Insert(rec) == null)
                    return null;
            }
            else return null;

            return TypedEntityRecordWrapper.WrapElseDefault<InventoryBooking>(
                RepositoryHelper.Delete(RecordManager, InventoryBooking.Entity, id));
        }

        private InventoryBooking? FindBooking(Guid id, string select = "*")
            => TypedEntityRecordWrapper.Wrap<InventoryBooking>(RepositoryHelper.Find(RecordManager, InventoryBooking.Entity, id, select));

        public List<InventoryBooking> FindManyBookingsByProject(Guid? projectId, string select = "*")
        {
            var query = new QueryObject()
            {
                QueryType = QueryType.OR,
                SubQueries = 
                [
                    new() 
                    {
                        FieldName = InventoryBooking.Fields.ProjectId,
                        FieldValue = projectId,
                        QueryType = QueryType.EQ,
                    },
                    new()
                    {
                        FieldName = InventoryBooking.Fields.ProjectSourceId,
                        FieldValue = projectId,
                        QueryType = QueryType.EQ,
                    }
                ]
            };


            return [..RepositoryHelper.FindManyByQuery(RecordManager, InventoryBooking.Entity, query, select)
                .Select(TypedEntityRecordWrapper.Wrap<InventoryBooking>)];
        }

        public List<InventoryBooking> FindManyBookingsByArticle(Guid articleId, string select = "*")
        {
            return [..RepositoryHelper.FindManyBy(RecordManager, InventoryBooking.Entity, InventoryBooking.Fields.ArticleId, articleId, select)
                .Select(TypedEntityRecordWrapper.Wrap<InventoryBooking>)];
        }

        public Dictionary<(Guid ArticleId, decimal Denomination), decimal> GetReservedArticleAmountLookup(Guid projectId)
        {
            var takenLookup = FindManyBookingsByProject(projectId)
                .Where(be => (be.Kind == InventoryBookingKind.Take && be.ProjectId == projectId || be.Kind == InventoryBookingKind.Store && be.ProjectSourceId == projectId) && be.Amount != 0m)
                .GroupBy(be => (be.ArticleId, be.Denomination))
                .ToDictionary(g => g.Key, g => g
                    .Aggregate(0m, (sum, be) => sum + (be.Kind == InventoryBookingKind.Take ? be.Amount : -be.Amount)));

            foreach(var ie in FindManyByProject(projectId))
            {
                if (takenLookup.ContainsKey((ie.Article, ie.Denomination)))
                    takenLookup[(ie.Article, ie.Denomination)] += ie.Amount;
                else
                    takenLookup[(ie.Article, ie.Denomination)] = ie.Amount;
            }

            return takenLookup;
        }

        public List<InventoryBooking> FindManyBookingsByTaggedRecord(string entityName, Guid id, string select = "*")
        {
            var query = new QueryObject()
            {
                QueryType = QueryType.AND,
                SubQueries = [
                    new()
                    {
                        FieldName = InventoryBooking.Fields.TaggedEntityName,
                        FieldValue = entityName,
                        QueryType = QueryType.EQ
                    },
                    new()
                    {
                        FieldName = InventoryBooking.Fields.TaggedRecordId,
                        FieldValue = id,
                        QueryType = QueryType.EQ
                    },
                ]
            };

            return [..RepositoryHelper.FindManyByQuery(RecordManager, InventoryBooking.Entity, query, select)
                .Select(TypedEntityRecordWrapper.Wrap<InventoryBooking>)];  
        }

        private static void RoundNumbers(InventoryEntry record)
        {
            record.Amount = Math.Round(record.Amount, 2);
            record.Denomination = Math.Round(record.Denomination, 2);
        }
    }
}
