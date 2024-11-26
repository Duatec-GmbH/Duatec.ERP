using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class OrderListValidator : IRecordValidator
    {
        public List<ValidationError> ValidateOnCreate(EntityRecord record)
        {
            var projectId = record[OrderList.Project] as Guid?;
            var result = ValidateProject(projectId);
            if (projectId.HasValue && OrderList.ByProject(projectId.Value) != null)
                result.Add(new ValidationError(OrderList.Project, "Project has already an order list"));
            return result;
        }

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var projectId = record[OrderList.Project] as Guid?;
            return ValidateProject(projectId);
        }

        private static List<ValidationError> ValidateProject(Guid? projectId)
        {
            var result = new List<ValidationError>();
            if (!projectId.HasValue || projectId.Value == Guid.Empty)
                result.Add(new ValidationError(OrderList.Project, "Order list entry project is required"));
            return result;
        }
    }
}
