using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
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
        private static readonly NameFormatValidator _nameValidator = new(Entity, Fields.Number, true);

        public List<ValidationError> ValidateOnCreate(Order record)
        {
            return Validate(record);
        }

        public List<ValidationError> ValidateOnUpdate(Order record)
        {
            return Validate(record);
        }

        private static List<ValidationError> Validate(Order record)
        {
            var result = _nameValidator.Validate(record.Number, Fields.Number);

            if (!record.Project.HasValue || record.Project == Guid.Empty)
                result.Add(new ValidationError(Fields.Project, "Project is required"));
            else
            {
                var orders = new OrderRepository().FindManyByProject(record.Project.Value);

                if (orders.Any(o => o.Id != record.Id && o.Number == record.Number))
                    result.Add(new ValidationError(Fields.Number, "Order number must be unique within project"));
            }

            return result;
        }

        public List<ValidationError> ValidateOnDelete(Order record)
            => [];
    }
}
