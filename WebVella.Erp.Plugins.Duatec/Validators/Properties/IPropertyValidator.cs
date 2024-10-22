using WebVella.Erp.Exceptions;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    internal interface IPropertyValidator<in T>
    {
        List<ValidationError> ValidateOnUpdate(T value, string formField, Guid id);

        List<ValidationError> ValidateOnCreate(T value, string formField);
    }
}
