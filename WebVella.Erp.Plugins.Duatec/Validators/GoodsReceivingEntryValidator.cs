using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Args = (Guid? GoodsReceiving, Guid? Article, decimal Amount);

    internal class GoodsReceivingEntryValidator : IRecordValidator
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
                result.Add(new ValidationError(string.Empty, $"Part list entry 'id' is required"));
                result.AddRange(Validate(record, null));
            }
            return result;
        }

        private static List<ValidationError> Validate(EntityRecord record, Guid? id)
        {
            var (goodsReceiving, article, amount) = GetArgs(record);

            var result = new List<ValidationError>();
            if (!goodsReceiving.HasValue)
                result.Add(new ValidationError(GoodsReceivingEntry.GoodsReceiving, "Goods receiving entry 'goods receiving' is required"));
            if (!article.HasValue)
                result.Add(new ValidationError(GoodsReceivingEntry.Article, "Goods receiving entry 'article' is required"));
            if (goodsReceiving.HasValue && article.HasValue && GoodsReceivingEntry.Exists(goodsReceiving.Value, article.Value, id))
                result.Add(new ValidationError(GoodsReceivingEntry.Article, "Goods receiving entry with the same article already exists within goods receiving"));

            if (article.HasValue)
            {
                var type = ArticleType.FromArticle(article.Value);
                var amountValidator = GetNumberFormatValidator(GoodsReceivingEntry.Amount, type);

                result.AddRange(amountValidator.Validate(amount.ToString(), GoodsReceivingEntry.Amount));
            }

            return result;
        }

        private static Args GetArgs(EntityRecord record)
        {
            return (record[GoodsReceivingEntry.GoodsReceiving] as Guid?,
                record[GoodsReceivingEntry.Article] as Guid?,
                record[GoodsReceivingEntry.Amount] as decimal? ?? 0m);
        }

        private static NumberFormatValidator GetNumberFormatValidator(string entityProperty, EntityRecord? type)
        {
            var isInteger = type == null || (bool)type[ArticleType.IsInteger];
            return new NumberFormatValidator(GoodsReceivingEntry.Entity, entityProperty, isInteger, true);
        }
    }
}
