using WebVella.Erp.Eql;
using WebVella.Erp.Exceptions;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    internal class NameUniqueValidator(string entity, string entityProperty)
        : NameFormatValidator(entity, entityProperty, true)
    {
        protected bool RecordExists(string value, Guid id = default)
        {
            var cmd = new EqlCommand($"select id from {_entity} where {_entityProperty} = @param and id != @id",
                new EqlParameter("param", value),
                new EqlParameter("id", id));

            return cmd.Execute()?.Count is > 0;
        }

        public virtual List<ValidationError> ValidateOnCreate(string value, string formField)
            => Validate(value, formField, default);

        public virtual List<ValidationError> ValidateOnUpdate(string value, string formField, Guid id)
            => Validate(value, formField, id);

        private List<ValidationError> Validate(string value, string formField, Guid id)
        {
            var result = base.ValidateFormat(value, formField);
            if (result.Count == 0 && RecordExists(value, id))
                result.Add(new ValidationError(formField, $"{_entityPretty} with {_entityPropertyPretty} '{value}' already exists"));
            return result;
        }
    }
}
