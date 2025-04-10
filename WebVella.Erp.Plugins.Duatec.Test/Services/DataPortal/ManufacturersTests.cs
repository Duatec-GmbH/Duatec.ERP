using WebVella.Erp.Plugins.Duatec.Services;

namespace WebVella.Erp.Plugins.Duatec.Test.Services.DataPortal
{
    [TestFixture]
    public class ManufacturersTests
    {
        [Test]
        public void GetManufacturers_HasNoEmptyRequiredProperty()
        {
            var manufacturers = EplanDataPortal.GetManufacturers();

            Assert.Multiple(() =>
            {
                foreach (var sut in manufacturers)
                    Common.AssertManufacturerIsValid(sut);
            });
        }
    }
}