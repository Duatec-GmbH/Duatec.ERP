using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.TypedRecords.Attributes;
using WebVella.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    [TypedValidator(typeof(GoodsReceiving))]
    internal class GoodsReceivingValidator : IRecordValidator<GoodsReceiving>
    {
        public List<ValidationError> ValidateOnCreate(GoodsReceiving record)
            => [];

        public List<ValidationError> ValidateOnUpdate(GoodsReceiving record)
            => [];

        public List<ValidationError> ValidateOnDelete(GoodsReceiving record)
            => [];
    }
}
