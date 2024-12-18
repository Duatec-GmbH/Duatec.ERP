using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    public abstract class RepositoryBase<T> where T : EntityRecordWrapper
    {
        public abstract string Entity { get; }

        protected abstract T? CreateResult(EntityRecord? record);

        public T? Find(Guid id, string select = "*")
            => CreateResult(Record.Find(Entity, id, select));

        public bool Exists(Guid id)
            => Record.Exists(Entity, "id", id);

        public Guid? Insert(T record)
            => Record.Insert(Entity, record);

        public bool Delete(Guid id)
            => Record.Delete(Entity, id);

        protected T? FindBy(string property, object? value)
            => CreateResult(Record.FindBy(Entity, property, value));

        protected bool ExistsBy(string property, object? value)
            => Record.Exists(Entity, property, value);

        protected List<T> FindManyBy(string property, object? value, string select = "*")
            => Record.FindManyBy(Entity, property, value, select).Select(CreateResult).ToList()!;

        protected Dictionary<TKey, T?> FindManyByUniqueArgs<TKey>(string property, string select = "*", params TKey[] args)
            where TKey : notnull
        {
            return Record.FindManyByUniqueArgs(Entity, property, select, args)
                .ToDictionary(kp => kp.Key, kp => CreateResult(kp.Value));
        }

        protected List<T> FindManyByQuery(QueryObject query, string select = "*")
            => Record.FindManyByQuery(Entity, query, select).Select(CreateResult).ToList()!;

        protected T? FindByQuery(QueryObject query, string select = "*")
            => CreateResult(Record.FindByQuery(Entity, query, select));

    }
}
