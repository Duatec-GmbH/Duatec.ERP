using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Transfere;

namespace WebVella.Erp.Plugins.Duatec.Test.EplanAPI
{
    [TestFixture]
    public class ManufacturersTests
    {
        [Test]
        public async Task GetManufacturers_HasNoEmptyRequiredProperty()
        {
            var manufacturers = await EplanDataPortal.GetManufacturers();

            Assert.Multiple(() =>
            {
                foreach (var sut in manufacturers)
                    Common.AssertManufacturerIsValid(sut);
            });
        }

        [Test]
        public async Task GetManufacturerPerId_ReturnsValidResult()
        {
            var manufacturers = await EplanDataPortal.GetManufacturers();
            var tasks = new List<Task<ManufacturerDto?>>();

            foreach (var manufacturer in manufacturers)
                tasks.Add(EplanDataPortal.GetManufacturer(manufacturer.Id, manufacturer.Name));

            Task.WaitAll([.. tasks]);
            Assert.Multiple(() =>
            {
                foreach (var task in tasks)
                {
                    Assert.That(task.IsCompletedSuccessfully, Is.True);
                    Common.AssertManufacturerIsValid(task.Result);
                }
            });
        }
    }
}