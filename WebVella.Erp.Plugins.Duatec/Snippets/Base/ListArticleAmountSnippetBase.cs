
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Base
{
    internal abstract class ListArticleAmountSnippetBase : SnippetBase
    {
        protected abstract decimal? GetAmount(EntityRecord rowRecord);

        protected abstract EntityRecord? GetArticle(EntityRecord rowRecord);

        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");
            if (rec == null)
                return null;

            var amount = GetAmount(rec)?.ToString();
            var article = GetArticle(rec);
            var type = (article?['$' + Article.Relations.Type] as List<EntityRecord>)?.FirstOrDefault();
            var unit = type?[ArticleType.Unit]?.ToString();
            var isInteger = type?[ArticleType.IsInteger] is bool b && b;

            return isInteger
                ? $"{amount:0} {unit}"
                : $"{amount:0.00} {unit}";
        }
    }
}
