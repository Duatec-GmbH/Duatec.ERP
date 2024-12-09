﻿using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class Article
    {
        public static class Relations
        {
            public const string Manufacturer = "article_manufacturer";
            public const string Type = "article_article_type";
        }

        public static Guid DefaultType { get; } = new Guid("14a2d274-c18e-46f8-a920-2814ea5faa2d");

        public const string Entity = "article";
        public const string EplanId = "eplan_id";
        public const string PartNumber = "part_number";
        public const string TypeNumber = "type_number";
        public const string OrderNumber = "order_number";
        public const string Designation = "designation";
        public const string Type = "article_type";
        public const string ManufacturerId = "manufacturer_id";
        public const string Image = "preview";
        public const string IsBlocked = "is_blocked";

        public static EntityRecord? Find(Guid id)
            => Record.Find(Entity, id, $"*, ${Relations.Manufacturer}.{Manufacturer.Name}");

        public static bool HasAlternatives(Guid id)
            => Record.Exists(ArticleAlternative.Entity, ArticleAlternative.Source, id);

        public static bool Exists(long eplanId)
            => Record.Exists(Entity, EplanId, eplanId.ToString());

        public static bool Exists(string partNumber)
            => Record.Exists(Entity, PartNumber, partNumber);

        public static Dictionary<string, EntityRecord?> FindMany(params string[] partNumbers)
        {
            if (partNumbers.Length == 0)
                return [];

            var recMan = new RecordManager();
            var subQuery = partNumbers
                .Select(pn => new QueryObject() { QueryType = QueryType.EQ, FieldName = PartNumber, FieldValue = pn })
                .ToList();

            var queryResponse = recMan.Find(new EntityQuery(Entity, $"*, ${Relations.Manufacturer}.{Manufacturer.Name}",
                new QueryObject() { QueryType = QueryType.OR, SubQueries = subQuery }));

            var result = new Dictionary<string, EntityRecord?>(partNumbers.Length);
            foreach (var pn in partNumbers)
                result[pn] = null;

            if(queryResponse.Object?.Data != null)
            {
                foreach (var obj in queryResponse.Object.Data)
                    result[(string)obj[PartNumber]] = obj;
            }

            return result;
        }

        public static async Task<Dictionary<string, EntityRecord?>> FindManyAsync(params string[] partNumbers)
        {
            var t = new Task<Dictionary<string, EntityRecord?>>(() => FindMany(partNumbers));
            t.Start();
            return await t;
        }

        public static Guid? Insert(DataPortalArticle article, Guid manufacturerId, Guid typeId)
        {
            var rec = new EntityRecord();

            rec[PartNumber] = article.PartNumber;
            rec[TypeNumber] = article.TypeNumber;
            rec[OrderNumber] = article.OrderNumber;
            rec[EplanId] = article.EplanId.ToString();
            rec[Designation] = article.Designation;
            rec[ManufacturerId] = manufacturerId;
            rec[Type] = typeId;
            rec[Image] = article.PictureUrl;

            return Record.Insert(Entity, rec);
        }
    }
}
