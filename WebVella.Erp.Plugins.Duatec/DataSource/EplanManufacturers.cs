using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;

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

            Parameters.Add(new DataSourceParameter { Name = "sortBy", Type = "text", Value = Manufacturer.EplanId });
            Parameters.Add(new DataSourceParameter { Name = "sortOrder", Type = "text", Value = "asc" });

            Parameters.Add(new DataSourceParameter { Name = "page", Type = "int", Value = "1" });
            Parameters.Add(new DataSourceParameter { Name = "pageSize", Type = "int", Value = "10" });
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var page = (int)arguments["page"];
            var pageSize = (int)arguments["pageSize"];
            var shortName = (string?)arguments["shortName"];
            var name = (string?)arguments["name"];
            var sortBy = (string?)arguments["sortBy"];
            var sortOrder = (string?)arguments["sortOrder"];

            var comparison = StringComparison.OrdinalIgnoreCase;
            var manufacturers = EplanDataPortal.GetManufacturers()
                .Where(m => (shortName == null || m.ShortName.Equals(shortName, comparison)) 
                    && (name == null || m.Name.StartsWith(name, comparison)));

            if (sortBy == Manufacturer.Name)
                manufacturers = manufacturers.OrderBy(m => m.Name);
            else if (sortBy == Manufacturer.ShortName)
                manufacturers = manufacturers.OrderBy(m => m.ShortName);
            else manufacturers = manufacturers.OrderBy(m => m.EplanId);

            if (sortOrder == "desc")
                manufacturers = manufacturers.Reverse();

            if (shortName != null || name != null)
            {
                manufacturers = manufacturers.Where(m => 
                    (shortName == null || m.ShortName.Equals(shortName, StringComparison.OrdinalIgnoreCase)) 
                    && (name == null || m.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase)));
            }

            var all = manufacturers.ToArray();
            var result = new EntityRecordList
            {
                TotalCount = all.Length
            };

            foreach (var m in all.Skip((page -1) * pageSize).Take(pageSize))
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
