﻿using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services.EplanTypes.DataModel;

namespace WebVella.Erp.Plugins.Duatec.Services.EplanTypes
{
    internal class ArticleImportResult
    {
        public ArticleImportResult(
            string partNumber, string typeNumber, string orderNumber, string designation, Guid type,
            ArticleImportState importState, string action, string[] availableActions)
        {
            PartNumber = partNumber;
            TypeNumber = typeNumber;
            OrderNumber = orderNumber;
            Designation = designation;
            ImportState = importState;
            Type = type;
            Action = action;
            AvailableActions = availableActions;
        }

        public string PartNumber { get; }

        public string TypeNumber { get; }

        public string OrderNumber { get; }

        public string Designation { get; }

        public Guid Type { get; }

        public ArticleImportState ImportState { get; }

        public string Action { get; }

        public string[] AvailableActions { get; }

        public static List<ArticleImportResult> FromEplanArticles(List<EplanArticleDto> eplanArticles)
        {
            if (eplanArticles.Count == 0)
                return [];

            var partNumbers = GetPartNumbers(eplanArticles);
            var dbArticles = RepositoryService.ArticleRepository.FindMany(partNumbers: partNumbers);
            var edpArticles = GetDataPortalArticles(partNumbers, dbArticles);

            var result = new List<ArticleImportResult>(eplanArticles.Count);

            foreach (var article in eplanArticles)
            {
                var dbArticle = dbArticles[article.PartNumber];
                var edpArticle = edpArticles[article.PartNumber];

                var importState = GetArticleState(article, edpArticle, dbArticle);
                var typeId = dbArticle != null
                    ? (Guid)dbArticle[Article.Fields.Type]
                    : Article.DefaultType;

                var importResult = new ArticleImportResult(
                    partNumber: article.PartNumber,
                    typeNumber: article.TypeNumber,
                    orderNumber: article.OrderNumber,
                    designation: article.Description,
                    type: typeId,
                    importState: importState,
                    action: ArticleImportAction.Default(importState),
                    availableActions: ArticleImportAction.AvailableActions(importState));

                result.Add(importResult);
            }

            return result;
        }

        private static string[] GetPartNumbers(List<EplanArticleDto> eplanArticles)
        {
            var result = eplanArticles
                .Select(a => a.PartNumber)
                .Distinct()
                .ToArray();

            if (result.Length != eplanArticles.Count)
                throw new ArgumentException($"argument '{nameof(eplanArticles)}' must not contain multiple articles with equal part numbers");

            return result;
        }

        private static Dictionary<string, DataPortalArticleDto?> GetDataPortalArticles(string[] partNumbers, Dictionary<string, Article?> dbArticles)
        {
            var result = partNumbers.ToDictionary(pn => pn, _ => default(DataPortalArticleDto?));

            var edpPartNumbers = partNumbers
                .Where(pn => dbArticles[pn] == null)
                .ToArray();

            if (edpPartNumbers.Length == 0)
                return result;

            var edpArticles = EplanDataPortal.GetArticlesByPartNumber(edpPartNumbers);

            foreach (var (key, val) in edpArticles)
                result[key] = val;

            return result;
        }

        private static ArticleImportState GetArticleState(EplanArticleDto article,
            DataPortalArticleDto? edpArticle, EntityRecord? dbRecord)
        {
            if (IsDbArticle(article, dbRecord))
            {
                return (bool)dbRecord![Article.Fields.IsBlocked]
                    ? ArticleImportState.BlockedArticle
                    : ArticleImportState.DbArticle;
            }

            if (IsValidEplanArticle(article, edpArticle))
                return ArticleImportState.EplanArticle;

            return ArticleImportState.UnknownArticle;
        }

        private static bool IsValidEplanArticle(EplanArticleDto article, DataPortalArticleDto? edpArticle)
        {
            return edpArticle != null
                && article.PartNumber == edpArticle.PartNumber
                && article.TypeNumber == edpArticle.TypeNumber
                && article.OrderNumber == edpArticle.OrderNumber;
        }

        private static bool IsDbArticle(EplanArticleDto article, EntityRecord? dbArticle)
        {
            return dbArticle != null
                && article.PartNumber.Equals(dbArticle[Article.Fields.PartNumber])
                && article.TypeNumber.Equals(dbArticle[Article.Fields.TypeNumber])
                && article.OrderNumber.Equals(dbArticle[Article.Fields.OrderNumber]);
        }
    }
}
