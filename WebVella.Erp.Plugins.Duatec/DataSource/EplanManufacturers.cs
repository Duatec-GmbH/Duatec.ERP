using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class EplanManufacturers : CodeDataSource
    {
        public static class Arguments
        {
            public const string ShortName = "shortName";
            public const string Name = "name";
            public const string Page = "page";
            public const string PageSize = "pageSize";
        }

        public EplanManufacturers() : base()
        {
            Id = new Guid("0fdba4a2-6779-49eb-b299-41e394d86df3");
            Name = nameof(EplanManufacturers);
            Description = "List of all manufacturers from EPLAN Data Portal";
            ResultModel = "EntityRecordList";

            Parameters.Add(new DataSourceParameter { Name = Arguments.ShortName, Type = "text", Value = "null" });
            Parameters.Add(new DataSourceParameter { Name = Arguments.Name, Type = "text", Value = "null" });

            Parameters.Add(new DataSourceParameter { Name = Arguments.Page, Type = "int", Value = "1" });
            Parameters.Add(new DataSourceParameter { Name = Arguments.PageSize, Type = "int", Value = "10" });
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var page = (int)arguments[Arguments.Page];
            var pageSize = (int)arguments[Arguments.PageSize];
            var shortName = (string?)arguments[Arguments.ShortName];
            var name = (string?)arguments[Arguments.Name];

            var comparison = StringComparison.OrdinalIgnoreCase;
            var manufacturers = EplanDataPortal.GetManufacturers()
                .Where(m => (shortName == null || m.ShortName.Contains(shortName, comparison)) 
                    && (name == null || m.Name.Contains(name, comparison)))
                .OrderBy(m => m.ShortName)
                .ToArray();

            var result = new EntityRecordList { TotalCount = manufacturers.Length };

            foreach (var m in manufacturers.Skip((page -1) * pageSize).Take(pageSize))
            {
                result.Add(new Company()
                {
                    EplanId = m.EplanId.ToString(),
                    Name = m.Name,
                    ShortName = m.ShortName,
                    WebsiteUrl = m.WebsiteUrl,
                    LogoUrl = m.LogoUrl,
                });
            }
            return result;
        }
    }
}
