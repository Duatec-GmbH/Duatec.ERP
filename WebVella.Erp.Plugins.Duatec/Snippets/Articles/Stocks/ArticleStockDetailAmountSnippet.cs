﻿using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks
{
    [Snippet]
    internal class ArticleStockDetailAmountSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
            var amount = rec?[ArticleStock.Amount] as decimal?;
            var type = GetArticleType(rec);
            var unit = type?[ArticleType.Unit];
            var isInteger = type?[ArticleType.IsInteger] is bool b && b;

            return isInteger
                ? $"{amount:0} {unit}"
                : $"{amount:0.00} {unit}";
        }

        private static EntityRecord? GetArticleType(EntityRecord? rec)
        {
            if (rec?[ArticleStock.Article] is not Guid articleId)
                return null;
            return ArticleType.FromArticle(articleId);
        }
    }
}
