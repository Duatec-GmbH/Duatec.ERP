using System.Xml.Linq;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;

namespace WebVella.Erp.Plugins.Duatec.Eplan.DataModel
{
    internal class EplanArticle
    {
        private EplanArticle(string partNumber, string typeNumber, string orderNumber, string description, int count)
        {
            PartNumber = partNumber;
            TypeNumber = typeNumber;
            OrderNumber = orderNumber;
            Description = description;
            Count = count;
        }

        /// <summary>
        /// P_ARTICLEREF_PARTNO
        /// </summary>
        public string PartNumber { get; }

        /// <summary>
        /// P_ARTICLE_TYPENR
        /// </summary>
        public string TypeNumber { get; }

        /// <summary>
        /// P_ARTICLE_ORDERNR
        /// </summary>
        public string OrderNumber { get; }

        /// <summary>
        /// P_ARTICLE_DESCR1, P_ARTICLE_DESCR2, P_ARTICLE_DESCR3
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// P_ARTICLEREF_COUNT
        /// </summary>
        public int Count { get; }


        public static EplanArticle FromXElement(XElement element)
        {
            return new EplanArticle(
                partNumber: GetAttributeValue(element, "P_ARTICLEREF_PARTNO"),
                typeNumber: GetAttributeValue(element, "P_ARTICLE_TYPENR"),
                orderNumber: GetAttributeValue(element, "P_ARTICLE_ORDERNR"),
                description: GetDescription(element),
                count: GetCount(element));
        }

        public EntityRecord ToRecord()
        {
            var rec = new EntityRecord();
            rec[Article.PartNumber] = PartNumber;
            rec[Article.OrderNumber] = OrderNumber;
            rec[Article.TypeNumber] = TypeNumber;
            rec[Article.Designation] = Description;
            rec["count"] = Count;
            return rec;
        }

        private static string GetAttributeValue(XElement element, string attributeName)
            => element.Attribute(attributeName)?.Value ?? string.Empty;

        private static string GetDescription(XElement element)
        {
            LanguageKey? lang = LanguageKeys.Default;
            var description = GetDescription(element, lang.Value);

            while (description == null)
            {
                lang = LanguageKeys.FallBackLanguage(lang!.Value);
                if (!lang.HasValue)
                    description = string.Empty;
                else
                    description = GetDescription(element, lang.Value);
            }
            return description;
        }

        private static int GetCount(XElement element)
        {
            var val = GetAttributeValue(element, "P_ARTICLEREF_COUNT");
            return int.Parse(val);
        }

        private static string? GetDescription(XElement element, LanguageKey languageKey)
        {
            var descriptions = new string[]
            {
                GetAttributeValue(element, "P_ARTICLE_DESCR1"),
                GetAttributeValue(element, "P_ARTICLE_DESCR2"),
                GetAttributeValue(element, "P_ARTICLE_DESCR3")

            }.Select(s => ExtractDescription(s, languageKey))
            .Where(s => !string.IsNullOrEmpty(s));

            return string.Join(" / ", descriptions);
        }

        private static string ExtractDescription(string value, LanguageKey languageKey)
        {
            var langKey = $"{languageKey}@";
            var idx = value.IndexOf(langKey);
            if (idx < 0)
                return string.Empty;
            idx += langKey.Length;

            var end = value.IndexOf(';', idx);
            if (end < 0)
                return string.Empty;

            return value[idx..end];
        }

        public static Dictionary<string, EntityRecord?> FindMany(params string[] partNumbers)
        {
            if (partNumbers.Length == 0)
                return [];

            var recMan = new RecordManager();
            var subQuery = partNumbers
                .Select(pn => new QueryObject() { QueryType = QueryType.EQ, FieldName = Article.PartNumber, FieldValue = pn })
                .ToList();

            var queryResponse = recMan.Find(new EntityQuery(Article.Entity, $"*, ${Article.Relations.Manufacturer}.{Manufacturer.Name}",
                new QueryObject() { QueryType = QueryType.OR, SubQueries = subQuery }));

            var result = new Dictionary<string, EntityRecord?>(partNumbers.Length);
            foreach (var pn in partNumbers)
                result[pn] = null;

            foreach (var obj in queryResponse.Object.Data)
                result[(string)obj[Article.PartNumber]] = obj;

            return result;
        }
    }
}
