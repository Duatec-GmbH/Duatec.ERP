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
            return Validate(record, result);
        }

        public List<ValidationError> ValidateOnUpdate(Order record)
        {
            var result = _orderNumberValidator.ValidateOnUpdate(record.Number, Fields.Number, record.Id!.Value);
            return Validate(record, result);
        }

        private static List<ValidationError> Validate(Order record, List<ValidationError> result)
        {
            if (record.Project == Guid.Empty)
                result.Add(new ValidationError(Fields.Project, "Project is required"));
            if (string.IsNullOrEmpty(record.OfferFile))
                result.Add(new ValidationError(Fields.Offer, "Offer is required"));
            if (string.IsNullOrEmpty(record.OrderFile))
                result.Add(new ValidationError(Fields.Order, "Order is required"));
            if (string.IsNullOrEmpty(record.ConfirmationFile))
                result.Add(new ValidationError(Fields.Confirmation, "Confirmation is required"));

            return result;
        }

        public List<ValidationError> ValidateOnDelete(Order record)
            => [];
    }
}
