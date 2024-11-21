using System.Xml.Linq;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;

namespace WebVella.Erp.Plugins.Duatec.Eplan
{
    internal static class EplanXml
    {
        public static List<EplanArticle> GetArticles(Stream stream)
        {
            return GetParts(XElement.Load(stream))
                .Where(p => !string.IsNullOrEmpty(p.PartNumber))
                .DistinctBy(a => (a.PartNumber, a.OrderNumber, a.TypeNumber, a.Description))
                .Select(EplanArticle.FromPart)
                .ToList();
        }

        public static List<EplanPart> GetParts(Stream stream)
        {
            return GetParts(XElement.Load(stream))
                .ToList(); 
        }

        private static IEnumerable<EplanPart> GetParts(XElement node)
        {
            return All(node)
                .Where(n => n.Name == "part")
                .Select(EplanPart.FromXElement);
        }

        private static IEnumerable<XElement> All(XElement element)
        {
            if (element == null)
                return [];
            return element.Elements()
                .SelectMany(All)
                .Prepend(element);
        }
    }
}
