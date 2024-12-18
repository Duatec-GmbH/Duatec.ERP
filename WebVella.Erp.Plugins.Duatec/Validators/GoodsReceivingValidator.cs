using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class GoodsReceivingValidator : IRecordValidator<EntityRecord>
    {
        public List<ValidationError> ValidateOnCreate(EntityRecord record)
        {
            return [];
        }

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            return [];
        }
    }
}
