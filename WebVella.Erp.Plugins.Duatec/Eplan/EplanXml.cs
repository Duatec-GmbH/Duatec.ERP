using System.Xml.Linq;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;

namespace WebVella.Erp.Plugins.Duatec.Eplan
{
    internal static class EplanXml
    {
        public static List<EplanArticle> GetArticles(string text)
        {
            return GetArticles(XElement.Parse(text))
                .DistinctBy(a => (a.PartNumber, a.OrderNumber, a.TypeNumber))
                .ToList();
        }

        private static IEnumerable<EplanArticle> GetArticles(XElement node)
        {
            if (node == null)
                return [];
            else if (node.Name != "part")
                return node.Elements().SelectMany(GetArticles);

            var article = EplanArticle.FromXElement(node);
            if (article == null || string.IsNullOrEmpty(article.PartNumber))
                return [];

            return [article];
        }
    }
}
