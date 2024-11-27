using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Args = (Guid? OrderList, Guid? Article, Guid? Order, decimal Amount);

    internal class OrderListEntryValidator : IRecordValidator
    {

        public List<ValidationError> ValidateOnCreate(EntityRecord record)
            => Validate(record, null);

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var result = new List<ValidationError>();
            if (record["id"] is Guid id)
                result.AddRange(Validate(record, id));
            else
            {
                result.Add(new ValidationError(string.Empty, $"Order list entry 'id' is required"));
                result.AddRange(Validate(record, null));
            }
            return result;
        }

        private static List<ValidationError> Validate(EntityRecord record, Guid? id)
        {
            var (orderList, article, order, amount) = GetArgs(record);

            var result = new List<ValidationError>();
            if (!orderList.HasValue)
                result.Add(new ValidationError(OrderListEntry.OrderList, "Order list entry 'order list' is required"));
            if (!article.HasValue)
                result.Add(new ValidationError(OrderListEntry.Article, "Order list entry 'article' is required"));
            if (orderList.HasValue && article.HasValue && OrderListEntry.Exists(orderList.Value, article.Value, order, id))
                result.Add(new ValidationError(string.Empty, "Order list entry with same article and order already exists"));

            if (article.HasValue)
            {
                var type = ArticleType.FromArticle(article.Value);
                var amountValidator = GetNumberFormatValidator(OrderListEntry.Amount, type);
                result.AddRange(amountValidator.Validate(amount.ToString(), OrderListEntry.Amount));
            }
            return result;
        }

        private static Args GetArgs(EntityRecord record)
        {
            return (record[OrderListEntry.OrderList] as Guid?,
                record[OrderListEntry.Article] as Guid?,
                record[OrderListEntry.Order] as Guid?,
                record[OrderListEntry.Amount] as decimal? ?? 0m);
        }

        private static NumberFormatValidator GetNumberFormatValidator(string entityProperty, EntityRecord? type)
        {
            var isInteger = type == null || (bool)type[ArticleType.IsInteger];
            return new NumberFormatValidator(PartListEntry.Entity, entityProperty, isInteger, true, false);
        }
    }
}
