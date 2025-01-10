using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class DeliveryNotesValidator : IRecordValidator<DeliveryNote>
    {
        public List<ValidationError> ValidateOnCreate(DeliveryNote record)
            => Validate(record);

        public List<ValidationError> ValidateOnUpdate(DeliveryNote record)
            => Validate(record);

        private static List<ValidationError> Validate(DeliveryNote record)
        {
            var result = new List<ValidationError>();
            if (record.GoodsReceiving == Guid.Empty)
                result.Add(new ValidationError(DeliveryNote.Fields.GoodsReceiving, "Delivery notes 'goods receiving' is required"));
            if (record.File == null)
                result.Add(new ValidationError(DeliveryNote.Fields.File, "Delivery notes 'file' is required"));

            return result;
        }
    }
}
