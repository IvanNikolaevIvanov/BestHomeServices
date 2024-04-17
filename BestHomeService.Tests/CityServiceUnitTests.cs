using BestHomeServices.Core.Models.City;
using BestHomeServices.Core.Services;
using BestHomeServices.Infrastructure.Data.Common;
using BestHomeServices.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

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
            int currentPage = 1;
            int citiesPerPage = 5;

            // Act
            var cities = await repository.AllReadOnly<City>().ToListAsync();
            
            var list = await cityService.GetAllCitiesAsync(currentPage, citiesPerPage);
            var actualCount = list.Cities.Count();

            //Assert
            Assert.That(cities, Is.Not.Null);
            Assert.That(actualCount, Is.LessThanOrEqualTo(citiesPerPage));
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
