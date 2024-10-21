
using WebVella.Erp.Api.Models;
using WebVella.Erp.Eql;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class ArticleType
    {
        public const string Entity = "article_type";
        public const string Label = "label";
        public const string Unit = "unit";

        public static string? FindLabel(Guid id)
        {
            var cmd = new EqlCommand($"select {Label} from {Entity} where id = @param",
                new EqlParameter("param", id));

            return cmd.Execute()?.SingleOrDefault()?[Label]?.ToString();
        }

        public static Guid? FindId(string label)
        {
            var cmd = new EqlCommand($"select id from {Entity} where {Label} = @param",
                new EqlParameter("param", label));

            return QueryResults.Id(cmd.Execute());
        }

        public static EntityRecordList FindAll()
        {
            return new EqlCommand($"select * from {Entity}").Execute();
        }

        public static EntityRecord? Find(Guid id)
        {
            var cmd = new EqlCommand($"select * from {Entity} where id = @param",
                new EqlParameter("param", id));

            return cmd.Execute()?.SingleOrDefault();
        }
    }
}
