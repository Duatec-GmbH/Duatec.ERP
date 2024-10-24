﻿using WebVella.Erp.Api.Models;
using WebVella.Erp.Eql;
using WebVella.Erp.Plugins.Duatec.Entities;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class ArticleEquivalents : CodeDataSource
    {
        public ArticleEquivalents() : base()
        {
            Id = new Guid("33a3f693-5f26-478e-8ded-64b8f8009798");
            Name = nameof(ArticleEquivalents);
            Description = "All equivalents of an article";
            ResultModel = nameof(EntityRecordList);

            Parameters.Add(new DataSourceParameter { Name = "id", Type = "guid", Value = "null" });
            Parameters.Add(new DataSourceParameter { Name = "sortBy", Type = "text", Value = Article.PartNumber });
            Parameters.Add(new DataSourceParameter { Name = "sortOrder", Type = "text", Value = "asc" });
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var result = new EntityRecordList();
            if (!arguments.TryGetValue("id", out var objId) || objId is not Guid id)
                return result;

            var cmd = new EqlCommand($"select {ArticleEquivalent.Target} from {ArticleEquivalent.Entity} " +
                $"where {ArticleEquivalent.Source} = @id",
                new EqlParameter("id", id));

            var targets = cmd.Execute();
            var articles = targets.Select(target => Article.Find((Guid)target[ArticleEquivalent.Target])!)
                .Where(a => a != null)!;

            var sortBy = (string)arguments["sortBy"];
            var sortOrder = (string)arguments["sortOrder"];

            if (sortBy == Article.Designation)
                articles = articles.OrderBy(a => (string)a[Article.Designation]);
            else articles = articles.OrderBy(a => (string)a[Article.PartNumber]);

            if (sortOrder == "desc")
                articles = articles.Reverse();

            foreach (var article in articles)
                result.Add(article);

            result.TotalCount = result.Count;
            return result;  
        }
    }
}
