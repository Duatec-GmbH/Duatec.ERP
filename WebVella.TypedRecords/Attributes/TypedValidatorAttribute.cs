namespace WebVella.TypedRecords.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class TypedValidatorAttribute : Attribute
    {
        public TypedValidatorAttribute(string entity)
        {
            Entity = entity;
        }

        public string Entity { get; }
    }
}
