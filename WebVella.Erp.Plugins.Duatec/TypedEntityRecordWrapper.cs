using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec
{
    public abstract class TypedEntityRecordWrapper : EntityRecord
    {
        public Guid? Id
        {
            get => TryGet<Guid?>("id");
            set => Properties["id"] = value;
        }

        protected virtual void Init(EntityRecord? record)
        {
            if (record != null)
                Properties = record.Properties;

            // TODO: think about also initialize fields here
        }

        protected T TryGet<T>(string property, T defaultValue = default!)
        {
            if (!Properties.TryGetValue(property, out var v) || v is not T value)
                return defaultValue;
            return value;
        }

        public static T? Cast<T>(EntityRecord? record) where T : TypedEntityRecordWrapper, new()
        {
            if (record == null) return null;
            if (record is T r) return r;

            var result = new T();
            result.Init(record);

            return result;
        }
    }
}
