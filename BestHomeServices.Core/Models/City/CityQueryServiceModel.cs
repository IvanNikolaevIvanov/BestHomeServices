using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestHomeServices.Core.Models.City
{
    public class CityQueryServiceModel
    {
        public int totalCitiesCount { get; set; }

        public IEnumerable<CityViewModel> Cities { get; set; } = new List<CityViewModel>();
    }
}
