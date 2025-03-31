using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Hooks.Pages.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Orders
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
                var arrivalFormId = $"{OrderEntry.Fields.ExpectedArrival}[{i}]";

                var form = pageModel.Request.Form;

                if (!form.ContainsKey(articleFormId))
                    break;

                var entry = new OrderEntry()
                {
                    Amount = GetNumber(pageModel.GetFormValue(amountFormId)),
                    Article = GetId(pageModel.GetFormValue(articleFormId)),
                    ExpectedArrival = GetDate(pageModel.GetFormValue(arrivalFormId)),
                };
                result.Add(entry);
            }
            return result;
        }

        protected override List<ValidationError> Validate(Order record, Entity entity, TModel pageModel)
        {
            var result = base.Validate(record, entity, pageModel);

            for(var i = 0; i < int.MaxValue; i++)
            {
                var articleFormId = $"{OrderEntry.Fields.Article}[{i}]";
                var arrivalFormId = $"{OrderEntry.Fields.ExpectedArrival}[{i}]";

                if (!pageModel.Request.Form.ContainsKey(articleFormId))
                    break;

                var arrivalValue = pageModel.GetFormValue(arrivalFormId);

                if (!string.IsNullOrWhiteSpace(arrivalValue) && !SimpleDate.TryParse(arrivalValue, out _))
                    result.Add(Error(OrderEntry.Fields.ExpectedArrival, i, "Invalid date format (expected: DD.MM.YYYY)"));
            }

            return result;
        }

        protected override IEnumerable<ValidationError> ValidateEntries(Order record, List<OrderEntry> entries)
        {
            var recMan = new RecordManager();

            var articleIds = entries.Select(e => e.Article)
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
        }

        private static IEnumerable<ValidationError> GetEntryFormatErrors(OrderEntry entry, int idx, ArticleType? type)
        {
            var result = GetAmountFormatErrors(entry, idx, type);
            if (entry.Article == Guid.Empty)
                result.Add(Error(OrderEntry.Fields.Article, idx, "Order entry 'article' is required"));

            return result;
        }

        private static IEnumerable<ValidationError> GetArticleUniquenessErrors(List<OrderEntry> entries, Guid[] articleIds)
        {
            if (entries.Count != articleIds.Length)
            {
                var idx = 0;
                var idxInfo = entries.Select(e => new { Index = idx++, e.Article })
                    .ToArray();

                foreach (var id in articleIds.Where(aId => aId != Guid.Empty))
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

        protected static ValidationError Error(string field, int index, string errorMessage)
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

        private static DateTime? GetDate(string value)
        {
            if (string.IsNullOrEmpty(value) || !SimpleDate.TryParse(value, out var result))
                return null;
            return result;
        }

        protected static List<OrderConfirmation> GetConfirmations(Order record, TModel pageModel)
        {
            var files = pageModel.Request.Form["confirmations"].ToString();
            if (string.IsNullOrWhiteSpace(files))
                return [];

            return files.Split(',')
                .Select(path => new OrderConfirmation()
                {
                    path = path,
                    OrderId = record.Id!.Value,
                }).ToList();
        }

        protected static List<OrderBill> GetBills(Order record, TModel pageModel)
        {
            var files = pageModel.Request.Form["bills"].ToString();
            if (string.IsNullOrWhiteSpace(files))
                return [];

            return files.Split(',')
                .Select(path => new OrderBill()
                {
                    path = path,
                    OrderId = record.Id!.Value
                }).ToList();
        }

        protected static List<dynamic> GetDynamicConfirmations(Order record, TModel pageModel)
        {
            var confirmations = GetConfirmations(record, pageModel);
            var result = new List<dynamic>(confirmations.Count);
            foreach (var conf in confirmations)
                result.Add(conf);
            return result;
        }

        protected static List<dynamic> GetDynamicBills(Order record, TModel pageModel)
        {
            var bills = GetBills(record, pageModel);
            var result = new List<dynamic>(bills.Count);
            foreach (var bill in bills)
                result.Add(bill);
            return result;
        }

        protected override IActionResult FailureResult(Order record, TModel pageModel, List<OrderEntry> entries, List<ValidationError> validationErrors)
        {
            record["confirmations"] = GetDynamicConfirmations(record, pageModel);
            record["bills"] = GetDynamicBills(record, pageModel);

            for(var i = 0; i < entries.Count; i++)
            {
                var arrivalFormId = $"{OrderEntry.Fields.ExpectedArrival}[{i}]";
                if (pageModel.Request.Form.TryGetValue(arrivalFormId, out var arrivalValue))
                    entries[i][OrderEntry.Fields.ExpectedArrival] = arrivalValue.ToString();
            }

            return base.FailureResult(record, pageModel, entries, validationErrors);
        }
    }
}
