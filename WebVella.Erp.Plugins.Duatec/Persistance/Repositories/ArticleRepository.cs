using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories.Base;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    internal class ArticleRepository : RepositoryBase<Article>
    {
        public static class Alternatives
        {
            public const string Entity = "article_equivalent";

            public static class Fields
            {
                public const string Source = "source";
                public const string Target = "target";
            }
        }

        public override string Entity => Article.Entity;

        protected override Article? MapToTypedRecord(EntityRecord? record)
             => Article.Create(record);

        public bool Exists(long eplanId)
            => ExistsBy(Article.Fields.EplanId, eplanId.ToString());

        public bool Exists(string partNumber)
            => ExistsBy(Article.Fields.PartNumber, partNumber);

        public Dictionary<string, Article?> FindMany(string select = "*", params string[] partNumbers)
            => FindManyByUniqueArgs(Article.Fields.PartNumber, select, partNumbers);

        public Dictionary<Guid, Article?> FindMany(string select = "*", params Guid[] ids)
            => FindManyByUniqueArgs("id", select, ids);

        public override bool Delete(Guid id)
        {
            var alternatives = FindAlternativeIds(id);
            var result = false;

            Transactional.TryExecute(() =>
            {
                foreach (var alternative in alternatives)
                    DeleteAlternativeMapping(alternative, id);
                result = base.Delete(id);
            });
            return result;
        }

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
                result[key] = ArticleType.Create(val);

            return result;
        }

        public bool ArticleHasAlternatives(Guid id)
            => Record.Exists(Alternatives.Entity, Alternatives.Fields.Source, id);

        public List<Guid> FindAlternativeIds(Guid id)
        {
            return Record.FindManyBy(Alternatives.Entity, Alternatives.Fields.Source, id)
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

#pragma warning restore CA1822 // Mark members as static

        private static Guid? InsertAlternativeEntry(Guid source, Guid target)
        {
            var id = FindAlternative(source, target)?["id"] as Guid?;
            if (id.HasValue)
                return id;

            var rec = new EntityRecord();
            rec[Alternatives.Fields.Source] = source;
            rec[Alternatives.Fields.Target] = target;

            return Record.Insert(Alternatives.Entity, rec);
        }

        private static void DeleteAlternativeEntry(Guid source, Guid target)
        {
            var id = FindAlternative(source, target)?["id"] as Guid?;
            if (!id.HasValue)
                return;

            Record.Delete(Alternatives.Entity, id.Value);
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
            return Record.FindByQuery(Alternatives.Entity, query);
        }
    }
}
