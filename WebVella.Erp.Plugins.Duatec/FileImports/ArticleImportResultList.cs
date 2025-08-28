using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.FileImports.CsvTypes;
using WebVella.Erp.Plugins.Duatec.FileImports.EplanTypes.DataModel;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Services;

namespace WebVella.Erp.Plugins.Duatec.FileImports
{
    internal static class ArticleImportResultList
    {
        public static List<ArticleImportResult> FromCsvArticles(List<CsvArticleDto> csvArticles)
        {
            if (csvArticles.Count == 0)
                return [];

            var partNumbers = csvArticles
                .Select(a => a.PartNumber)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct()
                .ToArray();

            var orderNumbers = csvArticles
                .Select(a => a.OrderNumber)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct()
                .ToArray();

            var articleRepo = new ArticleRepository();

            var articlesByPartNumber = partNumbers.Length > 0
                ? articleRepo.FindMany(partNumbers: partNumbers) : [];

            var articlesByOrderNumber = orderNumbers.Length > 0
                ? articleRepo.FindManyByOrderNumbers(orderNumbers: orderNumbers) : [];

            var orderArticlesFlattened = articlesByOrderNumber
                .Where(kp => kp.Value != null)
                .SelectMany(kp => kp.Value);

            foreach (var dbArticle in orderArticlesFlattened)
            {
                if (!articlesByPartNumber.TryGetValue(dbArticle.PartNumber, out var a) || a == null)
                    articlesByPartNumber[dbArticle.PartNumber] = dbArticle;
            }

            foreach (var dbArticle in articlesByPartNumber.Values.Where(a => a != null))
            {
                if (!articlesByOrderNumber.TryGetValue(dbArticle!.OrderNumber, out var l))
                    articlesByOrderNumber.Add(dbArticle.OrderNumber, [dbArticle]);

                else if (!l.Exists(dbA => dbA.PartNumber == dbArticle.PartNumber))
                    l.Add(dbArticle);
            }

            partNumbers = articlesByPartNumber
                .Where(kp => kp.Value == null)
                .Select(kp => kp.Key)
                .ToArray();

            var edpArticlesByPartNumber = GetDataPortalArticlesByPartNumber(partNumbers);

            orderNumbers = articlesByOrderNumber
                .Where(kp => kp.Value == null || kp.Value.Count == 0)
                .Select(kp => kp.Key)
                .Intersect(articlesByPartNumber.Values.Where(a => a != null).Select(a => a!.OrderNumber).ToArray())
                .ToArray();

            var edpArticlesByOrderNumber = GetDataPortalArticlesByOrderNumber(orderNumbers);
            var result = new List<ArticleImportResult>(csvArticles.Count);

            foreach (var article in csvArticles)
            {
                var dbArticle = GetDbArticle(article, articlesByPartNumber, articlesByOrderNumber);
                var edpArticle = GetDataPortalArticle(article, edpArticlesByPartNumber, edpArticlesByOrderNumber);

                var importResult = CsvImportResult(article, dbArticle, edpArticle);

                result.Add(importResult);
            }

            return result.GroupBy(a => (a.PartNumber, a.OrderNumber, a.Denomination)).Select(FromGroup).ToList();
        }

        public static List<ArticleImportResult> FromEplanArticles(List<EplanArticleDto> eplanArticles)
        {
            if (eplanArticles.Count == 0)
                return [];

            var partNumbers = eplanArticles
                .Select(a => a.PartNumber)
                .Distinct()
                .ToArray();

            var dbArticles = new ArticleRepository().FindMany(partNumbers: partNumbers);
            partNumbers = partNumbers
                .Where(pn => !dbArticles.TryGetValue(pn, out var a) || a == null)
                .ToArray();

            var edpArticles = GetDataPortalArticlesByPartNumber(partNumbers);

            var result = new List<ArticleImportResult>(eplanArticles.Count);

            foreach (var article in eplanArticles)
            {
                var dbArticle = dbArticles.TryGetValue(article.PartNumber, out var a) ? a : null;
                var edpArticle = edpArticles.TryGetValue(article.PartNumber, out var edpA) ? edpA : null;

                var importState = GetState(article, edpArticle, dbArticle);
                var typeId = dbArticle?.TypeId ?? Article.DefaultType;

                var importResult = new ArticleImportResult(
                    partNumber: article.PartNumber,
                    typeNumber: article.TypeNumber,
                    orderNumber: article.OrderNumber,
                    designation: article.Description,
                    type: typeId,
                    deviceTags: article.DeviceTags,
                    amount: article.Amount,
                    denomination: 0,
                    importState: importState,
                    action: ArticleImportAction.Default(importState),
                    availableActions: ArticleImportAction.AvailableActions(importState));

                result.Add(importResult);
            }

            return result;
        }

        private static ArticleImportResult FromGroup(IGrouping<(string PartNumber, string OrderNumber, decimal Denomination), ArticleImportResult> group)
        {
            var first = group.First();

            return new(
                partNumber: group.Key.PartNumber,
                orderNumber: group.Key.OrderNumber,
                typeNumber: first.TypeNumber,
                designation: first.Designation,
                deviceTags: first.DeviceTags,
                type: first.Type,
                amount: group.Sum(a => a.Amount),
                importState: first.ImportState,
                availableActions: first.AvailableActions,
                denomination: group.Key.Denomination,
                action: first.Action);
        }

        private static ArticleImportResult CsvImportResult(CsvArticleDto article, Article? dbArticle, DataPortalArticleDto? edpArticle)
        {
            var state = GetState(dbArticle, edpArticle);
            var partNumber = string.IsNullOrWhiteSpace(article.PartNumber) ? "-" : article.PartNumber;
            var orderNumber = string.IsNullOrWhiteSpace(article.OrderNumber) ? "-" : article.OrderNumber;
            var typeNumber = string.Empty;
            var designation = string.Empty;

            if (dbArticle != null)
            {
                partNumber = dbArticle.PartNumber;
                orderNumber = dbArticle.OrderNumber;
                typeNumber = dbArticle.TypeNumber;
                designation = dbArticle.Designation;
            }
            else if (edpArticle != null)
            {
                partNumber = edpArticle.PartNumber;
                orderNumber = edpArticle.OrderNumber;
                typeNumber = edpArticle.TypeNumber;
                designation = edpArticle.Designation;
            }

            return new(
                partNumber: partNumber,
                orderNumber: orderNumber,
                typeNumber: typeNumber,
                designation: designation,
                deviceTags: [],
                type: dbArticle?.TypeId ?? Article.DefaultType,
                amount: article.Amount,
                denomination: article.Denomination,
                importState: state,
                availableActions: ArticleImportAction.AvailableActions(state),
                action: ArticleImportAction.Default(state));
        }

        private static Article? GetDbArticle(CsvArticleDto article, Dictionary<string, Article?> partNumberLookup, Dictionary<string, List<Article>> orderNumberLookup)
        {
            if (string.IsNullOrWhiteSpace(article.PartNumber) && string.IsNullOrWhiteSpace(article.OrderNumber))
                return null;

            if (partNumberLookup.TryGetValue(article.PartNumber, out var a) && a != null)
                return a;

            if (orderNumberLookup.TryGetValue(article.OrderNumber, out var l) && l != null && l.Count == 1)
                return l[0];

            return null;
        }


        private static DataPortalArticleDto? GetDataPortalArticle(CsvArticleDto article,
            Dictionary<string, DataPortalArticleDto?> partNumberLookup,
            Dictionary<string, DataPortalArticleDto?> orderNumberLookup)
        {
            if (string.IsNullOrWhiteSpace(article.PartNumber) && string.IsNullOrWhiteSpace(article.OrderNumber))
                return null;

            if (partNumberLookup.TryGetValue(article.PartNumber, out var a) && a != null)
                return a;

            if (orderNumberLookup.TryGetValue(article.OrderNumber, out a) && a != null)
                return a;

            return null;
        }

        private static Dictionary<string, DataPortalArticleDto?> GetDataPortalArticlesByPartNumber(string[] partNumbers)
        {
            var result = partNumbers.ToDictionary(pn => pn, _ => default(DataPortalArticleDto?));

            if (partNumbers.Length == 0)
                return result;

            return EplanDataPortal.GetArticlesByPartNumber(partNumbers);
        }

        private static Dictionary<string, DataPortalArticleDto?> GetDataPortalArticlesByOrderNumber(string[] orderNumbers)
        {
            var result = orderNumbers.ToDictionary(pn => pn, _ => default(DataPortalArticleDto?));

            if (orderNumbers.Length == 0)
                return result;

            return EplanDataPortal.GetArticlesByOrderNumber(orderNumbers);
        }

        private static ArticleImportState GetState(Article? dbArticle, DataPortalArticleDto? edpArticle)
        {
            if (dbArticle != null)
                return dbArticle.IsBlocked ? ArticleImportState.BlockedArticle : ArticleImportState.DbArticle;
            if (edpArticle != null)
                return ArticleImportState.EplanArticle;
            return ArticleImportState.UnknownArticle;
        }


        private static ArticleImportState GetState(EplanArticleDto article,
            DataPortalArticleDto? edpArticle, Article? dbRecord)
        {
            if (IsValidDbArticle(article, dbRecord))
            {
                return dbRecord!.IsBlocked
                    ? ArticleImportState.BlockedArticle
                    : ArticleImportState.DbArticle;
            }

            if (IsDbArticle(article, dbRecord))
                return ArticleImportState.InvalidDbArticle;

            if (IsValidEplanArticle(article, edpArticle))
                return ArticleImportState.EplanArticle;

            if (IsEplanArticle(article, edpArticle))
                return ArticleImportState.InvalidEplanArticle;

            return ArticleImportState.UnknownArticle;
        }

        private static bool IsEplanArticle(EplanArticleDto article, DataPortalArticleDto? edpArticle)
        {
            return edpArticle != null
                && article.PartNumber == edpArticle.PartNumber;
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
                && article.PartNumber.Equals(dbArticle[Article.Fields.PartNumber]);
        }

        private static bool IsValidDbArticle(EplanArticleDto article, EntityRecord? dbArticle)
        {
            return dbArticle != null
                && article.PartNumber.Equals(dbArticle[Article.Fields.PartNumber])
                && article.TypeNumber.Equals(dbArticle[Article.Fields.TypeNumber])
                && article.OrderNumber.Equals(dbArticle[Article.Fields.OrderNumber]);
        }
    }
}
