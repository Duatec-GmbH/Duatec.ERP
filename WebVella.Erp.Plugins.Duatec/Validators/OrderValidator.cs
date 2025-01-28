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
            var result = _orderNumberValidator.ValidateOnCreate(record.Number, Fields.Number);
            return ForeignKeyValidations(record, result);
        }

        public List<ValidationError> ValidateOnUpdate(Order record)
        {
            var result = _orderNumberValidator.ValidateOnUpdate(record.Number, Fields.Number, record.Id!.Value);
            return ForeignKeyValidations(record, result);
        }

        private static List<ValidationError> ForeignKeyValidations(Order record, List<ValidationError> result)
        {
            if (record.Project == Guid.Empty)
                result.Add(new ValidationError(Fields.Project, "Order field 'project' is required"));
            return result;
        }

        public List<ValidationError> ValidateOnDelete(Order record)
            => [];
    }
}
