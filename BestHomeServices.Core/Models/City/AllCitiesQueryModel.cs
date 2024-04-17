using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestHomeServices.Core.Models.City
{
    public class AllCitiesQueryModel
    {
        public int citiesPerPage { get; } = 5;

        public int currentPage { get; init; } = 1;

        public int totalCitiesCount { get; set; }

        public IEnumerable<CityViewModel> Cities { get; set; } = new List<CityViewModel>();
    }
}
