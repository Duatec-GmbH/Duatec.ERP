﻿using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.TypedRecords.Attributes;
using WebVella.Erp.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Fields = GoodsReceivingEntry.Fields;

    [TypedValidator(Entity)]
    internal class GoodsReceivingEntryValidator : IRecordValidator<GoodsReceivingEntry>
    {
        const string Entity = GoodsReceivingEntry.Entity;

        public List<ValidationError> ValidateOnCreate(GoodsReceivingEntry record)
            => Validate(record, null);

        public List<ValidationError> ValidateOnUpdate(GoodsReceivingEntry record)
        {
            var result = new List<ValidationError>();
            if (record.Id.HasValue && record.Id.Value != Guid.Empty)
                result.AddRange(Validate(record, record.Id.Value));
            else
            {
                result.Add(new ValidationError(string.Empty, $"Goods Receiving entry 'id' is required"));
                result.AddRange(Validate(record, null));
            }
            return result;
        }

        public List<ValidationError> ValidateOnDelete(GoodsReceivingEntry record)
            => [];

        private static List<ValidationError> Validate(GoodsReceivingEntry record, Guid? id)
        {
            var result = new List<ValidationError>();

            if (record.GoodsReceiving == Guid.Empty)
                result.Add(new ValidationError(Fields.GoodsReceiving, "Goods receiving entry 'goods receiving' is required"));
            if (record.Article == Guid.Empty)
                result.Add(new ValidationError(Fields.Article, "Goods receiving entry 'article' is required"));
            if (record.GoodsReceiving != Guid.Empty && record.Article != Guid.Empty && RepositoryService.GoodsReceivingRepository.EntryExists(record.GoodsReceiving, record.Article, id))
                result.Add(new ValidationError(Fields.Article, "Goods receiving entry with the same article already exists within goods receiving"));

            if (record.Article != Guid.Empty)
            {
                var type = RepositoryService.ArticleRepository.FindTypeByArticleId(record.Article);
                var amountValidator = GetNumberFormatValidator(Fields.Amount, type);

                result.AddRange(amountValidator.Validate(record.Amount, Fields.Amount));
            }

            return result;
        }

        private static NumberFormatValidator GetNumberFormatValidator(string entityProperty, ArticleType? type)
        {
            var isInteger = type?.IsInteger is true;
            return new NumberFormatValidator(GoodsReceivingEntry.Entity, entityProperty, isInteger, true, false);
        }
    }
}
