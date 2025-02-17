﻿using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords.Attributes;
using WebVella.Erp.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    [TypedValidator(Entity)]
    internal class GoodsReceivingValidator : IRecordValidator<GoodsReceiving>
    {
        const string Entity = GoodsReceiving.Entity;

        public List<ValidationError> ValidateOnCreate(GoodsReceiving record)
            => [];

        public List<ValidationError> ValidateOnUpdate(GoodsReceiving record)
            => [];

        public List<ValidationError> ValidateOnDelete(GoodsReceiving record)
            => [];
    }
}
