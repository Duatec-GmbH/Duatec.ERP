﻿using System.Xml.Linq;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;

namespace WebVella.Erp.Plugins.Duatec.Eplan.DataModel
{
    internal class EplanPart
    {
        private EplanPart(string deviceTag, string partNumber, string typeNumber, string orderNumber, string description)
        {
            DeviceTag = deviceTag;
            PartNumber = partNumber;
            TypeNumber = typeNumber;
            OrderNumber = orderNumber;
            Description = description;
        }

        /// <summary>
        /// P_FUNC_IDENTDEVICETAG
        /// </summary>
        public string DeviceTag { get; }

        /// <summary>
        /// P_ARTICLEREF_PARTNO
        /// </summary>
        public string PartNumber { get; }

        /// <summary>
        /// XML Attribute P_ARTICLE_TYPENR
        /// </summary>
        public string TypeNumber { get; }

        /// <summary>
        /// XML Attribute P_ARTICLE_ORDERNR
        /// </summary>
        public string OrderNumber { get; }

        /// <summary>
        /// XML Attributes P_ARTICLE_DESCR1, P_ARTICLE_DESCR2, P_ARTICLE_DESCR3
        /// </summary>
        public string Description { get; }


        public static EplanPart FromXElement(XElement element)
        {
            return new EplanPart(
                deviceTag: GetAttributeValue(element, "P_FUNC_IDENTDEVICETAG"),
                partNumber: GetAttributeValue(element, "P_ARTICLEREF_PARTNO"),
                typeNumber: GetAttributeValue(element, "P_ARTICLE_TYPENR"),
                orderNumber: GetAttributeValue(element, "P_ARTICLE_ORDERNR"),
                description: GetDescription(element));
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

        private static string? GetDescription(XElement element, LanguageKey languageKey)
        {
            var descriptions = new string[]
            {
                GetAttributeValue(element, "P_ARTICLE_DESCR1"),
                GetAttributeValue(element, "P_ARTICLE_DESCR2"),
                GetAttributeValue(element, "P_ARTICLE_DESCR3")

            }.Select(s => ExtractDescription(s, languageKey))
            .Where(s => !string.IsNullOrWhiteSpace(s));

            var result = string.Join(" / ", descriptions);
            if (string.IsNullOrWhiteSpace(result))
                return null;
            return result;
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
