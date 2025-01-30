using WebVella.Erp.Exceptions;
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
        {
            if (record.GetEntries().Any(e => e.StoredAmount > 0))
                return [new ValidationError(string.Empty, "Can not delete goods receiving record because one or more entries are already stored")];
            return [];
        }
    }
}
