﻿
using WebVella.Erp.Api.Models;
using WebVella.Erp.Eql;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class ArticleType
    {
        public const string Entity = "article_type";
        public const string Label = "label";
        public const string Unit = "unit";

        public static EntityRecord? Find(Guid id)
        {
            var cmd = new EqlCommand($"select * from {Entity} where id = @param",
                new EqlParameter("param", id));

            return cmd.Execute()?.SingleOrDefault();
        }
    }
}
