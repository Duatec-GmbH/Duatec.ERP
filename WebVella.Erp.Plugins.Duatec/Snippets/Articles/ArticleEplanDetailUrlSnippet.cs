using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
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

            var partNumber = rec[Article.PartNumber]?.ToString();
            var eplanId = rec[Article.EplanId]?.ToString();
            var manufacturer = Manufacturer.Find((Guid)rec[Article.ManufacturerId])?[Manufacturer.Name]?.ToString();

            if (string.IsNullOrEmpty(partNumber) || string.IsNullOrEmpty(eplanId) || string.IsNullOrEmpty(manufacturer))
                return null;

            return $"https://dataportal.eplan.com/part-details/{manufacturer}/{partNumber}/id-{eplanId}";
        }
    }
}
