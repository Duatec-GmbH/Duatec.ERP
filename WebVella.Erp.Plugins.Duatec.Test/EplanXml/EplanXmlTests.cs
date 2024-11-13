namespace WebVella.Erp.Plugins.Duatec.Test.EplanXml
{
    [TestFixture]
    internal class EplanXmlTests
    {
        private static MemoryStream StreamFromString(string text)
        {
            var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }


        [Test]  
        public void SingleItemAsRootReturnsExpectedEntry()
        {
            var text = EplanXmlResources.SingleItemAsRoot;

            using var stream = StreamFromString(text);

            var result = Eplan.EplanXml.GetArticles(stream);

            Assert.That(result, Has.Count.EqualTo(1));
            var article = result[0];
            Assert.Multiple(() =>
            {
                Assert.That(article.PartNumber, Is.EqualTo("HAR.09330242616"));
                Assert.That(article.OrderNumber, Is.EqualTo("09330242616"));
                Assert.That(article.TypeNumber, Is.EqualTo("09 33 024 2616"));
                Assert.That(article.Description, Is.EqualTo("Kontakteinsatz für Industriesteckverbinder / Han 24 ES-M"));
            });
        }
    }
}
