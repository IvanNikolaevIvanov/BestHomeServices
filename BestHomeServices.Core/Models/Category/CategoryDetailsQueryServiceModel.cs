using BestHomeServices.Core.Models.Specialist;

namespace BestHomeServices.Core.Models.Category
{
    public class CategoryDetailsQueryServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;

        public IEnumerable<SpecialistViewModel> Specialists { get; set; } = new List<SpecialistViewModel>();
    }
}
