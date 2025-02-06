using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
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

        public bool ReservationsExistByProject(Guid projectId)
        {
            var list = FindReservationListByProject(projectId);
            if (list == null)
                return false;

            return RepositoryHelper.Exists(RecordManager, InventoryReservationEntry.Entity, InventoryReservationEntry.Fields.InventoryReservationList, list.Id);
        }

        public override InventoryEntry? Insert(InventoryEntry record)
        {
            RoundAmount(record);
            if (record.Amount <= 0)
                throw new ArgumentException("Can not insert inventory entry with amount smaller or equal '0'");

            if(Find(record.Article, record.WarehouseLocation, record.Project) is InventoryEntry entry)
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

        public InventoryEntry? MovePartial(InventoryEntry record)
        {
            RoundAmount(record);
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
            RoundAmount(record);
            if (record.Amount <= 0)
                return Delete(record.Id!.Value);

            var unmodified = Find(record.Id!.Value)!;

            if (unmodified.Project == record.Project
                && unmodified.Article == record.Article 
                && unmodified.WarehouseLocation == record.WarehouseLocation)
            {
                return base.Update(record);
            }

            if (Find(record.Article, record.WarehouseLocation, record.Project) is InventoryEntry entry)
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

        public List<InventoryEntry> FindManyByArticleAndProject(Guid articleId, Guid? projectId, string select = "*")
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
                        FieldName = InventoryEntry.Fields.Project, 
                        FieldValue = projectId, 
                        QueryType = QueryType.EQ 
                    },
                ]
            };
            return FindManyByQuery(query, select);
        }

        public InventoryEntry? Find(Guid articleId, Guid locationId, Guid? projectId, string select = "*")
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
                ]
            };
            return FindByQuery(query, select);
        }

        public InventoryBooking? InsertBooking(InventoryBooking record)
        {
            record.Amount = Math.Round(record.Amount, 2);
            return TypedEntityRecordWrapper.Wrap<InventoryBooking>(RepositoryHelper.Insert(RecordManager, record.EntityName, record));
        }

        public InventoryReservation? FindReservationListByProject(Guid projectId, string select = "*")
        {
            var rec = RepositoryHelper.FindBy(RecordManager, InventoryReservation.Entity, InventoryReservation.Fields.Project, projectId, select);
            return TypedEntityRecordWrapper.WrapElseDefault<InventoryReservation>(rec);
        }

        public List<InventoryReservationEntry> FindManyReservationEntriesByProject(Guid projectId, string select = "*")
        {
            var list = FindReservationListByProject(projectId, "id")?.Id;
            if (!list.HasValue || list == Guid.Empty)
                return [];

            return RepositoryHelper.FindManyBy(RecordManager, InventoryReservationEntry.Entity, InventoryReservationEntry.Fields.InventoryReservationList, list, select)
                .Select(TypedEntityRecordWrapper.WrapElseDefault<InventoryReservationEntry>)
                .ToList()!;
        }

        public InventoryReservationEntry? FindReservationEntryByProjectAndArticle(Guid projectId, Guid articleId)
        {
            var listId = FindReservationListByProject(projectId)?.Id;
            if (!listId.HasValue)
                return null;

            var query = new QueryObject()
            {
                QueryType = QueryType.AND,
                SubQueries =
                [
                    new(){
                        QueryType = QueryType.EQ,
                        FieldName = InventoryReservationEntry.Fields.Article,
                        FieldValue = articleId,
                    },
                    new(){
                        QueryType = QueryType.EQ,
                        FieldName = InventoryReservationEntry.Fields.InventoryReservationList,
                        FieldValue = listId.Value
                    }
                ]
            };

            return TypedEntityRecordWrapper.WrapElseDefault<InventoryReservationEntry>(
                RepositoryHelper.FindByQuery(RecordManager, InventoryReservationEntry.Entity, query));
        }

        public InventoryReservationEntry? Reserve(Guid articleId, Guid projectId, decimal amount)
        {
            var reservation = FindReservationEntryByProjectAndArticle(projectId, articleId);
            if(reservation == null)
            {
                var list = FindReservationListByProject(projectId)
                    ?? InsertReservationList(new InventoryReservation() { Id = Guid.NewGuid(), Project = projectId })
                    ?? throw new DbException("Could not create reservation list");

                reservation = new InventoryReservationEntry()
                {
                    Article = articleId,
                    Amount = amount,
                    InventoryReservationList = list.Id!.Value,
                };
                return InsertReservationEntry(reservation);
            }
            else
            {
                reservation.Amount += amount;
                return UpdateReservationEntry(reservation);
            }
        }

        public InventoryReservationEntry? Unreserve(InventoryReservationEntry reservation, decimal amount)
        {
            if (reservation.Amount == amount)
                return DeleteReservationEntry(reservation.Id!.Value);
            if (reservation.Amount > amount)
            {
                reservation.Amount -= amount;
                return UpdateReservationEntry(reservation);
            }
            throw new ArgumentException($"Amount is greater than reserved amount ({reservation.Amount})");
        }

        private InventoryReservation? InsertReservationList(InventoryReservation record)
        {
            return TypedEntityRecordWrapper.WrapElseDefault<InventoryReservation>(
                RepositoryHelper.Insert(RecordManager, InventoryReservation.Entity, record));
        }

        private InventoryReservationEntry? UpdateReservationEntry(InventoryReservationEntry record)
        {
            return TypedEntityRecordWrapper.WrapElseDefault<InventoryReservationEntry>(
                RepositoryHelper.Update(RecordManager, InventoryReservationEntry.Entity, record));
        }

        private InventoryReservationEntry? InsertReservationEntry(InventoryReservationEntry record)
        {
            return TypedEntityRecordWrapper.WrapElseDefault<InventoryReservationEntry>(
                RepositoryHelper.Insert(RecordManager, InventoryReservationEntry.Entity, record));
        }

        private InventoryReservationEntry? DeleteReservationEntry(Guid inventoryReservationId)
        {
            return TypedEntityRecordWrapper.WrapElseDefault<InventoryReservationEntry>(
                RepositoryHelper.Delete(RecordManager, InventoryReservationEntry.Entity, inventoryReservationId));
        }

        private static void RoundAmount(InventoryEntry record)
            => record.Amount = Math.Round(record.Amount, 2);
    }
}
