using WebVella.Erp.Api.Models;
using WebVella.TypedRecords.Common;

namespace WebVella.TypedRecords.Persistance
{
    public abstract class TypedRepositoryBase<T> where T : TypedEntityRecordWrapper, new()
    {
        protected string Entity { get; } = new T().EntityName;

        public T? Find(Guid id, string select = "*")
            => TypedEntityRecordWrapper.WrapElseDefault<T>(RepositoryHelper.Find(Entity, id, select));

        public bool Exists(Guid id)
            => RepositoryHelper.Exists(Entity, "id", id);

        public virtual Guid? Insert(T record)
            => RepositoryHelper.Insert(Entity, record);

        public virtual bool Update(T record)
            => RepositoryHelper.Update(Entity, record);

        public virtual bool Delete(Guid id)
            => RepositoryHelper.Delete(Entity, id);

        protected T? FindBy(string property, object? value, string select = "*")
            => TypedEntityRecordWrapper.WrapElseDefault<T>(RepositoryHelper.FindBy(Entity, property, value, select));

        protected bool ExistsBy(string property, object? value)
            => RepositoryHelper.Exists(Entity, property, value);

        protected List<T> FindManyBy(string property, object? value, string select = "*")
            => RepositoryHelper.FindManyBy(Entity, property, value, select).Select(TypedEntityRecordWrapper.Wrap<T>).ToList();

        protected Dictionary<TKey, T?> FindManyByUniqueArgs<TKey>(string property, string select = "*", params TKey[] args)
            where TKey : notnull
        {
            return RepositoryHelper.FindManyByUniqueArgs(Entity, property, select, args)
                .ToDictionary(kp => kp.Key, kp => TypedEntityRecordWrapper.WrapElseDefault<T>(kp.Value))!;
        }

        protected bool ExistsByQuery(QueryObject query)
            => RepositoryHelper.ExistsByQuery(Entity, query);

        protected List<T> FindManyByQuery(QueryObject query, string select = "*")
            => RepositoryHelper.FindManyByQuery(Entity, query, select).Select(TypedEntityRecordWrapper.Wrap<T>).ToList()!;

        protected T? FindByQuery(QueryObject query, string select = "*")
            => TypedEntityRecordWrapper.WrapElseDefault<T>(RepositoryHelper.FindByQuery(Entity, query, select));

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
