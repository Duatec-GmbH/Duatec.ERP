using System.Collections;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;

namespace WebVella.Erp.Plugins.Duatec.Test.DataPortal
{
    internal static class Common
    {
        public static void AssertArticleIsValid(DataPortalArticle? sut)
        {
            Assert.That(sut, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(sut!.EplanId, Is.Not.Zero, nameof(DataPortalArticle.EplanId));
                AssertManufacturerIsValid(sut.Manufacturer);
                AssertIsNotEmpty(sut.PartNumber, nameof(DataPortalArticle.PartNumber));
                AssertIsNotEmpty(sut.Designation, nameof(DataPortalArticle.Designation));
                Assert.That(sut.PictureUrl, Is.Not.Null, nameof(DataPortalArticle.PictureUrl));
            });
        }

        public static void AssertManufacturerIsValid(DataPortalManufacturer? sut)
        {
            Assert.That(sut, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(sut!.EplanId, Is.Not.Zero, nameof(DataPortalManufacturer.EplanId));
                AssertIsNotEmpty(sut.Name, nameof(DataPortalManufacturer.Name));
                AssertIsNotEmpty(sut.ShortName, nameof(DataPortalManufacturer.ShortName));
                Assert.That(sut.WebsiteUrl, Is.Not.Null, nameof(DataPortalManufacturer.WebsiteUrl));
                AssertIsNotEmpty(sut.LogoUrl, nameof(DataPortalManufacturer.LogoUrl));
            });
        }

        private static void AssertIsNotEmpty(IEnumerable? value, string name)
        {
            Assert.That(value, Is.Not.Null, name);
            CollectionAssert.IsNotEmpty(value, name);
        }
    }
}
