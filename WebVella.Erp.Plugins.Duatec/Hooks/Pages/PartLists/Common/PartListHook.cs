﻿using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.PartLists.Common
{
    using Row = (Guid ArticleId, decimal Amount, int Index);

    internal static class PartListHook
    {
        public static IEnumerable<ValidationError> ValidateEntries(BaseErpPageModel pageModel)
        {
            var formValues = GetEntryFormValues(pageModel);
            var articleLookup = GetArticleLookup(formValues);

            foreach (var (articleId, amount, idx) in formValues)
            {
                if (articleId == Guid.Empty)
                    yield return ArticleError(idx, "Article must not be empty");

                else if (!articleLookup.TryGetValue(articleId, out var article) || article == null)
                    yield return ArticleError(idx, $"Article with id '{articleId}' does not exist");

                else
                {
                    var isInt = article.GetArticleType().IsInteger;

                    if (isInt && amount % 1 != 0)
                        yield return AmountError(idx, "Integer value expected");

                    if (amount == 0)
                        yield return AmountError(idx, "Positive amount expected");
                    else if (amount < 0)
                        yield return AmountError(idx, "Unexpected negative amount");
                }
            }

            var duplications = formValues
                .Where(t => t.ArticleId != Guid.Empty)
                .GroupBy(t => t.ArticleId)
                .Where(g => g.Count() > 1);

            foreach (var (_, _, idx) in duplications.SelectMany(g => g))
                yield return ArticleError(idx, "Article is used multiple times within same part list");
        }

        public static void SetUpErrorPage(BaseErpPageModel pageModel, PartList record)
        {
            var formValues = GetEntryFormValues(pageModel);

            record.SetEntries(formValues.Select(fv => new PartListEntry()
            {
                Amount = fv.Amount,
                ArticleId = fv.ArticleId
            }));
            pageModel.DataModel.SetRecord(record);
            pageModel.BeforeRender();
        }

        private static Dictionary<Guid, Article?> GetArticleLookup(List<Row> rows)
        {
            var articleIds = rows.Select(r => r.ArticleId)
                .Distinct()
                .ToArray();

            return new ArticleRepository()
                .FindMany($"*, ${Article.Relations.Type}.*", articleIds);
        }

        public static List<Row> GetEntryFormValues(BaseErpPageModel pageModel)
        {
            var idx = 0;
            var form = pageModel.Request.Form;
            var result = new List<Row>(64);

            while (form.TryGetValue($"article_id[{idx}]", out var articleVal))
            {
                var articleId = Guid.TryParse(articleVal, out var id) ? id : Guid.Empty;
                var amount = decimal.TryParse(form[$"amount[{idx}]"], out var d) ? d : 0m;

                result.Add((articleId, amount, idx));

                idx++;
            }
            return result;
        }

        private static ValidationError ArticleError(int index, string message)
            => new($"article_id[{index}]", message);

        private static ValidationError AmountError(int index, string message)
            => new($"amount[{index}]", message);
    }
}
