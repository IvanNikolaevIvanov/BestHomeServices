using BestHomeServices.Core.Models.City;
using BestHomeServices.Core.Services;
using BestHomeServices.Infrastructure.Data.Common;
using BestHomeServices.Infrastructure.Data.Models;

namespace BestHomeServices.UnitTests
{
    public class CityServiceUnitTests : UnitTestsBase
    {
        private CityService cityService;

        [SetUp]
        public void SetUp()
        {
            cityService = new CityService(repository);
        }

        [Test]
        public async Task GetAllCitiesAsyncShouldReturnCorrectly()
        {
            // Arrange
            int expectedCount = 3;

            // Act

            var list = await cityService.GetAllCitiesAsync();

            //Assert

            Assert.That(list.Count(), Is.EqualTo(expectedCount));
        }

        [Test]
        public async Task GetCityByIdAsyncShouldReturnExistingCity()
        {
            // Arrange

            var expectedCityName = "Larnaca";

            //Act

            var city = await cityService.GetCityByIdAsync(1);

            //Assert

            Assert.That(city.Name, Is.EqualTo(expectedCityName));
        }

        [Test]
        public async Task AddCityAsyncShouldAddANewCity()
        {
            //Arrange
            var city = new CityFormModel()
            {
                Name = "Test"
            };

            //Act

            await cityService.AddCityAsync(city);
            var newCity = await cityService.GetCityByIdAsync(4);

            //Assert

            Assert.That(city.Name, Is.EqualTo(newCity.Name));
        }
    }
}
