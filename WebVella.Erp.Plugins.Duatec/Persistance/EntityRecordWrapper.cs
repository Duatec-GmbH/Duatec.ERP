using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Persistance
{
    public abstract class EntityRecordWrapper : EntityRecord
    {
        public EntityRecordWrapper() 
            : base() { }

        public EntityRecordWrapper(EntityRecord record) 
            : base() { Properties = record.Properties; }

        public Guid? Id
        {
            get => TryGet<Guid?>("id");
            set => Properties["id"] = value;
        }

        public T TryGet<T>(string property, T defaultValue = default!)
        {
            if (!Properties.TryGetValue(property, out var v) || v is not T value)
                return defaultValue;
            return value;
        }
    }
}
