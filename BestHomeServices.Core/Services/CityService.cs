using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.City;
using BestHomeServices.Infrastructure.Data.Common;
using BestHomeServices.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestHomeServices.Core.Services
{
    public class CityService : ICityService
    {
        private readonly IRepository repository;

        public CityService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddCityAsync(CityFormModel model)
        {
            var city = new City()
            {
                Name = model.Name
            };

            await repository.AddAsync(city);
            await repository.SaveChangesAsync();
        }

        public async Task<CityQueryServiceModel> GetAllCitiesAsync(int currentPage, int citiesPerPage)
        {
            var cities = repository.AllReadOnly<City>();

            var citiesToShow = await cities
                .Skip((currentPage - 1) * citiesPerPage)
                .Take(citiesPerPage)
                .Select(c => new CityViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            int totalCitiesCount = await cities.CountAsync();

            return new CityQueryServiceModel()
            {
                Cities = citiesToShow,
                totalCitiesCount = totalCitiesCount
            };

        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            var city = await repository.AllReadOnly<City>()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }

            return city;
        }
    }
}
