using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec.FileImports.EplanTypes.DataModel;
using WebVella.Erp.Plugins.Duatec.Hooks.Pages.Articles;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Persistance;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    internal class ArticleRepository : TypedRepositoryBase<Article>
    {
        private static class Alternatives
        {
            public const string Entity = "article_equivalent";

            public static class Fields
            {
                public const string Source = "source";
                public const string Target = "target";
            }
        }

        public ArticleRepository(RecordManager? recordManager = null)
            : base(recordManager) { }

        public bool Exists(long eplanId)
            => ExistsBy(Article.Fields.EplanId, eplanId.ToString());

        public bool Exists(string partNumber)
            => ExistsBy(Article.Fields.PartNumber, partNumber);

        public Dictionary<string, Article?> FindMany(string select = "*", params string[] partNumbers)
            => FindManyByUniqueArgs(Article.Fields.PartNumber, select, partNumbers);

        public Dictionary<string, List<Article>> FindManyByOrderNumbers(string select = "*", params string[] orderNumbers)
        {
            if (orderNumbers.Length == 0)
                return [];

            var subQueries = orderNumbers.Select(orderNumber => new QueryObject()
            {
                FieldName = Article.Fields.OrderNumber,
                FieldValue = orderNumber,
                QueryType = QueryType.EQ,
            }).ToList();

            var query = subQueries.Count == 1 ? subQueries[0] : new QueryObject()
            {
                QueryType = QueryType.OR,
                SubQueries = subQueries
            };

            var resultSet = FindManyByQuery(query, select)
                .GroupBy(a => a.OrderNumber)
                .ToDictionary(g => g.Key, g => g.ToList());

            foreach(var orderNumber in orderNumbers)
            {
                if (!resultSet.ContainsKey(orderNumber))
                    resultSet.Add(orderNumber, []);
            }
            return resultSet;
        }


        public override Article? Delete(Guid id)
        {
            var alternatives = FindAlternativeIds(id);
            if (alternatives.Count == 0)
                return base.Delete(id);

            Article? result = null;
            Transactional.TryExecute(() =>
            {
                foreach (var alternative in alternatives)
                    DeleteAlternativeMapping(alternative, id);
                result = base.Delete(id);
            });
            return result;
        }

        public Article? Insert(DataPortalArticleDto article, Guid manufacturerId, Guid typeId)
            => Insert(ArticleFromDataPortalArticle(article, manufacturerId, typeId));
        

        public List<Article> InsertMany(IEnumerable<(DataPortalArticleDto Article, Guid ManufacturerId, Guid TypeId)> articleInfo)
        {
            var entries = articleInfo.Select(t => ArticleFromDataPortalArticle(t.Article, t.ManufacturerId, t.TypeId));
            return RepositoryHelper.InsertMany(RecordManager, Entity, entries)
                .Select(TypedEntityRecordWrapper.Wrap<Article>)
                .ToList();
        }

        private static Article ArticleFromDataPortalArticle(DataPortalArticleDto article, Guid manufacturerId, Guid typeId)
        {
            return new Article
            {
                PartNumber = article.PartNumber,
                TypeNumber = article.TypeNumber,
                OrderNumber = article.OrderNumber,
                EplanId = article.EplanId.ToString(),
                Designation = article.Designation,
                ManufacturerId = manufacturerId,
                TypeId = typeId,
                Image = article.PictureUrl,
            };
        }


        public ArticleType? FindType(Guid typeId)
        {
            var rec = RepositoryHelper.FindBy(RecordManager, ArticleType.Entity, "id", typeId);
            return TypedEntityRecordWrapper.WrapElseDefault<ArticleType>(rec);
        }

        public ArticleType? FindTypeByArticle(Article article)
            => FindType(article.TypeId);

        public ArticleType? FindTypeByArticleId(Guid articleId)
        {
            var article = Find(articleId);
            return article == null ? null : FindTypeByArticle(article);
        }

        public Dictionary<Guid, ArticleType?> FindManyTypesById(params Guid[] ids)
        {
            var dict = RepositoryHelper.FindManyByUniqueArgs(RecordManager, ArticleType.Entity, "id", "*", ids);
            var result = new Dictionary<Guid, ArticleType?>(dict.Count);

            foreach (var (key, val) in dict)
                result[key] = TypedEntityRecordWrapper.WrapElseDefault<ArticleType>(val);

            return result;
        }

        public bool ArticleHasAlternatives(Guid id)
            => RepositoryHelper.Exists(RecordManager, Alternatives.Entity, Alternatives.Fields.Source, id);

        public List<Guid> FindAlternativeIds(Guid id)
        {
            return RepositoryHelper.FindManyBy(RecordManager, Alternatives.Entity, Alternatives.Fields.Source, id)
                .Select(r => (Guid)r[Alternatives.Fields.Target])
                .ToList();
        }

        public List<Article> FindAlternatives(Guid id, string select = "*")
        {
            var ids = FindAlternativeIds(id)
                .Distinct()
                .ToArray();

            return FindMany(select, ids)
                .Where(kp => kp.Value != null)
                .Select(kp => kp.Value)
                .ToList()!;
        }

        public void InsertAlternativeMapping(Guid a, Guid b)
        {
            InsertAlternativeEntry(a, b);
            InsertAlternativeEntry(b, a);
        }

        public void DeleteAlternativeMapping(Guid a, Guid b)
        {
            DeleteAlternativeEntry(a, b);
            DeleteAlternativeEntry(b, a);
        }

        private void InsertAlternativeEntry(Guid source, Guid target)
        {
            var id = FindAlternative(source, target)?["id"] as Guid?;
            if (id.HasValue)
                return;

            var rec = new EntityRecord();
            rec[Alternatives.Fields.Source] = source;
            rec[Alternatives.Fields.Target] = target;

            RepositoryHelper.Insert(RecordManager, Alternatives.Entity, rec);
        }

        private void DeleteAlternativeEntry(Guid source, Guid target)
        {
            var id = FindAlternative(source, target)?["id"] as Guid?;
            if (!id.HasValue)
                return;

            RepositoryHelper.Delete(RecordManager, Alternatives.Entity, id.Value);
        }

        private EntityRecord? FindAlternative(Guid source, Guid target)
        {
            var query = new QueryObject()
            {
                QueryType = QueryType.AND,
                SubQueries =
                [
                    new()
                    {
                        FieldName = Alternatives.Fields.Source,
                        FieldValue = source,
                        QueryType = QueryType.EQ
                    },
                    new()
                    {
                        FieldName = Alternatives.Fields.Target,
                        FieldValue = target,
                        QueryType = QueryType.EQ
                    },
                ]
            };
            return RepositoryHelper.FindByQuery(RecordManager, Alternatives.Entity, query);
        }

        public void DeletePreviewIfUnused(string? imagePath, Guid? excludedArticleId = null)
        {
            if (!string.IsNullOrEmpty(imagePath) && imagePath.StartsWith(Images.FilePath))
            {
                var fsPath = imagePath["/fs".Length..];
                var fileRepo = new DbFileRepository();

                if (fileRepo.Find(fsPath) != null)
                {
                    var records = FindManyBy(Article.Fields.Image, imagePath, "id");

                    if (records.Count == 0 || records.Count == 1 && excludedArticleId.HasValue && excludedArticleId.Equals(records[0]["id"]))
                        fileRepo.Delete(fsPath);
                }
            }
        }
    }
}
