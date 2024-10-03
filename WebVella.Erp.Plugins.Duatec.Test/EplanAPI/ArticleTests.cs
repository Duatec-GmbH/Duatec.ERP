using WebVella.Erp.Plugins.Duatec.Eplan;

namespace WebVella.Erp.Plugins.Duatec.Test.EplanAPI
{
    [TestFixture]
    internal class ArticleTests
    {
        [Test]
        [TestCaseSource(typeof(ArticleResources), nameof(ArticleResources.ArticleIds100))]
        public async Task GetArticleWithId_ReturnsValidDto(string id)
        {
            var sut = await DataPortal.GetArticleByIdAsync(long.Parse(id));

            Common.AssertArticleIsValid(sut);
        }

        [Test]
        [TestCaseSource(typeof(ArticleResources), nameof(ArticleResources.ArticlePartNumbers100))]
        public async Task GetArticleWithPartNumber_ReturnsValidDto(string partNumber)
        {
            var sut = await DataPortal.GetArticleByPartNumberAsync(partNumber);

            Common.AssertArticleIsValid(sut);
        }
    }
}
