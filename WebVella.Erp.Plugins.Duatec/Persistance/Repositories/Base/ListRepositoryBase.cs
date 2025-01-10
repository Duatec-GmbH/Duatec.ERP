using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.TypedRecords;
using WebVella.TypedRecords.Persistance;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories.Base
{
    internal abstract class ListRepositoryBase<TList, TEntry> : TypedRepositoryBase<TList>
        where TList : TypedEntityRecordWrapper, new()
        where TEntry : TypedEntityRecordWrapper, new()
    {
        protected string EntryEntity { get; } = new TEntry().EntityName;

        protected abstract string EntryParentIdPath { get; }

        protected TList? MapToTypedRecord(EntityRecord? record)
            => TypedEntityRecordWrapper.WrapElseDefault<TList>(record);

        protected TEntry? MapEntryToTypedRecord(EntityRecord? record)
            => TypedEntityRecordWrapper.WrapElseDefault<TEntry>(record);

        public override bool Delete(Guid id)
        {
            var children = FindManyEntriesBy(EntryParentIdPath, id)
                .ToIdArray();

            if(children.Length > 0)
            {
                return Transactional.TryExecute(() =>
                {
                    var recMan = new RecordManager();
                    recMan.DeleteRecords(EntryEntity, children);

                    base.Delete(id);
                });
            }

            return base.Delete(id);
        }

        public TEntry? FindEntry(Guid id, string select = "*")
            => MapEntryToTypedRecord(RepositoryHelper.Find(EntryEntity, id, select));

        public bool EntryExists(Guid id)
            => RepositoryHelper.Exists(EntryEntity, "id", id);

        public Guid? Insert(TEntry record)
            => RepositoryHelper.Insert(EntryEntity, record);

        public bool UpdateEntry(TEntry record)
            => RepositoryHelper.Update(EntryEntity, record);

        public bool DeleteEntry(Guid id)
            => RepositoryHelper.Delete(EntryEntity, id);

        protected TEntry? FindEntryBy(string property, object? value, string select = "*")
            => MapEntryToTypedRecord(RepositoryHelper.FindBy(EntryEntity, property, value, select));

        protected bool EntryExistsBy(string property, object? value)
            => RepositoryHelper.Exists(EntryEntity, property, value);

        protected List<TEntry> FindManyEntriesBy(string property, object? value, string select = "*")
            => RepositoryHelper.FindManyBy(EntryEntity, property, value, select).Select(MapEntryToTypedRecord).ToList()!;

        protected Dictionary<TKey, TEntry?> FindManyEntriesByUniqueArgs<TKey>(string property, string select = "*", params TKey[] args)
            where TKey : notnull
        {
            return RepositoryHelper.FindManyByUniqueArgs(EntryEntity, property, select, args)
                .ToDictionary(kp => kp.Key, kp => MapEntryToTypedRecord(kp.Value));
        }

        protected bool EntryExistsByQuery(QueryObject query)
            => RepositoryHelper.ExistsByQuery(EntryEntity, query);

        protected List<TEntry> FindManyEntriesByQuery(QueryObject query, string select = "*")
            => RepositoryHelper.FindManyByQuery(EntryEntity, query, select).Select(MapEntryToTypedRecord).ToList()!;

        protected TEntry? FindEntryByQuery(QueryObject query, string select = "*")
            => MapEntryToTypedRecord(RepositoryHelper.FindByQuery(EntryEntity, query, select));
    }
}
