namespace WebVella.Erp.Plugins.Duatec.Test.DataPortal
{
    [TestFixture]
    internal class ArticleTests
    {
        [Test]
        [TestCaseSource(typeof(ArticleResources), nameof(ArticleResources.ArticleIds100))]
        public void GetArticleWithId_ReturnsValidDto(string id)
        {
            var sut = Eplan.DataPortal.GetArticleById(long.Parse(id));

            Common.AssertArticleIsValid(sut);
        }

        [Test]
        [TestCaseSource(typeof(ArticleResources), nameof(ArticleResources.ArticlePartNumbers100))]
        public void GetArticleWithPartNumber_ReturnsValidDto(string partNumber)
        {
            var sut = Eplan.DataPortal.GetArticleByPartNumber(partNumber);

            Common.AssertArticleIsValid(sut);
        }
    }
}
