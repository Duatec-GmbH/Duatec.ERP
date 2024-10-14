namespace WebVella.Erp.Plugins.Duatec.Test
{
    [TestFixture]
    internal class ArticleTests
    {
        [Test]
        [TestCaseSource(typeof(ArticleResources), nameof(ArticleResources.ArticleIds100))]
        public void GetArticleWithId_ReturnsValidDto(string id)
        {
            var sut = EplanDataPortal.GetArticleById(long.Parse(id));

            Common.AssertArticleIsValid(sut);
        }

        [Test]
        [TestCaseSource(typeof(ArticleResources), nameof(ArticleResources.ArticlePartNumbers100))]
        public void GetArticleWithPartNumber_ReturnsValidDto(string partNumber)
        {
            var sut = EplanDataPortal.GetArticleByPartNumber(partNumber);

            Common.AssertArticleIsValid(sut);
        }
    }
}
