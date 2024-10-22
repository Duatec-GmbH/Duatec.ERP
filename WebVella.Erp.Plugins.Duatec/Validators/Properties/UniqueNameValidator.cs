using WebVella.Erp.Eql;
using WebVella.Erp.Exceptions;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    public class UniqueNameValidator(string entity, string entityProperty)
        : NameValidator(entity, entityProperty)
    {
        protected bool RecordExists(string value, Guid id = default)
        {
            var cmd = new EqlCommand($"select id from {_entity} where {_entityProperty} = @param and id != @id",
                new EqlParameter("param", value),
                new EqlParameter("id", id));

            return cmd.Execute()?.Count is > 0;
        }

        public override List<ValidationError> ValidateOnCreate(string value, string formField)
            => ValidateOnUpdate(value, formField, default);

        public override List<ValidationError> ValidateOnUpdate(string value, string formField, Guid id)
        {
            var result = base.ValidateFormat(value, formField);
            if (result.Count == 0 && RecordExists(value, id))
                result.Add(new ValidationError(formField, $"{_entityPretty} with {_entityPropertyPretty} '{value}' already exists"));
            return result;
        }
    }
}
