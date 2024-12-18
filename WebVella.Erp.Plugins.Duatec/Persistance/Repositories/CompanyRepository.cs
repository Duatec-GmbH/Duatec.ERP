using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    internal class CompanyRepository : RepositoryBase<Company>
    {
        public override string Entity => Company.Entity;

        protected override Company? MapToTypedRecord(EntityRecord? record)
            => Company.Create(record);

        public Dictionary<string, Company?> FindManyByShortName(params string[] shortNames)
            => FindManyByUniqueArgs(Company.Fields.ShortName, "*", shortNames);

        public Guid? Insert(DataPortalManufacturer manufacturer)
        {
            var rec = new Company()
            {
                EplanId = manufacturer.EplanId.ToString(),
                ShortName = manufacturer.ShortName,
                Name = manufacturer.Name,
                WebsiteUrl = manufacturer.WebsiteUrl,
                LogoUrl = manufacturer.LogoUrl,
            };
            return Insert(rec);
        }

        public bool CanBeImported(DataPortalManufacturer manufacturer)
        {
            var query = new QueryObject()
            {
                QueryType = QueryType.AND,
                SubQueries =
                [
                    new()
                    { 
                        FieldName = Company.Fields.ShortName, 
                        FieldValue = manufacturer.ShortName, 
                        QueryType = QueryType.EQ 
                    },
                    new()
                    { 
                        FieldName = Company.Fields.Name, 
                        FieldValue = manufacturer.Name, 
                        QueryType = QueryType.EQ 
                    },
                    new()
                    { 
                        FieldName = Company.Fields.EplanId, 
                        FieldValue = manufacturer.EplanId.ToString(), 
                        QueryType = QueryType.EQ 
                    },
                ]
            };

            var recMan = new RecordManager();
            var response = recMan.Count(new EntityQuery(Entity, "*", query));
            return response.Success && response.Object == 0;
        }
    }
}
