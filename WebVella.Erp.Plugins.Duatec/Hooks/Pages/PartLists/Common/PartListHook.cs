using System.Globalization;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.PartLists.Common
{
    using Row = (Guid ArticleId, decimal Denomination, decimal Amount, int Index);

    internal static class PartListHook
    {
        public static IEnumerable<ValidationError> ValidateEntries(BaseErpPageModel pageModel)
        {
            var formValues = GetEntryFormValues(pageModel);
            var articleLookup = GetArticleLookup(formValues);

            foreach (var (articleId, denomination, amount, idx) in formValues)
            {
                if (articleId == Guid.Empty)
                    yield return ArticleError(idx, "Article must not be empty");

                else if (!articleLookup.TryGetValue(articleId, out var article) || article == null)
                    yield return ArticleError(idx, $"Article with id '{articleId}' does not exist");

                else
                {
                    var isInt = article.GetArticleType().IsInteger;

                    if(isInt && denomination % 1 != 0)
                        yield return DenominationError(idx, "Integer value expected");

                    else if (denomination < 0)
                        yield return DenominationError(idx, "Unexpected negative amount");

                    if (isInt && amount % 1 != 0)
                        yield return AmountError(idx, "Integer value expected");

                    else if (amount == 0)
                        yield return AmountError(idx, "Positive amount expected");

                    else if (amount < 0)
                        yield return AmountError(idx, "Unexpected negative amount");
                }
            }

            var duplications = formValues
                .Where(t => t.ArticleId != Guid.Empty)
                .GroupBy(t => (t.ArticleId, t.Denomination))
                .Where(g => g.Count() > 1);

            foreach (var (_, _, _, idx) in duplications.SelectMany(g => g))
                yield return ArticleError(idx, "Article is used multiple times within same part list");
        }

        public static void SetUpErrorPage(BaseErpPageModel pageModel, PartList record)
        {
            var formValues = GetEntryFormValues(pageModel);
            var articleIds = formValues.Select(t => t.ArticleId)
                .Where(id => id != Guid.Empty)
                .Distinct()
                .ToArray();

            var articleLookup = new ArticleRepository().FindMany($"*, ${Article.Relations.Type}.*", articleIds);

            record.SetEntries(formValues.Select(fv => {
                var entry = new PartListEntry()
                {
                    Amount = fv.Amount,
                    ArticleId = fv.ArticleId,
                    Denomination = fv.Denomination
                };

                if(articleLookup.TryGetValue(entry.ArticleId, out var article) && article != null)
                    entry.SetArticle(article);

                return entry;
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

            while (true)
            {
                var hasArticle = form.TryGetValue($"{PartListEntry.Fields.Article}[{idx}]", out var articleVal);
                var hasAmount = form.TryGetValue($"{PartListEntry.Fields.Amount}[{idx}]", out var amountVal);
                var hasDenomination = form.TryGetValue($"{PartListEntry.Fields.Denomination}[{idx}]", out var denominationVal);

                if (!hasArticle && !hasAmount && !hasDenomination)
                    break;


                var articleId = Guid.TryParse(articleVal, out var id) ? id : Guid.Empty;
                var amount = decimal.TryParse(amountVal, CultureInfo.InvariantCulture, out var d) ? d : 0m;
                var denomination = decimal.TryParse(denominationVal, CultureInfo.InvariantCulture, out d) ? d : 0m;

                result.Add((articleId, denomination, amount, idx));

                idx++;
            }

            const string articleSelect = $"id, ${Article.Relations.Type}.{ArticleType.Fields.IsDivisible}";
            var ids = result.Select(r => r.ArticleId).ToArray();

            var isDivisibleLookup = new ArticleRepository().FindMany(articleSelect, ids)
                .ToDictionary(kp => kp.Key, kp => kp.Value?.GetArticleType()?.IsDivisible ?? false);

            for(var i = 0; i < result.Count; i++)
            {
                var (articleId, denomination, amount, index) = result[i];

                if (!isDivisibleLookup.TryGetValue(articleId, out var isDivisible) || !isDivisible)
                    denomination = 0;

                result[i] = (articleId, denomination, amount, index);
            }

            return result;
        }

        private static ValidationError ArticleError(int index, string message)
            => new($"article_id[{index}]", message);

        private static ValidationError AmountError(int index, string message)
            => new($"amount[{index}]", message);

        private static ValidationError DenominationError(int index, string message)
            => new($"denomination[{index}]", message);
    }
}
