namespace WebVella.TypedRecords.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class TypedValidatorAttribute : Attribute
    {
        public TypedValidatorAttribute(Type targetType)
        {
            TargetType = targetType;
        }

        public Type TargetType { get; }
    }
}
