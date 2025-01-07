using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Base
{
    internal abstract class ArticleRelatedSnippetBase : SnippetBase
    {
        protected abstract string DataSourceProperty { get; }

        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var entity = pageModel.TryGetDataSourceProperty<EntityRecord>(DataSourceProperty);

            if (entity == null || !entity.Properties.TryGetValue(Article.AsForeignKey, out var idValue) || idValue is not Guid id)
                return null;

            var articleRelations = entity.Properties
                .Where(kp => kp.Key.StartsWith('$'))
                .Select(kp => kp.Value)
                .OfType<List<EntityRecord>>()
                .Where(l => l.Count == 1 && IsArticle(l[0], id))
                .Select(l => l[0])
                .ToArray();

            if(articleRelations.Length != 1)
                return null;

            return GetValue(pageModel, new Article(articleRelations[0]));
        }

        private static bool IsArticle(EntityRecord rec, Guid id)
        {
            return rec.Properties.TryGetValue("id", out var idValue)
                && id.Equals(idValue);
        }

        protected abstract object? GetValue(BaseErpPageModel pageModel, Article article);
    }
}
