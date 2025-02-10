using WebVella.Erp.Plugins.Duatec.Services;

namespace WebVella.Erp.Plugins.Duatec.Test.Services.DataPortal
{
    [TestFixture]
    internal class ArticleTests
    {
        [Test]
        [TestCaseSource(typeof(ArticleResources), nameof(ArticleResources.ArticleIds10))]
        public void GetArticleWithId_ReturnsValidDto(string id)
        {
            var sut = EplanDataPortal.GetArticleById(long.Parse(id));

            Common.AssertArticleIsValid(sut);
        }

        [Test]
        [TestCaseSource(typeof(ArticleResources), nameof(ArticleResources.ArticlePartNumbers10))]
        public void GetArticleWithPartNumber_ReturnsValidDto(string partNumber)
        {
            var sut = EplanDataPortal.GetArticleByPartNumber(partNumber);

            Common.AssertArticleIsValid(sut);
        }

        [Test]
        public void GetMultipleArticlesByPartNumber_ReturnsValidResult()
        {
            var partNumbers = ArticleResources.ArticlePartNumbers10;

            var result = EplanDataPortal.GetArticlesByPartNumber(partNumbers);

            Assert.That(result, Has.Count.EqualTo(partNumbers.Length));
            Assert.Multiple(() =>
            {
                foreach (var pn in partNumbers)
                {
                    Assert.That(result, Contains.Key(pn));
                    Assert.That(result[pn], Is.Not.Null);
                }
            });
        }
    }
}
