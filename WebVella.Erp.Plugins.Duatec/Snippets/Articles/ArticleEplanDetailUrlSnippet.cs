using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles
{
    [Snippet]
    internal class ArticleEplanDetailUrlSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
            if (rec == null)
                return null;

            var article = new Article(rec);
            var manufacturer = Repository.Company.Find(article.Manufacturer)?.Name;

            if (string.IsNullOrEmpty(article.PartNumber) || string.IsNullOrEmpty(article.EplanId) || string.IsNullOrEmpty(manufacturer))
                return null;

            return $"https://dataportal.eplan.com/part-details/{manufacturer}/{article.PartNumber}/id-{article.EplanId}";
        }
    }
}
