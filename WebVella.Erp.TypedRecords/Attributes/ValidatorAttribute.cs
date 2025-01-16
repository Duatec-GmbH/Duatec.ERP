namespace WebVella.Erp.TypedRecords.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal class ValidatorAttribute : Attribute
    {
        public ValidatorAttribute(string entity)
        {
            Entity = entity;
        }

        public string Entity { get; }
    }
}
