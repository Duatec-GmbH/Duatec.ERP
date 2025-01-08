using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Args = (Guid? GoodsReceiving, object? DeliveryNote);

    internal class DeliveryNotesValidator : IRecordValidator<EntityRecord>
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
            var (goodsReceiving, deliveryNote) = GetArgs(record);

            var result = new List<ValidationError>();
            if (!goodsReceiving.HasValue)
                result.Add(new ValidationError(GoodsReceivingEntry.GoodsReceiving, "Delivery notes 'goods receiving' is required"));
            if (deliveryNote == null)
                result.Add(new ValidationError(GoodsReceivingEntry.Article, "Delivery notes 'delivery note' is required"));

            return result;
        }

        private static Args GetArgs(EntityRecord record)
        {
            return (record[DeliveryNote.GoodsReceiving] as Guid?,
                record[DeliveryNote.File]);
        }
    }
}
