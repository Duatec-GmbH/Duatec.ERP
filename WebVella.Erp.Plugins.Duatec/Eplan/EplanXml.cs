using System.Xml.Linq;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;

namespace WebVella.Erp.Plugins.Duatec.Eplan
{
    internal static class EplanXml
    {
        public static List<EplanArticle> GetArticles(string text)
            => GetArticles(XElement.Parse(text)).ToList();

        private static IEnumerable<EplanArticle> GetArticles(XElement node)
        {
            if (node == null)
                return [];
            else if (node.Name == "part")
                return [EplanArticle.FromXElement(node)];
            return node.Elements().SelectMany(GetArticles);
        }
    }
}
