using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.TypedRecords.Hooks;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Web.Utils;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Orders
{
    [HookAttachment(HookKeys.Order.Create)]
    internal class OrderCreateHook : TypedValidatedCreateHook<Order>, IPageHook
    {
        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel) => null;

        protected override List<ValidationError> Validate(Order record, Entity entity, RecordCreatePageModel pageModel)
        {
            var result = base.Validate(record, entity, pageModel);

            result.AddRange(ValidateEntries(pageModel));

            return result;
        }

        protected override IActionResult? OnValidationSuccess(Order record, Entity entity, RecordCreatePageModel pageModel)
        {
            record.Id = Guid.NewGuid();

            var entries = GetEntries(pageModel);
            foreach (var entry in entries)
                entry.Order = record.Id.Value;

            void TransactionalAction()
            {
                var result = RepositoryService.OrderRepository.Insert(record)
                    ?? throw new DbException("Could not create order record");

                foreach(var entry in entries)
                {
                    if (RepositoryService.OrderRepository.InsertEntry(entry) == null)
                        throw new DbException("Could not create order entry record");
                }
            }

            if (!Transactional.TryExecute(pageModel, TransactionalAction))
                return FailureResult(record, pageModel, entries, []);

            pageModel.PutMessage(ScreenMessageType.Success, SuccessMessage(entity));

            return pageModel.LocalRedirect(pageModel.EntityDetailUrl(record.Id!.Value));
        }

        protected override IActionResult? OnValidationFailure(Order record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            var entries = GetEntries(pageModel);

            return FailureResult(record, pageModel, entries, validationErrors);
        }

        private static PageResult FailureResult(Order record, RecordCreatePageModel pageModel, List<OrderEntry> entries, List<ValidationError> validationErrors)
        {
            pageModel.Validation.Errors.AddRange(validationErrors);

            record.SetEntries(entries);
            pageModel.DataModel.SetRecord(record);

            pageModel.BeforeRender();

            var result = pageModel.Page();

            return result;
        }

        private static IEnumerable<ValidationError> ValidateEntries(RecordCreatePageModel pageModel)
        {
            var entries = GetEntries(pageModel);

            var articleIds = entries.Select(e => e.Article)
                .Where(g => g != Guid.Empty)
                .Distinct()
                .ToArray();

            var typeLookup = RepositoryService.ArticleRepository.FindMany($"*, ${Article.Relations.Type}.*", articleIds)
                .ToDictionary(kp => kp.Key, kp => kp.Value?.GetArticleType());

            for(var i = 0; i < entries.Count; i++)
            {
                var entry = entries[i];

                if (entry.Article == Guid.Empty)
                    yield return Error(OrderEntry.Fields.Article, i, "Order entry 'article' is required");

                foreach (var error in ValidateAmount(entry, i, typeLookup))
                    yield return error;
            }

            if(entries.Count != articleIds.Length)
            {
                var idx = 0;
                var idxInfo = entries.Select(e => new { Index = idx++, e.Article })
                    .ToArray();

                foreach(var id in articleIds)
                {
                    var occurances = idxInfo.Where(t => t.Article == id)
                        .ToArray();

                    if(occurances.Length > 1)
                    {
                        foreach (var occurance in occurances)
                            yield return Error(OrderEntry.Fields.Article, occurance.Index, "Articles must only occure once");
                    }
                }
            }            
        }

        private static List<ValidationError> ValidateAmount(OrderEntry entry, int idx, Dictionary<Guid, ArticleType?> typeLookup)
        {
            var isInt = typeLookup[entry.Article]?.IsInteger ?? false;

            var validator = new NumberFormatValidator(entry.EntityName, OrderEntry.Fields.Amount, isInt, true, false);

            return validator.Validate(entry.Amount, $"{OrderEntry.Fields.Amount}[{idx}]");
        }


        private static ValidationError Error(string field, int index, string errorMessage)
            => new($"{field}[{index}]", errorMessage);

        private static List<OrderEntry> GetEntries(RecordCreatePageModel pageModel)
        {
            var result = new List<OrderEntry>();

            for(var i = 0; i < int.MaxValue; i++)
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
