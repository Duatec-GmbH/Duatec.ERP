namespace WebVella.Erp.Plugins.Duatec.Test
{
    [TestFixture]
    internal class ArticleTests
    {
        [Test]
        [TestCaseSource(typeof(ArticleResources), nameof(ArticleResources.ArticleIds100))]
        public async Task GetArticleWithId_ReturnsValidDto(string id)
        {
            var sut = await EplanDataPortal.GetArticleByIdAsync(long.Parse(id));

            Common.AssertArticleIsValid(sut);
        }

        [Test]
        [TestCaseSource(typeof(ArticleResources), nameof(ArticleResources.ArticlePartNumbers100))]
        public async Task GetArticleWithPartNumber_ReturnsValidDto(string partNumber)
        {
            var sut = await EplanDataPortal.GetArticleByPartNumberAsync(partNumber);

            Common.AssertArticleIsValid(sut);
        }
    }
}
