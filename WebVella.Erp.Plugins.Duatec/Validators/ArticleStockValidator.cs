using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class ArticleStockValidator : IRecordValidator
    {
        private readonly static string _entityPretty = Text.FancyfySnakeCaseStartWithUpper(ArticleStock.Entity);
        private readonly static string _articlePretty = Text.FancyfySnakeCase(Article.Entity);
        private readonly static string _locationPretty = Text.FancyfySnakeCase(WarehouseLocation.Entity);
        private static readonly NumberFormatValidator _amountValidator 
            = new(ArticleStock.Entity, ArticleStock.Amount, false, true);

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

            if (!article.HasValue)
                result.Add(new ValidationError(ArticleStock.Article, $"{_entityPretty} {_articlePretty} is required"));
            if (!location.HasValue)
                result.Add(new ValidationError(ArticleStock.WarehouseLocation, $"{_entityPretty} {_locationPretty} is required"));

            result.AddRange(_amountValidator.ValidateOnCreate(amount, ArticleStock.Amount));

            return result;
        }
    }
}
