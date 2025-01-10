using WebVella.Erp.Api.Models;

namespace WebVella.TypedRecords
{
    public abstract class TypedEntityRecordWrapper : EntityRecord
    {
        public abstract string EntityName { get; }

        public Guid? Id
        {
            get => Get<Guid?>("id");
            set => Properties["id"] = value;
        }

        protected virtual void Init(EntityRecord? record)
        {
            if (record != null)
                Properties = record.Properties;

            // TODO: maybe initialize fields here, maybe define default values, but first check if it is possible
        }

        protected T Get<T>(string property, T defaultValue = default!)
        {
            if (!Properties.TryGetValue(property, out var v) || v is not T value)
                return defaultValue;
            return value;
        }

        public bool TryGet<T>(string property, out T result)
        {
            if(!Properties.TryGetValue(property, out var obj) || obj is not T value)
            {
                result = default!;
                return false;
            }
            result = value;
            return true;
        }

        public static T? WrapElseDefault<T>(EntityRecord? record) where T : TypedEntityRecordWrapper, new()
        {
            if (record == null) return null;
            if (record is T r) return r;

            var result = new T();
            result.Init(record);

            return result;
        }

        public static T Wrap<T>(EntityRecord? record) where T : TypedEntityRecordWrapper, new()
        {
            return WrapElseDefault<T>(record)
                ?? throw new ArgumentException($"Argument {nameof(record)} must not be null");
        }
    }
}
