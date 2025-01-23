using System.Xml.Linq;
using WebVella.Erp.Plugins.Duatec.Services.EplanTypes.DataModel;

namespace WebVella.Erp.Plugins.Duatec.Services
{
    internal static class EplanXml
    {
        public static List<EplanArticleDto> GetArticles(Stream stream)
        {
            return GetParts(XElement.Load(stream))
                .DistinctBy(a => (a.PartNumber, a.OrderNumber, a.TypeNumber, a.Description))
                .Select(EplanArticleDto.FromPart)
                .ToList();
        }

        public static List<EplanPartDto> GetParts(Stream stream)
        {
            return GetParts(XElement.Load(stream))
                .ToList();
        }

        private static IEnumerable<EplanPartDto> GetParts(XElement node)
        {
            return All(node)
                .Where(n => n.Name == "part")
                .Select(EplanPartDto.FromXElement)
                .Where(p => !string.IsNullOrEmpty(p.PartNumber));
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
