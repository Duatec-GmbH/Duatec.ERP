using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords.Attributes;
using WebVella.Erp.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Fields = DeliveryNote.Fields;

    [TypedValidator(Entity)]
    internal class DeliveryNoteValidator : IRecordValidator<DeliveryNote>
    {
        const string Entity = DeliveryNote.Entity;

        public List<ValidationError> ValidateOnCreate(DeliveryNote record)
            => Validate(record);

        public List<ValidationError> ValidateOnUpdate(DeliveryNote record)
            => Validate(record);

        public List<ValidationError> ValidateOnDelete(DeliveryNote record)
            => [];

        private static List<ValidationError> Validate(DeliveryNote record)
        {
            var result = new List<ValidationError>();
            if (record.GoodsReceiving == Guid.Empty)
                result.Add(new ValidationError(Fields.GoodsReceiving, "Delivery notes 'goods receiving' is required"));
            if (record.File == null)
                result.Add(new ValidationError(Fields.File, "Delivery notes 'file' is required"));

            return result;
        }
    }
}
