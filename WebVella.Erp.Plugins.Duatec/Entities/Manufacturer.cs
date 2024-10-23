using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Eql;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class Manufacturer
    {
        public const string Entity = "manufacturer";
        public const string EplanId = "eplan_id";
        public const string ShortName = "short_name";
        public const string Name = "name";
        public const string WebsiteUrl = "website";
        public const string LogoUrl = "logo";

        public static Guid? FindId(string shortName)
        {
            var cmd = new EqlCommand($"select id from {Entity} where {ShortName} = @param",
                new EqlParameter("param", shortName));

            return QueryResults.Id(cmd.Execute());
        }

        public static bool CanBeImported(ManufacturerDto manufacturer)
        {
            var cmd = new EqlCommand($"select id from {Entity} where {ShortName} = @shortName or {EplanId} = @id or {Name} = @name",
                new EqlParameter("shortName", manufacturer.ShortName),
                new EqlParameter("id", manufacturer.EplanId.ToString()),
                new EqlParameter("name", manufacturer.Name));

            return !QueryResults.Exists(cmd.Execute());
        }

        public static bool WithShortNameExists(string shortName)
        {
            var cmd = new EqlCommand($"select id from {Entity} where {ShortName} = @shortName",
                new EqlParameter("shortName", shortName));

            return QueryResults.Exists(cmd.Execute());
        }

        public static Guid? Insert(ManufacturerDto manufacturer)
        {
            var recMan = new RecordManager();
            var rec = new EntityRecord();

            var id = Guid.NewGuid();

            rec["id"] = id;
            rec[EplanId] = manufacturer.EplanId.ToString();
            rec[LogoUrl] = manufacturer.LogoUrl;
            rec[Name] = manufacturer.Name;
            rec[ShortName] = manufacturer.ShortName;
            rec[WebsiteUrl] = manufacturer.WebsiteUrl;

            var result = recMan.CreateRecord(Entity, rec);
            if (result.Success)
                return id;
            return null;
        }
    }
}
