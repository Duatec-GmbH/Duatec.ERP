using System.Collections;
using WebVella.Erp.Plugins.Duatec.Services.EplanTypes.DataModel;

namespace WebVella.Erp.Plugins.Duatec.Test.DataPortal
{
    internal static class Common
    {
        public static void AssertArticleIsValid(DataPortalArticleDto? sut)
        {
            Assert.That(sut, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(sut!.EplanId, Is.Not.Zero, nameof(DataPortalArticleDto.EplanId));
                AssertManufacturerIsValid(sut.Manufacturer);
                AssertIsNotEmpty(sut.PartNumber, nameof(DataPortalArticleDto.PartNumber));
                AssertIsNotEmpty(sut.Designation, nameof(DataPortalArticleDto.Designation));
                Assert.That(sut.PictureUrl, Is.Not.Null, nameof(DataPortalArticleDto.PictureUrl));
            });
        }

        public static void AssertManufacturerIsValid(DataPortalManufacturerDto? sut)
        {
            Assert.That(sut, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(sut!.EplanId, Is.Not.Zero, nameof(DataPortalManufacturerDto.EplanId));
                AssertIsNotEmpty(sut.Name, nameof(DataPortalManufacturerDto.Name));
                AssertIsNotEmpty(sut.ShortName, nameof(DataPortalManufacturerDto.ShortName));
                Assert.That(sut.WebsiteUrl, Is.Not.Null, nameof(DataPortalManufacturerDto.WebsiteUrl));
                AssertIsNotEmpty(sut.LogoUrl, nameof(DataPortalManufacturerDto.LogoUrl));
            });
        }

        private static void AssertIsNotEmpty(IEnumerable? value, string name)
        {
            Assert.That(value, Is.Not.Null, name);
            CollectionAssert.IsNotEmpty(value, name);
        }
    }
}
