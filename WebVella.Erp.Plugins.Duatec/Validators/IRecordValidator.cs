using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    public interface IRecordValidator<in T> where T : EntityRecord
    {
        List<ValidationError> ValidateOnCreate(T record);

        List<ValidationError> ValidateOnUpdate(T record);
    }
}
