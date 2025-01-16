using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;

namespace WebVella.Erp.TypedRecords.Validation
{
    public interface IRecordValidator
    {
        List<ValidationError> ValidateOnCreate(EntityRecord record);

        List<ValidationError> ValidateOnUpdate(EntityRecord record);

        List<ValidationError> ValidateOnDelete(EntityRecord record);
    }


    public interface IRecordValidator<in T> : IRecordValidator where T : TypedEntityRecordWrapper, new()
    {
        List<ValidationError> IRecordValidator.ValidateOnCreate(EntityRecord record)
            => ValidateOnCreate(TypedEntityRecordWrapper.Wrap<T>(record));

        List<ValidationError> IRecordValidator.ValidateOnUpdate(EntityRecord record)
            => ValidateOnUpdate(TypedEntityRecordWrapper.Wrap<T>(record));

        List<ValidationError> IRecordValidator.ValidateOnDelete(EntityRecord record)
            => ValidateOnDelete(TypedEntityRecordWrapper.Wrap<T>(record));

        List<ValidationError> ValidateOnCreate(T record);

        List<ValidationError> ValidateOnUpdate(T record);

        List<ValidationError> ValidateOnDelete(T record);
    }
}
