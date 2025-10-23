namespace WebVella.Erp.Plugins.Duatec.Services.ArticleFinders
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ArticleFinderAttribute(string shortName) : Attribute
    {
        public string ShortName { get; set; } = shortName;
    }
}
