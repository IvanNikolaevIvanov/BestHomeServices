using BestHomeServices.Core.Models.City;
using BestHomeServices.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestHomeServices.Core.Contracts
{
    public interface ICityService
    {
        Task<ICollection<City>> GetAllCitiesAsync();

        Task<City> GetCityByIdAsync(int id);
    }
}
