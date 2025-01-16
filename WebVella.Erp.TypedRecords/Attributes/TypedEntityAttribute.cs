namespace WebVella.Erp.TypedRecords.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class TypedEntityAttribute : Attribute
    {
        public TypedEntityAttribute(string entity)
        {
            Entity = entity;
        }

        public string Entity { get; }
    }
}
