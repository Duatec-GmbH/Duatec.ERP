namespace WebVella.Erp.Plugins.Duatec.Test
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