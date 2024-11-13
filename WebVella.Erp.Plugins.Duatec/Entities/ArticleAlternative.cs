using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class ArticleAlternative
    {
        public const string Entity = "article_equivalent";
        public const string Source = "source";
        public const string Target = "target";

        public static Guid[] AllTargetsForSource(Guid id)
        {
            return Record.FindManyBy(Entity, Source, id, Target)
                .Select(r => (Guid)r[Target])
                .ToArray();
        }

        public static void InsertMapping(Guid a, Guid b)
        {
            Insert(a, b);
            Insert(b, a);
        }

        public static void DeleteMapping(Guid a, Guid b)
        {
            Delete(a, b);
            Delete(b, a);
        }

        private static EntityRecord? Find(Guid source, Guid target)
        {
            var subQueries = new List<QueryObject>()
            {
                new() { FieldName = Source, FieldValue = source, QueryType = QueryType.EQ },
                new() { FieldName = Target, FieldValue = target, QueryType = QueryType.EQ },
            };

            var recMan = new RecordManager();
            var response = recMan.Find(new EntityQuery(Entity, "*",
                new QueryObject() { QueryType = QueryType.AND, SubQueries = subQueries }));

            return response.Object.Data.SingleOrDefault();
        }

        private static Guid? Insert(Guid source, Guid target)
        {
            var id = Find(source, target)?["id"] as Guid?;
            if (id.HasValue)
                return id;

            var rec = new EntityRecord();
            rec[Source] = source;
            rec[Target] = target;

            return Record.Insert(Entity, rec);
        }

        private static void Delete(Guid source, Guid target)
        {
            var id = Find(source, target)?["id"] as Guid?;
            if (!id.HasValue)
                return;

            Record.Delete(Entity, id.Value);
        }
    }
}
