using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Eplan;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class EplanManufacturers : CodeDataSource
    {
        public EplanManufacturers() : base()
        {
            Id = new Guid("0fdba4a2-6779-49eb-b299-41e394d86df3");
            Name = nameof(EplanManufacturers);
            Description = "List of all manufacturers from EPLAN Data Portal";
            ResultModel = "EntityRecordList";

            Parameters.Add(new DataSourceParameter { Name = "shortName", Type = "text", Value = "null" });
            Parameters.Add(new DataSourceParameter { Name = "name", Type = "text", Value = "null" });

            Parameters.Add(new DataSourceParameter { Name = "page", Type = "int", Value = "1" });
            Parameters.Add(new DataSourceParameter { Name = "pageSize", Type = "int", Value = "10" });
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var page = (int)arguments["page"];
            var pageSize = (int)arguments["pageSize"];
            var shortName = (string?)arguments["shortName"];
            var name = (string?)arguments["name"];

            var comparison = StringComparison.OrdinalIgnoreCase;
            var manufacturers = DataPortal.GetManufacturers()
                .Where(m => (shortName == null || m.ShortName.Contains(shortName, comparison)) 
                    && (name == null || m.Name.Contains(name, comparison)))
                .OrderBy(m => m.ShortName)
                .ToArray();

            var result = new EntityRecordList { TotalCount = manufacturers.Length };

            foreach (var m in manufacturers.Skip((page -1) * pageSize).Take(pageSize))
            {
                result.Add(new EntityRecord()
                {
                    [Manufacturer.EplanId] = m.EplanId.ToString(),
                    [Manufacturer.Name] = m.Name,
                    [Manufacturer.ShortName] = m.ShortName,
                    [Manufacturer.WebsiteUrl] = m.WebsiteUrl,
                    [Manufacturer.LogoUrl] = m.LogoUrl,
                });
            }
            return result;
        }
    }
}
