﻿using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class ArticleEquivalents : CodeDataSource
    {
        public static class Arguments
        {
            public const string Id = "id";
            public const string SortBy = "sortBy";
            public const string SortOrder = "sortOrder";
        }

        public ArticleEquivalents() : base()
        {
            Id = new Guid("33a3f693-5f26-478e-8ded-64b8f8009798");
            Name = nameof(ArticleEquivalents);
            Description = "All equivalents of an article";
            ResultModel = nameof(EntityRecordList);

            Parameters.Add(new DataSourceParameter { Name = Arguments.Id, Type = "guid", Value = "null" });
            Parameters.Add(new DataSourceParameter { Name = Arguments.SortBy, Type = "text", Value = Article.Fields.PartNumber });
            Parameters.Add(new DataSourceParameter { Name = Arguments.SortOrder, Type = "text", Value = "asc" });
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var result = new EntityRecordList();
            if (!arguments.TryGetValue(Arguments.Id, out var objId) || objId is not Guid id)
                return result;

            IEnumerable<Article> articles = new ArticleRepository()
                .FindAlternatives(id, $"*, ${Article.Relations.Manufacturer}.name");

            var sortBy = (string)arguments[Arguments.SortBy];
            var sortOrder = (string)arguments[Arguments.SortOrder];

            if (sortBy == Article.Fields.Designation)
                articles = articles.OrderBy(a => a.Designation);
            else articles = articles.OrderBy(a => a.PartNumber);

            if (sortOrder == "desc")
                articles = articles.Reverse();

            foreach (var article in articles)
                result.Add(article);

            result.TotalCount = result.Count;
            return result;  
        }
    }
}
