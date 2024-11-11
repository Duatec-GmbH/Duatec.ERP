using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebVella.Erp.Plugins.Duatec.Test.EplanXml
{
    [TestFixture]
    internal class EplanXmlTests
    {
        [Test]  
        public void SingleItemAsRootReturnsExpectedEntry()
        {
            var text = EplanXmlResources.SingleItemAsRoot;

            var result = Eplan.EplanXml.GetArticles(text);

            Assert.That(result, Has.Count.EqualTo(1));
            var article = result[0];
            Assert.Multiple(() =>
            {
                Assert.That(article.PartNumber, Is.EqualTo("HAR.09330242616"));
                Assert.That(article.OrderNumber, Is.EqualTo("09330242616"));
                Assert.That(article.TypeNumber, Is.EqualTo("09 33 024 2616"));
                Assert.That(article.Description, Is.EqualTo("Kontakteinsatz für Industriesteckverbinder / Han 24 ES-M"));
                Assert.That(article.Count, Is.EqualTo(1));
            });
        }
    }
}
