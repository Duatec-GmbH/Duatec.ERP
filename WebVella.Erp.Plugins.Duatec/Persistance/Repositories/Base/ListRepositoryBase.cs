using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities.Base;
using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories.Base
{
    internal abstract class ListRepositoryBase<TList, TEntry> : RepositoryBase<TList>
        where TList : TypedEntityRecord
        where TEntry : TypedEntityRecord
    {
        protected abstract string EntryEntity { get; }

        protected abstract string EntryParentIdPath { get; }

        protected abstract TEntry? MapEntryToTypedRecord(EntityRecord? record);

        public override bool Delete(Guid id)
        {
            var children = FindManyEntriesBy(EntryParentIdPath, id)
                .ToIdArray();

            if(children.Length > 0)
            {
                Transactional.TryExecute(() =>
                {
                    var recMan = new RecordManager();
                    recMan.DeleteRecords(EntryEntity, children);
                });
            }

            return base.Delete(id);
        }

        public TEntry? FindEntry(Guid id, string select = "*")
            => MapEntryToTypedRecord(Record.Find(EntryEntity, id, select));

        public bool EntryExists(Guid id)
            => Record.Exists(EntryEntity, "id", id);

        public Guid? Insert(TEntry record)
            => Record.Insert(EntryEntity, record);

        public bool UpdateEntry(TEntry record)
            => Record.Update(EntryEntity, record);

        public bool DeleteEntry(Guid id)
            => Record.Delete(EntryEntity, id);

        protected TEntry? FindEntryBy(string property, object? value, string select = "*")
            => MapEntryToTypedRecord(Record.FindBy(EntryEntity, property, value, select));

        protected bool EntryExistsBy(string property, object? value)
            => Record.Exists(EntryEntity, property, value);

        protected List<TEntry> FindManyEntriesBy(string property, object? value, string select = "*")
            => Record.FindManyBy(EntryEntity, property, value, select).Select(MapEntryToTypedRecord).ToList()!;

        protected Dictionary<TKey, TEntry?> FindManyEntriesByUniqueArgs<TKey>(string property, string select = "*", params TKey[] args)
            where TKey : notnull
        {
            return Record.FindManyByUniqueArgs(EntryEntity, property, select, args)
                .ToDictionary(kp => kp.Key, kp => MapEntryToTypedRecord(kp.Value));
        }

        protected bool EntryExistsByQuery(QueryObject query)
            => Record.ExistsByQuery(EntryEntity, query);

        protected List<TEntry> FindManyEntriesByQuery(QueryObject query, string select = "*")
            => Record.FindManyByQuery(EntryEntity, query, select).Select(MapEntryToTypedRecord).ToList()!;

        protected TEntry? FindEntryByQuery(QueryObject query, string select = "*")
            => MapEntryToTypedRecord(Record.FindByQuery(EntryEntity, query, select));
    }
}
