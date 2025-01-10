namespace WebVella.Erp.Plugins.Duatec.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal class ValidatorAttribute : Attribute
    {
        public ValidatorAttribute(Type targetType)
        {
            TargetType = targetType;
        }

        public Type TargetType { get; }
    }
}
