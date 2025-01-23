using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories.Base;
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

        public List<InventoryEntry> FindManyByProject(Guid? projectId)
            => FindManyBy(InventoryEntry.Fields.Project, projectId);

        public bool ExistsByProject(Guid projectId)
            => ExistsBy(InventoryEntry.Fields.Project, projectId);

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
            return base.Insert(record);
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

#pragma warning disable CA1822 // Mark members as static
        public InventoryReservationList? FindReservationListByProject(Guid projectId, string select = "*")
        {
            var rec = RepositoryHelper.FindBy(InventoryReservationList.Entity, InventoryReservationList.Fields.Project, projectId, select);
            return TypedEntityRecordWrapper.WrapElseDefault<InventoryReservationList>(rec);
        }

        public List<InventoryReservationEntry> FindManyReservationEntriesByProject(Guid projectId, string select = "*")
        {
            var list = FindReservationListByProject(projectId)?.Id;
            if (!list.HasValue || list == Guid.Empty)
                return [];

            return RepositoryHelper.FindManyBy(InventoryReservationEntry.Entity, InventoryReservationEntry.Fields.InventoryReservationList, list, select)
                .Select(TypedEntityRecordWrapper.WrapElseDefault<InventoryReservationEntry>)
                .ToList()!;
        }

        public Dictionary<string, InventoryReservationEntry?> FindManyReservationEntriesByProjectAndArticle(
            Guid projectId, params string[] partNumbers)
        {
            const string articleRelation = $"${InventoryReservationEntry.Relations.Article}";
            const string select = $"{articleRelation}.{Article.Fields.PartNumber}";

            var partNumberLookup = partNumbers.ToHashSet();
            var entries = FindManyReservationEntriesByProject(projectId, select)
                .Where(r => GetPartNumberFromInventoryReservationEntry(r) is string pn && partNumberLookup.Contains(pn));

            var result = partNumbers.ToDictionary(pn => pn, _ => default(InventoryReservationEntry));
            foreach (var entry in entries)
            {
                var pn = GetPartNumberFromInventoryReservationEntry(entry);
                if (pn == null || result[pn] != null)
                    throw new DbException($"Inconsistent data at entity '{Entity}' part number '{pn}'");

                entry.Properties.Remove(articleRelation);
                result[pn] = entry;
            }
            return result;
        }


#pragma warning restore CA1822 // Mark members as static

        private static string? GetPartNumberFromInventoryReservationEntry(InventoryReservationEntry rec)
        {
            const string articleRelation = $"${InventoryReservationEntry.Relations.Article}";
            return (rec[articleRelation] as List<EntityRecord>)?.FirstOrDefault()?[Article.Fields.PartNumber] as string;
        }

        private static void RoundAmount(InventoryEntry record)
            => record.Amount = Math.Round(record.Amount, 2);
    }
}
