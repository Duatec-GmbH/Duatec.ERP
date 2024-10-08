using System.Collections;
using WebVella.Erp.Plugins.Eplan.DataModel;

namespace WebVella.Erp.Plugins.Eplan.Test
{
    internal static class Common
    {
        public static void AssertArticleIsValid(ArticleDto? sut)
        {
            Assert.That(sut, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(sut!.Id, Is.Not.Zero, nameof(ArticleDto.Id));
                AssertManufacturerIsValid(sut.Manufacturer);
                AssertIsNotEmpty(sut.PartNumber, nameof(ArticleDto.PartNumber));
                AssertIsNotEmpty(sut.Description, nameof(ArticleDto.Description));
                AssertIsNotEmpty(sut.PartType, nameof(ArticleDto.PartType));
                Assert.That(sut.PictureUrl, Is.Not.Null, nameof(ArticleDto.PictureUrl));
            });
        }

        public static void AssertManufacturerIsValid(ManufacturerDto? sut)
        {
            Assert.That(sut, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(sut!.Id, Is.Not.Zero, nameof(ManufacturerDto.Id));
                AssertIsNotEmpty(sut.Name, nameof(ManufacturerDto.Name));
                AssertIsNotEmpty(sut.ShortName, nameof(ManufacturerDto.ShortName));
                Assert.That(sut.WebsiteUrl, Is.Not.Null, nameof(ManufacturerDto.WebsiteUrl));
                AssertIsNotEmpty(sut.LogoUrl, nameof(ManufacturerDto.LogoUrl));
            });
        }

        private static void AssertIsNotEmpty(IEnumerable? value, string name)
        {
            Assert.That(value, Is.Not.Null, name);
            CollectionAssert.IsNotEmpty(value, name);
        }
    }
}
