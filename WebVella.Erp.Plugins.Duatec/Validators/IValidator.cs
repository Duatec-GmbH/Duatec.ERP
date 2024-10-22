using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    public interface IValidator
    {
        List<ValidationError> ValidateOnCreate(EntityRecord record);

        List<ValidationError> ValidateOnUpdate(EntityRecord record);
    }
}
