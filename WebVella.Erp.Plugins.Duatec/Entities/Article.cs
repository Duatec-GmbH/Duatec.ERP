using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Eql;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class Article
    {
        public const string Entity = "article";
        public const string EplanId = "eplan_id";
        public const string PartNumber = "part_number";
        public const string Designation = "designation";
        public const string Type = "article_type";
        public const string ManufacturerId = "manufacturer_id";
        public const string Image = "preview";
        public const string IsBlocked = "is_blocked";

        public static EntityRecord? Find(Guid id)
        {
            var cmd = new EqlCommand($"select *, $article_manufacturer.name from {Entity} where id = @param",
                new EqlParameter("param", id));

            return cmd.Execute()?.SingleOrDefault();
        }

        // is used in snippet do not delete
        public static bool HasAlternatives(Guid id)
        {
            var cmd = new EqlCommand($"select id from {ArticleEquivalent.Entity} where {ArticleEquivalent.Source} = @id",
                new EqlParameter("id", id));

            return QueryResults.Exists(cmd.Execute());
        }

        public static bool Exists(long eplanId)
        {
            var cmd = new EqlCommand($"select id from {Entity} where {EplanId} = @param",
                new EqlParameter("param", eplanId.ToString()));

            return QueryResults.Exists(cmd.Execute());
        }

        public static bool Exists(string partNumber)
        {
            var cmd = new EqlCommand($"select id from {Entity} where {PartNumber} = @param",
                new EqlParameter("param", partNumber));

            return QueryResults.Exists(cmd.Execute());
        }

        public static Guid? Insert(ArticleDto article, Guid manufacturerId, string articleType)
        {
            var recMan = new RecordManager();
            var rec = new EntityRecord();

            var id = Guid.NewGuid();

            rec["id"] = Guid.NewGuid();
            rec[PartNumber] = article.PartNumber;
            rec[EplanId] = article.EplanId.ToString();
            rec[Designation] = article.Description;
            rec[Type] = articleType;
            rec[ManufacturerId] = manufacturerId;
            rec[Image] = article.PictureUrl;

            var result = recMan.CreateRecord(Entity, rec);
            if (result.Success)
                return id;
            return null;
        }
    }
}
