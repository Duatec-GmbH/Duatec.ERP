using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class ArticleStockValidator : IRecordValidator
    {
        public List<ValidationError> ValidateOnCreate(EntityRecord record)
            => Validate(record);

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
            => Validate(record);

        private static List<ValidationError> Validate(EntityRecord record)
        {
            var result = new List<ValidationError>();

            var article = record[ArticleStock.Article] as Guid?;
            var location = record[ArticleStock.WarehouseLocation] as Guid?;

            var amount = record[ArticleStock.Amount]?.ToString() ?? "0";
            NumberFormatValidator amountValidator;

            if (!location.HasValue)
                result.Add(new ValidationError(ArticleStock.WarehouseLocation, "Warehouse location is required"));
            if (article.HasValue)
                amountValidator = GetAmountValidator(article.Value);
            else
            {
                result.Add(new ValidationError(ArticleStock.Article, "Article is required"));
                amountValidator = GetDefaultAmountValidator();
            }

            result.AddRange(amountValidator.ValidateOnCreate(amount, ArticleStock.Amount));

            return result;
        }

        private static NumberFormatValidator GetAmountValidator(Guid article)
        {
            var isInteger = (bool)ArticleType.Find((Guid)Article.Find(article)![Article.Type])
                ![ArticleType.IsInteger];

            return new (ArticleStock.Entity, ArticleStock.Amount, isInteger, true, false);
        }

        private static NumberFormatValidator GetDefaultAmountValidator()
            => new (ArticleStock.Entity, ArticleStock.Amount, true, true, false);
    }
}
