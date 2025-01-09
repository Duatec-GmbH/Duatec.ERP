using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class GoodsReceivingValidator : IRecordValidator<GoodsReceiving>
    {
        public List<ValidationError> ValidateOnCreate(GoodsReceiving record)
        {
            return [];
        }

        public List<ValidationError> ValidateOnUpdate(GoodsReceiving record)
        {
            return [];
        }
    }
}
