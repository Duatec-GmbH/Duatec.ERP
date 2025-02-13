using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.TypedRecords.Persistance
{
    public abstract class TypedListRepositoryBase<TList, TEntry> : TypedRepositoryBase<TList>
        where TList : TypedEntityRecordWrapper, new()
        where TEntry : TypedEntityRecordWrapper, new()
    {
        protected TypedListRepositoryBase(RecordManager? recordManager = null)
            : base(recordManager) { }

        protected string EntryEntity { get; } = new TEntry().EntityName;

        protected abstract string EntryParentIdPath { get; }

        public override TList? Delete(Guid id)
        {
            var children = FindManyEntriesBy(EntryParentIdPath, id)
                .Select(e => e.Id!.Value)
                .ToArray();

            if(children.Length > 0)
            {
                TList? result = null;
                var recMan = new RecordManager();

                recMan.DeleteRecords(EntryEntity, children);

                result = base.Delete(id);
                return result;
            }

            return base.Delete(id);
        }

        public virtual TEntry? InsertEntry(TEntry record)
            => TypedEntityRecordWrapper.WrapElseDefault<TEntry>(RepositoryHelper.Insert(RecordManager, EntryEntity, record));

        public virtual List<TEntry> InsertManyEntries(IEnumerable<TEntry> records)
            => RepositoryHelper.InsertMany(RecordManager, EntryEntity, records).Select(TypedEntityRecordWrapper.Wrap<TEntry>).ToList();

        public TEntry? FindEntry(Guid id, string select = "*")
            => TypedEntityRecordWrapper.WrapElseDefault<TEntry>(RepositoryHelper.Find(RecordManager, EntryEntity, id, select));

        public bool EntryExists(Guid id)
            => RepositoryHelper.Exists(RecordManager, EntryEntity, "id", id);

        public virtual TEntry? UpdateEntry(TEntry record)
            => TypedEntityRecordWrapper.WrapElseDefault<TEntry>(RepositoryHelper.Update(RecordManager, EntryEntity, record));

        public virtual TEntry? DeleteEntry(Guid id)
            => TypedEntityRecordWrapper.WrapElseDefault<TEntry>(RepositoryHelper.Delete(RecordManager, EntryEntity, id));

        public virtual List<TEntry> DeleteManyEntries(params Guid[] ids)
            => RepositoryHelper.DeleteMany(RecordManager, EntryEntity, ids).Select(TypedEntityRecordWrapper.Wrap<TEntry>).ToList();

        protected TEntry? FindEntryBy(string property, object? value, string select = "*")
            => TypedEntityRecordWrapper.WrapElseDefault<TEntry>(RepositoryHelper.FindBy(RecordManager, EntryEntity, property, value, select));

        protected bool EntryExistsBy(string property, object? value)
            => RepositoryHelper.Exists(RecordManager, EntryEntity, property, value);

        public List<TEntry> FindAllEntries(string select = "*")
            => RepositoryHelper.FindMany(RecordManager, EntryEntity, select).Select(TypedEntityRecordWrapper.Wrap<TEntry>).ToList();

        public Dictionary<Guid, TEntry?> FindManyEntries(string select = "*", params Guid[] ids)
        {
            return RepositoryHelper.FindManyByUniqueArgs(RecordManager, EntryEntity, "id", select, ids)
                .ToDictionary(kp => kp.Key, kp => TypedEntityRecordWrapper.WrapElseDefault<TEntry>(kp.Value));
        }

        protected List<TEntry> FindManyEntriesBy(string property, object? value, string select = "*")
            => RepositoryHelper.FindManyBy(RecordManager, EntryEntity, property, value, select).Select(TypedEntityRecordWrapper.Wrap<TEntry>).ToList();

        protected Dictionary<TKey, TEntry?> FindManyEntriesByUniqueArgs<TKey>(string property, string select = "*", params TKey[] args)
            where TKey : notnull
        {
            return RepositoryHelper.FindManyByUniqueArgs(RecordManager, EntryEntity, property, select, args)
                .ToDictionary(kp => kp.Key, kp => TypedEntityRecordWrapper.WrapElseDefault<TEntry>(kp.Value));
        }

        protected bool EntryExistsByQuery(QueryObject query)
            => RepositoryHelper.ExistsByQuery(RecordManager, EntryEntity, query);

        protected List<TEntry> FindManyEntriesByQuery(QueryObject query, string select = "*")
            => RepositoryHelper.FindManyByQuery(RecordManager, EntryEntity, query, select).Select(TypedEntityRecordWrapper.Wrap<TEntry>).ToList();

        protected TEntry? FindEntryByQuery(QueryObject query, string select = "*")
            => TypedEntityRecordWrapper.WrapElseDefault<TEntry>(RepositoryHelper.FindByQuery(RecordManager, EntryEntity, query, select));
    }
}
