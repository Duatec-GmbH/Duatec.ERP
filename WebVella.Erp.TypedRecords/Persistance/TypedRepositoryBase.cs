﻿using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.TypedRecords.Persistance
{
    public abstract class TypedRepositoryBase<T> where T : TypedEntityRecordWrapper, new()
    {
        protected TypedRepositoryBase(RecordManager? record)
        {
            RecordManager = record ?? new RecordManager();
        }

        protected RecordManager RecordManager { get; }

        protected string Entity { get; } = new T().EntityName;

        public T? Find(Guid id, string select = "*")
            => TypedEntityRecordWrapper.WrapElseDefault<T>(RepositoryHelper.Find(RecordManager, Entity, id, select));

        public bool Exists(Guid id)
            => RepositoryHelper.Exists(RecordManager, Entity, "id", id);

        public virtual T? Insert(T record)
            => TypedEntityRecordWrapper.WrapElseDefault<T>(RepositoryHelper.Insert(RecordManager, Entity, record));

        public virtual List<T> InsertMany(IEnumerable<T> records)
            => RepositoryHelper.InsertMany(RecordManager, Entity, records).Select(TypedEntityRecordWrapper.Wrap<T>).ToList();

        public virtual T? Update(T record)
            => TypedEntityRecordWrapper.WrapElseDefault<T>(RepositoryHelper.Update(RecordManager, Entity, record));

        public virtual T? Delete(Guid id)
            => TypedEntityRecordWrapper.WrapElseDefault<T>(RepositoryHelper.Delete(RecordManager, Entity, id));

        public virtual List<T> DeleteMany(params Guid[] ids)
            => RepositoryHelper.DeleteMany(RecordManager, Entity, ids).Select(TypedEntityRecordWrapper.Wrap<T>).ToList();

        public List<T> FindAll(string select = "*")
            => RepositoryHelper.FindMany(RecordManager, Entity, select).Select(TypedEntityRecordWrapper.Wrap<T>).ToList();

        public Dictionary<Guid, T?> FindMany(string select = "*", params Guid[] ids)
        {
            return RepositoryHelper.FindManyByUniqueArgs(RecordManager, Entity, "id", select, ids)
                .ToDictionary(kp => kp.Key, kp => TypedEntityRecordWrapper.WrapElseDefault<T>(kp.Value));
        }

        protected T? FindBy(string property, object? value, string select = "*")
            => TypedEntityRecordWrapper.WrapElseDefault<T>(RepositoryHelper.FindBy(RecordManager, Entity, property, value, select));

        protected bool ExistsBy(string property, object? value)
            => RepositoryHelper.Exists(RecordManager, Entity, property, value);

        protected List<T> FindManyBy(string property, object? value, string select = "*")
            => RepositoryHelper.FindManyBy(RecordManager, Entity, property, value, select).Select(TypedEntityRecordWrapper.Wrap<T>).ToList();

        protected Dictionary<TKey, T?> FindManyByUniqueArgs<TKey>(string property, string select = "*", params TKey[] args)
            where TKey : notnull
        {
            return RepositoryHelper.FindManyByUniqueArgs(RecordManager, Entity, property, select, args)
                .ToDictionary(kp => kp.Key, kp => TypedEntityRecordWrapper.WrapElseDefault<T>(kp.Value))!;
        }

        protected bool ExistsByQuery(QueryObject query)
            => RepositoryHelper.ExistsByQuery(RecordManager, Entity, query);

        protected List<T> FindManyByQuery(QueryObject query, string select = "*")
            => RepositoryHelper.FindManyByQuery(RecordManager, Entity, query, select).Select(TypedEntityRecordWrapper.Wrap<T>).ToList()!;

        protected T? FindByQuery(QueryObject query, string select = "*")
            => TypedEntityRecordWrapper.WrapElseDefault<T>(RepositoryHelper.FindByQuery(RecordManager, Entity, query, select));

        protected static QueryObject ExcludeIdQuery(Guid excludedId)
        {
            return new()
            {
                QueryType = QueryType.NOT,
                SubQueries =
                [
                    new()
                    {
                        FieldName = "id",
                        FieldValue = excludedId,
                        QueryType = QueryType.EQ
                    }
                ]
            };
        }
    }
}
