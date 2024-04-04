using BestHomeServices.Core.Models.Category;

namespace BestHomeServices.Core.Models.Home
{
    public class AllCategoriesIndexServiceModel
    {
        public string CategoryTitle { get; set; } = null!;

        public string City { get; set; } = null!;

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

    }
}
