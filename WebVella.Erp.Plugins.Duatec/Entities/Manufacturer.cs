using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
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
            => Record.FindBy(Entity, ShortName, shortName, "id")?["id"] as Guid?;

        public static EntityRecord? Find(Guid id)
            => Record.Find(Entity, id);

        public static Dictionary<string, EntityRecord?> FindMany(params string[] shortNames)
        {
            if (shortNames.Length == 0)
                return [];

            var subQueries = shortNames
                .Select(sn => new QueryObject { FieldName = ShortName, FieldValue = sn, QueryType = QueryType.EQ })
                .ToList();

            var recMan = new RecordManager();
            var response = recMan.Find(new EntityQuery(Entity, "*", 
                new QueryObject { QueryType = QueryType.OR, SubQueries = subQueries }));

            var result = new Dictionary<string, EntityRecord?>(shortNames.Length);
            foreach (var sn in shortNames)
                result[sn] = null;

            foreach (var resObj in response.Object.Data)
                result[(string)resObj[ShortName]] = resObj;

            return result;
        }

        public static bool CanBeImported(DataPortalManufacturer manufacturer)
        {
            var subQueries = new List<QueryObject>()
            {
                new(){ FieldName = ShortName, FieldValue = manufacturer.ShortName, QueryType = QueryType.EQ },
                new(){ FieldName = Name, FieldValue = manufacturer.Name, QueryType = QueryType.EQ },
                new(){ FieldName = EplanId, FieldValue = manufacturer.EplanId.ToString(), QueryType = QueryType.EQ },
            };

            var recMan = new RecordManager();
            var response = recMan.Count(new EntityQuery(Entity, "id",
                new QueryObject() { QueryType = QueryType.AND, SubQueries = subQueries }));

            return response.Success && response.Object == 0;
        }

        public static Guid? Insert(DataPortalManufacturer manufacturer)
        {
            var rec = new EntityRecord();
            rec[EplanId] = manufacturer.EplanId.ToString();
            rec[LogoUrl] = manufacturer.LogoUrl;
            rec[Name] = manufacturer.Name;
            rec[ShortName] = manufacturer.ShortName;
            rec[WebsiteUrl] = manufacturer.WebsiteUrl;

            return Record.Insert(Entity, rec);
        }
    }
}
