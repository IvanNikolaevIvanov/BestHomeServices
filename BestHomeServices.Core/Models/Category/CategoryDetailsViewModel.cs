using BestHomeServices.Core.Models.Client;
using BestHomeServices.Core.Models.Specialist;

namespace BestHomeServices.Core.Models.Category
{
    public class CategoryDetailsViewModel 
    {
        //public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;

        public int CityId { get; set; }

        public int SpecialistId { get; set; }

        public IEnumerable<SpecialistViewModel> Specialists { get; set; } = new List<SpecialistViewModel>();

       
        

    }
}
