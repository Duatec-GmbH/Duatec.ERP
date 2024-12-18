using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    internal class ArticleRepository : RepositoryBase<Article>
    {
        private const string ManufacturerSelect = $"*, ${Article.Relations.Manufacturer}.{Manufacturer.Name}";

        public override string Entity => Article.Entity;

        protected override Article? CreateResult(EntityRecord? record)
             => Article.Create(record);

        public Article? Find(Guid id)
            => Find(id, ManufacturerSelect);

        public bool Exists(long eplanId)
            => ExistsBy(Article.Fields.EplanId, eplanId.ToString());

        public bool Exists(string partNumber)
            => ExistsBy(Article.Fields.PartNumber, partNumber);

        public Dictionary<string, Article?> FindMany(params string[] partNumbers)
            => FindManyByUniqueArgs(Article.Fields.PartNumber, ManufacturerSelect, partNumbers);

        public Dictionary<string, Article?> FindManyWithTypes(params string[] partNumbers)
            => IncludeTypes(FindMany(partNumbers));

        public Dictionary<Guid, Article?> FindMany(params Guid[] ids)
            => FindManyByUniqueArgs("id", ManufacturerSelect, ids);

        public Dictionary<Guid, Article?> FindManyWithTypes(params Guid[] ids)
            => IncludeTypes(FindMany(ids));

        public Guid? Insert(DataPortalArticle article, Guid manufacturerId, Guid typeId)
        {
            var rec = new Article
            {
                PartNumber = article.PartNumber,
                TypeNumber = article.TypeNumber,
                EplanId = article.EplanId.ToString(),
                Designation = article.Designation,
                Manufacturer = manufacturerId,
                Type = typeId,
                Image = article.PictureUrl,
            };
            return Record.Insert(Entity, rec);
        }

#pragma warning disable CA1822 // Mark members as static

        public ArticleType? FindType(Guid typeId)
        {
            var rec = Record.FindBy(ArticleType.Entity, "id", typeId);
            return rec == null ? null : new ArticleType(rec);
        }

        public ArticleType? FindTypeByArticle(Article article)
            => FindType(article.Type);

        public ArticleType? FindTypeByArticleId(Guid articleId)
        {
            var article = Find(articleId);
            return article == null ? null : FindTypeByArticle(article);
        }

        public Dictionary<Guid, ArticleType?> FindManyTypesById(params Guid[] ids)
        {
            var dict = Record.FindManyByUniqueArgs(ArticleType.Entity, "id", "*", ids);
            var result = new Dictionary<Guid, ArticleType?>(dict.Count);

            foreach (var (key, val) in dict)
                result[key] = val == null ? null : new ArticleType(val);

            return result;
        }

        public bool ArticleHasAlternatives(Guid id)
            => Record.Exists(ArticleAlternative.Entity, ArticleAlternative.Fields.Source, id);

        public List<Guid> FindAlternativeIds(Guid id)
        {
            return Record.FindManyBy(ArticleAlternative.Entity, ArticleAlternative.Fields.Source, id)
                .Select(r => (Guid)r[ArticleAlternative.Fields.Target])
                .ToList();
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

#pragma warning restore CA1822 // Mark members as static

        private Dictionary<T, Article?> IncludeTypes<T>(Dictionary<T, Article?> articleLookup)
            where T : notnull
        {
            var typeIds = articleLookup.Values
                .Where(v => v != null)
                .Select(a => (Guid)a![Article.Fields.Type])
                .Distinct()
                .ToArray();

            if (typeIds.Length == 0)
                return articleLookup;

            var typeLookup = FindManyTypesById(typeIds);

            foreach (var rec in articleLookup.Values.Where(v => v != null))
            {
                var typeId = (Guid)rec![Article.Fields.Type];
                var list = new List<ArticleType>();

                if (typeLookup.TryGetValue(typeId, out var type) && type != null)
                    list.Add(type);

                rec[$"${Article.Relations.Type}"] = list;
            }

            return articleLookup;
        }

        private static Guid? InsertAlternativeEntry(Guid source, Guid target)
        {
            var id = FindAlternative(source, target)?["id"] as Guid?;
            if (id.HasValue)
                return id;

            var rec = new EntityRecord();
            rec[ArticleAlternative.Fields.Source] = source;
            rec[ArticleAlternative.Fields.Target] = target;

            return Record.Insert(ArticleAlternative.Entity, rec);
        }

        private static void DeleteAlternativeEntry(Guid source, Guid target)
        {
            var id = FindAlternative(source, target)?["id"] as Guid?;
            if (!id.HasValue)
                return;

            Record.Delete(ArticleAlternative.Entity, id.Value);
        }

        private static EntityRecord? FindAlternative(Guid source, Guid target)
        {
            var query = new QueryObject()
            {
                QueryType = QueryType.AND,
                SubQueries =
                [
                    new()
                    {
                        FieldName = ArticleAlternative.Fields.Source,
                        FieldValue = source,
                        QueryType = QueryType.EQ
                    },
                    new()
                    {
                        FieldName = ArticleAlternative.Fields.Target,
                        FieldValue = target,
                        QueryType = QueryType.EQ
                    },
                ]
            };
            return Record.FindByQuery(ArticleAlternative.Entity, query);
        }
    }
}
