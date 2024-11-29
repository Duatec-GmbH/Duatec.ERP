using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Base
{
    internal abstract class ArticleAmountSnippetBase : SnippetBase
    {
        protected abstract EntityRecord? GetArticle(BaseErpPageModel pageModel);

        protected abstract EntityRecord? GetArticleType(BaseErpPageModel pageModel);

        protected abstract decimal? GetAmount(BaseErpPageModel pageModel);

        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var article = GetArticle(pageModel);
            if (article == null)
                return null;

            var amount = GetAmount(pageModel) ?? 0m;
            var type = GetArticleType(pageModel);
            var unit = type?[ArticleType.Unit]?.ToString();
            var isInteger = type?[ArticleType.IsInteger] is bool b && b;

            return isInteger
                ? $"{amount:0} {unit}"
                : $"{amount:0.00} {unit}";
        }

        protected static object? GetDataSourcePropertyFromRecord(BaseErpPageModel pageModel, string path)
        {
            var rec = TargetRecord(pageModel);
            if (rec == null)
                return null;
            return pageModel.TryGetDataSourceProperty($"{rec}.{path}");
        }

        protected static string? TargetRecord(BaseErpPageModel pageModel)
        {
            if (string.IsNullOrEmpty(pageModel.CurrentUrl))
                return null;

            if (Try.Get(() => pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord"), out var r) && r != null)
                return "RowRecord";
            return "Record";
        }
    }
}
