using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Base
{
    internal abstract class ArticleAmountSnippetBase : SnippetBase
    {
        protected abstract EntityRecord? GetArticle(BaseErpPageModel pageModel);

        protected abstract decimal? GetAmount(BaseErpPageModel pageModel);

        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var article = GetArticle(pageModel);
            if (article == null)
                return null;

            var amount = GetAmount(pageModel) ?? 0m;
            var type = (article?['$' + Article.Relations.Type] as List<EntityRecord>)?.FirstOrDefault();
            var unit = type?[ArticleType.Unit]?.ToString();
            var isInteger = type?[ArticleType.IsInteger] is bool b && b;

            return isInteger
                ? $"{amount:0} {unit}"
                : $"{amount:0.00} {unit}";
        }
    }
}
