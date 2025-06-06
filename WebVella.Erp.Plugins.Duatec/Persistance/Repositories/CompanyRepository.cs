﻿using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec.FileImports.EplanTypes.DataModel;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords.Persistance;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    internal class CompanyRepository : TypedRepositoryBase<Company>
    {
        public CompanyRepository(RecordManager? recordManager = null)
            : base(recordManager) { }

        public Dictionary<string, Company?> FindManyByShortName(params string[] shortNames)
            => FindManyByUniqueArgs(Company.Fields.ShortName, "*", shortNames);

        public Company? FindByShortName(string shortName)
            => FindBy(Company.Fields.ShortName, shortName);

        public Company? Insert(DataPortalManufacturerDto manufacturer)
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

        public bool CanBeImported(DataPortalManufacturerDto manufacturer)
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

        public List<Company> FindManyByLogo(string logoUrl, string select = "*")
            => FindManyBy(Company.Fields.LogoUrl, logoUrl, select);

        public void DeleteLogoIfUnused(string? imagePath, Guid? excludedArticleId = null)
        {
            if (!string.IsNullOrEmpty(imagePath) && imagePath.StartsWith(Images.FilePath))
            {
                var fsPath = imagePath["/fs".Length..];
                var fileRepo = new DbFileRepository();
                var file = fileRepo.Find(fsPath);

                if (file != null && new ImageRepository(RecordManager).FindManyByPath(file.FilePath).Count == 0)
                {
                    var companyRecords = FindManyByLogo(imagePath, "id");
                    var articleRecords = new ArticleRepository(RecordManager).FindManyByPreview(imagePath);

                    if (articleRecords.Count == 0 && (companyRecords.Count == 0 || companyRecords.Count == 1 && excludedArticleId.HasValue && excludedArticleId.Equals(companyRecords[0]["id"])))
                        fileRepo.Delete(fsPath);
                }
            }
        }
    }
}
