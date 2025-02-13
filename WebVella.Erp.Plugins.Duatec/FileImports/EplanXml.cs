using System.Xml.Linq;
using WebVella.Erp.Plugins.Duatec.FileImports.EplanTypes.DataModel;

namespace WebVella.Erp.Plugins.Duatec.FileImports
{
    internal static class EplanXml
    {
        public static List<EplanArticleDto> GetArticles(Stream stream)
        {
            return GetParts(XElement.Load(stream))
                .GroupBy(a => (a.PartNumber, a.OrderNumber, a.TypeNumber, a.Description))
                .Select(g => EplanArticleDto.FromPart(g.First(), GetDeviceTags(g), g.Count()))
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

        private static List<string> GetDeviceTags(IEnumerable<EplanPartDto> parts)
        {
            return parts.Where(p => !string.IsNullOrWhiteSpace(p.DeviceTag))
                .Select(p => p.DeviceTag)
                .Order()
                .ToList();
        }
    }
}
