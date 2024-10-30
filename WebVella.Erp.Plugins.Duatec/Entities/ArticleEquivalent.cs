using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Eql;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class ArticleEquivalent
    {
        public const string Entity = "article_equivalent";
        public const string Source = "source";
        public const string Target = "target";

        public static Guid[] AllTargetsForSource(Guid id)
        {
            var cmd = new EqlCommand($"select {Target} from {Entity} " +
                $"where {Source} = @id",
                new EqlParameter("id", id));

            return cmd.Execute()
                .Select(eq => (Guid)eq[Target])
                .ToArray();
        }

        public static bool Exists(Guid source, Guid target)
        {
            var cmd = new EqlCommand($"select id from {Entity} where {Source} = @source and {Target} = @target",
                new EqlParameter("source", source),
                new EqlParameter("target", target));

            return QueryResults.Exists(cmd.Execute());
        }

        public static Guid? Find(Guid source, Guid target)
        {
            var cmd = new EqlCommand($"select id from {Entity} where {Source} = @source and {Target} = @target",
                new EqlParameter("source", source),
                new EqlParameter("target", target));

            return QueryResults.Id(cmd.Execute());
        }

        public static bool InsertMapping(Guid a, Guid b)
        {
            return Insert(a, b) && Insert(b, a);
        }

        public static bool DeleteMapping(Guid a, Guid b)
        {
            return Delete(a, b) && Delete(b, a);
        }

        private static bool Insert(Guid source, Guid target)
        {
            if (Exists(source, target))
                return true;

            var recMan = new RecordManager();
            var rec = new EntityRecord();

            rec["id"] = Guid.NewGuid();
            rec[Source] = source;
            rec[Target] = target;

            return recMan.CreateRecord(Entity, rec).Success;
        }

        private static bool Delete(Guid source, Guid target)
        {
            var id = Find(source, target);
            if (!id.HasValue)
                return true;

            var recMan = new RecordManager();
            return recMan.DeleteRecord(Entity, id.Value).Success;
        }
    }
}
