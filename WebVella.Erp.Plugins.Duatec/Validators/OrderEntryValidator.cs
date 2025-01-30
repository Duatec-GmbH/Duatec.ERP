using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.TypedRecords.Attributes;
using WebVella.Erp.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Fields = OrderEntry.Fields;

    [TypedValidator(Entity)]
    internal class OrderEntryValidator : IRecordValidator<OrderEntry>
    {
        const string Entity = OrderEntry.Entity;

        public List<ValidationError> ValidateOnCreate(OrderEntry record)
            => Validate(record, null);

        public List<ValidationError> ValidateOnUpdate(OrderEntry record)
            => Validate(record, record.Id!.Value);

        public List<ValidationError> ValidateOnDelete(OrderEntry record)
            => [];

        private static List<ValidationError> Validate(OrderEntry record, Guid? id)
        {
            var result = ValidateAmount(record);            
            result.AddRange(ValidateArticle(record, id));
            return result;
        }

        private static List<ValidationError> ValidateAmount(OrderEntry record)
        {
            var isInt = record.GetArticle().GetArticleType()?.IsInteger ?? false;

            var validator = new NumberFormatValidator(record.EntityName, Fields.Amount, isInt, true, false);

            return validator.Validate(record.Amount, Fields.Amount);
        }

        private static IEnumerable<ValidationError> ValidateArticle(OrderEntry record, Guid? id)
        {
            if (record.Article == Guid.Empty)
                yield return new ValidationError(Fields.Article, "Order entry 'article' is required");

            else if (ArticleAlreadyExists(record, id))
                yield return new ValidationError(Fields.Article, "Current order already contains given article");
        }

        private static bool ArticleAlreadyExists(OrderEntry record, Guid? id)
        {
            return record.Order != Guid.Empty
                && record.Article != Guid.Empty
                && new OrderRepository().FindEntryByOrderAndArticle(record.Order, record.Article, id) != null;
        }
    }
}
