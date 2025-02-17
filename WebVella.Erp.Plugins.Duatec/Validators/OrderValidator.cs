using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.TypedRecords.Attributes;
using WebVella.Erp.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Validators
{ 
    using Fields = Order.Fields;

    [TypedValidator(Entity)]
    internal class OrderValidator : IRecordValidator<Order>
    {
        const string Entity = Order.Entity;
        private static readonly NameUniqueValidator _orderNumberValidator = new(Entity, Fields.Number);

        public List<ValidationError> ValidateOnCreate(Order record)
        {
            return _orderNumberValidator.ValidateOnCreate(record.Number, Fields.Number);
        }

        public List<ValidationError> ValidateOnUpdate(Order record)
        {
            return _orderNumberValidator.ValidateOnUpdate(record.Number, Fields.Number, record.Id!.Value);
        }

        public List<ValidationError> ValidateOnDelete(Order record)
            => [];
    }
}
