using BestHomeServices.Core.Models.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestHomeServices.Core.Contracts
{
    public interface ICityService
    {
        Task<IEnumerable<CityViewModel>> GetAllCitiesAsync();
    }
}
