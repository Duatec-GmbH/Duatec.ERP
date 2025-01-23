using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.TypedRecords.Attributes;
using WebVella.Erp.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Fields = InventoryEntry.Fields;

    [TypedValidator(Entity)]
    internal class InventoryEntryValidator : IRecordValidator<InventoryEntry>
    {
        const string Entity = InventoryEntry.Entity;

        public List<ValidationError> ValidateOnCreate(InventoryEntry record)
            => Validate(record);

        public List<ValidationError> ValidateOnUpdate(InventoryEntry record)
            => Validate(record);

        public List<ValidationError> ValidateOnDelete(InventoryEntry record)
            => [];

        private static List<ValidationError> Validate(InventoryEntry record)
        {
            var result = new List<ValidationError>();

            NumberFormatValidator amountValidator;

            if (record.WarehouseLocation == Guid.Empty)
                result.Add(new ValidationError(Fields.WarehouseLocation, "Warehouse location is required"));
            if (record.Article != Guid.Empty)
                amountValidator = GetAmountValidator(record.Article);
            else
            {
                result.Add(new ValidationError(Fields.Article, "Article is required"));
                amountValidator = GetDefaultAmountValidator();
            }

            result.AddRange(amountValidator.Validate(record.Amount, Fields.Amount));

            return result;
        }

        private static NumberFormatValidator GetAmountValidator(Guid article)
        {
            var type = new ArticleRepository().FindTypeByArticleId(article);
            var isInteger = type?.IsInteger is true;
            return new (Entity, Fields.Amount, isInteger, true, false);
        }

        private static NumberFormatValidator GetDefaultAmountValidator()
            => new (Entity, Fields.Amount, true, true, false);
    }
}
