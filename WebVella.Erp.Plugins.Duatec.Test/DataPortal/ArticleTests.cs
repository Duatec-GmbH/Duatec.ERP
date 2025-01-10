namespace WebVella.Erp.Plugins.Duatec.Test.DataPortal
{
    [TestFixture]
    internal class ArticleTests
    {
        [Test]
        [TestCaseSource(typeof(ArticleResources), nameof(ArticleResources.ArticleIds100))]
        public void GetArticleWithId_ReturnsValidDto(string id)
        {
            var sut = Services.EplanDataPortal.GetArticleById(long.Parse(id));

            Common.AssertArticleIsValid(sut);
        }

        [Test]
        [TestCaseSource(typeof(ArticleResources), nameof(ArticleResources.ArticlePartNumbers100))]
        public void GetArticleWithPartNumber_ReturnsValidDto(string partNumber)
        {
            var sut = Services.EplanDataPortal.GetArticleByPartNumber(partNumber);

            Common.AssertArticleIsValid(sut);
        }

        [Test]
        public void GetMultipleArticlesByPartNumber_ReturnsValidResult()
        {
            var partNumbers = ArticleResources.ArticlePartNumbers100;

            var result = Services.EplanDataPortal.GetArticlesByPartNumber(partNumbers);

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
