using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestHomeServices.Core.Services
{
    public class CityService : ICityService
    {
        public Task<IEnumerable<CityViewModel>> GetAllCitiesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
