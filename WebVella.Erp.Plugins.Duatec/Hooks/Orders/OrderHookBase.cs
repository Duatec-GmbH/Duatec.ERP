using WebVella.Erp.Api;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Orders
{
    internal abstract class OrderHookBase<TModel> : ListFullModificationHookBase<Order, OrderEntry, TModel>
        where TModel : BaseErpPageModel
    {
        protected override string RelationName => OrderEntry.Relations.Order;

        protected override List<OrderEntry> GetEntries(TModel pageModel)
        {
            var result = new List<OrderEntry>();

            for (var i = 0; i < int.MaxValue; i++)
            {
                var articleFormId = $"{OrderEntry.Fields.Article}[{i}]";
                var amountFormId = $"{OrderEntry.Fields.Amount}[{i}]";
                var form = pageModel.Request.Form;

                if (!form.ContainsKey(articleFormId) && !form.ContainsKey(amountFormId))
                    break;

                var entry = new OrderEntry()
                {
                    Amount = GetNumber(pageModel.GetFormValue(amountFormId)),
                    Article = GetId(pageModel.GetFormValue(articleFormId)),
                };
                result.Add(entry);
            }
            return result;
        }

        protected override IEnumerable<ValidationError> ValidateEntries(Order record, List<OrderEntry> entries)
        {
            var recMan = new RecordManager();

            var articleIds = entries.Select(e => e.Article)
                .Where(g => g != Guid.Empty)
                .Distinct()
                .ToArray();



            var typeLookup = new ArticleRepository(recMan).FindMany($"*, ${Article.Relations.Type}.*", articleIds)
                .ToDictionary(kp => kp.Key, kp => kp.Value?.GetArticleType());

            for (var i = 0; i < entries.Count; i++)
            {
                foreach (var error in GetEntryFormatErrors(entries[i], i, typeLookup[entries[i].Article]))
                    yield return error;
            }

            foreach (var error in GetArticleUniquenessErrors(entries, articleIds))
                yield return error;

            foreach (var error in GetConsistencyErrors(recMan, record, entries))
                yield return error;

        }

        private static IEnumerable<ValidationError> GetEntryFormatErrors(OrderEntry entry, int idx, ArticleType? type)
        {
            var result = GetAmountFormatErrors(entry, idx, type);
            if (entry.Article == Guid.Empty)
                result.Add(Error(OrderEntry.Fields.Article, idx, "Order entry 'article' is required"));

            return result;
        }

        private static IEnumerable<ValidationError> GetConsistencyErrors(RecordManager recMan, Order record, List<OrderEntry> entries)
        {
            var demandedArticles = new PartListRepository(recMan).FindManyEntriesByProject(record.Project, true)
                .Select(ple => ple.ArticleId)
                .Distinct()
                .ToHashSet();

            for (var i = 0; i < entries.Count; i++)
            {
                if (!demandedArticles.Contains(entries[i].Article))
                    yield return Error(OrderEntry.Fields.Article, i, "There is no demand for this article (does not occure in any active part list)");
            }
        }

        private static IEnumerable<ValidationError> GetArticleUniquenessErrors(List<OrderEntry> entries, Guid[] articleIds)
        {
            if (entries.Count != articleIds.Length)
            {
                var idx = 0;
                var idxInfo = entries.Select(e => new { Index = idx++, e.Article })
                    .ToArray();

                foreach (var id in articleIds)
                {
                    var occurances = idxInfo.Where(t => t.Article == id)
                        .ToArray();

                    if (occurances.Length > 1)
                    {
                        foreach (var occurance in occurances)
                            yield return Error(OrderEntry.Fields.Article, occurance.Index, "Articles must only occure once");
                    }
                }
            }
        }

        private static List<ValidationError> GetAmountFormatErrors(OrderEntry entry, int idx, ArticleType? type)
        {
            var isInt = type?.IsInteger ?? false;

            var validator = new NumberFormatValidator(
                entry.EntityName, OrderEntry.Fields.Amount, isInt, true, false);

            return validator.Validate(entry.Amount, $"{OrderEntry.Fields.Amount}[{idx}]");
        }

        private static ValidationError Error(string field, int index, string errorMessage)
            => new($"{field}[{index}]", errorMessage);

        private static Guid GetId(string value)
        {
            return Guid.TryParse(value, out var g) ? g : Guid.Empty;
        }

        private static decimal GetNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0m;

            return decimal.TryParse(value, out var d) ? d : decimal.MinValue;
        }
    }
}
