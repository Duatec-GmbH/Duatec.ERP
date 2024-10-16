using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Eql;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;

namespace WebVella.Erp.Plugins.Duatec
{
    public static class Db
    {
        public static Guid? GetArticleIdByEplanId(string eplanId)
        {
            var eql = new EqlCommand($"select id from {Article.Entity} " +
                $"where {Article.EplanId} = @param",
                new EqlParameter("param", eplanId));

            return GetIdFromQueryResult(eql.Execute());
        }

        public static Guid? GetArticleIdByPartNumber(string partNumber)
        {
            var eql = new EqlCommand($"select id from {Article.Entity} " +
                $"where {Article.PartNumber} = @param",
                new EqlParameter("param", partNumber));

            return GetIdFromQueryResult(eql.Execute());
        }

        public static Guid? GetArticleTypeByLabel(string label)
        {
            var eql = new EqlCommand($"select id from {ArticleType.Entity} "
                + $"where {ArticleType.Label} = @param",
                new EqlParameter("param", label));

            return GetIdFromQueryResult(eql.Execute());
        }

        public static Guid? GetManufacturerIdByEplanId(string eplanId)
        {
            var eql = new EqlCommand($"select id from {Manufacturer.Entity} " +
                $"where {Manufacturer.EplanId} = @param",
                new EqlParameter("param", eplanId));

            return GetIdFromQueryResult(eql.Execute());
        }

        public static Guid? GetManufacturerIdByShortName(string shortName)
        {
            var eql = new EqlCommand($"select id from {Manufacturer.Entity} " +
                $"where {Manufacturer.ShortName} = @param",
                new EqlParameter("param", shortName));

            return GetIdFromQueryResult(eql.Execute());
        }

        private static Guid? GetIdFromQueryResult(EntityRecordList? result)
        {
            if (result != null && result.Count > 0)
                return (Guid)result[0]["id"];
            return null;
        }

        public static Guid? InsertManufacturer(ManufacturerDto manufacturer)
        {
            var recMan = new RecordManager();
            var rec = new EntityRecord();

            var id = Guid.NewGuid();

            rec["id"] = id;
            rec[Manufacturer.EplanId] = manufacturer.EplanId.ToString();
            rec[Manufacturer.LogoUrl] = manufacturer.LogoUrl;
            rec[Manufacturer.Name] = manufacturer.Name;
            rec[Manufacturer.ShortName] = manufacturer.ShortName;
            rec[Manufacturer.WebsiteUrl] = manufacturer.WebsiteUrl;

            var result = recMan.CreateRecord(Manufacturer.Entity, rec);
            if (result.Success)
                return id;
            return null;
        }

        public static Guid? InsertArticle(ArticleDto article, Guid manufacturerId, string articleType)
        {
            var recMan = new RecordManager();
            var rec = new EntityRecord();

            var id = Guid.NewGuid();

            rec["id"] = Guid.NewGuid();
            rec[Article.PartNumber] = article.PartNumber;
            rec[Article.EplanId] = article.EplanId.ToString();
            rec[Article.Designation] = article.Description;
            rec[Article.Type] = articleType;
            rec[Article.ManufacturerId] = manufacturerId;
            rec[Article.Image] = article.PictureUrl;

            var result = recMan.CreateRecord(Article.Entity, rec);
            if (result.Success)
                return id;
            return null;
        }

        public static bool ManufacturerCanBeImported(ManufacturerDto manufacturer)
        {
            var eql = new EqlCommand($"select id from {Manufacturer.Entity} " +
                $"where {Manufacturer.ShortName} = @shortName OR {Manufacturer.EplanId} = @id OR {Manufacturer.Name} = @name",
                new EqlParameter("shortName", manufacturer.ShortName),
                new EqlParameter("id", manufacturer.EplanId.ToString()),
                new EqlParameter("name", manufacturer.Name));

            var res = eql.Execute();
            return res == null || res.Count == 0;
        }

        public static bool ManufacturerWithShortNameExists(string shortName)
        {
            var eql = new EqlCommand($"select id from {Manufacturer.Entity} " +
                $"where {Manufacturer.ShortName} = @shortName",
                new EqlParameter("shortName", shortName));

            var res = eql.Execute();
            return res != null && res.Count > 0;
        }

        public static bool ManufacturerWithNameExists(string name)
        {
            var eql = new EqlCommand($"select id from {Manufacturer.Entity} " +
                $"where {Manufacturer.Name} = @name",
                new EqlParameter("name", name));

            var res = eql.Execute();
            return res != null && res.Count > 0;
        }
    }
}
