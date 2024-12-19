using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class ArticleStockValidator : IRecordValidator<InventoryEntry>
    {
        public List<ValidationError> ValidateOnCreate(InventoryEntry record)
            => Validate(record);

        public List<ValidationError> ValidateOnUpdate(InventoryEntry record)
            => Validate(record);

        private static List<ValidationError> Validate(InventoryEntry record)
        {
            var result = new List<ValidationError>();

            var article = record.Article;
            var location = record.WarehouseLocation;
            var amount = record.Amount;

            NumberFormatValidator amountValidator;

            if (location == Guid.Empty)
                result.Add(new ValidationError(InventoryEntry.Fields.WarehouseLocation, "Warehouse location is required"));
            if (article != Guid.Empty)
                amountValidator = GetAmountValidator(article);
            else
            {
                result.Add(new ValidationError(InventoryEntry.Fields.Article, "Article is required"));
                amountValidator = GetDefaultAmountValidator();
            }

            result.AddRange(amountValidator.Validate(amount, InventoryEntry.Fields.Amount));

            return result;
        }

        private static NumberFormatValidator GetAmountValidator(Guid article)
        {
            var type = Repository.Article.FindTypeByArticleId(article);
            var isInteger = type?.IsInteger is true;
            return new (InventoryEntry.Entity, InventoryEntry.Fields.Amount, isInteger, true, false);
        }

        private static NumberFormatValidator GetDefaultAmountValidator()
            => new (InventoryEntry.Entity, InventoryEntry.Fields.Amount, true, true, false);
    }
}
