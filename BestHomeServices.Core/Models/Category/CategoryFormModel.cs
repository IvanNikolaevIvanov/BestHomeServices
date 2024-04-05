using BestHomeServices.Core.Models.City;
using BestHomeServices.Core.Models.Client;
using BestHomeServices.Core.Models.Specialist;
using BestHomeServices.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BestHomeServices.Core.Models.Category
{
    public class CategoryFormModel 
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;

        public int CityId { get; set; }

        public int SpecialistId { get; set; }

        public IEnumerable<SpecialistViewModel> Specialists { get; set; } = new List<SpecialistViewModel>();

        public ClientsServiceModel Client = null!;
        

    }
}
