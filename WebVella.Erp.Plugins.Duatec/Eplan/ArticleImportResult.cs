using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;
using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.Eplan
{
    internal enum ArticleImportState
    {
        UnknownArticle,
        ValidEplanArticle,
        ValidDbArticle,
        InvalidEplanArticle,
        InvalidDbArticle,
        InvalidUnknownArticle,
    }

    public static class ArticleImportAction
    {
        public const string NoAction = "No Action";
        public const string Skip = "Skip";
        public const string Import = "Import";
        public const string Create = "Create";
    }

    internal class ArticleImportResult
    {
        public ArticleImportResult(
            string partNumber, string typeNumber, string orderNumber, decimal demand, 
            ArticleImportState importState, string action, string[] availableActions)
        {
            PartNumber = partNumber;
            TypeNumber = typeNumber;
            OrderNumber = orderNumber;
            Demand = demand;
            ImportState = importState;
            Action = action;
            AvailableActions = availableActions;
        }

        public string PartNumber { get; }

        public string TypeNumber { get; }

        public string OrderNumber { get; }

        public decimal Demand { get; }

        public ArticleImportState ImportState { get; }

        public string Action { get; }

        public string[] AvailableActions { get; }


        public static List<ArticleImportResult> FromEplanArticles(List<EplanArticle> eplanArticles)
        {
            if (eplanArticles.Count == 0)
                return [];

            var partNumbers = eplanArticles
                .Select(a => a.PartNumber)
                .ToArray();           

            var dbArticles = Article.FindMany(partNumbers);
            var edpArticles = DataPortal.GetArticlesByPartNumber(partNumbers);

            var result = new List<ArticleImportResult>(eplanArticles.Count);

            foreach(var article in eplanArticles)
            {
                var dbArticle = dbArticles.GetOrDefault(article.PartNumber);
                var edpArticle = edpArticles.GetOrDefault(article.PartNumber);

                var importState = GetArticleState(article, edpArticle, dbArticle);

                var importResult = new ArticleImportResult(
                    partNumber: article.PartNumber,
                    typeNumber: article.TypeNumber,
                    orderNumber: article.OrderNumber,
                    demand: article.Count,
                    importState: importState,
                    action: DefaultActionFromArticleState(importState),
                    availableActions: ActionsFromArticleState(importState, dbArticle == null));

                result.Add(importResult);
            }

            return result;
        }

        private static string DefaultActionFromArticleState(ArticleImportState state)
        {
            if (state is ArticleImportState.InvalidEplanArticle or ArticleImportState.InvalidDbArticle or ArticleImportState.InvalidUnknownArticle)
                return ArticleImportAction.Skip;
            if (state == ArticleImportState.UnknownArticle)
                return ArticleImportAction.Create;
            return ArticleImportAction.NoAction;
        }

        private static string[] ActionsFromArticleState(ArticleImportState state, bool notInDb)
        {
            if (state is ArticleImportState.InvalidEplanArticle or ArticleImportState.InvalidDbArticle or ArticleImportState.InvalidUnknownArticle)
                return [ArticleImportAction.Skip];
            if (state == ArticleImportState.UnknownArticle)
                return [ArticleImportAction.Skip, ArticleImportAction.Create];
            if (state == ArticleImportState.ValidEplanArticle && notInDb)
                return [ArticleImportAction.Skip, ArticleImportAction.NoAction];
            return [ ArticleImportAction.NoAction ];
        }


        private static ArticleImportState GetArticleState(EplanArticle article, DataPortalArticle? dpArticle, EntityRecord? dbRecord)
        {
            if (IsValidEplanArticle(article, dpArticle))
                return ArticleImportState.ValidEplanArticle;
            if (IsValidDbArticle(article, dbRecord))
                return ArticleImportState.ValidDbArticle;
            if (dpArticle != null)
                return ArticleImportState.InvalidEplanArticle;
            if (dbRecord != null)
                return ArticleImportState.InvalidDbArticle;

            if(string.IsNullOrWhiteSpace(article.PartNumber) 
                || string.IsNullOrWhiteSpace(article.TypeNumber) 
                || string.IsNullOrWhiteSpace(article.OrderNumber)
                || string.IsNullOrWhiteSpace(article.Description))
            {
                return ArticleImportState.InvalidUnknownArticle;
            }

            return ArticleImportState.UnknownArticle;
        }

        private static bool IsValidEplanArticle(EplanArticle article, DataPortalArticle? dpArticle)
        {
            return dpArticle != null
                && article.PartNumber == dpArticle.PartNumber
                && article.TypeNumber == dpArticle.TypeNumber
                && article.OrderNumber == dpArticle.OrderNumber;
        }

        private static bool IsValidDbArticle(EplanArticle article, EntityRecord? dbArticle)
        {
            return dbArticle != null
                && article.PartNumber.Equals(dbArticle[Article.PartNumber])
                && article.TypeNumber.Equals(dbArticle[Article.TypeNumber])
                && article.OrderNumber.Equals(dbArticle[Article.OrderNumber]);
        }
    }
}
