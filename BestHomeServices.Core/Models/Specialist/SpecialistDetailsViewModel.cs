using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestHomeServices.Core.Models.Specialist
{
    public class SpecialistDetailsViewModel
    {
        public int Id { get; set; }

        public bool IsBusy { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public int CityId { get; set; }

        public int NumberOfProjects { get; set; }

        public string CityName { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;
    }
}
