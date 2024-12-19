using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities.Base;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories.Base
{
    public abstract class RepositoryBase<T> where T : TypedEntityRecord
    {
        public abstract string Entity { get; }

        protected abstract T? MapToTypedRecord(EntityRecord? record);

        public T? Find(Guid id, string select = "*")
            => MapToTypedRecord(Record.Find(Entity, id, select));

        public bool Exists(Guid id)
            => Record.Exists(Entity, "id", id);

        public virtual Guid? Insert(T record)
            => Record.Insert(Entity, record);

        public virtual bool Update(T record)
            => Record.Update(Entity, record);

        public virtual bool Delete(Guid id)
            => Record.Delete(Entity, id);

        protected T? FindBy(string property, object? value, string select = "*")
            => MapToTypedRecord(Record.FindBy(Entity, property, value, select));

        protected bool ExistsBy(string property, object? value)
            => Record.Exists(Entity, property, value);

        protected List<T> FindManyBy(string property, object? value, string select = "*")
            => Record.FindManyBy(Entity, property, value, select).Select(MapToTypedRecord).ToList()!;

        protected Dictionary<TKey, T?> FindManyByUniqueArgs<TKey>(string property, string select = "*", params TKey[] args)
            where TKey : notnull
        {
            return Record.FindManyByUniqueArgs(Entity, property, select, args)
                .ToDictionary(kp => kp.Key, kp => MapToTypedRecord(kp.Value));
        }

        protected bool ExistsByQuery(QueryObject query)
            => Record.ExistsByQuery(Entity, query);

        protected List<T> FindManyByQuery(QueryObject query, string select = "*")
            => Record.FindManyByQuery(Entity, query, select).Select(MapToTypedRecord).ToList()!;

        protected T? FindByQuery(QueryObject query, string select = "*")
            => MapToTypedRecord(Record.FindByQuery(Entity, query, select));

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
