namespace WebVella.Erp.Plugins.Duatec.Test.DataPortal
{
    [TestFixture]
    public class ManufacturersTests
    {
        [Test]
        public void GetManufacturers_HasNoEmptyRequiredProperty()
        {
            var manufacturers = Eplan.DataPortal.GetManufacturers();

            Assert.Multiple(() =>
            {
                foreach (var sut in manufacturers)
                    Common.AssertManufacturerIsValid(sut);
            });
        }
    }
}